using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 함수
 */
public static partial class Func
{
	#region 함수
	/** 알림 팝업을 출력한다 */
	public static void UIShowPopup_Alert(string a_oMsg,
		System.Action<CUIPopup_Alert, bool> a_oCallback)
	{
		Func.UIShowPopup_Alert("알림", a_oMsg, "확인", a_oCallback);
	}

	/** 알림 팝업을 출력한다 */
	public static void UIShowPopup_Alert(string a_oTitle,
		string a_oMsg, string a_oStr_OKBtn, System.Action<CUIPopup_Alert, bool> a_oCallback)
	{
		Func.UIShowPopup_Alert(a_oTitle, a_oMsg, a_oStr_OKBtn, "취소", a_oCallback);
	}

	/** 알림 팝업을 출력한다 */
	public static void UIShowPopup_Alert(string a_oTitle,
		string a_oMsg, string a_oStr_OKBtn, string a_oStr_CancelBtn, System.Action<CUIPopup_Alert, bool> a_oCallback)
	{
		var oUIsPopup = CManager_Scene.ActiveScene_UIsPopup;

		// 팝업 출력이 불가능 할 경우
		if(oUIsPopup.transform.Find("UIPopup_Alert") != null)
		{
			return;
		}

		var reParams = CUIPopup_Alert.MakeParams(a_oTitle,
			a_oMsg, a_oStr_OKBtn, a_oStr_CancelBtn, a_oCallback);

		var oPopup_Alert = Factory.CreateGameObj_Clone<CUIPopup_Alert>("UIPopup_Alert",
			KDefine.G_P_OBJ_UI_POPUP_ALERT, CManager_Scene.ActiveScene_UIsPopup);

		oPopup_Alert.Init(reParams);
		oPopup_Alert.Show(null, null);
	}
	#endregion // 함수
}
