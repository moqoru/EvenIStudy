// C6x_E01Turret_06.cs 수정한 코드
// Unity Editor에서 Inspector 뷰 => Script에서 다른 종류의 Bullet 프리팹을 넣어 준다. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Practice
{
	/**
	 * 터렛
	 */
	public partial class C6x_E01Turret_06 : CComponent
	{
		#region 변수
		[Header("=====> Turret - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Bullet = null;
		[SerializeField] private GameObject m_oPrefab_Bullet_Rapid = null; // 속도가 점점 빨라짐
		[SerializeField] private GameObject m_oPrefab_Bullet_Homing = null; // 일정 범위 내에서 플레이어 유도
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Start()
		{
			base.Start();

			/*
			 * StartCoroutine 메서드는 코루틴을 시작하는 역할을 수행한다. (+ 즉, 
			 * 해당 메서드를 활용하면 비동기적인 연산을 좀 더 수월하게 처리하는 것이 가능하다.)
			 * 
			 * 코루틴 (Coroutine) 이란?
			 * - 프로그램의 흐름이 반환되었던 지점부터 다시 이어서 실행 할 수 있는 메서드를
			 * 의미한다. (+ 즉, 일반적인 메서드는 프로그램의 흐름이 반환되고 나면 해당 메서드를 
			 * 호출 시 다시 메서드의 처음부터 실행 되지만 코루틴은 반환되었던 위치부터 다시 이어서 
			 * 실행이 가능하다는 차이점이 존재한다.)
			 * 
			 * 따라서 코루틴을 활용하면 여러 작업을 병렬적으로 처리하는 결과를 만들어내는 것이
			 * 가능하다. (+ 즉, 일정 간격으로 프로그램의 흐름을 넘겨줌으로서 병렬 처리를 
			 * 수행 할 수 있다.)
			 */
			StartCoroutine(this.CoTryShootBullet());
		}
		#endregion // 함수
	}

	/**
	 * 터렛 - 코루틴
	 */
	public partial class C6x_E01Turret_06 : CComponent
	{
		#region 상수
		private const float RAPID_PROB = 0.1f; // 빨라진 총알 발사 확률
		private const float HOMING_PROB = 0.8f; // 유도탄 발사 확률
		#endregion // 상수

		#region 함수
		/** 초기화 */
		public IEnumerator CoTryShootBullet()
		{
			float fInterval = Random.Range(1.0f, 3.0f);
			var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_06>(KDefine.G_N_SCENE_EXAMPLE_06);

			do
			{
				float fRand = Random.Range(0.0f, 1.0f); // [0.0f, 1.0f) 범위 내의 난수 생성
				GameObject selectedBullet = m_oPrefab_Bullet;
				EBulletType eBulletType = EBulletType.Normal; // Bullet의 Shoot 함수를 호출할 때 총알 종류를 매개변수로 넘겨준다.

				if(fRand < RAPID_PROB) // 10% 확률
				{
					selectedBullet = m_oPrefab_Bullet_Rapid; // 총알이 점점 빨라짐
					eBulletType = EBulletType.Rapid;
				}
				else if(fRand < RAPID_PROB + HOMING_PROB) // 10% 확률
				{
					selectedBullet = m_oPrefab_Bullet_Homing; // 일정 범위 내에서 유도탄이 됨
					eBulletType = EBulletType.Homing;
				}

				var oBullet = Factory.CreateGameObj_Clone<C6x_E01Bullet_06>("Bullet",
					selectedBullet, oManager_Scene.GameObj_Bullets, Vector3.zero, selectedBullet.transform.localScale, Vector3.zero);
				
				oBullet.transform.position = this.transform.position;
				oBullet.Shoot(oManager_Scene.Player.gameObject, eBulletType);

				oManager_Scene.ListBullets.ExAddVal(oBullet);
				yield return Access.CoGetWait_ForSecs(fInterval);
			} while(oManager_Scene.State != C6x_E01Example_06.EState.GAME_OVER);
		}
		#endregion // 함수
	}
}
