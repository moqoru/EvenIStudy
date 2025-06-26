using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 카메라 컨트롤러
	 */
	public partial class C6x_E01Controller_Camera_21 : CComponent
	{
		#region 변수
		[Header("=====> Camera Controller - Etc <=====")]
		[SerializeField] private float m_fHeight = 350.0f;
		[SerializeField] private float m_fOffset = 150.0f;
		[SerializeField] private float m_fDistance = 750.0f;

		[SerializeField] private float m_fSpeed_Lerp = 15.0f;

		[Header("=====> Camera Controller - Game Objects <=====")]
		[SerializeField] private GameObject m_oTarget_Follow = null;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Start()
		{
			base.Start();
			this.UpdatePos(true);
		}

		/** 상태를 갱신한다 */
		public void LateUpdate()
		{
			this.UpdatePos();
		}

		/** 위치를 갱신한다 */
		private void UpdatePos(bool a_bIsImmediate = false)
		{
			// 상태 갱신이 불가능 할 경우
			if(m_oTarget_Follow == null)
			{
				return;
			}

			var stPos_Base = m_oTarget_Follow.transform.position;
			var stPos_Height = Vector3.up * m_fHeight * KDefine.G_UNIT_SCALE;
			var stPos_Offset = Vector3.up * m_fOffset * KDefine.G_UNIT_SCALE;

			var stPos_Distance = -m_oTarget_Follow.transform.forward * 
				m_fDistance * KDefine.G_UNIT_SCALE;

			// 즉시 갱신 모드 일 경우
			if(a_bIsImmediate)
			{
				this.transform.position = stPos_Base + stPos_Distance + stPos_Height;
			}
			else
			{
				var stPos_Start = this.transform.position;
				var stPos_End = stPos_Base + stPos_Distance + stPos_Height;

				/*
				 * Lerp 메서드는 선형 보간 결과를 계산하는 역할을 수행한다. (+ 즉, 해당 메서드를
				 * 활용하면 시간에 따른 중간 값을 계산하는 것이 가능하다.)
				 */
				this.transform.position = Vector3.Lerp(stPos_Start,
					stPos_End, Time.deltaTime * m_fSpeed_Lerp);
			}

			this.transform.LookAt(stPos_Base + stPos_Offset);
		}
		#endregion // 함수
	}
}
