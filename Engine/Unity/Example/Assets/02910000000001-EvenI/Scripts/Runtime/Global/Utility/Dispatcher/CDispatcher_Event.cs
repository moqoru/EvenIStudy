using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 이벤트 전파자
 */
public partial class CDispatcher_Event : CComponent
{
	#region 변수
	public System.Action<CDispatcher_Event> Callback_Particle { get; private set; } = null;
	public System.Action<CDispatcher_Event, string> Callback_Anim { get; private set; } = null;
	#endregion // 변수

	#region 함수
	/** 애니메이션 이벤트를 수신했을 경우 */
	public void OnReceiveEvent_Anim(string a_oParams)
	{
		this.Callback_Anim?.Invoke(this, a_oParams);
	}

	/** 파티클이 중지되었을 경우 */
	public void OnParticleSystemStopped()
	{
		this.Callback_Particle?.Invoke(this);
	}
	#endregion // 함수

	#region 접근 함수
	/** 애니메이션 이벤트 콜백을 변경한다 */
	public void SetCallback_AnimEvent(System.Action<CDispatcher_Event, string> a_oCallback)
	{
		this.Callback_Anim = a_oCallback;
	}

	/** 파티클 이벤트 콜백을 변경한다 */
	public void SetCallback_ParticleEvent(System.Action<CDispatcher_Event> a_oCallback)
	{
		this.Callback_Particle = a_oCallback;
	}
	#endregion // 접근 함수
}
