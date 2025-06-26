using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 - 비동기
 */
public static partial class Access
{
	#region 클래스 접근 함수
	/** 대기 객체를 반환한다 */
	private static WaitForSeconds GetWait_ForSecs(float a_fDelay)
	{
		var oWait_ForSecs = Access.m_oDictWaits_ForSecs.ExGetVal(a_fDelay) ??
			new WaitForSeconds(a_fDelay);

		Access.m_oDictWaits_ForSecs.ExAddVal(a_fDelay, oWait_ForSecs);
		return oWait_ForSecs;
	}

	/** 대기 객체를 반환한다 */
	private static WaitForSecondsRealtime GetWait_ForSecsRealtime(float a_fDelay)
	{
		var oWait_ForSecsRealtime = Access.m_oDictWaits_ForSecsRealtime.ExGetVal(a_fDelay) ??
			new WaitForSecondsRealtime(a_fDelay);

		Access.m_oDictWaits_ForSecsRealtime.ExAddVal(a_fDelay, oWait_ForSecsRealtime);
		return oWait_ForSecsRealtime;
	}
	#endregion // 클래스 접근 함수
}

/**
 * 접근자 - 비동기 (코루틴)
 */
public static partial class Access
{
	/**
	 * 실수 비교자
	 */
	private class CComparer_Real : IEqualityComparer<float>
	{
		#region 함수
		/** 같음 여부를 검사한다 */
		public bool Equals(float a_fLhs, float a_fRhs)
		{
			return a_fLhs.ExIsEquals(a_fRhs);
		}
		#endregion // 함수

		#region 접근 함수
		/** 해시 코드를 반환한다 */
		public int GetHashCode(float a_fVal)
		{
			return a_fVal.GetHashCode();
		}
		#endregion // 접근 함수
	}

	#region 클래스 변수
	private static CComparer_Real m_oComparer_Real = new CComparer_Real();
	private static WaitForEndOfFrame m_oWait_ForEndOfFrame = new WaitForEndOfFrame();
	private static WaitForFixedUpdate m_oWait_ForFixedUpdate = new WaitForFixedUpdate();

	private static Dictionary<float, WaitForSeconds> m_oDictWaits_ForSecs = new Dictionary<float, WaitForSeconds>(Access.m_oComparer_Real);
	private static Dictionary<float, WaitForSecondsRealtime> m_oDictWaits_ForSecsRealtime = new Dictionary<float, WaitForSecondsRealtime>(Access.m_oComparer_Real);
	#endregion // 클래스 변수

	#region 클래스 함수
	/** 대기 객체를 리셋한다 */
	public static void ResetWaitForSecs()
	{
		Access.m_oDictWaits_ForSecs.Clear();
		Access.m_oDictWaits_ForSecsRealtime.Clear();
	}

	/** 대기 객체를 반환한다 */
	public static IEnumerator CoGetWait_ForSecs(float a_fTime_Delta,
		bool a_bIsRealtime = false)
	{
		Debug.Assert(a_fTime_Delta.ExIsGreatEquals(0.0f));

		yield return a_bIsRealtime ?
			Access.GetWait_ForSecsRealtime(a_fTime_Delta) : Access.GetWait_ForSecs(a_fTime_Delta);
	}

	/** 대기 객체를 반환한다 */
	public static IEnumerator CoGetWait_ForFixedUpdate()
	{
		yield return Access.m_oWait_ForFixedUpdate;
	}

	/** 대기 객체를 반환한다 */
	public static IEnumerator CoGetWait_ForEndOfFrame()
	{
		yield return Access.m_oWait_ForEndOfFrame;
	}
	#endregion // 클래스 함수
}
