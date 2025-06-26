using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * OnCollision 계열 메서드란?
 * - 강체 컴포넌트 (Rigidbody) 와 충돌체 (Collider) 를 지니고 있는 게임 객체가 다른 충돌체와
 * 충돌했을 경우 호출되는 이벤트 메서드를 의미한다. (+ 즉, 해당 계열 메서드를 활용하면
 * 게임 객체 간에 충돌 여부를 간단하게 검사하는 것이 가능하다.)
 * 
 * OnCollision 계열 메서드 vs OnTrigger 계열 메서드
 * - OnCollision 계열 메서드는 충돌에 의한 물리 현상이 처리되는 특징이 있다. (+ 즉, 충돌한
 * 게임 객체들은 물리 엔진에 의해서 위치 및 회전 등에 변화가 발생한다는 것을 알 수 있다.)
 * 
 * 반면 OnTrigger 계열 메서드는 단순히 충돌만을 판정하기 때문에 물리 엔진에 의한 시뮬레이션이
 * 되지 않는 차이점이 존재한다.
 * 
 * 따라서 단순히 충돌만을 판정하는 것이 목적이라면 OnTrigger 계열 메서드를 사용하는 것이 좀 더
 * 성능 향상에 유리하다는 것을 알 수 있다. (+ 즉, OnCollision 계열 메서드는 물리 현상을 
 * 시뮬레이션하기 때문에 물리 엔진에 의해 성능 저하가 발생 할 수 있다는 것을 알 수 있다.)
 */

/**
 * 충돌 이벤트 전파자 - 2 차원
 */
public partial class CDispatcher_Collision : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Collision, Collision2D> _2DCallback_Enter { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision2D> _2DCallback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision2D> _2DCallback_Exit { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnCollisionEnter2D(Collision2D a_oCollision)
	{
		this._2DCallback_Enter?.Invoke(this, a_oCollision);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnCollisionStay2D(Collision2D a_oCollision)
	{
		this._2DCallback_Stay?.Invoke(this, a_oCollision);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnCollisionExit2D(Collision2D a_oCollision)
	{
		this._2DCallback_Exit?.Invoke(this, a_oCollision);
	}
	#endregion // 함수

	#region 접근 함수
	/** 충돌 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this._2DCallback_Enter = a_oCallback;
	}

	/** 충돌 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this._2DCallback_Stay = a_oCallback;
	}

	/** 충돌 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CDispatcher_Collision, Collision2D> a_oCallback)
	{
		this._2DCallback_Exit = a_oCallback;
	}
	#endregion // 접근 함수
}

/**
 * 충돌 이벤트 전파자
 */
public partial class CDispatcher_Collision : CComponent
{
	#region 프로퍼티
	public System.Action<CDispatcher_Collision, Collision> _3DCallback_Enter { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision> _3DCallback_Stay { get; private set; } = null;
	public System.Action<CDispatcher_Collision, Collision> _3DCallback_Exit { get; private set; } = null;
	#endregion // 프로퍼티

	#region 함수
	/** 충돌이 시작되었을 경우 */
	public void OnCollisionEnter(Collision a_oCollision)
	{
		this._3DCallback_Enter?.Invoke(this, a_oCollision);
	}

	/** 충돌이 진행 중 일 경우 */
	public void OnCollisionStay(Collision a_oCollision)
	{
		this._3DCallback_Stay?.Invoke(this, a_oCollision);
	}

	/** 충돌이 종료되었을 경우 */
	public void OnCollisionExit(Collision a_oCollision)
	{
		this._3DCallback_Exit?.Invoke(this, a_oCollision);
	}
	#endregion // 함수

	#region 접근 함수
	/** 충돌 시작 콜백을 변경한다 */
	public void SetCallback_Enter(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this._3DCallback_Enter = a_oCallback;
	}

	/** 충돌 진행 콜백을 변경한다 */
	public void SetCallback_Stay(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this._3DCallback_Stay = a_oCallback;
	}

	/** 충돌 종료 콜백을 변경한다 */
	public void SetCallback_Exit(System.Action<CDispatcher_Collision, Collision> a_oCallback)
	{
		this._3DCallback_Exit = a_oCallback;
	}
	#endregion // 접근 함수
}
