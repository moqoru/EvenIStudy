using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 추격 상태
	 */
	public partial class C6x_E01State_NonPlayerTracking_21 : C6x_E01State_NonPlayer_21
	{
		#region 함수
		/** 상태가 시작되었을 경우 */
		public override void OnState_Enter()
		{
			base.OnState_Enter();
			this.Owner.Animator.SetBool(C6x_E01State_NonPlayer_21.KEY_IS_TRACKING, true);

			this.Owner.Agent_NavMesh.isStopped = false;
		}

		/** 상태를 갱신한다 */
		public override void OnState_Update(float a_fTime_Delta)
		{
			base.OnState_Update(a_fTime_Delta);
			this.Owner.Agent_NavMesh.SetDestination(this.Owner.Target.transform.position);

			// 추격이 불가능 할 경우
			if(!this.Owner.IsEnable_Tracking() || this.Owner.IsEnable_Battle())
			{
				this.Owner.Machine_State.SetState(this.Owner.CreateState_Idle());
			}
		}
		#endregion // 함수
	}
}
