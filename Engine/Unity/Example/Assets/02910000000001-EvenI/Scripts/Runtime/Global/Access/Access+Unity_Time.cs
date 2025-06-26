using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자 - 시간
 */
public static partial class Access
{
	#region 클래스 접근 함수
	/** 시간 비율을 변경한다 */
	public static void SetTimeScale(float a_fScale)
	{
		int nRate_PhysicsFrame = Mathf.FloorToInt(Application.targetFrameRate * 0.9f);

		Time.timeScale = Mathf.Clamp(a_fScale, 0.0f, 9.0f);
		Time.fixedDeltaTime = (1.0f / nRate_PhysicsFrame) / a_fScale;
	}
	#endregion // 클래스 접근 함수
}
