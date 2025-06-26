using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

/**
 * 확장 클래스 - 씬
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 객체를 순회한다 */
	public static void ExEnumerateObjects_Root(this Scene a_stSender,
		System.Func<GameObject, bool> a_oCallback, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oCallback != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 객체 순회가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		var oListGameObjects = new List<GameObject>();

		/*
		 * GetRootGameObjects 메서드는 씬에 존재하는 최상단 게임 객체를 가져오는 역할을 수행한다. 
		 * (+ 즉, 해당 메서드를 활용하면 특정 씬에 존재하는 게임 객체에 접근하는 것이 가능하다.)
		 */
		a_stSender.GetRootGameObjects(oListGameObjects);

		for(int i = 0; i < oListGameObjects.Count; ++i)
		{
			// 객체 순회가 불가능 할 경우
			if(!a_oCallback(oListGameObjects[i]))
			{
				break;
			}
		}
	}

	/** 컴포넌트를 순회한다 */
	public static void ExEnumerateComponentsInChildren<T>(this Scene a_stSender,
		System.Func<T, bool> a_oCallback, bool a_bIsInclude_Inactive = false, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oCallback != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 객체 순회가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		a_stSender.ExEnumerateObjects_Root((a_oGameObj) =>
		{
			bool bIsTrue = true;

			a_oGameObj.ExEnumerateComponentsInChildren<T>((a_oComponent) =>
			{
				return bIsTrue = a_oCallback(a_oComponent);
			}, a_bIsInclude_Inactive, a_bIsAssert);

			return bIsTrue;
		}, a_bIsAssert);
	}
	#endregion // 클래스 함수
}
