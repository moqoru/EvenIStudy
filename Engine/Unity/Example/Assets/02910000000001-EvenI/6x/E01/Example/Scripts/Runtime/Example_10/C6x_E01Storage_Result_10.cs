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
	public partial class C6x_E01Storage_Result_10 : CSingleton<C6x_E01Storage_Result_10>
	{
		#region 프로퍼티
		public int Score { get; private set; } = 0;
		#endregion // 프로퍼티

		#region 함수
		/** 상태를 리셋한다 */
		public override void Reset()
		{
			base.Reset();
			this.Score = 0;
		}
		#endregion // 함수

		#region 접근 함수
		/** 점수를 변경한다 */
		public void SetScore(int a_nScore)
		{
			this.Score = a_nScore;
		}
		#endregion // 접근 함수
	}
}
