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
		}
		#endregion // 함수
	}
}
