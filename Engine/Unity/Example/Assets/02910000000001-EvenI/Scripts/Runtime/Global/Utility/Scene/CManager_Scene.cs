using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.Rendering.Universal;
using DG.Tweening;

/**
 * 씬 관리자
 */
public abstract partial class CManager_Scene : CComponent
{
	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		CManager_Schedule.Inst.AddComponent(this);
		CManager_NavStack.Inst.AddComponent(this);

		// 액티브 씬 일 경우
		if(this.IsScene_Active)
		{
			CManager_GameObjPool.Inst.transform.SetParent(this.transform);
			CManager_CollectionPool.Inst.transform.SetParent(this.transform);
		}

		this.SetupScene(true);
	}

	/** 초기화 */
	public override void Start()
	{
		base.Start();
		this.SetupScene(false);

		this.SetIsDirty_State(true);
		this.SetIsDirty_Layout(true);
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		CManager_Scene.DictManagers_Scene.ExRemoveVal(this.Name_Scene);

		// 추가 씬 일 경우
		if(this.IsScene_Additive)
		{
			return;
		}

		CManager_GameObjPool.Destroy();
		CManager_CollectionPool.Destroy();
	}

	/** 앱이 종료되었을 경우 */
	public virtual void OnApplicationQuit()
	{
		DOTween.KillAll();
		CManager_Scene.IsQuit_App = true;
	}

	/** 상태를 갱신한다 */
	public override void OnUpdate(float a_fTime_Delta)
	{
		base.OnUpdate(a_fTime_Delta);

		// 네트워크 상태가 변경되었을 경우
		if(CGSingleton.Inst.Reachability_Network != Application.internetReachability)
		{
			CGSingleton.Inst.SetReachability_Network(Application.internetReachability);
			this.HandleOnChange_NetworkReachability(CGSingleton.Inst.Reachability_Network);
		}

		// 디바이스 화면 크기가 변경되었을 경우
		if(!CGSingleton.Inst.Size_DeviceScreen.ExIsEquals(Access.Size_DeviceScreen))
		{
			CGSingleton.Inst.SetSize_DeviceScreen(Access.Size_DeviceScreen);
			this.HandleOnChange_DeviceScreenSize(CGSingleton.Inst.Size_DeviceScreen);
		}
	}

	/** 상태를 갱신한다 */
	public override void OnUpdate_Late(float a_fTime_Delta)
	{
		base.OnUpdate_Late(a_fTime_Delta);

		var oUIRectTrans_Canvas = CManager_Scene.ActiveScene_UICanvas.transform as RectTransform;
		CManager_Scene.ActiveScene_UISize_Canvas = oUIRectTrans_Canvas.sizeDelta.ExTo3D();

		// 백키 처리가 불가능 할 경우
		if(!Input.GetKeyDown(KeyCode.Escape))
		{
			return;
		}

		CManager_NavStack.Inst.OnReceiveEvent_NavStack(EEvent_NavStack.BACK_KEY_DOWN);
	}

	/** 내비게이션 스택 이벤트를 처리한다 */
	public override void HandleOnEvent_NavStack(EEvent_NavStack a_eEvent)
	{
		base.HandleOnEvent_NavStack(a_eEvent);

		switch(a_eEvent)
		{
			case EEvent_NavStack.BACK_KEY_DOWN:
				CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_01);
				break;
		}
	}

	/** 씬을 설정한다 */
	protected virtual void SetupScene(bool a_bIsSetup_Awake)
	{
		this.SetupLights();
		this.SetupCameras();
		this.SetupComponents_Unique();

		this.UISetupCanvases();

		// 메인 설정이 아닐 경우
		if(!a_bIsSetup_Awake)
		{
			return;
		}

		this.SetupObjects_Def();
		this.SetupObjects_DefUI();
		this.SetupObjects_DefObj();

		Time.fixedDeltaTime = 1.0f / 60.0f;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;

		Physics.defaultSolverIterations = 8;
		Physics.defaultSolverVelocityIterations = 1;
		Physics.gravity = new Vector3(0.0f, -9.81f * 2.0f, 0.0f);

		CManager_Scene.DictManagers_Scene.ExAddVal(this.Name_Scene, this);
	}

	/** 광원을 설정한다 */
	protected virtual void SetupLights()
	{
		this.gameObject.scene.ExEnumerateComponentsInChildren<Light>(this.SetupLight);
	}

	/** 광원을 설정한다 */
	protected virtual bool SetupLight(Light a_oLight)
	{
		a_oLight.type = a_oLight.name.Equals(KDefine.G_N_OBJ_MAIN_LIGHT) ?
			LightType.Directional : a_oLight.type;

		a_oLight.renderMode = a_oLight.name.Equals(KDefine.G_N_OBJ_MAIN_LIGHT) ?
			LightRenderMode.ForcePixel : a_oLight.renderMode;

		a_oLight.renderingLayerMask = a_oLight.name.Equals(KDefine.G_N_OBJ_MAIN_LIGHT) ?
			int.MaxValue : a_oLight.renderingLayerMask;

		bool bIsValid_Light = this.IsScene_Active;
		bIsValid_Light = bIsValid_Light || !a_oLight.name.Equals(KDefine.G_N_OBJ_MAIN_LIGHT);

		/*
		 * GameObject.SetActive 메서드는 게임 객체를 활성 여부를 변경하는 역할을 수행한다.
		 * (+ 즉, 해당 메서드를 활용하면 특정 순간에 게임 객체를 활성 및 비활성화하는 것이
		 * 가능하다.)
		 */
		a_oLight.gameObject.SetActive(bIsValid_Light);

		var oURP_LightData = a_oLight.GetUniversalAdditionalLightData();

		// 광원 데이터가 존재 할 경우
		if(oURP_LightData != null)
		{
			oURP_LightData.usePipelineSettings = true;
			oURP_LightData.shadowRenderingLayers = int.MaxValue;
			oURP_LightData.softShadowQuality = SoftShadowQuality.UsePipelineSettings;
		}

		return true;
	}

	/** 카메라를 설정한다 */
	protected virtual void SetupCameras()
	{
		this.gameObject.scene.ExEnumerateComponentsInChildren<Camera>(this.SetupCamera);
	}

	/** 카메라를 설정한다 */
	protected virtual bool SetupCamera(Camera a_oCamera)
	{
		bool bIsReset_CameraPos = this.IsReset_MainCameraPos &&
			a_oCamera.name.Equals(KDefine.G_N_OBJ_MAIN_CAMERA);

		a_oCamera.orthographic = this.Type_CameraProjection == EType_Projection._2D;
		a_oCamera.useOcclusionCulling = true;
		a_oCamera.clearStencilAfterLightingPass = true;

		a_oCamera.fieldOfView = KDefine.G_ANGLE_FIELD_OF_VIEW;

		a_oCamera.orthographicSize = (this.Height_DesignScreen / 2.0f) *
			KDefine.G_UNIT_SCALE;

		a_oCamera.nearClipPlane = KDefine.G_DISTANEC_NEAR_PLANE;
		a_oCamera.farClipPlane = KDefine.G_DISTANCE_FAR_PLANE;

		a_oCamera.clearFlags = a_oCamera.name.Equals(KDefine.G_N_OBJ_MAIN_CAMERA) ?
			a_oCamera.clearFlags : CameraClearFlags.Depth;

		a_oCamera.transform.localPosition = bIsReset_CameraPos ?
			new Vector3(0.0f, 0.0f, -this.Distance_ProjectionPlane) : a_oCamera.transform.localPosition;

		a_oCamera.transform.localEulerAngles = bIsReset_CameraPos ?
			Vector3.zero : a_oCamera.transform.localEulerAngles;

		bool bIsValid_Camera = this.IsScene_Active;
		bIsValid_Camera = bIsValid_Camera || !a_oCamera.name.Equals(KDefine.G_N_OBJ_MAIN_CAMERA);

		a_oCamera.gameObject.SetActive(bIsValid_Camera);
		var oURP_CameraData = a_oCamera.GetUniversalAdditionalCameraData();

		// 카메라 데이터가 존재 할 경우
		if(oURP_CameraData != null)
		{
			oURP_CameraData.renderShadows = true;
			oURP_CameraData.renderPostProcessing = true;
			oURP_CameraData.requiresDepthOption = CameraOverrideOption.UsePipelineSettings;

			oURP_CameraData.renderType =
				a_oCamera.name.Equals(KDefine.G_N_OBJ_MAIN_CAMERA) ? CameraRenderType.Base : CameraRenderType.Overlay;
		}

		return true;
	}

	/** 고유 컴포넌트를 설정한다 */
	protected virtual void SetupComponents_Unique()
	{
		this.gameObject.scene.ExEnumerateComponentsInChildren<EventSystem>((a_oEventSystem) =>
		{
			a_oEventSystem.enabled = this.IsScene_Active &&
				a_oEventSystem == this.UIEventSystem;

			return true;
		});

		this.gameObject.scene.ExEnumerateComponentsInChildren<AudioListener>((a_oAudioListener) =>
		{
			a_oAudioListener.enabled = this.IsScene_Active &&
				a_oAudioListener.name.Equals(KDefine.G_N_OBJ_MAIN_CAMERA);

			return true;
		});
	}

	/** 캔버스를 설정한다 */
	protected virtual void UISetupCanvases()
	{
		this.gameObject.scene.ExEnumerateComponentsInChildren<Canvas>(this.UISetupCanvas);
	}

	/** 캔버스를 설정한다 */
	protected virtual bool UISetupCanvas(Canvas a_oCanvas)
	{
		a_oCanvas.referencePixelsPerUnit = 1.0f;

		// 캔버스 비율 처리자가 존재 할 경우
		if(a_oCanvas.TryGetComponent(out CanvasScaler oScaler_Canvas))
		{
			oScaler_Canvas.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
			oScaler_Canvas.screenMatchMode = CanvasScaler.ScreenMatchMode.Expand;
			oScaler_Canvas.referenceResolution = KDefine.G_SIZE_DESIGN_SCREEN;
		}

		return true;
	}

	/** 기본 객체를 설정한다 */
	protected virtual void SetupObjects_Def()
	{
		this.gameObject.scene.ExEnumerateObjects_Root((a_oGameObj) =>
		{
			var oLight_Main = a_oGameObj.transform.Find(KDefine.G_P_OBJ_LIGHT_MAIN)?.gameObject;
			var oCamera_Main = a_oGameObj.transform.Find(KDefine.G_P_OBJ_CAMERA_MAIN)?.gameObject;

			var oUICanvas = a_oGameObj.transform.Find(KDefine.G_N_OBJ_UI_CANVAS)?.gameObject;
			var oUIEventSystem = a_oGameObj.transform.Find(KDefine.G_N_OBJ_UI_EVENT_SYSTEM)?.gameObject;

			var oUIs = a_oGameObj.transform.Find(KDefine.G_P_OBJ_UIS)?.gameObject;
			var oUIsPopup = a_oGameObj.transform.Find(KDefine.G_P_OBJ_UIS_POPUP)?.gameObject;
			var oUIsTopmost = a_oGameObj.transform.Find(KDefine.G_P_OBJ_UIS_TOPMOST)?.gameObject;

			var oObjects = a_oGameObj.transform.Find(KDefine.G_P_OBJ_OBJECTS)?.gameObject;
			var oObjects_Static = a_oGameObj.transform.Find(KDefine.G_P_OBJ_OBJECTS_STATIC)?.gameObject;

			var oUIsRoot = a_oGameObj.name.Equals(KDefine.G_N_OBJ_UIS_ROOT) ?
				a_oGameObj : null;

			var oObjects_Root = a_oGameObj.name.Equals(KDefine.G_N_OBJ_OBJECTS_ROOT) ?
				a_oGameObj : null;

			this.Light_Main = this.Light_Main ?? oLight_Main?.GetComponent<Light>();
			this.Camera_Main = this.Camera_Main ?? oCamera_Main?.GetComponent<Camera>();

			this.UICanvas = this.UICanvas ?? oUICanvas?.GetComponent<Canvas>();
			this.UICanvas_Popup = this.UICanvas_Popup ?? oUIsPopup?.GetComponent<Canvas>();

			this.UICanvas_Topmost = this.UICanvas_Topmost ?? oUIsTopmost?.GetComponent<Canvas>();
			this.UIEventSystem = this.UIEventSystem ?? oUIEventSystem?.GetComponent<EventSystem>();

			this.UIs = this.UIs ?? oUIs;
			this.UIsPopup = this.UIsPopup ?? oUIsPopup;
			this.UIsTopmost = this.UIsTopmost ?? oUIsTopmost;

			this.Objects = this.Objects ?? oObjects;
			this.Objects_Static = this.Objects_Static ?? oObjects_Static;

			this.UIsRoot = this.UIsRoot ?? oUIsRoot;
			this.Objects_Root = this.Objects_Root ?? oObjects_Root;

			return true;
		});

		CManager_Scene.ActiveScene_Light_Main = this.IsScene_Active ?
			this.Light_Main : CManager_Scene.ActiveScene_Light_Main;

		CManager_Scene.ActiveScene_Camera_Main = this.IsScene_Active ?
			this.Camera_Main : CManager_Scene.ActiveScene_Camera_Main;

		CManager_Scene.ActiveScene_UICanvas = this.IsScene_Active ?
			this.UICanvas : CManager_Scene.ActiveScene_UICanvas;

		CManager_Scene.ActiveScene_UICanvas_Popup = this.IsScene_Active ?
			this.UICanvas_Popup : CManager_Scene.ActiveScene_UICanvas_Popup;

		CManager_Scene.ActiveScene_UICanvas_Topmost = this.IsScene_Active ?
			this.UICanvas_Topmost : CManager_Scene.ActiveScene_UICanvas_Topmost;

		CManager_Scene.ActiveScene_UIEventSystem = this.IsScene_Active ?
			this.UIEventSystem : CManager_Scene.ActiveScene_UIEventSystem;

		CManager_Scene.ActiveScene_UIs = this.IsScene_Active ?
			this.UIs : CManager_Scene.ActiveScene_UIs;

		CManager_Scene.ActiveScene_UIsRoot = this.IsScene_Active ?
			this.UIsRoot : CManager_Scene.ActiveScene_UIs;

		CManager_Scene.ActiveScene_UIsPopup = this.IsScene_Active ?
			this.UIsPopup : CManager_Scene.ActiveScene_UIsPopup;

		CManager_Scene.ActiveScene_UIsTopmost = this.IsScene_Active ?
			this.UIsTopmost : CManager_Scene.ActiveScene_UIsTopmost;

		CManager_Scene.ActiveScene_Objects = this.IsScene_Active ?
			this.Objects : CManager_Scene.ActiveScene_Objects;

		CManager_Scene.ActiveScene_Objects_Root = this.IsScene_Active ?
			this.Objects_Root : CManager_Scene.ActiveScene_Objects_Root;

		CManager_Scene.ActiveScene_Objects_Static = this.IsScene_Active ?
			this.Objects_Static : CManager_Scene.ActiveScene_Objects_Static;
	}

	/** 기본 UI 객체를 설정한다 */
	protected virtual void SetupObjects_DefUI()
	{
		var oUIRectTrans_UIs = this.UIs.transform as RectTransform;
		oUIRectTrans_UIs.sizeDelta = KDefine.G_SIZE_DESIGN_SCREEN;

		var oUIRectTrans_PopupUIs = this.UIsPopup.transform as RectTransform;
		oUIRectTrans_PopupUIs.sizeDelta = Vector3.zero;

		var oUIRectTrans_TopmostUIs = this.UIsTopmost.transform as RectTransform;
		oUIRectTrans_TopmostUIs.sizeDelta = Vector3.zero;

		this.UICanvas.overrideSorting = false;
		this.UICanvas.overridePixelPerfect = false;

		this.UICanvas_Popup.overrideSorting = true;
		this.UICanvas_Popup.overridePixelPerfect = false;

		this.UICanvas_Topmost.overrideSorting = true;
		this.UICanvas_Topmost.overridePixelPerfect = false;

		this.UICanvas.sortingOrder = this.UIInfo_UIsSortingOrder.m_nOrder;
		this.UICanvas.sortingLayerName = this.UIInfo_UIsSortingOrder.m_oLayer;

		this.UICanvas_Popup.sortingOrder = this.UIInfo_PopupUIsSortingOrder.m_nOrder;
		this.UICanvas_Popup.sortingLayerName = this.UIInfo_PopupUIsSortingOrder.m_oLayer;

		this.UICanvas_Topmost.sortingOrder = this.UIInfo_TopmostUIsSortingOrder.m_nOrder;
		this.UICanvas_Topmost.sortingLayerName = this.UIInfo_TopmostUIsSortingOrder.m_oLayer;

		// 캔버스 비율 조절자가 존재 할 경우
		if(this.UICanvas.TryGetComponent(out CanvasScaler oScaler_Canvas))
		{
			oScaler_Canvas.referenceResolution = KDefine.G_SIZE_DESIGN_SCREEN;
			oScaler_Canvas.referencePixelsPerUnit = KDefine.G_UNIT_REF_PIXELS_PER;
		}
	}

	/** 기본 일반 객체를 설정한다 */
	protected virtual void SetupObjects_DefObj()
	{
		float fScale_ResolutionCorrect = Access.GetScale_ResolutionCorrect(this.Size_DesignScreen);

		this.Objects_Root.transform.localScale = Vector3.one *
			fScale_ResolutionCorrect * KDefine.G_UNIT_SCALE;
	}

	/** 레이아웃을 재배치한다 */
	protected override void RebuildLayout()
	{
		base.RebuildLayout();

		this.gameObject.scene.ExEnumerateObjects_Root((a_oGameObj) =>
		{
			CGSingleton.Inst.RebuildLayouts(a_oGameObj);
			return true;
		});
	}

	/** 네트워크 상태 변경을 처리한다 */
	protected virtual void HandleOnChange_NetworkReachability(NetworkReachability a_eNetworkReachability)
	{
		Func.ShowLog("CManager_Scene.HandleOnChange_NetworkReachability: {0}, {1}",
			this.Name_Scene, a_eNetworkReachability);
	}

	/** 디바이스 화면 크기 변경을 처리한다 */
	protected virtual void HandleOnChange_DeviceScreenSize(Vector3 a_stSize_Screen)
	{
		Func.ShowLog("CManager_Scene.HandleOnChange_DeviceScreenSize: {0}, {1}",
			this.Name_Scene, a_stSize_Screen);
	}

