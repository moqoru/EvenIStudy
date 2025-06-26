using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 확장 클래스 - 시간
 */
public static partial class Extension_Access
{
	#region 클래스 접근 함수
	/** 시간 간격을 반환한다 */
	public static double ExGetInterval(this System.DateTime a_stSender,
		System.DateTime a_stRhs)
	{
		Debug.Assert(a_stSender.ExIsValid() && a_stRhs.ExIsValid());
		return (a_stSender - a_stRhs).TotalSeconds;
	}

	/** 시간 간격을 반환한다 */
	public static double ExGetInterval_PerDays(this System.DateTime a_stSender,
		System.DateTime a_stRhs)
	{
		Debug.Assert(a_stSender.ExIsValid() && a_stRhs.ExIsValid());
		return (a_stSender - a_stRhs).TotalDays;
	}
	#endregion // 클래스 접근 함수
}
