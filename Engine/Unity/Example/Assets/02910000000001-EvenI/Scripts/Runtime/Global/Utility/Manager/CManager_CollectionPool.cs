using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 컬렉션 풀 관리자
 */
public partial class CManager_CollectionPool : CManager_Pool<CManager_CollectionPool, IEnumerable>
{
	#region 프로퍼티
	public override bool IsEnable_Destroy => true;
	#endregion // 프로퍼티

	#region 제네릭 함수
	/** 리스트를 반환한다 */
	public List<T> SpawnList<T>(List<T> a_oListValues_Def = null)
	{
		var oList = this.Spawn<List<T>>(() => new List<T>());
		a_oListValues_Def?.ExCopyValues(oList, (a_tVal) => a_tVal, a_bIsAssert: false);

		return oList;
	}

	/** 딕셔너리를 반환한다 */
	public Dictionary<K, V> SpawnDict<K, V>(Dictionary<K, V> a_oDictValues_Def = null)
	{
		var oDict = this.Spawn<Dictionary<K, V>>(() => new Dictionary<K, V>());
		a_oDictValues_Def?.ExCopyValues(oDict, (_, a_tVal) => a_tVal, a_bIsAssert: false);

		return oDict;
	}

	/** 리스트를 비활성화한다 */
	public void DespawnList<T>(List<T> a_oList, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oList != null);

		// 리스트 비활성이 불가능 할 경우
		if(a_oList == null)
		{
			return;
		}

		a_oList.Clear();
		this.Despawn(a_oList, a_bIsAssert);
	}

	/** 딕셔너리를 비활성화한다 */
	public void DespawnDict<K, V>(Dictionary<K, V> a_oDict, bool a_bIsAssert = true)
	{
		Debug.Assert(!a_bIsAssert || a_oDict != null);

		// 딕셔너리 비활성이 불가능 할 경우
		if(a_oDict == null)
		{
			return;
		}

		a_oDict.Clear();
		this.Despawn(a_oDict, a_bIsAssert);
	}
	#endregion // 제네릭 함수
}