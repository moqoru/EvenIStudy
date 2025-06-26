using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 스프라이트 (Sprite) 란?
 * - 3 차원 공간 상에 출력되는 2 차원 이미지를 의미한다. (+ 즉, 스프라이트를 활용하면
 * 간단하게 2 차원 이미지를 화면 상에 출력하는 것이 가능하다.)
 * 
 * Unity 는 2 차원 프로그램을 제작하기 위한 기능을 지원하기 때문에 2 차원과 관련 된 많은 컴포넌트와
 * 툴이 존재하며 이 중 2 차원 이미지를 화면 상에 출력하는 것은 
 * 스프라이트 렌더러 (Sprite Renderer) 컴포넌트를 활용하면 된다. (+ 즉, 
 * 스프라이트 렌더러를 활용하면 손쉽게 2 차원 이미지를 화면 상에 출력하는 것이 가능하다.)
 * 
 * 단, 스프라이트 렌더러를 통해 이미지를 출력하기 위해서는 스프라이트라고 불리는 이미지에 대한
 * 정보가 필요하며 해당 정보는 이미지의 타입을 스프라이트로 변경해줌으로서 생성하는 것이 가능하다.
 * (+ 즉, 이미지를 스프라이트 타입으로 변경하면 Unity 가 자동으로 스프라이트를 생성해준다는 것을 
 * 알 수 있다.)
 * 
 * 텍스처 아틀라스 (Texture Atlas) 란?
 * - 여러 텍스처를 하나의 텍스처에 합쳐놓은 것을 의미한다. (+ 즉, 텍스처 아틀라스를 활용하면 캐시
 * 적중률이 상승한다는 것을 알 수 있다.)
 * 
 * Unity 로 제작 된 프로그램을 최적화하는 방법 중 하나는 드로우 콜 (Draw Call) 을 낮추는 것이며
 * 텍스처 아틀라스는 드로우 콜을 낮추는 가장 대표적인 방법이다. (+ 즉, 텍스처 아틀라스를 통해 여러
 * 이미지를 그래픽 카드에 한번에 전달함으로서 CPU 와 GPU 간에 발생하는 데이터 전달을 효율적으로
 * 처리하는 것이 가능하다.)
 * 
 * Unity 는 스프라이트 아틀라스 (Sprite Atlas) 라는 이름으로 텍스처 아틀라스를 지원하며 해당
 * 기능을 활용하면 간단하게 스프라이트 타입의 텍스처를 합치는 것이 가능하다. (+ 즉, 
 * 스프라이트 타입이 아닌 텍스처는 별도의 툴을 활용해서 합쳐야한다는 것을 알 수 있다.)
 * 
 * Unity 애니메이션 관련 컴포넌트 종류
 * - 애니메이터 (Animator)
 * - 애니메이션 (Animation)
 * 
 * 애니메이터 (Animator) 란?
 * - FSM (Finite State Machine) 을 기반으로 애니메이션을 관리 할 수 있는 기능을 의미하며 Unity 는
 * 이를 메카님 시스템 (Mecanim System) 이라고 부른다. (+ 즉, 메카님 시스템을 활용하면 게임 객체의
 * 상태를 기반으로 다양한 애니메이션을 제어하는 것이 가능하다.)
 * 
 * 애니메이터는 애니메이션을 관리하는 기능이기 때문에 여러 애니메이션을 포함하는 것이 가능하며 각
 * 애니메이션은 매개 변수에 의한 조건을 만족시킴으로서 전환 (Transition) 이 가능하다. (+ 즉,
 * 애니메이터는 각 애니메이션들의 관계를 정립하고 전환 조건을 부여함으로서 애니메이션을
 * 제어 및 재생이 가능하다는 것을 알 수 있다.)
 * 
 * Unity 애니메이터 매개 변수 종류
 * - 논리 (Bool)
 * - 정수 (Integer)
 * - 실수 (Float)
 * - 트리거 (Trigger)
 * 
 * 위와 같이 애니메이터 매개 변수에는 여러 종류가 존재하기 때문에 애니메이션 전환을 위한 적절한
 * 조건을 설정하는 것이 중요하다는 것을 알 수 있다. (+ 즉, 잘못된 조건을 설정 할 경우 
 * 애니메이션 간에 전환이 발생하지 않는다는 것을 의미한다.)
 * 
 * 논리 (bool) 매개 변수 vs 트리거 (Trigger) 매개 변수
 * - 두 매개 변수 모두 참 or 거짓을 나타내는 매개 변수이다.
 * 
 * 논리 매개 변수는 영구적으로 참 or 거짓을 표현 할 수 있는 반면 트리거 매개 변수는 일회성이라는
 * 차이점이 존재한다. (+ 즉, 논리 매개 변수는 조건을 만족해서 애니메이션이 전환 되어도 계속 상태를
 * 유지하는 반면 트리거 매개 변수는 애니메이션이 전환되면 리셋된다.)
 * 
 * 따라서 논리 매개 변수는 게임 객체의 상태를 표현하는데 주로 활용되며 트리커 매개 변수는 일회성
 * 이벤트를 표현하는데 주로 활용된다.
 * 
 * 애니메이션 (Animation) 이란?
 * - 물체의 상태를 지속적으로 변화시킬 수 있는 기능을 의미한다. (+ 즉, 애니메이션을 활용하면 물체에
 * 생동감을 부여하는 것이 가능하다.)
 * 
 * Unity 는 키 프레임 (Keyframe) 기반의 애니메이션 제작 방식을 지원하며 해당 방식으로 제작 된
 * 애니메이션은 장면 연출 등 다양한 곳에서 활용하는 것이 가능하다.
 * 
 * 키 프레임 (Keyframe) 이란?
 * - 물체의 여러 상태 (위치, 회전 등등...) 를 지니고 있는 데이터를 의미한다. (+ 즉, 키 프레임은
 * 단순히 데이터의 집합이라는 것을 알 수 있다.)
 * 
 * 따라서 여러 키 프레임에 가중치를 두어 시간의 흐름에 따라 보간함으로서 결과를 연출하는 방식을
 * 키 프레임 애니메이션이라고 한다. (+ 즉, 키 프레임 애니메이션은 키 프레임과 시간에 따른 보간이 
 * 핵심이라는 것을 알 수 있다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 12
	 */
	public partial class C6x_E01Example_12 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 12 - Etc <=====")]
		[SerializeField] private SpriteRenderer m_oSprite_Target = null;

		private Animator m_oAnimator_Target = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			m_oAnimator_Target = m_oSprite_Target.GetComponentInChildren<Animator>();

			/*
			 * updateMode 프로퍼티는 애니메이터 갱신에 사용되는 시간 간격 (Delta Time) 을 
			 * 제어하는 역할을 수행한다. (+ 즉, 해당 프로퍼티를 활용하면 Time Scale 에 상관없이 
			 * 갱신되는 애니메이터를 설정하는 것이 가능하다.)
			 */
			m_oAnimator_Target.updateMode = AnimatorUpdateMode.Normal;

			var oDispatcher_Event = m_oSprite_Target.GetComponentInChildren<CDispatcher_Event>();
			oDispatcher_Event.SetCallback_AnimEvent(this.HandleOnEvent_Anim);

			var oDispatcher_Trigger = m_oSprite_Target.GetComponentInChildren<CDispatcher_Trigger>();
			oDispatcher_Trigger.SetCallback_Enter(this.HandleOnTrigger_Stay);
			oDispatcher_Trigger.SetCallback_Exit(this.HandleOnTrigger_Exit);
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			float fHorizontal = Input.GetAxis(KDefine.G_N_AXIS_HORIZONTAL);
			var stDirection = Vector3.right * fHorizontal;

			/*
			 * Set 계열 메서드를 활용하면 특정 매개 변수에 값을 설정하는 것이 가능하다. (+ 즉, 
			 * 애니메이터 컴포넌트는 현재 매개 변수에 설정 된 데이터를 가져오거나 변경 할 수 있는 
			 * 접근자 메서드를 지원한다는 것을 알 수 있다.)
			 */
			m_oAnimator_Target.SetBool("IsRun",
				!stDirection.ExIsEquals(Vector3.zero));

			// 상태 갱신이 불가능 할 경우
			if(stDirection.ExIsEquals(Vector3.zero))
			{
				return;
			}

			/*
			 * Flip 계열 프로퍼티를 활용하면 스프라이트를 상/하 or 좌/우 로 반전 시키는 것이 
			 * 가능하다. (+ 즉, 해당 계열 프로퍼티를 활용하면 제작해야 될 리소스의 양을 
			 * 줄일 수 있다는 것을 알 수 있다.)
			 */
			m_oSprite_Target.flipX = fHorizontal.ExIsLess(0.0f);

			m_oSprite_Target.transform.localPosition += stDirection *
				350.0f * a_fTime_Delta;
		}

		/** 애니메이션 이벤트를 처리한다 */
		private void HandleOnEvent_Anim(CDispatcher_Event a_oSender, string a_oParams)
		{
			Func.ShowLog("C6x_E01Example_12.HandleOnEvent_Anim : {0}", a_oParams);
		}

		/** 충돌 진행을 처리한다 */
		private void HandleOnTrigger_Stay(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			/*
			 * Color 프로퍼티를 활용하면 스프라이트 색상의 반사 정도를 제어하는 것이 가능하다.
			 * (+ 즉, 해당 프로퍼티를 활용하면 이미지에 존재하는 색상 중에 필요한 색상 성분만
			 * 반사 시키는 것이 가능하다.)
			 */
			m_oSprite_Target.color = Color.red;
		}

		/** 충돌 종료를 처리한다 */
		private void HandleOnTrigger_Exit(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			m_oSprite_Target.color = Color.white;
		}
		#endregion // 함수
	}
}
