using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 비동기
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 함수를 지연 호출한다 */
	public static void ExCallFunc_Late(this MonoBehaviour a_oSender,
		System.Action<MonoBehaviour> a_oCallback, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oSender != null);

		// 지연 호출이 불가능 할 경우
		if(a_oSender == null)
		{
			return;
		}

		a_oSender.StartCoroutine(a_oSender.ExCoCallFunc_Late(a_oCallback));
	}

	/** 함수를 지연 호출한다 */
	public static void ExCallFunc_Late(this MonoBehaviour a_oSender,
		System.Action<MonoBehaviour> a_oCallback, float a_fDelay, bool a_bIsRealtime = false, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oSender != null);

		// 지연 호출이 불가능 할 경우
		if(a_oSender == null)
		{
			return;
		}

		var oEnumerator = a_oSender.ExCoCallFunc_Late(a_oCallback,
			a_fDelay, a_bIsRealtime);

		a_oSender.StartCoroutine(oEnumerator);
	}

	/** 함수를 반복 호출한다 */
	public static void ExCallFunc_Repeat(this MonoBehaviour a_oSender,
		System.Func<MonoBehaviour, bool, bool> a_oCallback, float a_fInterval, float a_fTime_MaxDelta, bool a_bIsRealtime = false, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oSender != null);

		// 지연 호출이 불가능 할 경우
		if(a_oSender == null)
		{
			return;
		}

		var oEnumerator = a_oSender.ExCoCallFunc_Repeat(a_oCallback,
			a_fInterval, a_fTime_MaxDelta, a_bIsRealtime);

		a_oSender.StartCoroutine(oEnumerator);
	}
	#endregion // 클래스 함수
}

/**
 * 확장 클래스 - 비동기 (코루틴)
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 함수를 지연 호출한다 */
	private static IEnumerator ExCoCallFunc_Late(this MonoBehaviour a_oSender,
		System.Action<MonoBehaviour> a_oCallback)
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(bIsValid_Assert);

		yield return Access.CoGetWait_ForEndOfFrame();
		a_oCallback?.Invoke(a_oSender);
	}

	/** 함수를 지연 호출한다 */
	private static IEnumerator ExCoCallFunc_Late(this MonoBehaviour a_oSender,
		System.Action<MonoBehaviour> a_oCallback, float a_fDelay, bool a_bIsRealtime)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_fDelay.ExIsGreatEquals(0.0f);

		Debug.Assert(bIsValid_Assert);

		yield return Access.CoGetWait_ForSecs(a_fDelay, a_bIsRealtime);
		a_oCallback?.Invoke(a_oSender);
	}

	/** 함수를 반복 호출한다 */
	private static IEnumerator ExCoCallFunc_Repeat(this MonoBehaviour a_oSender,
		System.Func<MonoBehaviour, bool, bool> a_oCallback, float a_fInterval, double a_dblTime_MaxDelta, bool a_bIsRealtime)
	{
		bool bIsValid = a_oSender != null;
		bIsValid = bIsValid && a_oCallback != null;
		bIsValid = bIsValid && a_fInterval.ExIsGreatEquals(0.0f);

		Debug.Assert(bIsValid);
		var stTime_Start = System.DateTime.Now;

		do
		{
			yield return Access.CoGetWait_ForSecs(a_fInterval, a_bIsRealtime);

			// 반복 호출이 필요 없을 경우
			if(a_oCallback(a_oSender, false))
			{
				break;
			}
		} while(System.DateTime.Now.ExGetInterval(stTime_Start).ExIsLess(a_dblTime_MaxDelta));

		a_oCallback(a_oSender, true);
	}
	#endregion // 클래스 함수
}
