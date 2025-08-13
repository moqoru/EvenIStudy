using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Practice
{
	/*
	public partial class C6x_E01Obstacle_10 : CComponent
	{
		#region 변수
		[Header("=====> Obstacle - Game Objects <=====")]
		[SerializeField] private GameObject m_oGameObj_TopObstacle = null;
		[SerializeField] private GameObject m_oGameObj_BottomObstacle = null;

		[SerializeField] private GameObject m_oGameObj_SafeArea = null;
		#endregion // 변수

		#region 함수
		public override void Awake()
		{
			base.Awake();

			float fRate_SafeArea = 0.4f;
			float fAdjust_SafeArea = Random.Range(-0.3f, 0.3f);

			// 비율을 설정한다 {
			var stScale_TopObstacle = m_oGameObj_TopObstacle.transform.localScale;

			// 상하 장애물의 길이를 화면 전체로 변경
			stScale_TopObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN;

			var stScale_BottomObstacle = m_oGameObj_BottomObstacle.transform.localScale;

			stScale_BottomObstacle.y = KDefine.G_HEIGHT_DESIGN_SCREEN;

			var stScale_SafeArea = m_oGameObj_SafeArea.transform.localScale;

			stScale_SafeArea.y = KDefine.G_HEIGHT_DESIGN_SCREEN * fRate_SafeArea;

			m_oGameObj_TopObstacle.transform.localScale = stScale_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localScale = stScale_BottomObstacle;
			m_oGameObj_SafeArea.transform.localScale = stScale_SafeArea;


			// 비율을 설정한다 }

			// 위치를 설정한다 {

			var stPos_SafeArea = m_oGameObj_SafeArea.transform.localPosition;
			stPos_SafeArea.y = KDefine.G_HEIGHT_DESIGN_SCREEN * fAdjust_SafeArea;

			var stPos_TopObstacle = m_oGameObj_TopObstacle.transform.localPosition;

			stPos_TopObstacle.y = (KDefine.G_HEIGHT_DESIGN_SCREEN * (0.5f + fRate_SafeArea * 0.5f)) +
				stPos_SafeArea.y;

			var stPos_BottomObstacle = m_oGameObj_BottomObstacle.transform.localPosition;

			stPos_BottomObstacle.y = (-KDefine.G_HEIGHT_DESIGN_SCREEN * (0.5f + fRate_SafeArea * 0.5f)) +
				stPos_SafeArea.y;

			m_oGameObj_TopObstacle.transform.localPosition = stPos_TopObstacle;
			m_oGameObj_BottomObstacle.transform.localPosition = stPos_BottomObstacle;
			m_oGameObj_SafeArea.transform.localPosition = stPos_SafeArea;


			// 위치를 설정한다 }
		}
		#endregion // 함수
	}
	*/
}
