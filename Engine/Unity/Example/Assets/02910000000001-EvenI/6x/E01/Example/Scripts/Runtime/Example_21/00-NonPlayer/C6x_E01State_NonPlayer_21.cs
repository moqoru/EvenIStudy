using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 상태
	 */
	public partial class C6x_E01State_NonPlayer_21
	{
		#region 상수
		public const string KEY_IS_BATTLE = "IsBattle";
		public const string KEY_IS_TRACKING = "IsTracking";

		public const string KEY_ATTACK = "Attack";
		public const string KEY_HIT = "Hit";
		public const string KEY_DEATH = "Death";
		#endregion // 상수

		#region 프로퍼티
		public C6x_E01NonPlayer_21 Owner { get; private set; } = null;
		#endregion // 프로퍼티

		#region 함수
		/** 상태가 시작되었을 경우 */
		public virtual void OnState_Enter()
		{
			this.Owner.Agent_NavMesh.isStopped = true;

			this.Owner.Animator.SetBool(C6x_E01State_NonPlayer_21.KEY_IS_BATTLE, false);
			this.Owner.Animator.SetBool(C6x_E01State_NonPlayer_21.KEY_IS_TRACKING, false);

			this.Owner.Animator.ResetTrigger(C6x_E01State_NonPlayer_21.KEY_ATTACK);
			this.Owner.Animator.ResetTrigger(C6x_E01State_NonPlayer_21.KEY_HIT);
			this.Owner.Animator.ResetTrigger(C6x_E01State_NonPlayer_21.KEY_DEATH);
		}

		/** 상태가 종료되었을 경우 */
		public virtual void OnState_Exit()
		{
			// Do Something
		}

		/** 상태를 갱신한다 */
		public virtual void OnState_Update(float a_fTime_Delta)
		{
			// Do Something
		}
		#endregion // 함수

		#region 접근 함수
		/** 소유자를 변경한다 */
		public void SetOwner(C6x_E01NonPlayer_21 a_oOwner)
		{
			this.Owner = a_oOwner;
		}
		#endregion // 접근 함수
	}
}
