using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 팩토리 - 게임 객체
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		/* 
		 * new 키워드를 활용하면 새로운 게임 객체를 생성하는 것이 가능하다.
		 * 
		 * 단, 해당 키워드를 통해 생성 된 게임 객체는 Transform 컴포넌트만 지니고 있기 때문에
		 * 관련 된 컴포넌트를 명시적으로 설정해줘야하는 단점이 존재한다.
		 */
		var oGameObj = new GameObject(a_oName);
		oGameObj.transform.SetParent(a_oGameObj_Parent?.transform, a_bIsStay_WorldState);

		oGameObj.transform.localPosition = a_stPos;
		oGameObj.transform.localScale = a_stScale;
		oGameObj.transform.localEulerAngles = a_stRotate;

		return oGameObj;
	}
	#endregion // 클래스 팩토리 함수

	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj<T>(a_oName,
			a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj<T>(a_oName,
			a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj<T>(string a_oName,
		GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj(a_oName,
			a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState).ExAddComponent<T>();
	}
	#endregion // 클래스 팩토리 함수
}

/**
 * 팩토리 - 게임 객체 (사본)
 */
public static partial class Factory
{
	#region 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false)
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static GameObject CreateGameObj_Clone(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false)
	{
		/*
		 * Instantiate 메서드란?
		 * - 원본 게임 객체를 기반으로 사본 게임 객체를 생성하는 역할을 수행하는 메서드이다. (+ 즉, 
		 * 해당 메서드를 활용하면 간단하게 새로운 객체를 생성하는 것이 가능하다.)
		 * 
		 * Unity 는 컴포넌트 기반 구조로 동작하기 때문에 특정 게임 객체를 생성했다고 하더라도
		 * 컴포넌트를 설정해주지 않으면 아무런 역할도 하지 않는다. (+ 즉, 새로운 게임 객체를 
		 * 생성하기 위해서는 객체를 생성 후 관련 컴포넌트를 추가 및 설정해 줄 필요가 있다.)
		 * 
		 * 따라서 Unity 는 새로운 게임 객체를 생성하기 위해서 별도의 원본 게임 객체를 설정 후 해당 
		 * 게임 객체를 복사하는 형태로 새로운 객체를 생성하는 것이 일반적이다. (+ 즉, 
		 * 원본 게임 객체를 기반으로 사본 게임 객체를 생성하면 원본 게임 객체가 지니고 있는
		 * 컴포넌트가 같이 사본 게임 객체에 설정된다는 것을 알 수 있다.)
		 */
		var oGameObj = MonoBehaviour.Instantiate(a_oPrefab_Origin,
			Vector3.zero, Quaternion.identity);

		oGameObj.name = a_oName;
		oGameObj.transform.SetParent(a_oGameObj_Parent?.transform, a_bIsStay_WorldState);

		oGameObj.transform.localPosition = a_stPos;
		oGameObj.transform.localScale = a_stScale;
		oGameObj.transform.localEulerAngles = a_stRotate;

		return oGameObj;
	}
	#endregion // 클래스 팩토리 함수

	#region 제네릭 클래스 팩토리 함수
	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPath_Prefab, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		string a_oPath_Prefab, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			Resources.Load<GameObject>(a_oPath_Prefab), a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone<T>(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, Vector3.one, Vector3.zero, a_bIsStay_WorldState);
	}

	/** 객체를 생성한다 */
	public static T CreateGameObj_Clone<T>(string a_oName,
		GameObject a_oPrefab_Origin, GameObject a_oGameObj_Parent, Vector3 a_stPos, Vector3 a_stScale, Vector3 a_stRotate, bool a_bIsStay_WorldState = false) where T : Component
	{
		return Factory.CreateGameObj_Clone(a_oName,
			a_oPrefab_Origin, a_oGameObj_Parent, a_stPos, a_stScale, a_stRotate, a_bIsStay_WorldState).GetComponentInChildren<T>();
	}
	#endregion // 제네릭 클래스 팩토리 함수
}
