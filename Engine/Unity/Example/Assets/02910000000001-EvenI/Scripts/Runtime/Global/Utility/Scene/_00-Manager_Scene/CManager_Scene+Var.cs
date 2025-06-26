using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

/**
 * 씬 관리자 - 변수
 */
public abstract partial class CManager_Scene : CComponent
{
	#region 프로퍼티
	public Light Light_Main { get; private set; } = null;
	public Camera Camera_Main { get; private set; } = null;

	public Canvas UICanvas { get; private set; } = null;
	public Canvas UICanvas_Popup { get; private set; } = null;
	public Canvas UICanvas_Topmost { get; private set; } = null;

	public EventSystem UIEventSystem { get; private set; } = null;

	public GameObject UIs { get; private set; } = null;
	public GameObject UIsRoot { get; private set; } = null;
	public GameObject UIsPopup { get; private set; } = null;
	public GameObject UIsTopmost { get; private set; } = null;

	public GameObject Objects { get; private set; } = null;
	public GameObject Objects_Root { get; private set; } = null;
	public GameObject Objects_Static { get; private set; } = null;

	public bool IsScene_Active =>
		CManager_Scene.ActiveScene.Equals(this.gameObject.scene);

	public bool IsScene_Additive =>
		!CManager_Scene.ActiveScene.Equals(this.gameObject.scene);

	public virtual bool IsReset_MainCameraPos => true;

	public virtual float Width_DesignScreen => KDefine.G_WIDTH_DESIGN_SCREEN;
	public virtual float Height_DesignScreen => KDefine.G_HEIGHT_DESIGN_SCREEN;

	public virtual float Distance_ProjectionPlane =>
		Access.GetDistance_ProjectionPlane(this.Height_DesignScreen);

	public virtual string Name_Scene => this.gameObject.scene.name;
	public virtual EType_Projection Type_CameraProjection => EType_Projection._3D;

	public virtual Vector3 Size_DesignScreen =>
		new Vector3(this.Width_DesignScreen, this.Height_DesignScreen, 0.0f);

	public virtual STInfo_SortingOrder UIInfo_UIsSortingOrder =>
		new STInfo_SortingOrder(0, KDefine.G_N_LAYER_DEF);

	public virtual STInfo_SortingOrder UIInfo_PopupUIsSortingOrder =>
		new STInfo_SortingOrder(this.UIInfo_UIsSortingOrder.m_nOrder + (sbyte.MaxValue * 1), this.UIInfo_UIsSortingOrder.m_oLayer);

	public virtual STInfo_SortingOrder UIInfo_TopmostUIsSortingOrder =>
		new STInfo_SortingOrder(this.UIInfo_UIsSortingOrder.m_nOrder + (sbyte.MaxValue * 2), this.UIInfo_UIsSortingOrder.m_oLayer);
	#endregion // 프로퍼티

	#region 클래스 프로퍼티
	public static Dictionary<string, CManager_Scene> DictManagers_Scene { get; } = new Dictionary<string, CManager_Scene>();
	public static bool IsQuit_App { get; private set; } = false;

	public static bool IsRunning_App => !CManager_Scene.IsQuit_App;
	#endregion // 클래스 프로퍼티
}

/**
 * 씬 관리자 - 변수 (액티브 씬)
 */
public abstract partial class CManager_Scene : CComponent
{
	#region 클래스 프로퍼티
	public static Vector3 ActiveScene_UISize_Canvas { get; private set; } = Vector3.zero;

	public static Light ActiveScene_Light_Main { get; private set; } = null;
	public static Camera ActiveScene_Camera_Main { get; private set; } = null;

	public static Canvas ActiveScene_UICanvas { get; private set; } = null;
	public static Canvas ActiveScene_UICanvas_Popup { get; private set; } = null;
	public static Canvas ActiveScene_UICanvas_Topmost { get; private set; } = null;

	public static EventSystem ActiveScene_UIEventSystem { get; private set; } = null;

	public static GameObject ActiveScene_UIs { get; private set; } = null;
	public static GameObject ActiveScene_UIsRoot { get; private set; } = null;
	public static GameObject ActiveScene_UIsPopup { get; private set; } = null;
	public static GameObject ActiveScene_UIsTopmost { get; private set; } = null;

	public static GameObject ActiveScene_Objects { get; private set; } = null;
	public static GameObject ActiveScene_Objects_Root { get; private set; } = null;
	public static GameObject ActiveScene_Objects_Static { get; private set; } = null;

	/*
	 * SceneManager.GetActiveScene 메서드는 현재 로드 된 씬 중에 주요 씬을 가져오는 역할을
	 * 수행한다. (+ 즉, 해당 메서드를 활용하면 주요 씬에 대한 여러 정보를 가져오는 것이 가능하다.)
	 */
	public static Scene ActiveScene => SceneManager.GetActiveScene();

	public static string ActiveScene_Name => CManager_Scene.ActiveScene.name;
	#endregion // 클래스 프로퍼티
}
