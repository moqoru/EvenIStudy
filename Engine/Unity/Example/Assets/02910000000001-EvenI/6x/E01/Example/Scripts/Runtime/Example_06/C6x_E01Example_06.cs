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
	 * Example 6
	 */
	public partial class C6x_E01Example_06 : CManager_Scene
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
		[Header("=====> Example 6 - Etc <=====")]
		[SerializeField] private C6x_E01Player_06 m_oPlayer = null;
		[SerializeField] private List<C6x_E01Turret_06> m_oListTurrets = null;

		private float m_fTime_Survive = 0.0f;
		private Collider[] m_oColliders = new Collider[sbyte.MaxValue];

		[Header("=====> Example 6 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Time = null;

		[Header("=====> Example 6 - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_Bullets = null;
		#endregion // 변수

		#region 프로퍼티
		public EState State { get; private set; } = EState.PLAY;
		public C6x_E01Player_06 Player => m_oPlayer;

		public GameObject GameObj_Bullets => m_oGameObj_Bullets;
		public List<C6x_E01Bullet_06> ListBullets { get; private set; } = new List<C6x_E01Bullet_06>();
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
			C6x_E01Storage_Result_06.Inst.Reset();
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

			m_fTime_Survive += Time.deltaTime;
			m_oTMP_UIText_Time.text = $"{m_fTime_Survive:0.00}";

			m_oPlayer.OnUpdate(a_fTime_Delta);

			for(int i = 0; i < this.ListBullets.Count; ++i)
			{
				this.ListBullets[i].OnUpdate(a_fTime_Delta);
			}
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate_Fixed(float a_fTime_Delta)
		{
			base.OnUpdate_Fixed(a_fTime_Delta);

			// 상태 갱신이 불가능 할 경우
			if(this.State != EState.PLAY)
			{
				return;
			}

			var stPosA = m_oPlayer.transform.localPosition + (Vector3.up * 100.0f);
			stPosA = stPosA.ExToWorld(m_oPlayer.transform.parent.gameObject);

			var stPosB = m_oPlayer.transform.localPosition + (Vector3.down * 100.0f);
			stPosB = stPosB.ExToWorld(m_oPlayer.transform.parent.gameObject);

			/*
			 * Physics.Overlap 계열 메서드는 중첩 된 충돌체를 검사하는 역할을 수행한다. (+ 즉,
			 * 해당 메서드를 활용하면 월드 상에 존재하는 게임 객체 중 중첩 된 게임 객체를 판별하는
			 * 것이 가능하다.)
			 * 
			 * 단, Physics.Overlap 계열 메서드의 입력 데이터는 월드 공간을 기준으로 한 위치 및
			 * 크기 등을 명시해야한다. (+ 즉, 로컬 공간 상의 데이터를 명시 할 경우 잘못된 결과가
			 * 만들어진다는 것을 알 수 있다.)
			 */
			int nNumColliders = Physics.OverlapCapsuleNonAlloc(stPosA,
				stPosB, 0.5f, m_oColliders);

			for(int i = 0; i < nNumColliders; ++i)
			{
				// 총알이 아닐 경우
				if(!m_oColliders[i].CompareTag("6x_E01Tag_Bullet_06"))
				{
					continue;
				}

				this.State = EState.GAME_OVER;
				C6x_E01Storage_Result_06.Inst.SetTime_Survive(m_fTime_Survive);

				CLoader_Scene.Inst.LoadScene(KDefine.G_N_SCENE_EXAMPLE_07, false);
				break;
			}
		}
		#endregion // 함수
	}
}
