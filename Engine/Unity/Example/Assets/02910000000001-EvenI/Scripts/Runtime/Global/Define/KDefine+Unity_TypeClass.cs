using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#region 타입 - 클래스
/**
 * 리스트 래퍼
 */
public class CWrapper_List<T>
{
	#region 변수
	public List<T> m_oListA = new List<T>();
	public List<T> m_oListB = new List<T>();
	public List<T> m_oListC = new List<T>();
	#endregion // 변수

	#region 함수
	/** 상태를 초기화한다 */
	public void Clear()
	{
		m_oListA.Clear();
		m_oListB.Clear();
		m_oListC.Clear();
	}
	#endregion // 함수
}

/**
 * 딕셔너리 래퍼
 */
public class CWrapper_Dict<K, V>
{
	#region 변수
	public Dictionary<K, V> m_oDictA = new Dictionary<K, V>();
	public Dictionary<K, V> m_oDictB = new Dictionary<K, V>();
	public Dictionary<K, V> m_oDictC = new Dictionary<K, V>();
	#endregion // 변수

	#region 함수
	/** 상태를 초기화한다 */
	public void Clear()
	{
		m_oDictA.Clear();
		m_oDictB.Clear();
		m_oDictC.Clear();
	}
	#endregion // 함수
}

/**
 * 리스트 큐 래퍼
 */
public class CWrapper_ListQueue<T>
{
	#region 변수
	public List<T> m_oList = new List<T>();
	public Queue<T> m_oQueue = new Queue<T>();
	#endregion // 변수

	#region 변수
	/** 상태를 초기화한다 */
	public void Clear()
	{
		m_oList.Clear();
		m_oQueue.Clear();
	}
	#endregion // 변수
}
#endregion // 타입 - 클래스
