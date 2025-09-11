using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;
using DG.Tweening;

namespace _6x_E01Example
{
	/**
	 * Example 14
	 */
	public partial class C6x_E01Example_14_Practice : CManager_Scene
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
		[Header("=====> Example 14 - Etc <=====")]
		private float m_fTime_Remain = 30.0f;
		private Tween m_oAnim_CameraShake = null;

		[Header("=====> Example 14 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Time = null;
		[SerializeField] private TMP_Text m_oTMP_UIText_Score = null;

		[Header("=====> Example 14 - Game Objects <=====")]
		[SerializeField] private GameObject m_oUIPrefab_Score = null;
		[SerializeField] private GameObject m_oUIGameObj_Scores = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State { get; private set; } = EState.PLAY;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			C6x_E01Storage_Result_14.Inst.Reset();
		}

		/** 제거되었을 경우 */
		public override void OnDestroy()
		{
			base.OnDestroy();
			Access.SetTimeScale(1.0f);

			m_oAnim_CameraShake?.Kill();
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

			m_fTime_Remain = Mathf.Max(m_fTime_Remain - Time.deltaTime, 0.0f);

			m_oTMP_UIText_Time.text = $"{m_fTime_Remain:0.00}";
			m_oTMP_UIText_Score.text = $"{C6x_E01Storage_Result_14.Inst.Score}";

			// 게임이 종료되었을 경우
			if(m_fTime_Remain.ExIsLessEquals(0.0f))
			{
				this.State = EState.GAME_OVER;
				Access.SetTimeScale(0.0f);

				CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_15, false);
			}

			// 마우스 버튼을 눌렀을 경우
			if(Input.GetMouseButtonDown((int)EBtn_Mouse.LEFT))
			{
				this.TryCatchMoly();
			}
		}

		/** 두더지를 잡는다 */
		private void TryCatchMoly()
		{
			/*
			 * ScreenPointToRay 메서드는 화면 위치로부터 광선을 생성하는 역할을 수행한다.
			 * (+ 즉, 해당 메서드를 활용하면 마우스 피킹과 같은 기법에 사용 할 광선을 손쉽게 
			 * 계산하는 것이 가능하다.)
			 * 
			 * Unity 는 월드 공간을 비롯한 여러 공간의 개념을 지니고 있기 때문에 마우스 클릭과
			 * 같은 단순한 연산도 여러 단계를 거쳐야하는 단점이 존재한다. (+ 즉, 일반적으로 마우스
			 * 위치는 화면 공간에 존재하지만 게임 객체는 월드 공간에 존재하기 때문에 공간을
			 * 일치 시키지 않으면 제대로 된 계산을 하는 것이 불가능하다.)
			 * 
			 * 따라서 Unity 는 공간을 변환하기 위한 여러 메서드를 제공하며 해당 메서드를 활용하면
			 * 간단하게 서로 다른 공간에 존재하는 데이터를 기반으로 연산을 수행하는 것이 가능하다.
			 */
			var stRay = this.Camera_Main.ScreenPointToRay(Input.mousePosition);

			// 충돌 대상이 없을 경우
			if(!Physics.Raycast(stRay, out RaycastHit stRaycastHit))
			{
				return;
			}

			/*
			 * GetComponentInParent 메서드는 해당 메서드를 호출한 게임 객체를 포함해서
			 * 부모 게임 객체로부터 컴포넌트를 가져오는 역할을 수행한다. (+ 즉,
			 * GetComponentInChildren 메서드와는 반대로 부모 게임 객체를 대상으로 동작한다는 것을
			 * 알 수 있다.)
			 */
			var oMoly = stRaycastHit.collider.GetComponentInParent<C6x_E01Moly_14_Practice>();

			// 오픈 상태가 아닐 경우
			if(oMoly == null || !oMoly.IsOpen)
			{
				return;
			}

			oMoly.Catch();

			var oAnim_CameraShake = this.Camera_Main.transform.DOShakePosition(0.05f, 0.15f);
			Access.AssignVal(ref m_oAnim_CameraShake, oAnim_CameraShake);

			int nScore = C6x_E01Storage_Result_14.Inst.Score;
			//int nScore_Incr = (oMoly.Type_Moly == C6x_E01Moly_14_Practice.EType_Moly.A) ? 10 : -20;
			int nScore_Incr = 0;

			// (Practice) 종류별로 점수 다르게 설정
			switch (oMoly.Type_Moly)
			{
				case C6x_E01Moly_14_Practice.EType_Moly.A:
					nScore_Incr = 10;
					break;

				case C6x_E01Moly_14_Practice.EType_Moly.D:
					nScore_Incr = -20;
					break;

				case C6x_E01Moly_14_Practice.EType_Moly.A_RAPID:
					nScore_Incr = 20;
					break;

				case C6x_E01Moly_14_Practice.EType_Moly.D_RAPID:
					nScore_Incr = -40;
					break;

				default:
					break;
			}

			C6x_E01Storage_Result_14.Inst.SetScore(Mathf.Max(nScore + nScore_Incr, 0));

			var oScore = Factory.CreateGameObj_Clone<C6x_E01UIScore_14_Practice>("Score",
				m_oUIPrefab_Score, m_oUIGameObj_Scores);

			oScore.transform.localPosition = oMoly.transform.localPosition +
				(Vector3.up * 25.0f);

			oScore.ShowScore(nScore_Incr);
		}
		#endregion // 함수
	}
}
