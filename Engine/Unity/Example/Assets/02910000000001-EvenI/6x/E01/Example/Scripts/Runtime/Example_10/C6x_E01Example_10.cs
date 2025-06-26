using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;

namespace _6x_E01Example
{
	/**
	 * Example 10
	 */
	public partial class C6x_E01Example_10 : CManager_Scene
	{
		/**
		 * 상태
		 */
		public enum EState
		{
			NONE = -1,
			PLAY,
			GAME_OVER,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Example 10 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Score = null;

		[Header("=====> Example 10 - Game Objects <=====")]
		[SerializeField] private GameObject m_oPrefab_Obstacle = null;

		[SerializeField] private GameObject m_oGameObj_Player = null;
		[SerializeField] private GameObject m_oGameObj_Obstacles = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State { get; private set; } = EState.PLAY;
		public List<GameObject> ListGameObjects_Obstacle { get; private set; } = new List<GameObject>();
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			C6x_E01Storage_Result_10.Inst.Reset();

			var oRigidbody = m_oGameObj_Player.GetComponentInChildren<Rigidbody>();
			oRigidbody.useGravity = true;

			/*
			 * Rigidbody.constraints 프로퍼티는 이동 및 회전에 대한 물리 시뮬레이션을 제한하는
			 * 역할을 수행한다. (+ 즉, 해당 프로퍼티를 통해 고정 된 속성은 물리 엔진에 의해서
			 * 시뮬레이션 되지 않는다는 것을 알 수 있다.)
			 */
			oRigidbody.constraints = RigidbodyConstraints.FreezePositionX |
				RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

			var oDispatcher_Trigger = m_oGameObj_Player.GetComponentInChildren<CDispatcher_Trigger>();
			oDispatcher_Trigger.SetCallback_Enter(this.HandleOnTrigger_Enter);
			oDispatcher_Trigger.SetCallback_Exit(this.HandleOnTrigger_Exit);
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();
			StartCoroutine(this.CoTryCreateObstacles());
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			// 상태 갱신이 불가능 할 경우
			if(this.State != EState.PLAY)
			{
				return;
			}

			m_oTMP_UIText_Score.text = $"{C6x_E01Storage_Result_10.Inst.Score}";

			// 스페이스 키를 눌렀을 경우
			if(Input.GetKeyDown(KeyCode.Space))
			{
				var oRigidbody = m_oGameObj_Player.GetComponentInChildren<Rigidbody>();
				oRigidbody.linearVelocity = Vector3.zero;

				oRigidbody.AddForce(Vector3.up * 10.0f, ForceMode.VelocityChange);
			}

			for(int i = 0; i < this.ListGameObjects_Obstacle.Count; ++i)
			{
				var oObstacle = this.ListGameObjects_Obstacle[i];
				oObstacle.transform.localPosition += (Vector3.left * 350.0f) * a_fTime_Delta;
			}
		}

		/** 충돌 시작을 처리한다 */
		private void HandleOnTrigger_Enter(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			bool bIsValid = this.State == EState.PLAY;
			bIsValid = bIsValid && a_oCollider.CompareTag("6x_E01Tag_Obstacle_10");

			// 충돌 처리가 불가능 할 경우
			if(!bIsValid)
			{
				return;
			}

			this.State = EState.GAME_OVER;

			var oRigidbody = m_oGameObj_Player.GetComponentInChildren<Rigidbody>();
			oRigidbody.useGravity = false;
			oRigidbody.linearVelocity = Vector3.zero;

			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_11, false);
		}

		/** 충돌 종료를 처리한다 */
		private void HandleOnTrigger_Exit(CDispatcher_Trigger a_oSender,
			Collider a_oCollider)
		{
			// 충돌 처리가 불가능 할 경우
			if(!a_oCollider.CompareTag("6x_E01Tag_SafeArea_10"))
			{
				return;
			}

			int nScore = C6x_E01Storage_Result_10.Inst.Score;
			C6x_E01Storage_Result_10.Inst.SetScore(nScore + 1);
		}
		#endregion // 함수
	}

	/**
	 * Example 10 - 코루틴
	 */
	public partial class C6x_E01Example_10 : CManager_Scene
	{
		#region 함수
		/** 장애물을 생성한다 */
		private IEnumerator CoTryCreateObstacles()
		{
			do
			{
				var oObstacle = Factory.CreateGameObj_Clone("Obstacle",
					m_oPrefab_Obstacle, m_oGameObj_Obstacles, false);

				oObstacle.transform.localPosition = new Vector3((KDefine.G_WIDTH_DESIGN_SCREEN / 2.0f) + 150.0f,
					0.0f, 0.0f);

				this.ListGameObjects_Obstacle.ExAddVal(oObstacle);
				yield return Access.CoGetWait_ForSecs(2.0f);
			} while(this.State != EState.GAME_OVER);
		}
		#endregion // 함수
	}
}
