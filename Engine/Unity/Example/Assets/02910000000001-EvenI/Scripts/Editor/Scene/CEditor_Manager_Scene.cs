using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 에디터 스크립트란?
 * - 에디터 환경에서만 동작하는 스크립트를 의미한다. (+ 즉, 에디터 스크립트는 
 * 실제 실행 중인 런타임에는 동작하지 않는다는 것을 알 수 있다.)
 * 
 * Unity 는 에디터 스크립트를 제공하며 해당 스크립트를 활용하면 Unity 에디터를 통한 작업 환경을
 * Unity 가 지원하는 범위 내에서 마음대로 커스터마이징하는 것이 가능하다. (+ 즉, 
 * 에디터 스크립트를 활용하면 특정 프로젝트에 맞는 최적화 된 개발 환경을 구축하는 것이 가능하다.)
 * 
 * 단, 모든 스크립트게 에디터 스크립트가 될 수는 없으면 특정 스크립트가 에디터 스크립트가 되기
 * 위해서는 해당 스크립트가 반드시 Editor 폴더 하위에 존재해야한다. (+ 즉, Unity 는 
 * Editor 폴더를 포함하여 특별한 의미로 사용되는 몇몇 폴더가 존재한다는 것을 알 수 있다.)
 * 
 * 또한 에디터 스크립트는 에디터 환경에서만 동작하는 스크립트이기 때문에 반드시 UNITY_EDITOR
 * 심볼을 이용해서 확실하게 에디터 환경에서만 동작하는 스크립트라는 것을 명시해야한다. (+ 즉,
 * Unity 에디터 환경에서는 문제되지 않지만 빌드 시 에디터 스크립트에 의해서 에러가 발생한다는 것을
 * 알 수 있다.)
 */
#if UNITY_EDITOR
using UnityEditor;

/**
 * 에디터 씬 관리자
 */
[InitializeOnLoad]
public partial class CEditor_Manager_Scene
{
	#region 클래스 변수
	private static double m_dblTime_PrevUpdate = 0.0f;

	private static bool IsEnable_Update =>
		!EditorApplication.isPlaying && CEditor_Manager_Scene.Interval_Update.ExIsGreatEquals(1.0f);

	private static double Interval_Update =>
		EditorApplication.timeSinceStartup - m_dblTime_PrevUpdate;
	#endregion // 클래스 변수

	#region 클래스 함수
	/** 생성자 */
	static CEditor_Manager_Scene()
	{
		// 플레이 모드 일 경우
		if(EditorApplication.isPlaying)
		{
			return;
		}

		EditorApplication.update -= CEditor_Manager_Scene.Update;
		EditorApplication.update += CEditor_Manager_Scene.Update;

		EditorApplication.update -= CEditor_Manager_Scene.LateUpdate;
		EditorApplication.update += CEditor_Manager_Scene.LateUpdate;

		EditorApplication.playModeStateChanged -= CEditor_Manager_Scene.OnChangeState_PlayMode;
		EditorApplication.playModeStateChanged += CEditor_Manager_Scene.OnChangeState_PlayMode;

		CEditor_Manager_Scene.m_dblTime_PrevUpdate = EditorApplication.timeSinceStartup;
	}

	/** 상태를 갱신한다 */
	private static void Update()
	{
		// 상태 갱신이 불가능 할 경우
		if(!CEditor_Manager_Scene.IsEnable_Update)
		{
			return;
		}

		Func.EnumerateComponents<CManager_Scene>((a_oManager_Scene) =>
		{
			a_oManager_Scene.Editor_SetupScene();
			return true;
		});
	}

	/** 상태를 갱신한다 */
	private static void LateUpdate()
	{
		// 상태 갱신이 불가능 할 경우
		if(!CEditor_Manager_Scene.IsEnable_Update)
		{
			return;
		}

		m_dblTime_PrevUpdate = EditorApplication.timeSinceStartup;
	}

	/** 플레이 모드가 변경되었을 경우 */
	private static void OnChangeState_PlayMode(PlayModeStateChange a_eMode_Play)
	{
		switch(a_eMode_Play)
		{
			case PlayModeStateChange.EnteredEditMode:
				Access.SetTimeScale(1.0f);
				break;
		}
	}
	#endregion // 클래스 함수
}
#endif // #if UNITY_EDITOR
