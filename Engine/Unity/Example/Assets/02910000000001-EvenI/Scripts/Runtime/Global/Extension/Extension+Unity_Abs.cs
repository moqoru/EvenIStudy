using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 유효 여부를 검사한다 */
	public static bool ExIsValid(this string a_oSender)
	{
		return !string.IsNullOrEmpty(a_oSender);
	}
	#endregion // 클래스 함수
}
