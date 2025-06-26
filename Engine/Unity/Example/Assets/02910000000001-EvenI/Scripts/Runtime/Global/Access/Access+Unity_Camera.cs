using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 - 카메라
 */
public static partial class Access
{
	#region 클래스 접근 함수
	/** 투영 평면 거리를 반환한다 */
	public static float GetDistance_ProjectionPlane(float a_fHeight)
	{
		float fAngle = KDefine.G_ANGLE_FIELD_OF_VIEW / 2.0f;
		float fHeight = a_fHeight / 2.0f;

		return (fHeight / Mathf.Tan(fAngle * Mathf.Deg2Rad)) * KDefine.G_UNIT_SCALE;
	}
	#endregion // 클래스 접근 함수
}
