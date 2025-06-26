using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 갱신 인터페이스
 */
public partial interface IUpdatable
{
	#region 함수
	/** 상태를 갱신한다 */
	void OnUpdate(float a_fTime_Delta);

	/** 상태를 갱신한다 */
	void OnUpdate_Late(float a_fTime_Delta);

	/** 상태를 갱신한다 */
	void OnUpdate_Fixed(float a_fTime_Delta);
	#endregion // 함수
}
