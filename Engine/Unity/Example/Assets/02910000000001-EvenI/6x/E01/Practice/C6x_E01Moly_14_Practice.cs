using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 두더지
	 */
	public partial class C6x_E01Moly_14_Practice : CComponent
	{
		/**
		 * 두더지 타입
		 */
		public enum EType_Moly
		{
			NONE = -1,
			A,
			D,
			A_RAPID,
			D_RAPID,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Moly - Etc <=====")]
		[SerializeField] private List<RuntimeAnimatorController> m_oListAControllers_Moly = new List<RuntimeAnimatorController>();

		private Animator m_oAnimator = null;
		private SpriteRenderer m_oSprite = null;
		#endregion // 변수

		#region 프로퍼티
		public bool IsOpen { get; private set; } = false;
		public EType_Moly Type_Moly { get; private set; } = EType_Moly.NONE;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			m_oAnimator = this.GetComponentInChildren<Animator>();
			m_oSprite = this.GetComponentInChildren<SpriteRenderer>();

			var oDispatcher_Event = this.GetComponentInChildren<CDispatcher_Event>();
			oDispatcher_Event.SetCallback_AnimEvent(this.HandleOnEvent_Anim);
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			this.HandleOnEvent_Anim(null, string.Empty);
		}

		/** 두더지를 잡는다 */
		public void Catch()
		{
			// 두더지 잡기가 불가능 할 경우
			if(!this.IsOpen)
			{
				return;
			}
			
			this.IsOpen = false;

			//m_oSprite.color = Color.white;

			m_oAnimator.SetTrigger("Catch");
			m_oAnimator.ResetTrigger("Open");
		}

		/** 애니메이션 이벤트를 처리한다 */
		private void HandleOnEvent_Anim(CDispatcher_Event a_oSender, string a_oParams)
		{
			this.IsOpen = false;

			m_oSprite.color = Color.white;

			StartCoroutine(this.CoTryOpen());
		}
		#endregion // 함수
	}

	/**
	 * 두더지 - 코루틴
	 */
	public partial class C6x_E01Moly_14_Practice : CComponent
	{
		#region 함수
		/** 두더지를 등장시킨다 */
		private IEnumerator CoTryOpen()
		{
			float fDelay = Random.Range(1.0f, 6.0f);
			yield return Access.CoGetWait_ForSecs(fDelay);

			this.Type_Moly = (EType_Moly)Random.Range((int)EType_Moly.A,
				(int)EType_Moly.MAX_VAL);

			// (Practice) 빠른 두더지라면 색깔 빨갛게 하기
			if(this.Type_Moly >= EType_Moly.A_RAPID)
			{
				m_oSprite.color = Color.red;
			}
			m_oAnimator.runtimeAnimatorController = m_oListAControllers_Moly[(int)this.Type_Moly];

			m_oAnimator.SetTrigger("Open");
			m_oAnimator.ResetTrigger("Catch");

			this.IsOpen = true;
		}
		#endregion // 함수
	}
}
