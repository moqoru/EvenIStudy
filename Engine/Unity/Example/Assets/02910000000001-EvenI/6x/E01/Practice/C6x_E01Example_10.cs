using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace _6x_E01Practice
{
	/*
		// 사용자 정의 클래스 추가 : 장애물과 타입, 이동 방향

		public enum EObstacleType
		{
			NORMAL = 0,
			MOVE,
			MAX_VAL
		}
		public partial class ObstacleClass
		{
			public GameObject GObjectVal { get; set; }
			public EObstacleType TypeVal { get; set; }
			public bool DirectionVal { get; set; }
		}

		public partial class C6x_E01Example_10 : CManager_Scene
		{
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
			//public List<GameObject> ListGameObjects_Obstacle { get; private set; } = new List<GameObject>();
			public List<ObstacleClass> ListGameObjects_Obstacle { get; private set; } = new List<ObstacleClass>();
			#endregion // 프로퍼티

			#region 함수

			public override void Awake()
			{
				base.Awake();
				C6x_E01Storage_Result_10.Inst.Reset();

				var oRigidbody = m_oGameObj_Player.GetComponentInChildren<Rigidbody>();
				oRigidbody.useGravity = true;

				oRigidbody.constraints = RigidbodyConstraints.FreezePositionX |
					RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;

				var oDispatcher_Trigger = m_oGameObj_Player.GetComponentInChildren<CDispatcher_Trigger>();
				oDispatcher_Trigger.SetCallback_Enter(this.HandleOnTrigger_Enter);
				oDispatcher_Trigger.SetCallback_Exit(this.HandleOnTrigger_Exit);
			}

			public override void Start()
			{
				base.Start();
				StartCoroutine(this.CoTryCreateObstacles());
			}

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
					oObstacle.GObjectVal.transform.localPosition += (Vector3.left * 350.0f) * a_fTime_Delta;

					if(oObstacle.TypeVal != EObstacleType.MOVE)
					{
						continue;
					}
					// 움직이는 장애물에 대해서만 다음과 같이 처리
					// 방향이 true이면 아래로, false이면 위로 이동
					// 단, 움직인 범위가 +-100.0f 이상이거나 1%의 확률로 방향 전환이 된다면 방향 전환
					
					float changeDirection = Random.Range(0.0f, 1.0f);
					if(oObstacle.DirectionVal == true)
					{
						oObstacle.GObjectVal.transform.localPosition += (Vector3.down * 200.0f) * a_fTime_Delta;
						if(oObstacle.GObjectVal.transform.localPosition.y <= -100.0f || changeDirection < 0.01f)
						{
							oObstacle.DirectionVal = false;
						}
					}
					else
					{
						oObstacle.GObjectVal.transform.localPosition += (Vector3.up * 200.0f) * a_fTime_Delta;
						if(oObstacle.GObjectVal.transform.localPosition.y >= 100.0f || changeDirection < 0.01f)
						{
							oObstacle.DirectionVal = true;
						}
					}
				}
				if(this.ListGameObjects_Obstacle[0].GObjectVal.transform.localPosition.x <= -1100.0f)
				{
					this.ListGameObjects_Obstacle.RemoveAt(0);
				}

			}

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

			private void HandleOnTrigger_Exit(CDispatcher_Trigger a_oSender,
				Collider a_oCollider)
			{
				// 충돌 처리가 불가능 할 경우
				if(!a_oCollider.CompareTag("6x_E01Tag_SafeArea_10"))
				{
					return;
				}

				int nScore = C6x_E01Storage_Result_10.Inst.Score;
				int plusScore = 1;

				if(this.ListGameObjects_Obstacle[0].TypeVal == EObstacleType.MOVE)
				{
					plusScore = 2;
				}
				//Func.ShowLog(a_oCollider.name);

				C6x_E01Storage_Result_10.Inst.SetScore(nScore + plusScore);
			}
			#endregion // 함수
		}

		public partial class C6x_E01Example_10 : CManager_Scene
		{
			#region 함수

			private IEnumerator CoTryCreateObstacles()
			{
				do
				{
					var oObstacle = Factory.CreateGameObj_Clone("Obstacle",
						m_oPrefab_Obstacle, m_oGameObj_Obstacles, false);

					oObstacle.transform.localPosition = new Vector3((KDefine.G_WIDTH_DESIGN_SCREEN / 2.0f) + 150.0f,
						0.0f, 0.0f);

					// 2종류의 방해물을 만들고, 클래스 자료형의 리스트로 관리
					int typeIdx = Random.Range(0, 2);
					EObstacleType typeEnum = EObstacleType.NORMAL;
					if(typeIdx < 1)
						typeEnum = EObstacleType.MOVE;

					this.ListGameObjects_Obstacle.ExAddVal(new ObstacleClass
					{
						GObjectVal = oObstacle,
						TypeVal = typeEnum,
						DirectionVal = true
					});
					//this.ListGameObjects_Obstacle.ExAddVal(oObstacle);
					yield return Access.CoGetWait_ForSecs(2.0f);
				} while(this.State != EState.GAME_OVER);
			}
			#endregion // 함수
		}
	*/
}
