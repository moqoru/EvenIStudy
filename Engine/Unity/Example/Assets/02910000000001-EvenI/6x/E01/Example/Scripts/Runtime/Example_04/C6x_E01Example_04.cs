using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 프리팹 (Prefab) 이란?
 * - 게임 객체를 에셋화시킬 수 있는 기능을 의미한다. (+ 즉, 프리팹을 활용하면 특정 객체를 
 * 손쉽게 재사용하는 것이 가능하다.)
 * 
 * Unity 는 컴포넌트 기반 구조로 되어있기 때문에 새로운 객체를 생성하는 과정이 번거롭다는 단점이
 * 존재한다. (+ 즉, 게임 객체를 생성하고 컴포넌트를 추가 및 초기화하는 여러 과정이 필요하다는 것을
 * 의미한다.)
 * 
 * 따라서 Unity 에서 새로운 객체를 생성 할 때는 기존에 미리 제작한 원본을 통해 사본 객체를 생성하는 
 * 것이 일반적이며 이때 주로 프리팹이 활용된다. (+ 즉, 프리팹은 게임 객체를 에셋으로 
 * 저장 및 활용 할 수 있는 기능이기 때문에 프리팹을 통해 사본 객체를 생성하는 것이 가능하다.)
 * 
 * 또한 프리팹을 통해 생성 된 사본 객체들은 원본 프리팹과 변경 사항을 공유하는 특징이 존재한다.
 * (+ 즉, 사본 객체의 변경 사항을 원본 프리팹에 적용함으로서 해당 프리팹으로부터 생성 된 
 * 모든 사본 객체에 변경 사항을 반영하는 것이 가능하다.)
 * 
 * 네스티드 프리팹 (Nested Prefab) 이란?
 * - 프리팹에 다른 프리팹을 포함시킬 수 있는 기능을 의미한다. (+ 즉, 해당 기능을 활용하면
 * 공통되는 구조를 별도의 프리팹으로 제작 후 재사용하는 것이 가능하다.)
 * 
 * 네스티드 프리팹은 주로 UI 와 같이 공통되는 구조를 많이 지니는 결과물을 제작 할 때 유용하다.
 * (+ 즉, 공통되는 구조를 별도의 프리팹으로 제작함으로서 이후 수정 사항에 좀 더 유연하게 대처하는
 * 것이 가능하다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 4
	 */
	public partial class C6x_E01Example_04 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 4 - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Target = null;
		[SerializeField] private GameObject m_oGameObj_Targets = null;
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

			// 객체 생성이 불가능 할 경우
			if(!Input.GetKeyDown(KeyCode.Space))
			{
				return;
			}

			var oGameObj = Factory.CreateGameObj_Clone("Target",
				m_oPrefab_Target, m_oGameObj_Targets);

			oGameObj.transform.localScale = new Vector3(Random.Range(50.0f, 200.0f),
				Random.Range(50.0f, 200.0f), Random.Range(50.0f, 200.0f));
		}
		#endregion // 함수
	}
}
