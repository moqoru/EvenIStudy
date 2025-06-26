using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 게임 객체 풀 관리자
 */
public partial class CManager_GameObjPool : CManager_Pool<CManager_GameObjPool, GameObject>
{
	#region 프로퍼티
	public override bool IsEnable_Destroy => true;
	#endregion // 프로퍼티

	#region 함수
	/** 게임 객체를 반환한다 */
	public GameObject SpawnGameObj(string a_oName_GameObj,
		string a_oPath_GameObj, GameObject a_oGameObj_Parent)
	{
		return this.Spawn(a_oPath_GameObj,
			() => Factory.CreateGameObj_Clone(a_oName_GameObj, a_oPath_GameObj, a_oGameObj_Parent));
	}

	/** 게임 객체를 비활성화한다 */
	public void DespawnGameObj(string a_oPath_GameObj, GameObject a_oGameObj)
	{
		this.Despawn(a_oPath_GameObj, a_oGameObj);
	}
	#endregion // 함수

	#region 제네릭 함수
	/** 게임 객체를 반한한다 */
	public T SpawnGameObj<T>(string a_oName_GameObj,
		string a_oPath_GameObj, GameObject a_oGameObj_Parent) where T : Component
	{
		var oGameObj = this.SpawnGameObj(a_oName_GameObj,
			a_oPath_GameObj, a_oGameObj_Parent);

		return oGameObj.GetComponentInChildren<T>();
	}
	#endregion // 제네릭 함수
}
