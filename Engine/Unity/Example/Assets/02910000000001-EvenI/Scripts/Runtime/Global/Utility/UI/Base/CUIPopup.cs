using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using DG.Tweening;

/**
 * 팝업
 */
public partial class CUIPopup : CComponent
{
	#region 변수
	[Header("=====> Popup - Etc <=====")]
	private bool m_bIsShow = false;
	private bool m_bIsClose = false;

	private Tween m_oAnim_Show = null;
	private Tween m_oAnim_Close = null;

	public System.Action<CUIPopup> m_oCallback_Show { get; private set; } = null;
	public System.Action<CUIPopup> m_oCallback_Close { get; private set; } = null;
	#endregion // 변수

	#region 프로퍼티
	public REParams Params { get; private set; } = null;

	public Image UIImg_Bg { get; private set; } = null;
	public Image UIImg_Blind { get; private set; } = null;

	public GameObject UIGameObj_Contents { get; private set; } = null;
	public GameObject UIGameObj_ContentsUIs { get; private set; } = null;
	public GameObject UIGameObj_BlindTouchResponder { get; private set; } = null;

	public virtual float TimeScale_Show => 0.0f;
	public virtual float TimeScale_Close => 1.0f;

	public virtual Color Color_Blind => KDefine.G_COLOR_UI_POPUP_BLIND;
	#endregion // 프로퍼티

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();

		CManager_Schedule.Inst.AddComponent(this);
		CManager_NavStack.Inst.AddComponent(this);

		this.UIGameObj_Contents = this.transform.Find(KDefine.G_P_OBJ_UI_POPUP_CONTENTS)?.gameObject;
		this.UIGameObj_ContentsUIs = this.transform.Find(KDefine.G_P_OBJ_UI_POPUP_CONTENTS_UIS)?.gameObject;

		this.UIGameObj_BlindTouchResponder = this.CreateResponder_BlindTouch();
		this.UIGameObj_BlindTouchResponder.transform.SetAsFirstSibling();

