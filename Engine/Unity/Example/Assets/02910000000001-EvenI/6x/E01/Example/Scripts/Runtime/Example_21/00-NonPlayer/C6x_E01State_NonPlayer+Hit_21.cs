using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 피격 상태
	 */
	public partial class C6x_E01State_NonPlayerHit_21 : C6x_E01State_NonPlayer_21
	{
		#region 함수
		/** 상태가 시작되었을 경우 */
		public override void OnState_Enter()
		{
			base.OnState_Enter();
			this.Owner.Animator.SetTrigger(C6x_E01State_NonPlayer_21.KEY_HIT);

			var oBehaviour_StateMachine = this.Owner.Animator.GetBehaviour<C6x_E01SMBehaviour_NonPlayerHit_21>();
			oBehaviour_StateMachine.SetCallback_Exit(this.HandleOnCallback_HitStateExit);
		}

		/** 피격 상태 종료 콜백을 처리한다 */
		private void HandleOnCallback_HitStateExit(CBehaviour_StateMachine a_oSender,
			Animator a_oAnimator, AnimatorStateInfo a_stInfo_AnimatorState, int a_nIdx_Layer)
		{
			// 상태 변경이 불가능 할 경우
			if(this != this.Owner.Machine_State.State)
			{
				return;
			}

			this.Owner.Machine_State.SetState(this.Owner.CreateState_Idle());
		}
		#endregion // 함수
	}
}
