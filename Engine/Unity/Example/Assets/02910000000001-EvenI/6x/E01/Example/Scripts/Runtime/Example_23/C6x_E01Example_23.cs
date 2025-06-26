using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 쉐이더 (Shader) 란?
 * - 화면에 출력되는 픽셀의 색상을 계산하는 GPU 상에서 구동되는 프로그램을 의미한다. (+ 즉, 
 * 쉐이더를 활용하면 물체를 감싸고 있는 표면의 다양한 재질을 표현하는 것이 가능하다.)
 * 
 * Unity 에서 쉐이더는 단순히 명령문을 담고 있는 에셋이기 때문에 특정 쉐이더를 사용하기 위해서는
 * 반드시 재질 (Material) 을 활용해야한다. (+ 즉, 재질을 통해 쉐이더를 제어한다는 것을 알 수 있다.)
 * 
 * Unity 쉐이더 제작 방법
 * - 쉐이더 그래프 (Shader Graph)
 * - 서피스 쉐이더 (Surface Shader)
 * - 정점 / 프래그먼트 쉐이더 (Vertex / Fragment Shader)
 * 
 * 위와 같이 Unity 는 쉐이더를 제작하기 위한 다양한 방법이 존재하며 해당 방법을 통해 제작 된
 * 쉐이더는 재질에 의해 물체를 렌더링하는 컴포넌트 (+ Ex. Mesh Renderer 등등...) 에 설정하는 것이
 * 가능하다.
 * 
 * 쉐이더 그래프 (Shader Graph) vs 서피스 쉐이더 (Surface Shader)
 * - 두 방법 모두 비교적 간단한 처리만으로 다양한 효과를 연출하는 쉐이더를 제작하는 것이 가능하다.
 * 
 * 쉐이더 그래프는 비주얼 에디터를 통해서 쉐이더를 제작하는 방법으로 해당 방법을 활용하면
 * 쉐이더 언어 (+ Ex. HLSL 등등...) 를 학습하지 않아도 여러 쉐이더를 제작하는 것이 가능하다.
 * (+ 즉, 프로그래밍 언어를 최소한으로 사용한다는 것을 알 수 있다.)
 * 
 * 단, 비주얼 에디터를 통해 쉐이더를 제작하기 때문에 복잡한 쉐이더를 제작 할 수록 가독성이 떨어지는
 * 단점이 존재한다. (+ 즉, 화면 상에 많은 노드가 존재하기 때문에 정리가 필수라는 것을 알 수 있다.)
 * 
 * 반면 서피스 쉐이더는 쉐이더 언어를 통해 쉐이더를 제작하는 방법으로서 Cg (C for Graphic) 언어를
 * 사용해서 쉐이더를 제작하는 것이 가능하다.
 * 
 * 쉐이더 언어를 사용하기 때문에 프로그래밍 스킬이 어느 정도 필요하지만 비교적 간단한 명령문으로
 * 다양한 효과를 연출하는 쉐이더를 제작하는 것이 가능하다. (+ 즉, 내부적으로 많은 처리가 생략 된다는
 * 것을 알 수 있다.)
 * 
 * 단, 해당 방법은 SRP (Scriptable Render Pipeline) 가 등장하기 이전에 사용되던 방법으로
 * SRP 환경에서는 사용하는 것이 불가능하다. (+ 즉, SRP 호환되지 않는다는 것을 의미한다.)
 * 
 * 정점 / 프래그먼트 쉐이더 (Vertex / Fragment Shader) 란?
 * - 쉐이더 언어를 통해 직접 정점 쉐이더와 프래그먼트 쉐이더를 제작하는 방법을 의미한다. (+ 즉,
 * Unity 가 제공하는 방법 중 가장 난이도가 높다는 것을 알 수 있다.)
 * 
 * 해당 방법은 Unity 가 자동으로 처리해주는 작업을 최소화하고 해당 부분을 직접 처리함으로서 가장
 * 자유롭게 쉐이더를 제작하는 것이 가능하지만 많은 배경 지식을 요구하는 단점이 존재한다. (+ 즉,
 * 쉐이더를 전문적으로 다루는 그래픽스 프로그래머들이 주로 활용하는 방법이라는 것을 알 수 있다.)
 * 
 * 정점 / 프래그먼트 쉐이더 방식에 사용되는 쉐이더 언어는 Cg, HLSL, GLSL 과 같이 다양한 언어가
 * 지원되만 Unity 에서 권장하는 언어는 Cg 와 HLSL 이다. (+ 즉, 다른 언어는 호환성에 문제가
 * 발생 할 수 있다는 것을 의미한다.)
 * 
 * Cg 는 레거시 파이프라인 환경에서 기본으로 사용되는 언어이며 
 * HLSL (High Level Shader Language) 은 SRP 환경에서 기본으로 사용되는 언어이다.
 * 
 * 따라서 현재 프로젝트를 제작하는 환경에 맞춰서 적절한 언어를 선택 할 필요가 있다. (+ 즉,
 * 특정 플랫폼에만 구동되는 프로그램을 제작하는 것이 아니라면 일반적으로 기본 언어를 사용하는 것을
 * 추천한다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 23
	 */
	public partial class C6x_E01Example_23 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 23 - Etc <=====")]
		private float m_fWeight = 1.0f;
		private float m_fDirection_Weight = -1.0f;

		[Header("=====> Example 23 - Game Objects <=====")]
		[SerializeField] private List<GameObject> m_oListGameObjects_Target = new List<GameObject>();
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

			m_fWeight += m_fDirection_Weight * Time.deltaTime * 0.25f;
			m_fWeight = Mathf.Clamp01(m_fWeight);

			// 방향 전환이 필요 할 경우
			if(m_fWeight.ExIsLessEquals(0.0f) || m_fWeight.ExIsGreatEquals(1.0f))
			{
				m_fDirection_Weight = -m_fDirection_Weight;
			}

			for(int i = 0; i < m_oListGameObjects_Target.Count; ++i)
			{
				m_oListGameObjects_Target[i].transform.Rotate(Vector3.up,
					90.0f * Time.deltaTime, Space.World);

				var oRenderer_Mesh = m_oListGameObjects_Target[i].GetComponentInChildren<MeshRenderer>();

				/*
				 * Has 계열 메서드를 활용하면 재질의 속성 존재 여부를 검사하는 것이 가능하다.
				 * (+ 즉, 존재하지 않는 속성을 변경하면 내부적으로 에러가 발생하기 때문에 
				 * 존재 여부가 확실하지 않을 경우에는 항상 해당 메서드를 통해 사전에 
				 * 예외 처리 할 필요가 있다.)
				 */
				// 가중치가 존재 할 경우
				if(oRenderer_Mesh.sharedMaterial.HasFloat("_Weight_Wet"))
				{
					oRenderer_Mesh.material.SetFloat("_Weight_Wet", m_fWeight);
				}

				// 가중치가 존재 할 경우
				if(oRenderer_Mesh.sharedMaterial.HasFloat("_Weight_Lerp"))
				{
					oRenderer_Mesh.material.SetFloat("_Weight_Lerp", m_fWeight);
				}

				// 가중치가 존재 할 경우
				if(oRenderer_Mesh.sharedMaterial.HasFloat("_Weight_Dissolve"))
				{
					oRenderer_Mesh.material.SetFloat("_Weight_Dissolve", m_fWeight);
				}
			}
		}
		#endregion // 함수
	}
}
