using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 스케줄 관리자 - 컴포넌트
 */
public partial class CManager_Schedule : CSingleton<CManager_Schedule>
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

		var stInfo_Component =
			new STInfo_Component(a_oComponent.GetInstanceID(), a_oComponent);

		m_oListWrapperInfos_Component.m_oListB.ExAddVal(stInfo_Component);
	}

	/** 컴포넌트를 제거한다 */
	public void RemoveComonent(CComponent a_oComponent)
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

		var stInfo_Component =
			new STInfo_Component(a_oComponent.GetInstanceID(), a_oComponent);

		m_oListWrapperInfos_Component.m_oListC.ExAddVal(stInfo_Component);
	}

	/** 컴포넌트 정보 상태를 갱신한다 */
	private void UpdateState_ComponentInfos()
	{
		for(int i = 0; i < m_oListWrapperInfos_Component.m_oListB.Count; ++i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListB[i].m_oComponent as CComponent;
			oComponent.SetCallback_Schedule(this.HandleOnCallback_Schedule);

			m_oListWrapperInfos_Component.m_oListA.ExAddVal(m_oListWrapperInfos_Component.m_oListB[i]);
		}

		for(int i = 0; i < m_oListWrapperInfos_Component.m_oListC.Count; ++i)
		{
			var oComponent = m_oListWrapperInfos_Component.m_oListC[i].m_oComponent as CComponent;
			oComponent.SetCallback_Schedule(null);

			m_oListWrapperInfos_Component.m_oListA.ExRemoveVal((a_stInfo_Component) =>
			{
				return a_stInfo_Component.m_nID == m_oListWrapperInfos_Component.m_oListC[i].m_nID;
			});
		}

		m_oListWrapperInfos_Component.m_oListB.Clear();
		m_oListWrapperInfos_Component.m_oListC.Clear();
	}
	#endregion // 함수
}
