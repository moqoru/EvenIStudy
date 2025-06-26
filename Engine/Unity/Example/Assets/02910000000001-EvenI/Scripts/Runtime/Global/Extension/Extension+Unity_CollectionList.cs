using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 컬렉션 (리스트)
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 유효 여부를 검사한다 */
	public static bool ExIsValid<T>(this List<T> a_oSender)
	{
		return a_oSender != null && a_oSender.Count > 0;
	}

	/** 유효 여부를 검사한다 */
	public static bool ExIsValid_Idx<T>(this List<T> a_oSender, int a_nIdx)
	{
		Debug.Assert(a_oSender != null);
		return a_nIdx >= 0 && a_nIdx < a_oSender.Count;
	}

	/** 값을 추가한다 */
	public static void ExAddVal<T>(this List<T> a_oSender,
		T a_tVal, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 값 추가가 불가능 할 경우
		if(!bIsValid_Assert || a_oSender.Contains(a_tVal))
		{
			return;
		}

		a_oSender.Add(a_tVal);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal<T>(this List<T> a_oSender,
		T a_tVal, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		a_oSender.ExRemoveVal((a_tVal_Compare) => a_tVal_Compare.Equals(a_tVal),
			a_bIsAssert);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal<T>(this List<T> a_oSender,
		System.Predicate<T> a_oCompare, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_oCompare != null;

		Debug.Assert(!a_bIsAssert || bIsValid_Assert);
		a_oSender.ExRemoveVal_At(a_oSender.ExFindVal(a_oCompare), a_bIsAssert);
	}

	/** 값을 제거한다 */
	public static void ExRemoveVal_At<T>(this List<T> a_oSender,
		int a_nIdx, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oSender != null);

		// 값 제거가 불가능 할 경우
		if(a_oSender == null || !a_oSender.ExIsValid_Idx(a_nIdx))
		{
			return;
		}

		a_oSender.RemoveAt(a_nIdx);
	}

	/** 값을 탐색한다 */
	public static int ExFindVal<T>(this List<T> a_oSender, System.Predicate<T> a_oCompare)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_oCompare != null;

		Debug.Assert(bIsValid_Assert);
		return a_oSender.FindIndex(a_oCompare);
	}

	/** 값을 복사한다 */
	public static void ExCopyValues<TSrc, TDest>(this List<TSrc> a_oSender,
		List<TDest> a_oListDest, System.Func<TSrc, TDest> a_oCallback, bool a_bIsClear = true, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oSender != null;
		bIsValid_Assert = bIsValid_Assert && a_oListDest != null;
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
			a_oListDest.Clear();
		}

		for(int i = 0; i < a_oSender.Count; ++i)
		{
			a_oListDest.Add(a_oCallback(a_oSender[i]));
		}
	}
	#endregion // 클래스 함수
}
