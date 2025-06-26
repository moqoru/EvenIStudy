using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 알림 팝업
 */
public partial class CUIPopup_Alert : CUIPopup
{
	/**
	 * 매개 변수
	 */
	public record REParams : global::REParams<CUIPopup_Alert, bool>
	{
		public string m_oTitle;
		public string m_oMsg;

		public string m_oStr_OKBtn;
		public string m_oStr_CancelBtn;
	}

	#region 변수
	[Header("=====> Popup Alert - UIs <=====")]
	[SerializeField] private Text m_oUIText_Title = null;
	[SerializeField] private Text m_oUIText_Msg = null;

	[SerializeField] private Button m_oUIBtn_OKBtn = null;
	[SerializeField] private Button m_oUIBtn_CancelBtn = null;
	#endregion // 변수

	#region 프로퍼티
	public new REParams Params => base.Params as REParams;
	#endregion // 프로퍼티

	#region 함수
	/** 컨텐츠를 설정한다 */
	protected override void SetupContents()
	{
		base.SetupContents();

		// 텍스트를 설정한다 {
		m_oUIText_Title.text = this.Params.m_oTitle;
		m_oUIText_Msg.text = this.Params.m_oMsg;

		var oUIText_OKBtn = m_oUIBtn_OKBtn.GetComponentInChildren<Text>();
		oUIText_OKBtn.text = this.Params.m_oStr_OKBtn;

		var oUIText_CancelBtn = m_oUIBtn_CancelBtn.GetComponentInChildren<Text>();
		oUIText_CancelBtn.text = this.Params.m_oStr_CancelBtn;
		// 텍스트를 설정한다 }

		// 버튼을 설정한다 {
		m_oUIBtn_OKBtn.onClick.AddListener(this.UIHandleOnBtn_OK);
		m_oUIBtn_OKBtn.gameObject.SetActive(this.Params.m_oStr_OKBtn.ExIsValid());

		m_oUIBtn_CancelBtn.onClick.AddListener(this.UIHandleOnBtn_Cancel);
		m_oUIBtn_CancelBtn.gameObject.SetActive(this.Params.m_oStr_CancelBtn.ExIsValid());
		// 버튼을 설정한다 }
	}

	/** 확인 버튼을 처리한다 */
	private void UIHandleOnBtn_OK()
	{
		this.Params.m_oCallbackB?.Invoke(this, true);
		this.Close();
	}

	/** 취소 버튼을 처리한다 */
	private void UIHandleOnBtn_Cancel()
	{
		this.Params.m_oCallbackB?.Invoke(this, false);
		this.Close();
	}
	#endregion // 함수

	#region 팩토리 함수
	/** 매개 변수를 생성한다 */
	public static REParams MakeParams(string a_oTitle,
		string a_oMsg, string a_oStr_OKBtn, string a_oStr_CancelBtn, System.Action<CUIPopup_Alert, bool> a_oCallback)
	{
		return new REParams()
		{
			m_oCallbackB = a_oCallback,

			m_oTitle = a_oTitle,
			m_oMsg = a_oMsg,

			m_oStr_OKBtn = a_oStr_OKBtn,
			m_oStr_CancelBtn = a_oStr_CancelBtn
		};
	}
	#endregion // 팩토리 함수
}
