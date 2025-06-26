using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using TMPro;

/*
 * 파티클 (Particle) 이란?
 * - 작은 입자를 의미하며 해당 입자를 통해 여러 효과를 연출하는 것이 가능하다. (+ 즉,
 * 파티클 효과는 파티클의 불규칙한 움직임을 이용해서 시각적인 효과를 연출하는 것을 의미한다.)
 * 
 * Unity 는 파티클 효과를 제작 할 수 있게 슈리켄 (Shuriken) 이라는 시스템을 지원하며 해당 시스템을
 * 활용하면 불규칙한 시각적인 효과를 연출하는 것이 가능하다.
 */
namespace _6x_E01Example
{
	/**
	 * Example 24
	 */
	public partial class C6x_E01Example_24 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 24 - UIs <=====")]
		[SerializeField] private TMP_Text m_oTMP_UIText_Page = null;

		[Header("=====> Example 24 - Game Objects <=====")]
		[SerializeField] private List<GameObject> m_oListGameObjects_Particle = new List<GameObject>();

		private int m_nIdx_Particle = 0;
		#endregion // 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

		/** 상태를 갱신한다 */
		public override void OnUpdate(float a_fTime_Delta)
		{
			base.OnUpdate(a_fTime_Delta);

			m_oTMP_UIText_Page.text = string.Format("{0}/{1}",
				m_nIdx_Particle + 1, m_oListGameObjects_Particle.Count);

			for(int i = 0; i < m_oListGameObjects_Particle.Count; ++i)
			{
				m_oListGameObjects_Particle[i].SetActive(m_nIdx_Particle == i);
			}
		}

		/** 이전 버튼을 눌렀을 경우 */
		public void UIHandleOnBtn_Prev()
		{
			m_nIdx_Particle = Mathf.Max(0, m_nIdx_Particle - 1);
		}

		/** 다음 버튼을 눌렀을 경우 */
		public void UIHandleOnBtn_Next()
		{
			m_nIdx_Particle = Mathf.Min(m_oListGameObjects_Particle.Count - 1, 
				m_nIdx_Particle + 1);
		}
		#endregion // 함수
	}
}
