using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 광원 (Light) 이란?
 * - 3 차원 공간 상에서 물체를 식별 할 수 있는 빛의 역할을 하는 기능을 의미한다. (+ 즉, Unity 는
 * 현실 세계의 여러 현상을 시뮬레이션하는 툴이기 때문에 광원이 없다면 물체를 식별하는 것이 
 * 불가능하다.)
 * 
 * Unity 는 여러 광원을 제공하며 해당 광원을 활용함으로서 다양한 장면을 출력하는 것이 가능하다.
 * 
 * Unity 광원 종류
 * - 방향 광원 (Directional)
 * - 점 광원 (Point)
 * - 집중 광원 (Spot)
 * - 영역 광원 (Area)			<- 베이크 전용
 * 
 * 방향 광원 (Directional) 이란?
 * - 태양과 같이 방향이 일정한 광원을 의미한다. (+ 즉, 방향 광원을 활용하면 씬 상에 존재하는 모든
 * 물체가 동일한 방향으로 빛을 받는 것이 가능하다.)
 * 
 * 방향 광원은 태양과 유사한 결과를 만들어내는 것이 가능하며 연산량이 가장 적기 때문에 메인 광원으로
 * 주로 활용된다. (+ 즉, 방향 광원을 메인 광원으로 설정하고 필요에 따라 다른 형태의 광원을 사용하는
 * 것이 일반적인 구조이다.)
 * 
 * 점 광원 (Point) 이란?
 * - 전구와 같이 근원지로부터 빛이 사방으로 뻗어나가는 광원을 의미한다. (+ 즉, 광원과 물체의 위치에 
 * 따라 광원을 받는 방향이 달라진다는 것을 알 수 있다.)
 * 
 * 집중 광원 (Spot) 이란?
 * - 손전등과 같이 근원지로부터 빛이 일정 각도로 뻗어나가는 광원을 의미한다. (+ 즉, 특정 방향으로
 * 빛을 집중 시키고 싶을 때 사용하는 광원이라는 것을 알 수 있다.)
 * 
 * 단, 집중 광원은 연산량이 가장 많기 때문에 광원에 의한 퍼포먼스 저하가 발생 할 경우 최대한 사용을
 * 자제해야한다.
 * 
 * 영역 광원 (Area) 이란?
 * - 설정한 영역으로부터 빛이 사방으로 뻗어나가는 광원을 의미한다. (+ 즉, 점 광원과 유사하다는 것을
 * 알 수 있다.)
 * 
 * 단, 실시간 연산이 가능한 다른 광원들과 달리 영역 광원은 미리 계산 된 데이터만을 가지고 연산을
 * 하는 것이 가능하다. (+ 즉, 영역 광원은 움직이지 않고 고정 되어있는 정적 광원이라는 것을 알 수 
 * 있다.)
 * 
 * 따라서 영역 광원은 광원 연산을 하기 위한 데이터가 필요하며 이를 광원 맵이라고 한다. (+ 즉,
 * 광원 맵은 베이킹 과정을 통해서 생성 가능하다는 것을 알 수 있다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 2
	 */
	public partial class C6x_E01Example_02 : CManager_Scene
	{
		/**
		 * 광원 종류
		 */
		public enum EType_Light
		{
			NONE = -1,
			DIRECTIONAL,
			POINT,
			SPOT,
			AREA,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Example 2 - Etc <=====")]
		private EType_Light m_eType_Light = EType_Light.DIRECTIONAL;

		[Header("=====> Example 2 - Game Objects <=====")]
		[SerializeField] private List<GameObject> m_oListGameObjects_Light = new List<GameObject>();
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			for(int i = 0; i < m_oListGameObjects_Light.Count; ++i)
			{
				// 키를 눌렀을 경우
				if(Input.GetKeyDown(KeyCode.Alpha1 + i))
				{
					m_eType_Light = (EType_Light)i;
				}
			}

			float fVertical = Input.GetAxis(KDefine.G_N_AXIS_VERTICAL);
			float fHorizontal = Input.GetAxis(KDefine.G_N_AXIS_HORIZONTAL);

			for(int i = 0; i < m_oListGameObjects_Light.Count; ++i)
			{
				m_oListGameObjects_Light[i].transform.Translate(Vector3.forward * 7.5f * fVertical * a_fTime_Delta,
					Space.World);

				m_oListGameObjects_Light[i].transform.Rotate(Vector3.up, 90.0f * fHorizontal * a_fTime_Delta,
					Space.World);

				m_oListGameObjects_Light[i].SetActive(m_eType_Light == (EType_Light)i);
			}
		}
		#endregion // 함수
	}
}
