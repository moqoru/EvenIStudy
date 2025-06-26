using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * StateMachineBehaviour 클라스란?
 * - 애니메이터에 추가 된 애니메이션의 상태를 검사 할 수 있는 클래스를 의미한다. (+ 즉,
 * 해당 클래스를 활용하면 특정 애니메이션의 시작 및 종료 등을 검사해서 처리하기 위한 명령문을
 * 작성하는 것이 가능하다.)
 */

/**
 * 상태 머신 처리자
 */
public abstract partial class CBehaviour_StateMachine : StateMachineBehaviour
{
	#region 프로퍼티
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Enter { get; private set; } = null;
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Exit { get; private set; } = null;
	public System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> Callback_Update { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 상태가 시작되었을 경우 */
	public override void OnStateEnter(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateEnter(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Enter?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}

	/** 상태가 종료되었을 경우 */
	public override void OnStateExit(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateExit(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Exit?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}

	/** 상태를 갱신한다 */
	public override void OnStateUpdate(Animator a_oSender,
		AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
	{
		base.OnStateUpdate(a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
		this.Callback_Update?.Invoke(this, a_oSender, a_stInfo_AnimatorState, a_nIdx_Layer);
	}
	#endregion // 함수

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Enter = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Exit = a_oCallback;
	}

	/** 갱신 콜백을 변경한다 */
	public void SetCallback_Update(System.Action<CBehaviour_StateMachine, Animator, AnimatorStateInfo, int> a_oCallback)
	{
		this.Callback_Update = a_oCallback;
	}
	#endregion // 접근 함수
}
