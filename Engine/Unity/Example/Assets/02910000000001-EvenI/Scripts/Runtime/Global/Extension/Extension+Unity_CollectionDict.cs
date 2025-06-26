using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 컬렉션 (딕셔너리)
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 유효 여부를 검사한다 */
	public static bool ExIsValid<K, V>(this Dictionary<K, V> a_oSender)
	{
		return a_oSender != null && a_oSender.Count > 0;
	}

	/** 값을 추가한다 */
	public static void ExAddVal<K, V>(this Dictionary<K, V> a_oSender,
		K a_tKey, V a_tVal, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 값 추가가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		a_oSender.TryAdd(a_tKey, a_tVal);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal<K, V>(this Dictionary<K, V> a_oSender,
		K a_tKey, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 값 제거가 불가능 할 경우
		if(!bIsValid_Assert || !a_oSender.ContainsKey(a_tKey))
		{
			return;
		}

		a_oSender.Remove(a_tKey);
	}

	/** 값을 복사한다 */
	public static void ExCopyValues<KSrc, VSrc, VDest>(this Dictionary<KSrc, VSrc> a_oSender,
		Dictionary<KSrc, VDest> a_oDictDest, System.Func<KSrc, VSrc, VDest> a_oCallback, bool a_bIsClear = true, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_oDictDest != null;
		bIsValid_Assert = bIsValid_Assert && a_oCallback != null;

		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 값 복사가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		// 클리어 모드 일 경우
		if(a_bIsClear)
		{
			a_oDictDest.Clear();
		}

		foreach(var stKeyVal in a_oSender)
		{
			a_oDictDest.TryAdd(stKeyVal.Key, a_oCallback(stKeyVal.Key, stKeyVal.Value));
		}
	}
	#endregion // 클래스 함수
}