#if UNITY_EDITOR
	/** 씬을 설정한다 */
	public void Editor_SetupScene()
	{
		this.SetupScene(true);
		this.SetupScene(false);
	}

	/** GUI 를 그린다 */
	protected virtual void OnGUI()
	{
		// Do Something
	}

	/*
	 * OnDrawGizmos 메서드는 Unity 에디터의 씬 뷰 상에 그래픽을 출력하는 역할을 수행한다.
	 * (+ 즉, 해당 메서드를 활용하면 프로그램을 제작하기 위한 여러 유용한 정보를 화면 상에
	 * 출력하는 것이 가능하다.)
	 * 
	 * 단, 해당 메서드는 Unity 에디터 상에서만 구동되기 때문에 해당 메서드는 반드시
	 * UNITY_EDITOR 조건문으로 감싸줘야한다. (+ 즉, 에디터 전용 메서드로 구현하지 않을 경우
	 * 빌드 시 에러가 발생한다는 것을 알 수 있다.)
	 */
	/** 기즈모를 그린다 */
	protected virtual void OnDrawGizmos()
	{
		// Do Something
	}
#endif // #if UNITY_EDITOR
	#endregion // 함수

	#region 제네릭 클래스 접근 함수
	/** 씬 관리자를 반환한다 */
	public static T GetManager_Scene<T>(string a_oName) where T : CManager_Scene
	{
		return CManager_Scene.DictManagers_Scene.ExGetVal(a_oName) as T;
	}
	#endregion // 제네릭 클래스 접근 함수
}
