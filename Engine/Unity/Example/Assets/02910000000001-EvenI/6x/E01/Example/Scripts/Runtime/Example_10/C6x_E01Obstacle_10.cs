using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 장애물
	 */
	public partial class C6x_E01Obstacle_10 : CComponent
	{
		#region 변수
		[Header("=====> Obstacle - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_TopObstacle = null;
		[SerializeField] private GameObject m_oGameObj_BottomObstacle = null;

		[SerializeField] private GameObject m_oGameObj_SafeArea = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

#if _6x_P01_PRACTICE_02
			this.Awake_Internal();
#else
			float fRate_SafeArea = 0.35f;
			float fRate_Obstacle = 1.0f - fRate_SafeArea;

			float fRate_TopObstacle = Random.Range(0.1f, 0.9f);
			float fRate_BottomObstacle = 1.0f - fRate_TopObstacle;

			// 비율을 설정한다 {
			var stScale_TopObstacle = m_oGameObj_TopObstacle.transform.localScale;

			stScale_TopObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN *
				fRate_Obstacle * fRate_TopObstacle;

			var stScale_BottomObstacle = m_oGameObj_BottomObstacle.transform.localScale;

			stScale_BottomObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN *
				fRate_Obstacle * fRate_BottomObstacle;

			var stScale_SafeArea = m_oGameObj_SafeArea.transform.localScale;
			stScale_SafeArea.y = KDefine.G_HEIGHT_DESIGN_SCREEN * fRate_SafeArea;

			m_oGameObj_TopObstacle.transform.localScale = stScale_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localScale = stScale_BottomObstacle;
			m_oGameObj_SafeArea.transform.localScale = stScale_SafeArea;
			// 비율을 설정한다 }

			// 위치를 설정한다 {
			var stPos_TopObstacle = m_oGameObj_TopObstacle.transform.localPosition;

			stPos_TopObstacle.y = (KDefine.G_HEIGHT_DESIGN_SCREEN / 2.0f) -
				(stScale_TopObstacle.y / 2.0f);

			var stPos_BottomObstacle = m_oGameObj_BottomObstacle.transform.localPosition;

			stPos_BottomObstacle.y = (KDefine.G_HEIGHT_DESIGN_SCREEN / -2.0f) +
				(stScale_BottomObstacle.y / 2.0f);

			var stPos_SafeArea = m_oGameObj_SafeArea.transform.localPosition;

			stPos_SafeArea.y = stPos_TopObstacle.y -
				(stScale_TopObstacle.y / 2.0f) - (stScale_SafeArea.y / 2.0f);

			m_oGameObj_TopObstacle.transform.localPosition = stPos_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localPosition = stPos_BottomObstacle;
			m_oGameObj_SafeArea.transform.localPosition = stPos_SafeArea;
			// 위치를 설정한다 }
#endif // #if _6x_P01_PRACTICE_02
		}
		#endregion // 함수
	}

#if _6x_P01_PRACTICE_02
	/**
	 * 장애물 - 과제
	 */
	public partial class C6x_E01Obstacle_10 : CComponent
	{
		/**
		 * 장애물 타입
		 */
		public enum EType_Obstacle
		{
			NONE = -1,
			NORM,
			SPECIAL,
			[HideInInspector] MAX_VAL
		}

		#region 변수
		[Header("=====> Obstacle - Etc <=====")]
		[SerializeField] private List<Material> m_oListMaterials = new List<Material>();

		private float m_fRate_TopObstacle = 0.0f;
		private float m_fWeight_Direction = 0.0f;
		#endregion // 변수

		#region 프로퍼티
		public EType_Obstacle Type_Obstacle { get; private set; } = EType_Obstacle.NONE;
		#endregion // 프로퍼티

		#region 함수
		/** 초기화 */
		private void Awake_Internal()
		{
			this.Type_Obstacle = (EType_Obstacle)Random.Range((int)EType_Obstacle.NORM,
				(int)EType_Obstacle.MAX_VAL);

			m_fRate_TopObstacle = Random.Range(0.1f, 0.9f);
			m_fWeight_Direction = (Random.Range(0, 2) <= 0) ? 1.0f : -1.0f;

			var oMat_TopObstacle = m_oGameObj_TopObstacle.GetComponentInChildren<MeshRenderer>();
			oMat_TopObstacle.sharedMaterial = m_oListMaterials[(int)this.Type_Obstacle];

			var oMat_BottomObstacle = m_oGameObj_BottomObstacle.GetComponentInChildren<MeshRenderer>();
			oMat_BottomObstacle.sharedMaterial = m_oListMaterials[(int)this.Type_Obstacle];

			this.SetupObstacles(m_fRate_TopObstacle);
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			// 특수 장애물이 아닐 경우
			if(this.Type_Obstacle != EType_Obstacle.SPECIAL)
			{
				return;
			}

			m_fRate_TopObstacle += m_fWeight_Direction * a_fTime_Delta * 0.1f;
			m_fRate_TopObstacle = Mathf.Clamp(m_fRate_TopObstacle, 0.1f, 0.9f);

			// 방향 전환이 필요 할 경우
			if(m_fRate_TopObstacle.ExIsLessEquals(0.1f) ||
				m_fRate_TopObstacle.ExIsGreatEquals(0.9f))
			{
				m_fWeight_Direction = -m_fWeight_Direction;
			}

			this.SetupObstacles(m_fRate_TopObstacle);
		}

		/** 장애물을 설정한다 */
		private void SetupObstacles(float a_fRate_TopObstacle)
		{
			float fRate_SafeArea = 0.35f;
			float fRate_Obstacle = 1.0f - fRate_SafeArea;

			float fRate_TopObstacle = a_fRate_TopObstacle;
			float fRate_BottomObstacle = 1.0f - fRate_TopObstacle;

			// 비율을 설정한다 {
			var stScale_TopObstacle = m_oGameObj_TopObstacle.transform.localScale;

			stScale_TopObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN *
				fRate_Obstacle * fRate_TopObstacle;

			var stScale_BottomObstacle = m_oGameObj_BottomObstacle.transform.localScale;

			stScale_BottomObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN *
				fRate_Obstacle * fRate_BottomObstacle;

			var stScale_SafeArea = m_oGameObj_SafeArea.transform.localScale;
			stScale_SafeArea.y = KDefine.G_HEIGHT_DESIGN_SCREEN * fRate_SafeArea;

			m_oGameObj_TopObstacle.transform.localScale = stScale_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localScale = stScale_BottomObstacle;
			m_oGameObj_SafeArea.transform.localScale = stScale_SafeArea;
			// 비율을 설정한다 }

			// 위치를 설정한다 {
			var stPos_TopObstacle = m_oGameObj_TopObstacle.transform.localPosition;

			stPos_TopObstacle.y = (KDefine.G_HEIGHT_DESIGN_SCREEN / 2.0f) -
				(stScale_TopObstacle.y / 2.0f);

			var stPos_BottomObstacle = m_oGameObj_BottomObstacle.transform.localPosition;

			stPos_BottomObstacle.y = (KDefine.G_HEIGHT_DESIGN_SCREEN / -2.0f) +
				(stScale_BottomObstacle.y / 2.0f);

			var stPos_SafeArea = m_oGameObj_SafeArea.transform.localPosition;

			stPos_SafeArea.y = stPos_TopObstacle.y -
				(stScale_TopObstacle.y / 2.0f) - (stScale_SafeArea.y / 2.0f);

			m_oGameObj_TopObstacle.transform.localPosition = stPos_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localPosition = stPos_BottomObstacle;
			m_oGameObj_SafeArea.transform.localPosition = stPos_SafeArea;
			// 위치를 설정한다 }
		}
		#endregion // 함수
	}
#endif // #if _6x_P01_PRACTICE_02
}
