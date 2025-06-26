using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/** 
 * 크기 조정자
 */
public partial class CUIAdjuster_Size : CComponent
{
	#region 변수
	[Header("=====> Adjuster Size - Etc <=====")]
	[SerializeField] private Vector3 m_stRate_ContentsSize = Vector3.one;
	#endregion // 변수

	#region 함수
	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		CManager_Schedule.Inst.AddComponent(this);
	}

	/** 초기화 */
	public override void Start()
	{
		base.Start();
		this.SetRate_ContentsSize(m_stRate_ContentsSize);
	}

	/** 상태를 갱신한다 */
	public override void OnUpdate_Late(float a_fTime_Delta)
	{
		base.OnUpdate_Late(a_fTime_Delta);

		// 앱이 종료되었을 경우
		if(!CManager_Scene.IsRunning_App)
		{
			return;
		}

		var stSize = CManager_Scene.ActiveScene_UISize_Canvas.ExGetVec_Scale(m_stRate_ContentsSize);
		var oRectTrans = this.transform as RectTransform;

		oRectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
			Mathf.Ceil(stSize.y));

		oRectTrans.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
			Mathf.Ceil(stSize.x));
	}
	#endregion // 함수

	#region 접근 함수
	/** 컨텐츠 크기 비율을 변경한다 */
	public void SetRate_ContentsSize(Vector3 a_stRate)
	{
		m_stRate_ContentsSize.x = Mathf.Clamp01(a_stRate.x);
		m_stRate_ContentsSize.y = Mathf.Clamp01(a_stRate.y);
		m_stRate_ContentsSize.z = Mathf.Clamp01(a_stRate.z);
	}
	#endregion // 접근 함수
}
