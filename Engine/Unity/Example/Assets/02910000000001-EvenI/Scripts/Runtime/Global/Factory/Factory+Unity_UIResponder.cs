using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 팩토리 - 응답자
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 터치 응답자를 생성한다 */
	public static GameObject CreateResponder_Touch(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor)
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oPath_Prefab.ExIsValid();

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder_Touch(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}

	/** 터치 응답자를 생성한다 */
	public static GameObject CreateResponder_Touch(string a_oName,
		GameObject a_oGameObj_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor)
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oGameObj_Origin != null;

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder(a_oName,
			a_oGameObj_Origin, a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}

	/** 드래그 응답자를 생성한다 */
	public static GameObject CreateResponder_Drag(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor)
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oPath_Prefab.ExIsValid();

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder_Drag(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}

	/** 드래그 응답자를 생성한다 */
	public static GameObject CreateResponder_Drag(string a_oName,
		GameObject a_oGameObj_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor)
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oGameObj_Origin != null;

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder(a_oName,
			a_oGameObj_Origin, a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}
	#endregion // 클래스 팩토리 함수

	#region 제네릭 클래스 팩토리 함수
	/** 터치 응답자를 생성한다 */
	public static T CreateResponder_Touch<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor) where T : Component
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oPath_Prefab.ExIsValid();

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder_Touch<T>(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}

	/** 터치 응답자를 생성한다 */
	public static T CreateResponder_Touch<T>(string a_oName,
		GameObject a_oGameObj_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor) where T : Component
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oGameObj_Origin != null;

		Debug.Assert(bIsValid_Assert);

		var oGameObj = Factory.CreateResponder_Touch(a_oName,
			a_oGameObj_Origin, a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);

		return oGameObj?.GetComponentInChildren<T>();
	}

	/** 드래그 응답자를 생성한다 */
	public static T CreateResponder_Drag<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor) where T : Component
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oPath_Prefab.ExIsValid();

		Debug.Assert(bIsValid_Assert);

		return Factory.CreateResponder_Drag<T>(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);
	}

	/** 드래그 응답자를 생성한다 */
	public static T CreateResponder_Drag<T>(string a_oName,
		GameObject a_oGameObj_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor) where T : Component
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oGameObj_Origin != null;

		Debug.Assert(bIsValid_Assert);

		var oGameObj = Factory.CreateResponder_Drag(a_oName,
			a_oGameObj_Origin, a_oGameObj_Parent, a_stPos, a_stSize, a_stColor);

		return oGameObj?.GetComponentInChildren<T>();
	}
	#endregion // 제네릭 클래스 팩토리 함수
}

/** 응답자 팩토리 - Private */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 응답자를 생성한다 */
	private static GameObject CreateResponder(string a_oName,
		GameObject a_oGameObj_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stSize, Color a_stColor)
	{
		bool bIsValid_Assert = a_oName.ExIsValid();
		bIsValid_Assert = bIsValid_Assert && a_oGameObj_Origin != null;

		Debug.Assert(bIsValid_Assert);

		var oGameObj = Factory.CreateGameObj_Clone(a_oName,
			a_oGameObj_Origin, a_oGameObj_Parent);

		var oRectTrans = oGameObj.transform as RectTransform;

		// 2 차원 트랜스 폼이 존재 할 경우
		if(oRectTrans != null)
		{
			oRectTrans.pivot = KDefine.G_ANCHOR_MID_CENTER;
			oRectTrans.anchorMin = KDefine.G_ANCHOR_MID_CENTER;
			oRectTrans.anchorMax = KDefine.G_ANCHOR_MID_CENTER;

			oRectTrans.anchoredPosition = a_stPos.ExTo2D();
			oRectTrans.sizeDelta = a_stSize.ExTo2D();
		}

		oGameObj.GetComponentInChildren<Image>().color = a_stColor;
		return oGameObj;
	}
	#endregion // 클래스 팩토리 함수
}
