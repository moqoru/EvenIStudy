using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * Example 21
	 */
	public partial class C6x_E01Example_21 : CManager_Scene
	{
		/**
		 * 상태
		 */
		private enum EState
		{
			NONE = -1,
			PLAY,
			GAME_OVER,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Example 21 - Etc <=====")]
		[SerializeField] private C6x_E01Player_21 m_oPlayer = null;
		[SerializeField] private List<C6x_E01NonPlayer_21> m_oListNonPlayers = new List<C6x_E01NonPlayer_21>();

		private EState m_eState = EState.PLAY;

		[Header("=====> Example 21 - UIs <=====")]
		[SerializeField] private Image m_oUIImg_HPGauge = null;
		#endregion // 변수

		#region 프로퍼티
		public C6x_E01Player_21 Player => m_oPlayer;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			C6x_E01Storage_Result_21.Inst.Reset();
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			// 상태 갱신이 불가능 할 경우
			if(m_eState != EState.PLAY)
			{
				return;
			}

			m_oPlayer.OnUpdate(Time.deltaTime);

			for(int i = 0; i < m_oListNonPlayers.Count; ++i)
			{
				m_oListNonPlayers[i].OnUpdate(Time.deltaTime);
			}
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate_Late(float a_fTime_Delta)
		{
			base.OnUpdate_Late(a_fTime_Delta);
			m_oUIImg_HPGauge.fillAmount = this.Player.Hp / this.Player.Hp_Origin;
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate_Fixed(float a_fTime_Delta)
		{
			base.OnUpdate_Fixed(a_fTime_Delta);

			// 상태 갱신이 불가능 할 경우
			if(m_eState != EState.PLAY)
			{
				return;
			}

			m_oPlayer.OnUpdate_Fixed(Time.fixedDeltaTime);
		}

		/** 플레이어 사망 이벤트를 처리한다 */
		public void HandleOnEvent_DeathPlayer(C6x_E01Player_21 a_oSender)
		{
			// 종료 처리가 불가능 할 경우
			if(m_eState != EState.PLAY)
			{
				return;
			}

			m_eState = EState.GAME_OVER;
			C6x_E01Storage_Result_21.Inst.SetIsClear(false);

			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_22, false);
		}

		/** NPC 사망 이벤트를 처리한다 */
		public void HandleOnEvent_DeathNonPlayer(C6x_E01NonPlayer_21 a_oNonPlayer)
		{
			m_oListNonPlayers.ExRemoveVal(a_oNonPlayer);

			// 남은 NPC 가 존재 할 경우
			if(m_oListNonPlayers.Count > 0 || m_eState != EState.PLAY)
			{
				return;
			}

			m_eState = EState.GAME_OVER;
			C6x_E01Storage_Result_21.Inst.SetIsClear(true);

			CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_22, false);
		}
		#endregion // 함수
	}
}
