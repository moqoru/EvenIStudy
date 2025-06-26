using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace _6x_E01Example
{
	/**
	 * 결과 저장소
	 */
	public partial class C6x_E01Storage_Result_06 : CSingleton<C6x_E01Storage_Result_06>
	{
		#region 프로퍼티
		public float Time_Survive { get; private set; } = 0.0f;
		#endregion // 프로퍼티

		#region 함수
		/** 상태를 리셋한다 */
		public override void Reset()
		{
			base.Reset();
			this.Time_Survive = 0.0f;
		}
		#endregion // 함수

		#region 접근 함수
		/** 생존 시간을 변경한다 */
		public void SetTime_Survive(float a_fTime)
		{
			this.Time_Survive = a_fTime;
		}
		#endregion // 접근 함수
	}
}
