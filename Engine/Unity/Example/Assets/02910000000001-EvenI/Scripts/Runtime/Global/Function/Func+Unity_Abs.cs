using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.Diagnostics;

/**
 * 함수
 */
public static partial class Func
{
	#region 클래스 함수
	[Conditional("DEBUG"), Conditional("DEVELOPMENT_BUILD")]
	/** 로그를 출력한다 */
	public static void ShowLog(string a_oFmt, params object[] a_oParams)
	{
		UnityEngine.Debug.LogFormat(a_oFmt, a_oParams);
	}
	#endregion // 클래스 함수

	#region 제네릭 클래스 함수
	/** 컴포넌트를 순회한다 */
	public static void EnumerateComponents<T>(System.Func<T, bool> a_oCallback,
		bool a_bIsInclude_Inactive = false, bool a_bIsAssert = true) where T : Component
	{
		bool bIsValid_Assert = a_oCallback != null;
		UnityEngine.Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 컴포넌트 순회가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		Func.EnumerateScenes((a_stScene) =>
		{
			bool bIsTrue = true;

			a_stScene.ExEnumerateComponentsInChildren<T>((a_oComponent) =>
			{
				return bIsTrue = a_oCallback(a_oComponent);
			}, a_bIsInclude_Inactive, a_bIsAssert);

			return bIsTrue;
		}, a_bIsAssert);
	}
	#endregion // 제네릭 클래스 함수
}
