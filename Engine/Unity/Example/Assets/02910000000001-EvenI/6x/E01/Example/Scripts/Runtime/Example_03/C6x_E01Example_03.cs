using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 카메라 (Camera) 란?
 * - 3 차원 공간을 화면 상에 출력해주는 역할을 하는 기능을 의미하다. (+ 즉, 카메라는 공간을 
 * 바라보는 사람의 눈을 시뮬레이션 한다는 것을 알 수 있다.)
 * 
 * 카메라는 씬의 특정 영역을 화면 상에 출력해주는 역할을 수행해주기 때문에 반드시 씬 상에 1 개
 * 이상의 카메라가 배치되어있어야한다. (+ 즉, 카메라가 없을 경우 아무런 결과물도 화면 상에 
 * 출력되지 않는다는 것을 알 수 있다.)
 * 
 * 카메라는 3 차원 공간을 2 차원 화면 상에 출력하기 위해서 투영이라는 과정을 거치며 투영 방식에
 * 따라 화면 상에 출력되는 장면이 달라지는 특징이 존재한다.
 * 
 * Unity 카메라 투영 방식 종류
 * - 직교 투영
 * - 원근 투영
 * 
 * 직교 투영 (Orthographic Projection) 이란?
 * - 깊이 (거리) 감이 없는 투영 방식을 의미한다. (+ 즉, 직교 투영을 통해 화면 상에 장면을 출력하면 
 * 물체와 카메라 간에 거리에 상관 없이 물체가 지닌 크기대로 출력된다는 것을 알 수 있다.)
 * 
 * 직교 투영은 물체와 카메라 간에 거리가 달려져도 항상 물체의 크기대로 출력되는 특징이 존재하기
 * 때문에 2 차원 프로그램을 제작 할 때 주로 활용된다.
 * 
 * 원근 투영 (Perspective Projection) 이란?
 * - 깊이 (거리) 감이 느껴지는 투영 방식을 의미한다. (+ 즉, 원근 투영은 
 * 물체와 카메라 간의 거리에 따라 물체가 커지거나 작아진다는 것을 알 수 있다.)
 * 
 * 원근 투영은 실제 현실 세계와 유사한 장면을 만들어내기 때문에 3 차원 프로그램을 제작 할 때 
 * 주로 활용된다.
 * 
 * 카메라 클리어 옵션 (Camera Clear Option) 이란?
 * - 카메라를 통해 보여지는 장면을 화면 상에 출력하기 전에 렌더 타겟 및 깊이 스텐실 버퍼를 지우는
 * 방법을 설정하는 것을 의미한다. (+ 즉, 클리어 옵션에 따라 화면 상에 출력되는 결과물이 달라진다는 
 * 것을 알 수 있다.)
 * 
 * 카메라는 여러 개를 배치하는 것이 가능하며 클리어 옵션을 어떻게 설정하는지에 따라 다양한 결과물을
 * 화면 상에 출력하는 것이 가능하다. (+ 즉, 필수로 필요한 메인 카메라 이외에 추가적으로 카메라를
 * 배치 할 수 있다는 것을 알 수 있다.)
 * 
 * Unity 는 카메라에 의해서 보여지는 장면을 순차적으로 화면 상에 출력하기 때문에 카메라가 그려지는
 * 순서를 지정하는 방법을 제공하며 이는 Depth 옵션을 통해 이루어진다. (+ 즉, Depth 옵션에 따라
 * 카메라가 그려지는 순서가 변경되며 해당 옵션 값이 작을수록 먼저 그려지고 값이 클수록 나중에
 * 그려진다.)
 * 
 * 카메라 클리어 옵션 종류
 * - Skybox
 * - Solid Color
 * - Depth Only
 * - Don't Clear
 * 
 * Skybox 클리어 옵션이란?
 * - 카메라를 통해 장면을 화면 상에 출력하기 전에 렌더 타겟을 설정한 이미지로 지우는 옵션을 
 * 의미한다. (+ 즉, Skybox 클리어 옵션을 활용하면 배경 이미지를 화면 상에 출력하는 것이 가능하다.)
 * 
 * Solid Color 클리어 옵션이란?
 * - 렌더 타겟을 설정한 색상으로 지우는 옵션을 의미한다. (+ 즉, Solid 클리어 옵션을 활용하면 
 * 배경을 특정 색상으로 채우는 것이 가능하다.)
 * 
 * Depth Only 클리어 옵션이란?
 * - 렌더 타겟을 지우지 않고 깊이 스텐실 버퍼만을 지우는 옵션을 의미한다. (+ 즉, 
 * Skybox 클리어 옵션과 Solid 클리어 옵션은 렌더 타겟과 더불어 깊이 스텐실 버퍼도 지운다는 것을 
 * 알 수 있다.)
 * 
 * Don't Clear 클리어 옵션이란?
 * - 렌더 타겟과 깊이 스텐실 버퍼를 모두 지우지 않는 옵션을 의미한다. (+ 즉, 
 * 렌더 타겟과 깊이 스텐실 버퍼를 지우지 않기 때문에 이전에 그려진 장면이 계속 화면 상에 
 * 출력된다는 것을 알 수 있다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 3
	 */
	public partial class C6x_E01Example_03 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 3 - Etc <=====")]
		private int m_nMask_CameraFilter = 0x01;

		[Header("=====> Example 3 - Game Objects <=====")]
		[SerializeField] private List<GameObject> m_oListGameObjects_Camera = new List<GameObject>();
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

			for(int i = 1; i < m_oListGameObjects_Camera.Count; ++i)
			{
				int nMask_Bit = 1 << i;

				// 키를 입력했을 경우
				if(Input.GetKeyDown(KeyCode.Alpha1 + i))
				{
					m_nMask_CameraFilter ^= nMask_Bit;
				}

				bool bIsActive_Camera = (m_nMask_CameraFilter & nMask_Bit) != 0;
				m_oListGameObjects_Camera[i].SetActive(bIsActive_Camera);
			}
		}
		#endregion // 함수
	}
}
