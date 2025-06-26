using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#region 타입 - 구조체
/**
 * 콜백 정보
 */
public struct STInfo_Callback
{
	public string m_oKey;
	public System.Action m_oCallback;

	#region 함수
	/** 생성자 */
	public STInfo_Callback(string a_oKey, System.Action a_oCallback)
	{
		this.m_oKey = a_oKey;
		this.m_oCallback = a_oCallback;
	}
	#endregion // 함수
}

/**
 * 컴포넌트 정보
 */
public struct STInfo_Component
{
	public int m_nID;
	public Component m_oComponent;

	/** 생성자 */
	public STInfo_Component(int a_nID, Component a_oComponent)
	{
		this.m_nID = a_nID;
		this.m_oComponent = a_oComponent;
	}
}

/**
 * 정렬 순서 정보
 */
public struct STInfo_SortingOrder
{
	public int m_nOrder;
	public string m_oLayer;

	/** 생성자 */
	public STInfo_SortingOrder(int a_nOrder, string a_oLayer)
	{
		this.m_nOrder = a_nOrder;
		this.m_oLayer = a_oLayer;
	}
}
#endregion // 타입 - 구조체