		this.UIImg_Bg = this.UIGameObj_Contents?.GetComponentInChildren<Image>();
		this.UIImg_Blind = this.UIGameObj_BlindTouchResponder.GetComponentInChildren<Image>();
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		this.ResetState_Animations();
	}

	/** 초기화 */
	public virtual void Init(REParams a_reParams)
	{
		this.Params = a_reParams;
		this.UIGameObj_Contents.transform.localScale = Vector3.zero;
	}

	/** 애니메이션을 리셋한다 */
	public virtual void ResetState_Animations()
	{
		Access.AssignVal(ref m_oAnim_Show, null);
		Access.AssignVal(ref m_oAnim_Close, null);
	}

	/** 내비게이션 스택 이벤트를 처리한다 */
	public override void HandleOnEvent_NavStack(EEvent_NavStack a_eEvent)
	{
		base.HandleOnEvent_NavStack(a_eEvent);

		switch(a_eEvent)
		{
			case EEvent_NavStack.TOP:
				this.HandleOnEvent_TopNavStack();
				break;

			case EEvent_NavStack.REMOVE:
				this.HandleOnEvent_RemoveNavStack();
				break;

			case EEvent_NavStack.BACK_KEY_DOWN:
				this.UIHandleOnBtn_Close();
				break;
		}
	}

	/** 팝업을 출력한다 */
	public virtual void Show(System.Action<CUIPopup> a_oCallback_Show,
		System.Action<CUIPopup> a_oCallback_Close)
	{
		bool bIsValid = !m_bIsShow;
		bIsValid = bIsValid && !m_bIsClose;
		bIsValid = bIsValid && !this.IsDestroy;

		// 출력이 불가능 할 경우
		if(!bIsValid)
		{
			return;
		}

		m_bIsShow = true;
		m_oCallback_Show = a_oCallback_Show;
		m_oCallback_Close = a_oCallback_Close;

		this.ExCallFunc_Late(this.Show_Internal, KDefine.G_INTERVAL_INTERMEDIATE, true);
	}

	/** 팝업을 닫는다 */
	public virtual void Close()
	{
		bool bIsValid = m_bIsShow;
		bIsValid = bIsValid && !m_bIsClose;
		bIsValid = bIsValid && !this.IsDestroy;

		// 닫기가 불가능 할 경우
		if(!bIsValid)
		{
			return;
		}

		this.StartAnim_Close();
		CManager_NavStack.Inst.RemoveComponent(this);
	}

	/** 컨텐츠를 설정한다 */
	protected virtual void SetupContents()
	{
		// Do Something
	}

	/** 최상단 내비게이션 스택 이벤트를 처리한다 */
	protected virtual void HandleOnEvent_TopNavStack()
	{
		// Do Something
	}

	/** 제거 내비게이션 스택 이벤트를 처리한다 */
	protected virtual void HandleOnEvent_RemoveNavStack()
	{
		// Do Something
	}

	/** 출력 애니메이션 완료를 처리한다 */
	protected virtual void HandleOnComplete_ShowAnim()
	{
		m_oCallback_Show?.Invoke(this);

		this.UIGameObj_Contents.transform.localScale = Vector3.one;
		this.UIGameObj_Contents.transform.localPosition = Vector3.zero;
	}

	/** 닫기 애니메이션 완료를 처리한다 */
	protected virtual void HandleOnComplete_CloseAnim()
	{
		m_oCallback_Close?.Invoke(this);
		this.UIGameObj_Contents.transform.localScale = Vector3.zero;

		Destroy(this.gameObject);
	}

	/** 닫기 버튼을 눌렀을 경우 */
	protected virtual void UIHandleOnBtn_Close()
	{
		this.Close();
	}

	/** 출력 애니메이션을 시작한다 */
	private void StartAnim_Show()
	{
		this.ResetState_Animations();
		Access.SetTimeScale(this.TimeScale_Show);

		Access.AssignVal(ref m_oAnim_Show,
			Factory.MakeSequence(this.MakeAnim_Show(), (a_oSender) => this.HandleOnComplete_ShowAnim(), a_bIsRealtime: true));
	}

	/** 닫기 애니메이션을 시작한다 */
	private void StartAnim_Close()
	{
		this.ResetState_Animations();
		Access.SetTimeScale(this.TimeScale_Close);

		Access.AssignVal(ref m_oAnim_Close,
			Factory.MakeSequence(this.MakeAnim_Close(), (a_oSender) => this.HandleOnComplete_CloseAnim(), a_bIsRealtime: true));
	}

	/** 팝업을 출력한다 */
	private void Show_Internal(MonoBehaviour a_oSender)
	{
		// 팝업 출력이 불가능 할 경우
		if(this.IsDestroy || m_bIsClose)
		{
			return;
		}

		this.StartAnim_Show();
		this.SetColor_Blind(this.Color_Blind);

		this.SetupContents();
	}
	#endregion // 함수

	#region 접근 함수
	/** 블라인드 색상을 변경한다 */
	public void SetColor_Blind(Color a_stColor)
	{
		this.UIImg_Blind.color = a_stColor;
	}
	#endregion // 접근 함수

	#region 팩토리 함수
	/** 출력 애니메이션을 생성한다 */
	protected virtual Tween MakeAnim_Show()
	{
		var oAnim = this.UIGameObj_Contents.transform.DOScale(1.0f,
			KDefine.G_UI_POPUP_DURATION_ANIM);

		return oAnim.SetEase(Ease.OutBack);
	}

	/** 닫기 애니메이션을 생성한다 */
	protected virtual Tween MakeAnim_Close()
	{
		var oAnim = this.UIGameObj_Contents.transform.DOScale(0.0f,
			KDefine.G_UI_POPUP_DURATION_ANIM);

		return oAnim.SetEase(Ease.InBack);
	}

	/** 블라인드 터치 반응자를 생성한다 */
	protected virtual GameObject CreateResponder_BlindTouch()
	{
		string oName = string.Format("UIResponder_BlindTouch_{0}", this.gameObject.name);

		return Factory.CreateResponder_Touch(oName,
			KDefine.G_P_OBJ_UI_RESPONDER_TOUCH, this.gameObject, Vector3.zero, CManager_Scene.ActiveScene_UISize_Canvas, Color.clear);
	}
	#endregion // 팩토리 함수
}
