using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 싱글턴이란?
 * - 객체의 생성 개수를 1 개로 제한하는 객체 생성 패턴을 의미한다. (+ 즉, 
 * 싱글턴 패턴 구조를 적용하면 프로그램 전체에서 접근 가능한 전역 객체를 생성하는 것이 가능하다.)
 * 
 * Unity 는 기본적으로 씬이 전환 될 때 기존 씬에 존재하는 모든 객체를 제거하기 때문에 씬 간에
 * 데이터를 공유하고 싶다면 싱글턴 패턴과 같은 구조를 적용 할 필요가 있다. (+ 즉, 
 * 싱글 모드가 아닌 추가 모드로 씬을 추가 할 경우에는 객체가 제거되지 않는다는 것을 알 수 있다.)
 */

/**
 * 싱글턴
 */
public abstract partial class CSingleton<TInst> : CComponent
	where TInst : CSingleton<TInst>
{
	#region 클래스 변수
	private static TInst m_tInst = null;
	#endregion // 클래스 변수

	#region 프로퍼티
	public virtual bool IsEnable_Destroy => false;
	#endregion // 프로퍼티

	#region 클래스 프로퍼티
	public static TInst Inst
	{
		get
		{
			// 인스턴스가 없을 경우
			if(CSingleton<TInst>.m_tInst == null)
			{
				CSingleton<TInst>.m_tInst = Factory.CreateGameObj<TInst>(typeof(TInst).ToString(),
					null);

				Debug.Assert(CSingleton<TInst>.m_tInst != null);
			}

			return CSingleton<TInst>.m_tInst;
		}
	}
	#endregion // 클래스 프로퍼티

	#region 함수
	/** 생성자 */
	protected CSingleton()
	{
		// Do Something
	}

	/** 초기화 */
	public override void Awake()
	{
		base.Awake();
		Debug.Assert(CSingleton<TInst>.m_tInst == null);

		CSingleton<TInst>.m_tInst = this as TInst;

		// 인스턴스 제거 가능 상태 일 경우
		if(CSingleton<TInst>.m_tInst.IsEnable_Destroy)
		{
			return;
		}

		/*
		 * DontDestroyOnLoad 메서드란?
		 * - 씬이 전환되어도 특정 객체를 제거하지 않도록 지정하는 역할을 수행하는 메서드이다. 
		 * (+ 즉, 해당 메서드를 통해 설정 된 객체는 명시적으로 제거하기 전까지는 
		 * 항상 씬에 존재한다는 것을 알 수 있다.)
		 */
		DontDestroyOnLoad(this.gameObject);
	}

	/** 제거되었을 경우 */
	public override void OnDestroy()
	{
		base.OnDestroy();
		CSingleton<TInst>.m_tInst = null;
	}
	#endregion // 함수

	#region 클래스 함수
	/** 인스턴스를 생성한다 */
	public static TInst Create()
	{
		return CSingleton<TInst>.Inst;
	}

	/** 인스턴스를 제거한다 */
	public static void Destroy()
	{
		// 인스턴스 제거가 불가능 할 경우
		if(CSingleton<TInst>.m_tInst == null ||
			!CSingleton<TInst>.m_tInst.IsEnable_Destroy)
		{
			return;
		}

		/*
		 * Destroy 메서드는 게임 객체를 제거하는 역할을 수행한다. (+ 즉, 해당 메서드를 활용하면 
		 * 특정 게임 객체를 씬에서 제거하는 것이 가능하다.)
		 * 
		 * Destroy 메서드 vs DestroyImmediate 메서드
		 * - 두 메서드 모두 게임 객체를 제거하는 역할을 수행한다.
		 * 
		 * Destroy 메서드는 게임 객체를 제거하는 메서드이지만 게임 객체를 바로 제거하는 것이
		 * 아니라 Unity 의 렌더링 루프가 모두 완료 된 후 제거되는 특징이 존재한다. (+ 즉,
		 * 메서드 호출 직후에는 아직 게임 객체가 씬 상에 존재한다는 것을 알 수 있다.)
		 * 
		 * 반면 DestroyImmediate 메서드는 호출 즉시 게임 객체를 제거하는 차이점이 존재한다.
		 * (+ 즉, 해당 메서드를 활용하면 호출 즉시 게임 객체가 씬에서 제거된다는 것을 알 수 
		 * 있다.)
		 * 
		 * Unity 는 렌더링 루프가 수행되면서 게임 객체를 대상으로 여러 함수들을 호출하기 때문에
		 * 렌더링 루프가 실행되는 도중에 게임 객체를 제거하는 것은 굉장히 위함한 일이다.
		 * 
		 * 따라서 호출 즉시 게임 객체를 제거하는 DestroyImmediate 메서드는 사용을 권장하지
		 * 않기 때문에 가능하면 Destroy 메서드를 활용하는 것을 추천한다. (+ 즉, 
		 * Destroy 메서드는 게임 객체를 안전하게 제거 할 수 있는 시점에 게임 객체를 제거하기 
		 * 때문에 DestroyImmediate 메서드보다 안전하게 사용하는 것이 가능하다.)
		 */
		GameObject.Destroy(CSingleton<TInst>.m_tInst.gameObject);
	}
	#endregion // 클래스 함수
}
