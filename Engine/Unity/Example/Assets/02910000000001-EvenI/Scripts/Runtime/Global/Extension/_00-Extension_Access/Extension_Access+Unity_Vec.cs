using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 확장 클래스 - 벡터
 */
public static partial class Extension_Access
{
	#region 클래스 접근 함수
	/** 비율 벡터를 반환한다 */
	public static Vector3 ExGetVec_Scale(this Vector2 a_stSender,
		Vector3 a_stScale, float a_fZ = 0.0f)
	{
		return a_stSender.ExTo3D(a_fZ).ExGetVec_Scale(a_stScale);
	}

	/** 비율 벡터를 반환한다 */
	public static Vector3 ExGetVec_Scale(this Vector3 a_stSender, Vector3 a_stScale)
	{
		return new Vector3(a_stSender.x * a_stScale.x,
			a_stSender.y * a_stScale.y, a_stSender.z * a_stScale.z);
	}
	#endregion // 클래스 접근 함수
}
