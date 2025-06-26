using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 상태 머신
	 */
	public partial class C6x_E01Machine_NonPlayerState_21
	{
		#region 프로퍼티
		public C6x_E01NonPlayer_21 Owner { get; private set; } = null;
		public C6x_E01State_NonPlayer_21 State { get; private set; } = null;
		#endregion // 프로퍼티

		#region 함수
		/** 상태가 시작되었을 경우 */
		public virtual void OnState_Enter()
		{
			this.State?.OnState_Enter();
		}

		/** 상태가 종료되었을 경우 */
		public virtual void OnState_Exit()
		{
			this.State?.OnState_Exit();
		}

		/** 상태를 갱신한다 */
		public virtual void OnState_Update(float a_fTime_Delta)
		{
			this.State?.OnState_Update(a_fTime_Delta);
		}
		#endregion // 함수

		#region 접근 함수
		/** 소유자를 변경한다 */
		public void SetOwner(C6x_E01NonPlayer_21 a_oOwner)
		{
			this.Owner = a_oOwner;
		}

		/** 상태를 변경한다 */
		public void SetState(C6x_E01State_NonPlayer_21 a_oState)
		{
			var oState_Prev = this.State;
			oState_Prev?.OnState_Exit();

			this.State = a_oState;
			this.State?.SetOwner(this.Owner);
			this.State?.OnState_Enter();
		}
		#endregion // 접근 함수
	}
}
