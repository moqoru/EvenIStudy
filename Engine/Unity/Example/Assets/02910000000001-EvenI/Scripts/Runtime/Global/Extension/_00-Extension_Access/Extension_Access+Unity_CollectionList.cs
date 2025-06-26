using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 확장 클래스 - 컬렉션 (리스트)
 */
public static partial class Extension_Access
{
	#region 제네릭 클래스 접근 함수
	/** 값을 반환한다 */
	public static T ExGetVal<T>(this List<T> a_oSender,
		int a_nIdx, T a_tVal_Def = default)
	{
		Debug.Assert(a_oSender != null);
		return a_oSender.ExIsValid_Idx(a_nIdx) ? a_oSender[a_nIdx] : a_tVal_Def;
	}
	#endregion // 제네릭 클래스 접근 함수
}
