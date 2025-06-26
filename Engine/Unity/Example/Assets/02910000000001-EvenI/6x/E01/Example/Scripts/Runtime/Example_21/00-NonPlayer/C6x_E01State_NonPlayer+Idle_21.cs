using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 대기 상태
	 */
	public partial class C6x_E01State_NonPlayerIdle_21 : C6x_E01State_NonPlayer_21
	{
		#region 함수
		/** 상태를 갱신한다 */
		public override void OnState_Update(float a_fTime_Delta)
		{
			base.OnState_Update(a_fTime_Delta);

			// 전투가 가능 할 경우
			if(this.Owner.IsEnable_Battle())
			{
				this.Owner.Machine_State.SetState(this.Owner.CreateState_Battle());
			}
			else if(this.Owner.IsEnable_Tracking())
			{
				this.Owner.Machine_State.SetState(this.Owner.CreateState_Tracking());
			}
		}
		#endregion // 함수
	}
}
