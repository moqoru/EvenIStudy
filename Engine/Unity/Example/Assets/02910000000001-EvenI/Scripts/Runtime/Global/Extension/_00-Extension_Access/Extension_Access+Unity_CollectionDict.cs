using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 확장 클래스 - 컬렉션 (딕셔너리)
 */
public static partial class Extension_Access
{
	#region 제네릭 클래스 접근 함수
	/** 값을 반환한다 */
	public static V ExGetVal<K, V>(this Dictionary<K, V> a_oSender,
		K a_tKey, V a_tVal_Def = default)
	{
		Debug.Assert(a_oSender != null);
		return a_oSender.TryGetValue(a_tKey, out V tVal) ? tVal : a_tVal_Def;
	}
	#endregion // 제네릭 클래스 접근 함수
}
