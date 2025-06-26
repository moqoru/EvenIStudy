using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 접근자
 */
public static partial class Access
{
	#region 클래스 프로퍼티
	public static Vector3 Size_DeviceScreen
	{
		get
		{
#if UNITY_EDITOR
			return new Vector3(Camera.main.pixelWidth,
				Camera.main.pixelHeight, 0.0f);
#else
			return new Vector3(Screen.currentResolution.width, 
				Screen.currentResolution.height, 0.0f);
#endif // #if UNITY_EDITOR
		}
	}

	public static Rect SafeArea
	{
		get
		{
#if UNITY_EDITOR
			return Camera.main.pixelRect;
#else
			return Screen.safeArea;
#endif // #if UNITY_EDITOR
		}
	}
	#endregion // 클래스 프로퍼티

	#region 클래스 접근 함수
	/** 종횡비를 반환한다 */
	public static float GetAspect(Vector3 a_stSize)
	{
		return a_stSize.x / a_stSize.y;
	}

	/** 해상도 보정 비율을 반환한다 */
	public static float GetScale_ResolutionCorrect(Vector3 a_stSize_Design)
	{
		float fAspect = Access.GetAspect(a_stSize_Design);
		float fWidth_Aspect = Access.Size_DeviceScreen.y * fAspect;

		return fWidth_Aspect.ExIsLessEquals(Access.Size_DeviceScreen.x) ?
			1.0f : Access.Size_DeviceScreen.x / fWidth_Aspect;
	}

	/** 해상도 화면 크기를 반환한다 */
	public static Vector3 GetSize_ResolutionScreen(Vector3 a_stSize_Design)
	{
		float fScale_ResolutionCorrect = Access.GetScale_ResolutionCorrect(a_stSize_Design);
		return Access.Size_DeviceScreen * fScale_ResolutionCorrect;
	}
	#endregion // 클래스 접근 함수
}
