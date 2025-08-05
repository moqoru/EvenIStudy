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
	public partial class C6x_E01Bullet_06 : CComponent
	{
		#region 변수
		[Header("=====> Bullet - Etc <=====")]
		private Collider m_oCollider = null;
		#endregion // 변수

		#region 프로퍼티
		public Vector3 Velocity { get; private set; } = Vector3.zero;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * GetComponentInChildren 메서는 해당 메서드를 호출한 게임 객체를 포함해서
			 * 자식 게임 객체로부터 컴포넌트를 가져오는 역할을 수행한다. (+ 즉, 
			 * 메서드를 호출한 게임 객체에 컴포넌트가 없을 경우 계층 구조를 타고 아래로 내려가면서 
			 * 컴포넌트를 가져온다는 것을 알 수 있다.)
			 * 
			 * 자식 게임 객체로부터 컴포넌트를 가져오는 해당 메서드 이외에도 부모 게임 객체로부터
			 * 컴포넌트를 가져오는 GetComponentInParent 메서드도 존재하며 컴포넌트를 가져오는
			 * 규칙은 GetComponentInChildren 메서드와 동일하다. (+ 즉, 메서드를 호출한
			 * 게임 객체에 컴포넌트가 없을 경우 계층 구조를 타고 위로 올라가면서 컴포넌트를
			 * 가져온다는 것을 알 수 있다.)
			 */
			m_oCollider = this.GetComponentInChildren<Collider>();
			m_oCollider.enabled = false;

#if _6x_P01_PRACTICE_01
			this.Awake_Internal();
#endif // #if _6x_P01_PRACTICE_01
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);
			this.transform.localPosition += this.Velocity * a_fTime_Delta;

#if _6x_P01_PRACTICE_01
			this.OnUpdateState_Bullet(a_fTime_Delta);
#endif // #if _6x_P01_PRACTICE_01
		}

		/** 총알을 발사한다 */
		public void Shoot(GameObject a_oGameObj_Target)
		{
			var stDirection = a_oGameObj_Target.transform.position -
				this.transform.position;

			stDirection.y = 0.0f;

			this.Velocity = stDirection.normalized * Random.Range(450.0f, 750.0f);
			m_oCollider.enabled = true;
		}
		#endregion // 함수
	}

#if _6x_P01_PRACTICE_01
	/**
	 * 총알 - 과제
	 */
	public partial class C6x_E01Bullet_06 : CComponent
	{
		/**
		 * 총알 타입
		 */
		public enum EType_Bullet
		{
			NONE = -1,
			BLUE,
			YELLOW,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Bullet - Etc <======")]
		[SerializeField] private EType_Bullet m_eType_Bullet = EType_Bullet.NONE;

		[Header("=====> Bullet - Game Objects <======")]
		private GameObject m_oGameObj_Player = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		private void Awake_Internal()
		{
			var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_06>(KDefine.G_N_SCENE_EXAMPLE_06);
			m_oGameObj_Player = oManager_Scene.Player.gameObject;
		}

		/** 총알 상태를 갱신한다 */
		private void OnUpdateState_Bullet(float a_fTime_Delta)
		{
			switch(m_eType_Bullet)
			{
				case EType_Bullet.BLUE:
					this.OnUpdateState_BlueBullet(a_fTime_Delta);
					break;

				case EType_Bullet.YELLOW:
					this.OnUpdateState_YellowBullet(a_fTime_Delta);
					break;
			}
		}

		/** 총알 상태를 갱신한다 */
		private void OnUpdateState_BlueBullet(float a_fTime_Delta)
		{
			this.transform.localScale += (Vector3.one * 25.0f) * a_fTime_Delta;
		}

		/** 총알 상태를 갱신한다 */
		private void OnUpdateState_YellowBullet(float a_fTime_Delta)
		{
			var stDirection = m_oGameObj_Player.transform.localPosition -
				this.transform.localPosition;

			// 추적이 불가능 할 경우
			if(stDirection.magnitude.ExIsGreat(250.0f))
			{
				return;
			}

			float fAngle = Vector3.SignedAngle(this.Velocity.normalized,
				stDirection.normalized, Vector3.up) * 0.03f;

			this.Velocity = Quaternion.AngleAxis(fAngle, Vector3.up) * this.Velocity;
		}
		#endregion // 함수
	}
#endif // #if _6x_P01_PRACTICE_01
}
