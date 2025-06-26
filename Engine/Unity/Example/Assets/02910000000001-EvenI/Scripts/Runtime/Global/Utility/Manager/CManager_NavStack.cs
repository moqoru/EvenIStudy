using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 내비게이션 스택 관리자
 */
public partial class CManager_NavStack : CSingleton<CManager_NavStack>
{
	#region 변수
	public CWrapper_List<STInfo_Component> m_oListWrapperInfos_Component = new CWrapper_List<STInfo_Component>();
	#endregion // 변수

	#region 프로퍼티
	public STInfo_Component Info_TopComponent => m_oListWrapperInfos_Component.m_oListA.ExGetVal(m_oListWrapperInfos_Component.m_oListA.Count - 1);
	#endregion // 프로퍼티

	#region 함수
	/** 내비게이션 스택 이벤트를 수신했을 경우 */
	public void OnReceiveEvent_NavStack(EEvent_NavStack a_eEvent)
	{
		// 이벤트 처리가 불가능 할 경우
		if(!m_oListWrapperInfos_Component.m_oListA.ExIsValid())
		{
			return;
		}

		var oComponent_Top = this.Info_TopComponent.m_oComponent as CComponent;
		oComponent_Top.HandleOnEvent_NavStack(a_eEvent);
	}

	/** 내비게이션 스택 콜백을 처리한다 */
	private void HandleOnCallback_NavStack(CComponent a_oSender)
	{
		this.RemoveComponent(a_oSender);
	}
	#endregion // 함수
}
