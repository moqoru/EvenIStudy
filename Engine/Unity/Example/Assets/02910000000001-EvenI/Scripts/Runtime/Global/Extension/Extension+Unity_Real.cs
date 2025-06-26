using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 실수 (Float)
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 작음 여부를 검사한다 */
	public static bool ExIsLess(this float a_fSender, float a_fRhs)
	{
		return a_fSender < a_fRhs - float.Epsilon;
	}

	/** 작거나 같음 여부를 검사한다 */
	public static bool ExIsLessEquals(this float a_fSender, float a_fRhs)
	{
		return a_fSender.ExIsLess(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}

	/** 큼 여부를 검사한다 */
	public static bool ExIsGreat(this float a_fSender, float a_fRhs)
	{
		return a_fSender > a_fRhs + float.Epsilon;
	}

	/** 크거나 같음 여부를 검사한다 */
	public static bool ExIsGreatEquals(this float a_fSender, float a_fRhs)
	{
		return a_fSender.ExIsGreat(a_fRhs) || a_fSender.ExIsEquals(a_fRhs);
	}

	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this float a_fSender, float a_fRhs)
	{
		return Mathf.Approximately(a_fSender, a_fRhs);
	}
	#endregion // 클래스 함수
}

/**
 * 확장 클래스 - 실수 (Double)
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 작음 여부를 검사한다 */
	public static bool ExIsLess(this double a_dblSender, double a_dblRhs)
	{
		return a_dblSender < a_dblRhs - double.Epsilon;
	}

	/** 작거나 같음 여부를 검사한다 */
	public static bool ExIsLessEquals(this double a_dblSender, double a_dblRhs)
	{
		return a_dblSender.ExIsLess(a_dblRhs) || a_dblSender.ExIsEquals(a_dblRhs);
	}

	/** 큼 여부를 검사한다 */
	public static bool ExIsGreat(this double a_dblSender, double a_dblRhs)
	{
		return a_dblSender > a_dblRhs + double.Epsilon;
	}

	/** 크거나 같음 여부를 검사한다 */
	public static bool ExIsGreatEquals(this double a_dblSender, double a_dblRhs)
	{
		return a_dblSender.ExIsGreat(a_dblRhs) || a_dblSender.ExIsEquals(a_dblRhs);
	}

	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this double a_dblSender, double a_dblRhs)
	{
		return a_dblSender >= a_dblRhs - double.Epsilon &&
			a_dblSender <= a_dblRhs + double.Epsilon;
	}
	#endregion // 클래스 함수
}
