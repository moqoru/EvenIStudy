using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using DG.Tweening;

/**
 * 접근자 - 애니메이션
 */
public static partial class Access
{
	#region 클래스 접근 함수
	/** 값을 할당한다 */
	public static void AssignVal(ref Tween a_rLhs, Tween a_oRhs, Tween a_oVal_Def = null)
	{
		a_rLhs?.Kill();
		a_rLhs = a_oRhs ?? a_oVal_Def;
	}

	/** 값을 할당한다 */
	public static void AssignVal(ref Sequence a_rLhs, Tween a_oRhs, Tween a_oVal_Def = null)
	{
		a_rLhs?.Kill();
		a_rLhs = (a_oRhs ?? a_oVal_Def) as Sequence;
	}
	#endregion // 클래스 접근 함수
}
