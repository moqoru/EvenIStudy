using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 총알
	 */
	public partial class C6x_E01Bullet_21 : CComponent
	{
		#region 변수
		[Header("=====> Bullet - Etc <=====")]
		private Collider m_oCollider = null;
		private Rigidbody m_oRigidbody = null;

		private TrailRenderer m_oTrail = null;
		private C6x_E01Player_21 m_oOwner = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * TrailRenderer 는 게임 객체가 이동한 경로를 따라 메쉬를 생성하는 역할을 수행한다. 
			 * (+ 즉, 해당 컴포넌트를 활용하면 총알 발사에 의한 궤적을 그려내는 등의 결과를 
			 * 만들어내는 것이 가능하다.)
			 */
			m_oTrail = this.GetComponentInChildren<TrailRenderer>();

			m_oCollider = this.GetComponentInChildren<Collider>();
			m_oCollider.enabled = false;
			m_oCollider.isTrigger = true;

			m_oRigidbody = this.GetComponentInChildren<Rigidbody>();
			m_oRigidbody.useGravity = false;

			var oDispatcher_Trigger = this.GetComponent<CDispatcher_Trigger>();
			oDispatcher_Trigger.SetCallback_Enter(this.HandleOnTrigger_Enter);
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			m_oTrail.Clear();

			m_oCollider.enabled = true;
		}

		/** 총알을 발사한다 */
		public void Shoot(C6x_E01Player_21 a_oOwner, Vector3 a_stVelocity)
		{
			m_oOwner = a_oOwner;
			this.transform.forward = a_stVelocity.normalized;

			m_oRigidbody.linearVelocity = Vector3.zero;
			m_oRigidbody.AddForce(a_stVelocity, ForceMode.VelocityChange);
		}

		/** 충돌이 발생을 처리한다 */
		private void HandleOnTrigger_Enter(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			m_oOwner.HandleOnTrigger_Enter(this, a_oCollider);
			Destroy(this.gameObject);
		}
		#endregion // 함수
	}
}
