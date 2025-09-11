using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;
using DG.Tweening;

namespace _6x_E01Example
{
	/**
	 * 점수
	 */
	public partial class C6x_E01UIScore_14_Practice : CComponent
	{
		#region 변수
		[Header("=====> Score - Etc <=====")]
		private Tween m_oAnim_Show = null;

		[Header("=====> Score - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Score = null;
		#endregion // 변수

		#region 함수
		/** 제거되었을 경우 */
		public override void OnDestroy()
		{
			base.OnDestroy();

			/*
			 * DOTween 으로 생성 된 애니메이션은 Unity 렌더링 루프와 무관하게 개별적인 루프를
			 * 지니고 있으므로 게임 객체가 제거 될 경우 반드시 해당 객체와 연관 된 DOTween
			 * 애니메이션도 제거해 줄 필요가 있다. (+ 즉, DOTween 애니메이션을 제거하지 않으면
			 * 이미 제거 된 게임 객체를 대상으로 애니메이션이 실행되기 때문에 내부적으로 문제가
			 * 발생한다는 것을 알 수 있다.)
			 */
			m_oAnim_Show?.Kill();
		}

		/** 점수를 출력한다 */
		public void ShowScore(int a_nScore)
		{
			/*
			 * Mathf.Sign 메서드는 부호를 검사하는 역할을 수행한다. (+ 즉, 해당 메서드의 입력으로
			 * 전달 된 값이 양수 일 경우 양수 값이 반환되며 음수 일 경우 음수 값이 반환된다.)
			 */
			bool bIsIncr = Mathf.Sign(a_nScore).ExIsGreat(0.0f);

			m_oTMP_UIText_Score.text = string.Format("{0}{1}", bIsIncr ? "+" : "", a_nScore);
			m_oTMP_UIText_Score.color = bIsIncr ? Color.white : Color.red;

			float fPos_Y = m_oTMP_UIText_Score.transform.localPosition.y;

			var oAnim_Show = DOTween.Sequence();
			oAnim_Show.Append(m_oTMP_UIText_Score.transform.DOLocalMoveY(fPos_Y + 50.0f, 1.0f));
			oAnim_Show.AppendCallback(() => this.OnCompleteAnim_Show(oAnim_Show));

			Access.AssignVal(ref m_oAnim_Show, oAnim_Show);
		}

		/** 출력 애니메이션이 완료되었을 경우 */
		private void OnCompleteAnim_Show(Sequence a_oSender)
		{
			Destroy(this.gameObject);
		}
		#endregion // 함수
	}
}
