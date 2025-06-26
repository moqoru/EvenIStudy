using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#region 타입 - 열거형
/**
 * 마우스 버튼
 */
public enum EBtn_Mouse
{
	NONE = -1,
	LEFT,
	RIGHT,
	MIDDLE,
	MAX_VAL
}

/**
 * 투영 타입
 */
public enum EType_Projection
{
	NONE = -1,
	_2D,
	_3D,
	MAX_VAL
}

/**
 * 내비게이션 스택 이벤트
 */
public enum EEvent_NavStack
{
	NONE = -1,
	TOP,
	REMOVE,
	BACK_KEY_DOWN,
	[HideInInspector] MAX_VAL
}
#endregion // 타입 - 열거형
