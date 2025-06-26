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
	public partial class C6x_E01Storage_Result_21 : CSingleton<C6x_E01Storage_Result_21>
	{
		#region 프로퍼티
		public bool IsClear { get; private set; } = false;
		#endregion // 프로퍼티

		#region 함수
		/** 상태를 리셋한다 */
		public override void Reset()
		{
			base.Reset();
			this.IsClear = false;
		}
		#endregion // 함수

		#region 접근 함수
		/** 클리어 여부를 변경한다 */
		public void SetIsClear(bool a_bIsClear)
		{
			this.IsClear = a_bIsClear;
		}
		#endregion // 접근 함수
	}
}
