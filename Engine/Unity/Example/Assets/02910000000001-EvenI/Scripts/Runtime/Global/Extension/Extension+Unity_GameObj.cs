using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 게임 객체
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 컴포넌트를 추가한다 */
	public static T ExAddComponent<T>(this GameObject a_oSender,
		bool a_bIsUnique = true, bool a_bIsAssert = true) where T : Component
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 컴포넌트 추가가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return null;
		}

		return (a_bIsUnique && a_oSender.TryGetComponent(out T oComponent)) ?
			oComponent : a_oSender.AddComponent<T>();
	}

	/** 컴포넌트를 순회한다 */
	public static void ExEnumerateComponentsInChildren<T>(this GameObject a_oSender,
		System.Func<T, bool> a_oCallback, bool a_bIsInclude_Inactive = false, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_oCallback != null;

		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 컴포넌트 순회가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		var oListComponents = new List<T>();
		a_oSender.GetComponentsInChildren(a_bIsInclude_Inactive, oListComponents);

		for(int i = 0; i < oListComponents.Count; ++i)
		{
			// 컴포넌트 순회가 불가능 할 경우
			if(!a_oCallback(oListComponents[i]))
			{
				break;
			}
		}
	}
	#endregion // 클래스 함수
}
