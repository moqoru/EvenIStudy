using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

/**
 * 함수
 */
public static partial class Func
{
	#region 클래스 함수
	/** 씬을 순회한다 */
	public static void EnumerateScenes(System.Func<Scene, bool> a_oCallback,
		bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oCallback != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 씬 순회가 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		for(int i = 0; i < SceneManager.sceneCount; ++i)
		{
			// 씬 순회가 불가능 할 경우
			if(!a_oCallback(SceneManager.GetSceneAt(i)))
			{
				break;
			}
		}
	}
	#endregion // 클래스 함수
}
