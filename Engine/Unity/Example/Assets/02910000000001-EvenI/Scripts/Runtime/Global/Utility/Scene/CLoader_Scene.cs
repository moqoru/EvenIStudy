using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.SceneManagement;

/**
 * 씬 로더
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 함수
	/** 씬을 로드한다 */
	public void LoadScene(string a_oName_Scene, bool a_bIsSingle = true)
	{
		SceneManager.LoadScene(a_oName_Scene,
			a_bIsSingle ? LoadSceneMode.Single : LoadSceneMode.Additive);
	}

	/** 씬을 로드한다 */
	public void LoadScene_Async(string a_oName_Scene,
		System.Action<CLoader_Scene, AsyncOperation, bool> a_oCallback, float a_fDelay = 0.0f, bool a_bIsSingle = true)
	{
		var oEnumerator = this.CoLoadScene_Async_Internal(a_oName_Scene,
			a_oCallback, a_fDelay, a_bIsSingle);

		StartCoroutine(oEnumerator);
	}
	#endregion // 함수
}

/**
 * 씬 로더 - 코루틴
 */
public partial class CLoader_Scene : CSingleton<CLoader_Scene>
{
	#region 코루틴 함수
	/** 씬을 로드한다 */
	private IEnumerator CoLoadScene_Async_Internal(string a_oName_Scene,
		System.Action<CLoader_Scene, AsyncOperation, bool> a_oCallback, float a_fDelay, bool a_bIsSingle)
	{
		yield return Access.CoGetWait_ForSecs(a_fDelay, true);

		/*
		 * LoadSceneAsync 메서드란?
		 * - 씬을 비동기로 로드하는 역할을 수행하는 메서드이다. (+ 즉, 해당 메서드를 활용하면 
		 * 규모가 큰 씬을 비동기로 로드함으로서 플레이 경험을 좀 더 쾌적하게 만드는 것이 가능하다.)
		 * 
		 * 해당 메서드는 AsyncOperation 객체를 반환하며 해당 객체를 활용하면 씬의 로드 완료 여부를
		 * 검사하는 것이 가능하다. (+ 즉, 해당 객체를 활용하면 비동기 씬의 로딩 상태를 화면 상에
		 * 출력하기 위한 여러 정보를 가져오는 것이 가능하다.)
		 */
		var oOperation_Async = SceneManager.LoadSceneAsync(a_oName_Scene,
			a_bIsSingle ? LoadSceneMode.Single : LoadSceneMode.Additive);

		CManager_Task.Inst.CoWaitOperation_Async(oOperation_Async,
			(a_oOperation_Async, a_bIsComplete) =>
		{
			a_oCallback?.Invoke(this, a_oOperation_Async, a_bIsComplete);
		});
	}
	#endregion // 코루틴 함수
}
