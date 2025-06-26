using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 전투 상태
	 */
	public partial class C6x_E01State_NonPlayerBattle_21 : C6x_E01State_NonPlayer_21
	{
		#region 변수
		[Header("=====> Non Player Battle State - Etc <=====")]
		private bool m_bIsAttacking = false;
		private float m_fTime_Skip = 0.0f;
		#endregion // 변수

		#region 함수
		/** 상태가 시작되었을 경우 */
		public override void OnState_Enter()
		{
			base.OnState_Enter();
			this.Owner.Animator.SetBool(C6x_E01State_NonPlayer_21.KEY_IS_BATTLE, true);
		}

		/** 상태를 갱신한다 */
		public override void OnState_Update(float a_fTime_Delta)
		{
			base.OnState_Update(a_fTime_Delta);
			this.Owner.LookTarget();

			// 전투가 불가능 할 경우
			if(!m_bIsAttacking && !this.Owner.IsEnable_Battle())
			{
				this.Owner.Machine_State.SetState(this.Owner.CreateState_Idle());
				return;
			}

			m_fTime_Skip += a_fTime_Delta;

			// 공격이 불가능 할 경우
			if(m_bIsAttacking || m_fTime_Skip.ExIsLess(1.5f))
			{
				return;
			}

			m_bIsAttacking = true;
			this.Owner.Animator.SetTrigger(C6x_E01State_NonPlayer_21.KEY_ATTACK);

			var oBehaviour_StateMachine = this.Owner.Animator.GetBehaviour<C6x_E01SMBehaviour_NonPlayerBattle_21>();
			oBehaviour_StateMachine.SetCallback_Exit(this.HandleOnCallback_BattleStateExit);
		}

		/** 전투 상태 종료 콜백을 처리한다 */
		private void HandleOnCallback_BattleStateExit(CBehaviour_StateMachine a_oSender,
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
