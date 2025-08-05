using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 터렛
	 */
	public partial class C6x_E01Turret_06 : CComponent
	{
		#region 변수
		[Header("=====> Turret - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Bullet = null;
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
		#region 함수
		/** 초기화 */
		public IEnumerator CoTryShootBullet()
		{
			float fInterval = Random.Range(1.0f, 3.0f);
			var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_06>(KDefine.G_N_SCENE_EXAMPLE_06);

			do
			{
#if _6x_P01_PRACTICE_01
				var oBullet = this.CreateBullet();
#else
				var oBullet = Factory.CreateGameObj_Clone<C6x_E01Bullet_06>("Bullet",
					m_oPrefab_Bullet, oManager_Scene.GameObj_Bullets, Vector3.zero, m_oPrefab_Bullet.transform.localScale, Vector3.zero);
#endif // #if _6x_P01_PRACTICE_01

				oBullet.transform.position = this.transform.position;
				oBullet.Shoot(oManager_Scene.Player.gameObject);

				oManager_Scene.ListBullets.ExAddVal(oBullet);
				yield return Access.CoGetWait_ForSecs(fInterval);
			} while(oManager_Scene.State != C6x_E01Example_06.EState.GAME_OVER);
		}
		#endregion // 함수
	}

#if _6x_P01_PRACTICE_01
	/**
	 * 터렛 - 과제
	 */
	public partial class C6x_E01Turret_06 : CComponent
	{
		#region 변수
		[Header("=====> Turret - Game Objects <=====")]
		[SerializeField] private List<GameObject> m_oListPrefabs_Bullet = null;
		#endregion // 변수

		#region 팩토리 함수
		/** 총알 생성한다 */
		private C6x_E01Bullet_06 CreateBullet()
		{
			int nIdx = Random.Range(0, m_oListPrefabs_Bullet.Count);
			var oPrefab_Bullet = m_oListPrefabs_Bullet[nIdx];

			var oManager_Scene = CManager_Scene.GetManager_Scene<C6x_E01Example_06>(KDefine.G_N_SCENE_EXAMPLE_06);

			return Factory.CreateGameObj_Clone<C6x_E01Bullet_06>("Bullet",
				oPrefab_Bullet, oManager_Scene.GameObj_Bullets, Vector3.zero, oPrefab_Bullet.transform.localScale, Vector3.zero);
		}
		#endregion // 팩토리 함수
	}
#endif // #if _6x_P01_PRACTICE_01
}
