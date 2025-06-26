using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 스케줄 관리자
 */
public partial class CManager_Schedule : CSingleton<CManager_Schedule>
{
	#region 변수
	public CWrapper_List<STInfo_Callback> m_oListWrapperInfos_Callback = new CWrapper_List<STInfo_Callback>();
	public CWrapper_List<STInfo_Component> m_oListWrapperInfos_Component = new CWrapper_List<STInfo_Component>();
	#endregion // 변수

	#region 프로퍼티
	public float Time_Delta { get; private set; } = 0.0f;
	public float Time_UnscaledDelta { get; private set; } = 0.0f;

	public float Time_FixedDelta { get; private set; } = 0.0f;
	public float Time_FixedUnscaledDelta { get; private set; } = 0.0f;
	#endregion // 프로퍼티

	#region 함수
	/** 상태를 리셋한다 */
	public override void Reset()
	{
		base.Reset();
	}

	/** 상태를 갱신한다 */
	public virtual void Update()
	{
		this.Time_Delta = Time.deltaTime;
		this.Time_UnscaledDelta = Time.unscaledDeltaTime;

		for(int i = 0; i < m_oListWrapperInfos_Component.m_oListA.Count; ++i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListA[i].m_oComponent as CComponent;

			// 상태 갱신이 불가능 할 경우
			if(!oComponent.IsEnable)
			{
				continue;
			}

			oComponent.OnUpdate(this.Time_Delta);
		}
	}

	/** 상태를 갱신한다 */
	public virtual void LateUpdate()
	{
		for(int i = 0; i < m_oListWrapperInfos_Component.m_oListA.Count; ++i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListA[i].m_oComponent as CComponent;

			// 제거 상태 일 경우
			if(oComponent.IsDestroy)
			{
				this.RemoveComonent(oComponent);
			}
			// 상태 갱신이 가능 할 경우
			else if(oComponent.IsEnable)
			{
				oComponent.OnUpdate_Late(this.Time_Delta);
			}
		}

		this.UpdateState_ComponentInfos();
	}

	/** 상태를 갱신한다 */
	public virtual void FixedUpdate()
	{
		this.Time_FixedDelta = Time.fixedDeltaTime;
		this.Time_FixedUnscaledDelta = Time.fixedUnscaledTime;

		for(int i = 0; i < m_oListWrapperInfos_Component.m_oListA.Count; ++i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListA[i].m_oComponent as CComponent;

			// 상태 갱신이 불가능 할 경우
			if(!oComponent.IsEnable)
			{
				continue;
			}

			oComponent.OnUpdate_Fixed(this.Time_FixedDelta);
		}
	}

	/** 스케줄 콜백을 처리한다 */
	private void HandleOnCallback_Schedule(CComponent a_oSender)
	{
		this.RemoveComonent(a_oSender);
	}
	#endregion // 함수
}
