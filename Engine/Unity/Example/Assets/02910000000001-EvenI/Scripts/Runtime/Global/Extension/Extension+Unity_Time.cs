using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 시간
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 유효 여부를 검사한다 */
	public static bool ExIsValid(this System.DateTime a_stSender)
	{
		return a_stSender.Ticks >= 0;
	}

	/** 유효 여부를 검사한다 */
	public static bool ExIsValid(this System.TimeSpan a_stSender)
	{
		return a_stSender.Ticks >= 0;
	}
	#endregion // 클래스 함수
}
