//#define E_E01_EXAMPLE_08_01
#define E_E01_EXAMPLE_08_02

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 물리 엔진 (Physics Engine) 이란?
 * - 현실 상에서 발생하는 여러 물리적인 현상을 시뮬레이션해주는 기능을 의미한다. (+ 즉, 
 * 물리 엔진을 활용하면 물체 간에 충돌 등을 검출하는 것이 가능하다.)
 * 
 * Unity 물리 엔진 종류
 * - PhysX			<- 3 차원 전용
 * - Box2D			<- 2 차원 전용
 * - Havok			<- 3 차원 전용
 * 
 * 위와 같이 Unity 는 여러 물리 엔진을 내장하고 있으며 제작하는 프로그램에 맞춰서 2 차원
 * 물리 엔진과 3 차원 물리 엔진을 선택해야한다는 것을 알 수 있다. (+ 즉, 2 차원 물리 엔진과 
 * 3 차원 물리 엔진은 사용하는 컴포넌트가 다르다는 것을 의미한다.)
 * 
 * 단, Havok 물리 엔진은 현재 개발이 진행 중인 물리 엔진이기 때문에 아직 Unity 에서 
 * 사용하기에는 아직 무리가 있으며 해당 물리 엔진을 사용하기 위해서는 
 * ECS (Entity Component System) 와 DOTS (Data Oriented Technology Stack) 기반으로 
 * 프로그램을 제작 할 필요가 있다. (+ 즉, 객체 지향 프로그래밍 구조에서는 사용이 불가능하다는 것을
 * 알 수 있다.)
 * 
 * Unity 물리 관련 컴포넌트
 * - 강체 (Rigidbody)
 * - 충돌체 (Collider)
 * 
 * 강체 (Rigidbody) 란?
 * - 물리 현상을 시뮬레이션해주는 컴포넌트를 의미한다. (+ 즉, 해당 컴포넌트가 추가 된 게임 객체에
 * 충격을 줄 경우 물리 엔진에 의해 밀려나는 현상이 발생한다는 것을 알 수 있다.)
 * 
 * 강체 컴포넌트는 2 차원 물리 처리를 위한 Rigidbody2D 와 3 차원 물리 처리를 위한 Rigidbody 로
 * 구분된다. (+ 즉, 게임 객체에 Rigidbody2D 컴포넌트를 추가 할 경우 내부적으로 
 * Box2D 물리 엔진에 의해서 물리 현상이 처리된다는 것을 알 수 있다.)
 * 
 * 충돌체 (Collider) 란?
 * - 대상의 물리적인 형태를 나타내는 컴포넌트를 의미한다. (+ 즉, Unity 물리 엔진은 충돌체를 
 * 기반으로 게임 객체의 형태를 인지한다는 것을 알 수 있다.)
 * 
 * Unity 주요 충돌체 종류
 * - Box
 * - Sphere
 * - Capsule
 * - Mesh
 * 
 * 위와 같이 Unity 는 여러 충돌체가 존재하며 Mesh 충돌체를 제외하고는 단순한 형태를 지니고 있다는
 * 것을 알 수 있다. (+ 즉, 충돌체의 형태를 단순하게 함으로서 물리 엔진의 부하를 최소화한다는 것을
 * 알 수 있다.)
 * 
 * 또한 충돌체는 필요에 따라 1 개 이상 포함하는 것이 가능하며 이를 복합 충돌체라고 지칭한다. (+ 즉,
 * 여러 충돌체를 조합해서 물체의 형태를 표현하는 것이 가능하다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 8
	 */
	public partial class C6x_E01Example_08 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 8 - Etc <=====")]
		private bool m_bIsEnable_Shoot_02 = true;
		private float m_fRate_Charging_02 = 0.0f;

		[Header("=====> Example 8 - UIs <=====")]
		[SerializeField] private Image m_oUIImg_Guage_02 = null;

		[Header("=====> Example 8 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Target_01 = null;
		[SerializeField] private GameObject m_oGameObj_Target_02 = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

#if E_E01_EXAMPLE_08_02
			/*
			 * Rigidbody.useGravity 프로퍼티는 중력 영향 여부를 변경하는 역할을 수행한다. (+ 즉,
			 * 해당 프로퍼티를 활성화하면 중력에 의해서 자동으로 중력이 작용하는 방향으로
			 * 이동한다는 것을 알 수 있다.)
			 */
			var oRigidbody = m_oGameObj_Target_02.GetComponentInChildren<Rigidbody>();
			oRigidbody.useGravity = false;
#endif // #if E_E01_EXAMPLE_08_02
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

#if E_E01_EXAMPLE_08_01
			// 상 / 하 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			{
				float fSign = Input.GetKey(KeyCode.UpArrow) ? 1.0f : -1.0f;

				m_oGameObj_Target_01.transform.Translate(0.0f,
					0.0f, 5.0f * fSign * Time.deltaTime, Space.Self);
			}

			// 좌 / 우 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
			{
				float fSign = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : 1.0f;

				m_oGameObj_Target_01.transform.Rotate(0.0f,
					180.0f * fSign * Time.deltaTime, 0.0f, Space.Self);
			}

			var stRay = new Ray(m_oGameObj_Target_01.transform.position,
				m_oGameObj_Target_01.transform.forward);

			/*
			 * Physics.Raycast 계열 메서드는 광선 추적을 통해 물체를 판별하는 역할을 수행한다.
			 * (+ 즉, 해당 계열 메서드를 활용하면 월드 상에 존재하는 게임 객체의 충돌 여부를 
			 * 검사하는 것이 가능하다.)
			 */
			// 충돌했을 경우
			if(Physics.Raycast(stRay, out RaycastHit stRaycastHit, 5.0f))
			{
				Func.ShowLog($"{stRaycastHit.collider.name} 충돌");
			}
#elif E_E01_EXAMPLE_08_02
			// 발사가 불가능 할 경우
			if(!m_bIsEnable_Shoot_02)
			{
				return;
			}

			// 상 / 하 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
			{
				float fSign = Input.GetKey(KeyCode.UpArrow) ? 1.0f : -1.0f;

				var stAngles = m_oGameObj_Target_02.transform.localEulerAngles;
				stAngles.z += 90.0f * fSign * Time.deltaTime;
				stAngles.z = Mathf.Clamp(stAngles.z, 0.0f, 90.0f);

				m_oGameObj_Target_02.transform.localEulerAngles = stAngles;
			}

			// 스페이스 키를 눌렀을 경우
			if(Input.GetKey(KeyCode.Space))
			{
				m_fRate_Charging_02 = Mathf.Clamp01(m_fRate_Charging_02 + Time.deltaTime);
			}

			// 스페이스 키 입력을 종료했을 경우
			if(Input.GetKeyUp(KeyCode.Space))
			{
				m_bIsEnable_Shoot_02 = false;

				var oRigidbody = m_oGameObj_Target_02.GetComponentInChildren<Rigidbody>();
				oRigidbody.useGravity = true;

				var stForce = m_oGameObj_Target_02.transform.right * 
					25.0f * m_fRate_Charging_02;

				var stPos_At = m_oGameObj_Target_02.transform.position + 
					Vector3.up * 0.5f;

				/*
				 * Rigidbody.AddForce 계열 메서드는 게임 객체에 물리적인 힘을 가하는 역할을
				 * 수행한다. (+ 즉, 해당 메서드를 활용하면 물리 엔진을 이용해 물리 현상을 
				 * 시뮬레이션하는 것이 가능하다.)
				 */
				oRigidbody.AddForceAtPosition(stForce,
					stPos_At, ForceMode.VelocityChange);
			}

			/*
			 * 이미지 컴포넌트가 Filled 모드 일 경우 fillAmount 프로퍼티를 통해 이미지가 
			 * 채워지는 영역을 설정하는 것이 가능하다.
			 */
			m_oUIImg_Guage_02.fillAmount = m_fRate_Charging_02;
#endif // E_E01_EXAMPLE_08_01
		}

#if UNITY_EDITOR
		/** 기즈모를 그린다 */
		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();

			/*
			 * Gizmos 클래스란?
			 * - Unity 에디터의 씬 뷰에 그래픽을 출력하기 위한 클래스를 의미한다. (+ 즉, 
			 * 해당 클래스를 활용하면 다양한 그래픽을 손쉽게 출력하는 것이 가능하다.)
			 * 
			 * 해당 클래스는 Unity 상에 존재하는 모든 스크립트가 공유하는 클래스이기 때문에
			 * 해당 클래스의 속성을 변경했다면 사용이 완료된 후에 반드시 원래 상태로 
			 * 되돌려 줄 필요가 있다. (+ 즉, 속성을 되돌리지 않음으로서 의도치 않은 결과가 
			 * 출력 될 수 있다는 것을 알 수 있다.)
			 */
			var stColor_Prev = Gizmos.color;

			try
			{
				Gizmos.color = Color.red;

#if E_E01_EXAMPLE_08_01
				var stStart = m_oGameObj_Target_01.transform.position;
				var stEnd = stStart + (m_oGameObj_Target_01.transform.forward * 5.0f);

				Gizmos.DrawLine(stStart, stEnd);
#elif E_E01_EXAMPLE_08_02
				var stStart = m_oGameObj_Target_02.transform.position;
				var stEnd = stStart + (m_oGameObj_Target_02.transform.right * 5.0f);

				Gizmos.DrawLine(stStart, stEnd);
#endif // #if E_E01_EXAMPLE_08_01
			}
			finally
			{
				Gizmos.color = stColor_Prev;
			}
		}
#endif // #if UNITY_EDITOR
		#endregion // 함수
	}
}
