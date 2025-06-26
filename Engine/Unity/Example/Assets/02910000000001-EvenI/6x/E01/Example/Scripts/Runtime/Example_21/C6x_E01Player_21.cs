using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 플레이어
	 */
	public partial class C6x_E01Player_21 : CComponent
	{
		#region 변수
		[Header("=====> Player - Etc <=====")]
		[SerializeField] private float m_fSpeed = 500.0f;
		[SerializeField] private float m_fSpeed_Shoot = 75.0f;
		[SerializeField] private float m_fSpeed_Rotate = 180.0f;

		private Animation m_oAnim = null;

		[Header("=====> Player - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Bullet = null;
		[SerializeField] private GameObject m_oGameObj_BulletSpawnPos = null;
		#endregion // 변수

		#region 프로퍼티
		public float Hp { get; private set; } = 10.0f;
		public float Hp_Origin { get; private set; } = 10.0f;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			m_oAnim = this.GetComponent<Animation>();
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			// 스페이스 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				var oBullet = Factory.CreateGameObj_Clone<C6x_E01Bullet_21>("Bullet",
					m_oPrefab_Bullet, this.transform.parent.gameObject);

				oBullet.transform.position = m_oGameObj_BulletSpawnPos.transform.position;
				oBullet.Shoot(this, this.transform.forward * m_fSpeed_Shoot);
			}
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate_Fixed(float a_fTime_Delta)
		{
			base.OnUpdate_Fixed(a_fTime_Delta);

			float fVertical = Input.GetAxisRaw("Vertical");
			float fHorizontal = Input.GetAxisRaw("Horizontal");

			var stDirection = (this.transform.forward * fVertical) +
				(this.transform.right * fHorizontal);

			// 보정이 필요 할 경우
			if(stDirection.magnitude.ExIsGreat(1.0f))
			{
				stDirection = stDirection.normalized;
			}

			this.transform.localPosition += (stDirection * m_fSpeed) * a_fTime_Delta;

			// 앞 / 뒤로 이동했을 경우
			if(!fVertical.ExIsEquals(0.0f))
			{
				m_oAnim.CrossFade(fVertical.ExIsGreat(0.0f) ? "RunF" : "RunB");
			}
			// 좌 / 우로 이동했을 경우
			else if(!fHorizontal.ExIsEquals(0.0f))
			{
				m_oAnim.CrossFade(fHorizontal.ExIsGreat(0.0f) ? "RunR" : "RunL");
			}
			else
			{
				m_oAnim.CrossFade("Idle");
			}

			// 회전이 가능 할 경우
			if(Input.GetMouseButton((int)EBtn_Mouse.RIGHT))
			{
				this.transform.Rotate(Vector3.up,
					Input.GetAxisRaw("Mouse X") * m_fSpeed_Rotate * a_fTime_Delta, Space.World);
			}
		}

		/** 대미지를 처리한다 */
		public void TakeDamage(C6x_E01NonPlayer_21 a_oAttacker, float a_fDamage)
		{
			this.Hp = Mathf.Clamp(this.Hp - a_fDamage, 0.0f, this.Hp_Origin);

			// 생존 상태 일 경우
			if(this.Hp.ExIsGreat(0.0f))
			{
				return;
			}

			var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_21>(KDefine.G_N_SCENE_EXAMPLE_21);
			oManager_Scene.HandleOnEvent_DeathPlayer(this);
		}

		/** 충돌이 발생을 처리한다 */
		public void HandleOnTrigger_Enter(C6x_E01Bullet_21 a_oSender, Collider a_oCollider)
		{
			var oNonPlayer = a_oCollider.GetComponent<C6x_E01NonPlayer_21>();

			// 충돌 처리가 불가능 할 경우
			if(oNonPlayer == null)
			{
				return;
			}

			oNonPlayer.TakeDamage(this, 1.0f);
		}
		#endregion // 함수
	}
}
