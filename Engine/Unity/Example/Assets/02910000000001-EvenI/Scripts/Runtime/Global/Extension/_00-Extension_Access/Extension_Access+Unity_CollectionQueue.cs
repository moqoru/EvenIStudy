using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 확장 클래스 - 컬렉션 (큐)
 */
public static partial class Extension_Acces
{
	#region 클래스 접근 함수
	/** 값을 반환한다 */
	public static T ExDequeueVal<T>(this Queue<T> a_oSender, T a_tVal_Def = default)
	{
		Debug.Assert(a_oSender != null);
		return a_oSender.TryDequeue(out T tVal) ? tVal : a_tVal_Def;
	}
	#endregion // 클래스 접근 함수
}
