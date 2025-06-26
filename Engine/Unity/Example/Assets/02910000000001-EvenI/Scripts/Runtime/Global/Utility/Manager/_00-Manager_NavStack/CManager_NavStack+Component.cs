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
	#region 함수
	/** 컴포넌트를 추가한다 */
	public void AddComponent(CComponent a_oComponent)
	{
		int nResult = m_oListWrapperInfos_Component.m_oListA.ExFindVal((a_stInfo_Component) =>
		{
			return a_stInfo_Component.m_nID == a_oComponent.GetInstanceID();
		});

		// 컴포넌트 추가가 불가능 할 경우
		if(m_oListWrapperInfos_Component.m_oListA.ExIsValid_Idx(nResult))
		{
			return;
		}

		a_oComponent.SetCallback_NavStack(this.HandleOnCallback_NavStack);

		var stInfo_Component = new STInfo_Component(a_oComponent.GetInstanceID(),
			a_oComponent);

		m_oListWrapperInfos_Component.m_oListA.ExAddVal(stInfo_Component);
		this.OnReceiveEvent_NavStack(EEvent_NavStack.TOP);
	}

	/** 컴포넌트를 제거한다 */
	public void RemoveComponent(CComponent a_oComponent)
	{
		int nResult = m_oListWrapperInfos_Component.m_oListA.FindIndex((a_stInfo_Component) =>
		{
			return a_stInfo_Component.m_nID == a_oComponent.GetInstanceID();
		});

		// 컴포넌트 제거가 불가능 할 경우
		if(!m_oListWrapperInfos_Component.m_oListA.ExIsValid_Idx(nResult))
		{
			return;
		}

		for(int i = m_oListWrapperInfos_Component.m_oListA.Count - 1; i >= nResult; --i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListA[i].m_oComponent as CComponent;
			oComponent.SetCallback_NavStack(null);

			oComponent.HandleOnEvent_NavStack(EEvent_NavStack.REMOVE);
		}

		m_oListWrapperInfos_Component.m_oListA.RemoveRange(
			nResult, m_oListWrapperInfos_Component.m_oListA.Count - nResult);

		this.OnReceiveEvent_NavStack(EEvent_NavStack.TOP);
	}
	#endregion // 함수
}
