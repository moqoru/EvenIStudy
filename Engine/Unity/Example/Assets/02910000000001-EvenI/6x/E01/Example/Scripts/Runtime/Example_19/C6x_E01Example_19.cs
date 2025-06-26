using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using UnityEngine.AI;
using DG.Tweening;

/*
 * 내비게이션 (Navigation) 이란?
 * - 내비게이션 메쉬 데이터를 기반으로 경로를 탐색 할 수 있는 기능을 의미한다. (+ 즉, 
 * 내비게이션을 활용하면 특정 물체를 손쉽게 특정 지점까지 이동 시키는 것이 가능하다.)
 * 
 * 내비게이션은 내부적으로 경로를 탐색하기 위해서 A* 알고리즘을 사용하며 내비게이션을 통해 경로를
 * 탐색하기 위해서는 반드시 내비게이션 메쉬 데이터를 제공 할 필요가 있다. (+ 즉, 
 * 내비게이션 메쉬 데이터가 없을 경우 내부적으로 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 내비게이션 메쉬 데이터는 내비게이션 메쉬 표면 (Nav Mesh Surface) 컴포넌트를 통해 생성하는 것이 
 * 가능하다.
 * 
 * 내비게이션 메쉬 표면 컴포넌트는 Unity 2022 버전 이상부터 제공되며 해당 컴포넌트를 활용하면
 * 내비게이션 메쉬 데이터를 정적 or 동적으로 생성 할 수 있다. (+ 즉, Unity 2021 버전 이하에서는
 * 해당 컴포넌트가 없으며 내비게이션 메쉬 데이터는 정적으로만 생성 할 수 있다.)
 * 
 * Unity 내비게이션 관련 주요 컴포넌트 종류
 * - 내비게이션 메쉬 에이전트 (Nav Mesh Agent)
 * - 내비게이션 메쉬 표면 (Nav Mesh Surface)
 * - 내비게이션 메쉬 장애물 (Nav Mesh Obstacle)
 * - 분할 메쉬 링크 (Off Mesh Link)
 * 
 * 내비게이션 메쉬 에이전트 (Nav Mesh Agent) 란?
 * - 내비게이션에 의해 움직이는 사물을 의미한다. (+ 즉, 내비게이션 메쉬 에이전트를 활용하면 
 * 특정 게임 객체를 간단하게 목적지까지 이동 시키는 것이 가능하다.)
 * 
 * 단, 내비게이션 메쉬 에이전트는 내비게이션 메쉬 표면 위에서만 움직이는 것이 가능하기 떄문에
 * 사전에 반드시 내비게이션 메쉬 표면을 생성해 줄 필요가 있다. (+ 즉, 내비게이션 메쉬 표면을 
 * 벗어날 경우 내부적으로 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 내비게이션 메쉬 표면 (Nav Mesh Surface) 란?
 * - 내비게이션 메쉬 데이터를 생성해주는 역할을 지닌 컴포넌트를 의미한다. (+ 즉, 
 * 해당 컴포넌트를 활용하면 간단하게 내비게이션 메쉬 표면을 생성하는 것이 가능하다.)
 * 
 * 내비게이션 메쉬 표면은 다양한 타입이 존재하며 제작하는 프로그램에 맞게 적절한 표면 타입을
 * 지정함으로서 생성되는 내비게이션 메쉬 표면에 가중치를 부여하는 것이 가능하다. (+ 즉, 
 * 내비게이션 메쉬 표면의 가중치에 따라 에이전트라 움직이는 경로가 달라 질 수 있다는 것을 의미한다.)
 * 
 * 내비게이션 메쉬 장애물 (Nav Mesh Obstacle) 란?
 * - 에이전트의 움직임을 방해하는 사물을 의미한다. (+ 즉, 해당 컴포넌트를 활용하면 
 * 동적으로 에이전트의 움직임을 방해하는 사물을 생성하는 것이 가능하다.)
 * 
 * 내비게이션 메쉬 표면은 정적 사물만 장애물로 인식하기 때문에 움직이는 사물에는 올바른 표면을
 * 생성하는 것이 불가능하다.
 * 
 * 따라서 동적으로 움직이는 장애물이 필요 할 경우 내비게이션 메쉬 장애물을 활용하면 간단하게
 * 내비게이션 메쉬 데이터를 갱신하는 것이 가능하다.
 * 
 * 분할 메쉬 링크 (Off Mesh Link) 란?
 * - 떨어져있는 내비게이션 메쉬 표면을 연결해주는 컴포넌트를 의미한다. (+ 즉, 
 * 해당 컴포넌트를 활용하면 에이전트가 서로 떨어져있는 내비게이션 메쉬 표면을 넘나드는 것이 
 * 가능하다.)
 * 
 * 에이전트는 기본적으로 해당 에이전트를 포함하고 있는 내비게이션 메쉬 표면을 벗어나는 것이
 * 불가능하다. (+ 즉, 강제로 위치를 변경 할 경우 내부적으로 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 따라서 떨어져있는 내비게이션 메쉬 표면으로 이동하기 위해서는 별도의 작업이 필요하며 해당 작업에
 * 사용되는 컴포넌트가 분할 메쉬 링크이다.
 * 
 * 분할 메쉬 링크에는 출발지와 목적지가 존재하며 해당 위치를 각 내비게이션 메쉬 표면에
 * 연결해줌으로서 서로 떨어져있는 내비게이션 메쉬 표면을 에이전트가 이동하도록 처리하는 것이
 * 가능하다. (+ 즉, 분할 메쉬 링크로 연결되지 않은 내비게이션 메쉬 표면은 이동하는 것이 불가능하다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 19
	 */
	public partial class C6x_E01Example_19 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 19 - Etc <=====")]
		private Tween m_oAnim_Obstacle = null;

		[Header("=====> Example 10 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Target = null;
		[SerializeField] private GameObject m_oGameObj_Obstacle = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			m_oAnim_Obstacle = m_oGameObj_Obstacle.transform.DOLocalMoveX(500.0f, 3.5f);
			m_oAnim_Obstacle.SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
		}

		/** 제거되었을 경우 */
		public override void OnDestroy()
		{
			base.OnDestroy();
			m_oAnim_Obstacle?.Kill();
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			// 상태 갱신이 불가능 할 경우
			if(!Input.GetMouseButtonDown((int)EBtn_Mouse.LEFT))
			{
				return;
			}

			var stRay = this.Camera_Main.ScreenPointToRay(Input.mousePosition);

			// 상태 갱신이 불가능 할 경우
			if(!Physics.Raycast(stRay, out RaycastHit stInfo_RaycastHit))
			{
				return;
			}

			NavMesh.SamplePosition(stInfo_RaycastHit.point,
				out NavMeshHit stInfo_NavMeshHit, float.MaxValue / 2.0f, NavMesh.AllAreas);

			var oAgent_NavMesh = m_oGameObj_Target.GetComponentInChildren<NavMeshAgent>();

			/*
			 * SetDestination 메서드는 내비게이션 시스템에 의해서 제어되는
			 * 내비 메쉬 에이전트의 목적지를 설정하는 역할을 수행한다. (+ 즉, 
			 * 해당 함수를 활용하면 게임 객체를 원하는 목적지까지 이동 시키는 것이 가능하다.)
			 */
			oAgent_NavMesh.SetDestination(stInfo_NavMeshHit.position);
		}
		#endregion // 함수
	}
}
