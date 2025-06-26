using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 플레이어
	 */
	public partial class C6x_E01Player_06 : CComponent
	{
		#region 변수
		[Header("=====> Player - Etc <=====")]
		[SerializeField] private float m_fSpeed = 0.0f;
		#endregion // 변수

		#region 함수
		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			/*
			 * Input.GetAxis 계열 메서드는 입력 장치의 축 정보를 가져오는 역할을 수행한다. (+ 즉,
			 * 해당 계열 메서드를 활용하면 게임 패드와 같이 조이 스틱이 존재하는 입력 장치를 제어
			 * 할 수 있다는 것을 알 수 있다.)
			 */
			float fVertical = Input.GetAxis(KDefine.G_N_AXIS_VERTICAL);
			float fHorizontal = Input.GetAxis(KDefine.G_N_AXIS_HORIZONTAL);

			var stDirection = (Vector3.forward * fVertical) +
				(Vector3.right * fHorizontal);

			stDirection = stDirection.magnitude.ExIsGreat(1.0f) ?
				stDirection.normalized : stDirection;

			var stPos = this.transform.localPosition;
			stPos += stDirection * m_fSpeed * a_fTime_Delta;

			stPos.x = Mathf.Clamp(stPos.x,
				KDefine.G_WIDTH_DESIGN_SCREEN / -2.0f, KDefine.G_WIDTH_DESIGN_SCREEN / 2.0f);

			stPos.z = Mathf.Clamp(stPos.z,
				KDefine.G_HEIGHT_DESIGN_SCREEN / -2.0f, KDefine.G_HEIGHT_DESIGN_SCREEN / 2.0f);

			this.transform.localPosition = stPos;
		}
		#endregion // 함수
	}
}
