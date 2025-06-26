using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/** 
 * 전역 싱글턴 
 */
public partial class CGSingleton : CSingleton<CGSingleton>
{
	#region 프로퍼티
	public NetworkReachability Reachability_Network { get; private set; } = NetworkReachability.NotReachable;
	public Vector3 Size_DeviceScreen { get; private set; } = Vector3.zero;
	#endregion // 프로퍼티

	#region 함수
	/** 레이아웃을 재배치한다 */
	public void RebuildLayouts(GameObject a_oObj)
	{
		var oListLayoutGroups = CManager_CollectionPool.Inst.SpawnList<LayoutGroup>();
		var oListFitters_ContentSize = CManager_CollectionPool.Inst.SpawnList<ContentSizeFitter>();

		try
		{
			a_oObj?.GetComponentsInChildren(true, oListLayoutGroups);
			a_oObj?.GetComponentsInChildren(true, oListFitters_ContentSize);

			this.RebuildLayouts(oListLayoutGroups);
			this.RebuildLayouts(oListFitters_ContentSize);
		}
		finally
		{
			CManager_CollectionPool.Inst.DespawnList(oListLayoutGroups);
			CManager_CollectionPool.Inst.DespawnList(oListFitters_ContentSize);
		}
	}
	#endregion // 함수

	#region 접근 함수
	/** 네트워크 상태를 변경한다 */
	public void SetReachability_Network(NetworkReachability a_eReachability)
	{
		this.Reachability_Network = a_eReachability;
	}

	/** 디바이스 화면 크기를 변경한다 */
	public void SetSize_DeviceScreen(Vector3 a_stSize)
	{
		this.Size_DeviceScreen = a_stSize;
	}
	#endregion // 접근 함수

	#region 제네릭 함수
	/** 레이아웃을 재배치한다 */
	private void RebuildLayouts<T>(List<T> a_oListComponents) where T : Component
	{
		for(int i = 0; i < a_oListComponents.Count; ++i)
		{
			/*
			 * LayoutRebuilder 클래스란?
			 * - Layout Group 계열 컴포넌트에서 파생 된 컴포넌트를 재정렬하는 클래스를 의미한다.
			 * (+ 즉, UI 게임 객체 계층에 Layout Group 계열 컴포넌트가 중복으로 존재 할 경우
			 * 내부적으로 연산 순서 차이에 의해서 원치 않는 결과가 만들어진다는 것 을 알 수 있다.)
			 * 
			 * 따라서 Layout Group 계열 컴포넌트가 중복으로 존재 할 경우 반드시 해당 클래스를
			 * UI 컴포넌트의 레이아웃 배치를 갱신해 줄 필요가 있다.
			 */
			LayoutRebuilder.ForceRebuildLayoutImmediate(a_oListComponents[i].transform as RectTransform);
		}

		for(int i = a_oListComponents.Count - 1; i >= 0; --i)
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(a_oListComponents[i].transform as RectTransform);
		}
	}
	#endregion // 제네릭 함수
}
