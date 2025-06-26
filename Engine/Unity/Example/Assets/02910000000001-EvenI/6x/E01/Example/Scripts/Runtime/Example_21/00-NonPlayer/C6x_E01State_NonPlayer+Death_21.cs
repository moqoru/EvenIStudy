using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * NPC 죽음 상태
	 */
	public partial class C6x_E01State_NonPlayerDeath_21 : C6x_E01State_NonPlayer_21
	{
		#region 함수
		/** 상태가 시작되었을 경우 */
		public override void OnState_Enter()
		{
			base.OnState_Enter();
			this.Owner.Animator.SetTrigger(C6x_E01State_NonPlayer_21.KEY_DEATH);

			var oUICanvas = this.Owner.UIImg_HPGauge.GetComponentInParent<Canvas>();
			oUICanvas.gameObject.SetActive(false);

			var oCollider = this.Owner.GetComponent<Collider>();
			oCollider.enabled = false;
		}
		#endregion // 함수
	}
}
