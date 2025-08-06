// C6x_E01Bullet_06.cs 수정한 코드

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Practice
{
	/**
	 * 총알
	 */

	/** 총알 타입 구분용 */
	// public으로 설정해야 터렛 쪽에서 접근할 수 있다.
	public enum EBulletType
	{
		Normal, // 기본값 : 0
		Rapid, // 1
		Homing // 2
	}

	public partial class C6x_E01Bullet_06 : CComponent
	{
		#region 상수
		private const float RAPID_RATIO = 0.8f; // 빨라지는 총알의 가속 비율
		private const float HOMING_RANGE = 500.0f; // 유도 발동 범위
		private const float HOMING_LERP_RATIO = 0.2f; // 이상적인(?) 유도탄에서 어느 정도 비율만큼의 성능을 낼 것인가?
		#endregion // 상수

		#region 변수
		[Header("=====> Bullet - Etc <=====")]
		private Collider m_oCollider = null;
		#endregion // 변수

		#region 프로퍼티
		public Vector3 Velocity { get; private set; } = Vector3.zero;
		public EBulletType BulletType { get; private set; } = EBulletType.Normal;
		public float BulletTimer { get; private set; } = 0.0f; // 시간을 재주는 프로퍼티가 있어야 '시간이 지나면서' 빨라지는 기능을 구현할 수 있다.
		public GameObject Target { get; private set; } = null; // 유도 대상
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
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);
			this.BulletTimer += a_fTime_Delta;
			switch(BulletType)
			{
				case EBulletType.Rapid:
				{
					this.Velocity *= 1.0f + (RAPID_RATIO * a_fTime_Delta); // 지수 함수 형태로 속도가 빨라진다.
				}
				break;

				case EBulletType.Homing:
				{
					if(this.Target != null)
					{
						// 총알과 타겟 사이의 거리 측정
						float fDistance = Vector3.Distance(this.transform.localPosition,
							this.Target.transform.localPosition);

						// 거리 범위 이내라면
						if(fDistance < HOMING_RANGE)
						{
							// 속도를 타겟 쪽으로 조절하기
							// 피드백 : position이 아니라 localPosition이었다...!
							var stHomingDirection = this.Target.transform.localPosition -
								this.transform.localPosition;
							stHomingDirection.y = 0.0f;
							
							// 이상적인 속도를 먼저 계산하고...
							var vIdealVelocity = stHomingDirection.normalized *
								this.Velocity.magnitude;

							// Lerp = 선형 보간 기능, 부드럽게 따라가도록 함
							// 그 속도의 RATIO만큼만 보정해 준다.
							this.Velocity = Vector3.Lerp(this.Velocity, vIdealVelocity, HOMING_LERP_RATIO);

							// 문제점 : 총알 자체의 방향이 계속 조절되어야 하는데, 총알 자체의 '방향'의 정보를 추가해야 한다.
							// 즉, 벡터가 있어야 하는데 스칼라 값만 있는 상태...
						}
					}
					break;
				}
				case EBulletType.Normal:

				default:
					break;
			}
			this.transform.localPosition += this.Velocity * a_fTime_Delta;
		}

		/** 총알을 발사한다 */
		public void Shoot(GameObject a_oGameObj_Target, EBulletType eType = EBulletType.Normal)
		{
			var stDirection = a_oGameObj_Target.transform.position -
				this.transform.position;

			stDirection.y = 0.0f;

			this.Velocity = stDirection.normalized * Random.Range(450.0f, 750.0f);
			m_oCollider.enabled = true;

			this.BulletType = eType; // 매개변수를 통해 총알 종류를 받고 총알 종류를 설정해 준다.
			this.BulletTimer = 0.0f; // 총알 발사 타이머 리셋
			this.Target = a_oGameObj_Target; // 타겟 정보를 저장해 둔다. (OnUpdate에서 또 타겟 정보를 받아올 순 없으므로)
		}
		#endregion // 함수
	}
}
