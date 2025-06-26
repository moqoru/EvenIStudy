using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.AI;

namespace _6x_E01Example
{
	/**
	 * NPC
	 */
	public partial class C6x_E01NonPlayer_21 : CComponent
	{
		#region 변수
		[Header("=====> Non Player - Etc <=====")]
		[SerializeField] private float m_fRange_Battle = 250.0f;
		[SerializeField] private float m_fRange_Tracking = 750.0f;

		private float m_fHp = 3.0f;
		private float m_fHp_Origin = 3.0f;

		[Header("=====> Non Player - UIs <=====")]
		[SerializeField] private Image m_oUIImg_HPGauge = null;
		#endregion // 변수

		#region 프로퍼티
		public Animator Animator { get; private set; } = null;
		public NavMeshAgent Agent_NavMesh { get; private set; } = null;

		public C6x_E01Machine_NonPlayerState_21 Machine_State { get; private set; } = new C6x_E01Machine_NonPlayerState_21();

		public C6x_E01Player_21 Target
		{
			get
			{
				var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_21>(KDefine.G_N_SCENE_EXAMPLE_21);
				return oManager_Scene.Player;
			}
		}

		public Image UIImg_HPGauge => m_oUIImg_HPGauge;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			this.Machine_State.SetOwner(this);

			this.Animator = this.GetComponentInChildren<Animator>();
			this.Animator.updateMode = AnimatorUpdateMode.Normal;

			this.Agent_NavMesh = this.GetComponentInChildren<NavMeshAgent>();

			/*
			 * isStopped 프로퍼티는 내비 메쉬 에이전트를 중지 시키는 역할을 수행한다. (+ 즉, 해당
			 * 프로퍼티를 활용하면 상황에 따라 내비 메쉬 에이전트의 활성 여부를 제어하는 것이
			 * 가능하다.)
			 * 
			 * 단, 내비 메쉬 에이전트가 중지 상태 일 때 
			 * 내비 메쉬 에이전트의 행동 (+ Ex. 목적지 설정 등등...) 과 같은 처리를 수행 할 경우 
			 * 내부적으로 에러가 발생하기 때문에 주의가 필요하다.
			 */
			this.Agent_NavMesh.isStopped = true;
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			this.Machine_State.SetState(this.CreateState_Idle());
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);
			this.Machine_State.OnState_Update(a_fTime_Delta);

			m_oUIImg_HPGauge.fillAmount = m_fHp / m_fHp_Origin;
		}

		/** 전투 가능 여부를 검사한다 */
		public bool IsEnable_Battle()
		{
			float fDistance = Vector3.Distance(this.transform.localPosition,
				this.Target.transform.localPosition);

			return this.IsEnable_Tracking() && fDistance.ExIsLessEquals(m_fRange_Battle);
		}

		/** 추격 가능 여부를 검사한다 */
		public bool IsEnable_Tracking()
		{
			float fDistance = Vector3.Distance(this.transform.localPosition,
				this.Target.transform.localPosition);

			return fDistance.ExIsLessEquals(m_fRange_Tracking);
		}

		/** 공격을 시도한다 */
		public void TryAttack()
		{
			// 공격이 불가능 할 경우
			if(!this.IsEnable_Battle())
			{
				return;
			}

			this.Target.TakeDamage(this, 1.0f);
		}

		/** 타겟을 주시한다 */
		public void LookTarget(bool a_bIsImmediate = false)
		{
			var stDirection_Forward = this.Target.transform.position - this.transform.position;
			stDirection_Forward.y = 0.0f;

			// 즉시 갱신 모드 일 경우
			if(a_bIsImmediate)
			{
				this.transform.forward = stDirection_Forward.normalized;
			}
			else
			{
				this.transform.forward = Vector3.Lerp(this.transform.forward,
					stDirection_Forward.normalized, Time.deltaTime * 5.0f);
			}
		}

		/** 대미지를 처리한다 */
		public void TakeDamage(C6x_E01Player_21 a_oAttacker, float a_fDamage)
		{
			m_fHp = Mathf.Clamp(m_fHp - a_fDamage, 0.0f, m_fHp_Origin);

			// 사망 상태 일 경우
			if(m_fHp.ExIsLessEquals(0.0f))
			{
				var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_21>(KDefine.G_N_SCENE_EXAMPLE_21);
				oManager_Scene.HandleOnEvent_DeathNonPlayer(this);

				this.Machine_State.SetState(this.CreateState_Death());
			}
			else
			{
				this.Machine_State.SetState(this.CreateState_Hit());
			}
		}
		#endregion // 함수

		#region 팩토리 함수
		/** 대기 상태를 생성한다 */
		public C6x_E01State_NonPlayer_21 CreateState_Idle()
		{
			return new C6x_E01State_NonPlayerIdle_21();
		}

		/** 추격 상태를 생성한다 */
		public C6x_E01State_NonPlayer_21 CreateState_Tracking()
		{
			return new C6x_E01State_NonPlayerTracking_21();
		}

		/** 전투 상태를 생성한다 */
		public C6x_E01State_NonPlayer_21 CreateState_Battle()
		{
			return new C6x_E01State_NonPlayerBattle_21();
		}

		/** 피격 상태를 생성한다 */
		public C6x_E01State_NonPlayer_21 CreateState_Hit()
		{
			return new C6x_E01State_NonPlayerHit_21();
		}

		/** 사망 상태를 생성한다 */
		public C6x_E01State_NonPlayer_21 CreateState_Death()
		{
			return new C6x_E01State_NonPlayerDeath_21();
		}
		#endregion // 팩토리 함수
	}
}
