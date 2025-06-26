using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 확장 클래스 - 벡터
 */
public static partial class Extension
{
	#region 클래스 함수
	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this Vector2 a_stSender, Vector2 a_stRhs)
	{
		return a_stSender.ExTo3D().ExIsEquals(a_stRhs);
	}

	/** 같음 여부를 검사한다 */
	public static bool ExIsEquals(this Vector3 a_stSender, Vector3 a_stRhs)
	{
		return a_stSender.x.ExIsEquals(a_stRhs.x) &&
			a_stSender.y.ExIsEquals(a_stRhs.y) && a_stSender.z.ExIsEquals(a_stRhs.z);
	}

	/** 3 차원 => 2 차원으로 변환한다 */
	public static Vector2 ExTo2D(this Vector3 a_stSender)
	{
		return new Vector2(a_stSender.x, a_stSender.y);
	}

	/** 2 차원 => 3 차원으로 변환한다 */
	public static Vector3 ExTo3D(this Vector2 a_stSender, float a_fZ = 0.0f)
	{
		return new Vector3(a_stSender.x, a_stSender.y, a_fZ);
	}

	/** 월드 -> 로컬 공간으로 변환한다 */
	public static Vector3 ExToLocal(this Vector3 a_stSender,
		GameObject a_oParent, bool a_bIsCoord = true)
	{
		var stVec = new Vector4(a_stSender.x,
			a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);

		return a_oParent.transform.worldToLocalMatrix * stVec;
	}

	/** 로컬 -> 월드 공간으로 변환한다 */
	public static Vector3 ExToWorld(this Vector3 a_stSender,
		GameObject a_oParent, bool a_bIsCoord = true)
	{
		var stVec = new Vector4(a_stSender.x,
			a_stSender.y, a_stSender.z, a_bIsCoord ? 1.0f : 0.0f);

		return a_oParent.transform.localToWorldMatrix * stVec;
	}
	#endregion // 클래스 함수
}
