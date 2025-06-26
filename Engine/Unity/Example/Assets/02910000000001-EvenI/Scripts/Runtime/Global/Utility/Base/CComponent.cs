using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 이벤트 메서드 (Event Method) 란?
 * - Unity 가 내부적으로 처리하는 일련의 연산을 처리하기 위한 메서드를 의미한다. (+ 즉,
 * 이벤트 메서드를 활용하면 특정 시점에 원하는 작업을 수행하는 것이 가능하다.)
 * 
 * Unity 는 렌더링을 비롯한 물리, 사운드, 애니메이션 등등 여러 연산을 처리하며 해당 연산을 처리하는
 * 과정에서 호출되는 메서드를 이벤트 메서드라고 한다. (+ 즉, 이벤트 메서드는 Unity 에 의해서
 * 자동으로 호출된다는 것을 알 수 있다.)
 * 
 * Unity 는 내부적으로 게임 루프 (Game Loop) 라고 불리는 라이프 사이클 (Life Cycle) 존재하며
 * 게임 루프에 존재하는 여러 연산을 단계적으로 수행함으로서 특정 결과물을 화면 상에 출력하는 것이
 * 가능하다.
 * 
 * 참고 URL)
 * https://docs.unity3d.com/kr/2022.3/Manual/ExecutionOrder.html
 * 
 * Unity 주요 이벤트 메서드 종류 - 1
 * - Awake
 * - Start
 * - Reset
 * - OnDestroy
 * 
 * Awake 메서드란?
 * - 컴포넌트가 게임 객체에 추가 될때 호출되는 메서드이다. (+ 즉, 해당 메서드는 컴포넌트가
 * 특정 게임 객체에 추가 된 직후 호출되기 때문에 스크립트를 초기화하는 용도로 활용된다는 것을 알 수
 * 있다.)
 * 
 * 단, 비활성 상태인 게임 객체에 스크립트를 추가 할 경우 메서드는 호출되지 않으며
 * 이후 해당 게임 객체가 활성화 될 경우 호출된다는 특징이 존재한다.
 * 
 * 따라서 해당 메서드가 호출되었다는 것은 해당 컴포넌트를 지니고 있는 게임 객체가 사용 완료 된
 * 상태라는 것을 알 수 있다.
 * 
 * Start 메서드란?
 * - Awake 메서드와 같이 게임 객체에 추가 될때 호출되는 메서드이기 때문에 객체를 초기화하는 용도로
 * 활용된다.
 * 
 * 단, 게임 객체에 추가되면 즉시 호출되는 Awake 메서드와 달리 Start 메서드는 다음 프레임이
 * 시작될 때 호출되는 차이점이 존재한다. (+ 즉, 다음 프레임이 시작 될 때 Start 메서드가 일괄적으로
 * 호출된다는 것을 알 수 있다.)
 * 
 * 따라서 해당 메서드는 주로 초기화가 완료 된 다른 스크립트를 대상으로 초기화 작업을 수행 할 때
 * 주로 활용된다는 것을 알 수 있다.
 * 
 * Reset 메서드란?
 * - Unity 에디터 상에서 스크립트를 추가 할 때 호출되는 메서드이다. (+ 즉, 런타임 환경에서는
 * 직접 호출하지 않으면 해당 메서드는 호출되지 않는다는 것을 알 수 있다.)
 * 
 * Unity 에디터 환경에서 Reset 메뉴를 눌러도 해당 메서드가 호출되기 때문에 특정 스크립트가
 * 지닌 멤버를 초기 데이터로 리셋하는데 활용하는 것이 가능하다.
 * 
 * OnDestroy 메서드란?
 * - 게임 객체가 제거 될 때 호출되는 메서드이다. (+ 즉, 해당 메서드를 활용하면 특정 스크립트가
 * 사용하고 있던 리소스를 정리하는 등의 작업을 좀 더 수월하게 처리하는 것이 가능하다.)
 * 
 * 해당 메서드가 호출되었다는 것은 해당 스크립트를 지니고 있던 게임 객체를 더이상 사용 할 수 없다는
 * 것을 의미하기 때문에 해당 메서드 내부에서 게임 객체에 접근하는 명령문을 작성 할 경우 예외가
 * 발생하기 때문에 주의가 필요하다. (+ 즉, 제거 된 게임 객체에 접근하는 것은 불가능하다는 것을
 * 알 수 있다.)
 * 
 * Unity 주요 이벤트 메서드 종류 - 2
 * - OnEnable / OnDisable
 * - Update / LateUpdate / FixedUpdate
 * 
 * OnEnable / OnDisable 메서드란?
 * - 게임 객체가 활성 or 비활성 될 때 호출되는 메서드이다. (+ 즉, 해당 메서드를 활용하면
 * 게임 객체가 활성 or 비활성화되는 시점에 특정 작업을 처리하는 것이 가능하다.)
 * 
 * Update / LateUpdate / FixedUpdate 메서드란?
 * - 호출 빈도가 가장 높은 메서드이다. (+ 즉, 다른 이벤트 메서드와 달리 해당 메서드는 매 프레임
 * 호출된다는 것을 알 수 있다.)
 * 
 * 따라서 입력 장치에 반응하는 작업과 같이 이벤트가 발생한 시점과 처리 시점이 가능한 짧아야하는
 * 작업에 주로 활용된다는 것을 알 수 있다.
 * 
 * Unity 에서는 매 프레임마다 1 번씩 호출되는 가변 프레임 (Variable Frame) 메서드와
 * 일정 시간 간격으로 호출되는 고정 프레임 (Fixed Frame) 메서드가 존재한다. (+ 즉, 
 * 가변 프레임 메서드는 이전 작업의 부하 여부에 따라 호출 간격이 일정하지 않을 수 있다는 것을
 * 의미한다.)
 * 
 * 가변 프레임 (Variable Frame) 메서드 vs 고정 프레임 (Fixed Frame) 메서드
 * - 가변 프레임 메서드는 매 프레임마다 무조건 1 번씩 호출되기 때문에 고정 프레임 메서드에 비해
 * 부하가 적은 장점이 존재한다. (+ 즉, 고정 프레임 메서드는 이전 작업의 부하에 따라 1 번 이상
 * 호출 될 수 있다는 것을 알 수 있다.)
 * 
 * 단, 가변 프레임 메서드는 이전 작업의 부하에 따라 호출 간격이 일정하지 않을 수 있기 때문에
 * 반드시 Time.deltaTime 데이터를 기반으로 작업을 수행해야한다. (+ 즉, Time.deltaTime 은
 * 이전 프레임과 현재 프레임 사이에 흘러간 시간 데이터라는 것을 알 수 있다.)
 * 
 * 반면 고정 프레임 메서드는 호출 간격이 일정하기 때문에 가변 프레임 메서드 보다 좀 더 안정적인
 * 명령문을 작성하는 것이 가능하다. (+ 즉, 호출 간격이 일정하기 때문에 Time.deltaTime 에 의존하지
 * 않아도 된다는 것을 알 수 있다.)
 */

/**
 * 컴포넌트
 */
public abstract partial class CComponent : MonoBehaviour, IUpdatable
{
	#region 프로퍼티
	public bool IsDestroy { get; private set; } = false;

	public bool IsDirty_Info { get; private set; } = false;
	public bool IsDirty_State { get; private set; } = false;
	public bool IsDirty_Layout { get; private set; } = false;

	public System.Action<CComponent> Callback_Destroy { get; private set; } = null;
	public System.Action<CComponent> Callback_Schedule { get; private set; } = null;
	public System.Action<CComponent> Callback_NavStack { get; private set; } = null;

	public virtual bool IsEnable => !this.IsDestroy &&
		this.enabled && this.gameObject.activeInHierarchy;
	#endregion // 프로퍼티

	#region IUpdatable
	/** 상태를 갱신한다 */
	public virtual void OnUpdate(float a_fTime_Delta)
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	public virtual void OnUpdate_Late(float a_fTime_Delta)
	{
		/*
		 * 더티 플래그 패턴 (Dirty Flag Pattern) 이란?
		 * - 특정 상태에 대한 처리를 지연시킴으로서 중복으로 처리되는 연산량을 줄이는 패턴을 
		 * 의미한다. (+ 즉, 해당 패턴은 상태 변화에 대한 처리를 특정 시점에 한번에 처리한다는 것을 
		 * 알 수 있다.)
		 * 
		 * 단, 해당 패턴은 이벤트의 발생 시점과 처리 시점을 지연해서 한번에 처리하는 것이기 때문에
		 * 특정 이벤트를 가능한 빠르게 처리해야 될 경우 사용하는 것을 지양해야한다. (+ 즉, 
		 * 해당 패턴은 주로 UI 와 같이 상태 변화를 실시간으로 처리하지 않아도 되는 작업에
		 * 적절하다는 것을 알 수 있다.)
		 */
		// 정보 저장이 필요 할 경우
		if(this.IsDirty_Info)
		{
			this.SetIsDirty_Info(false, true);
			this.SaveInfo();
		}

		// 상태 갱신이 필요 할 경우
		if(this.IsDirty_State)
		{
			this.SetIsDirty_State(false, true);
			this.UpdateState();
		}

		// 레이아웃 재배치가 필요 할 경우
		if(this.IsDirty_Layout)
		{
			this.SetIsDirty_Layout(false, true);
			this.RebuildLayout();
		}
	}

	/** 상태를 갱신한다 */
	public virtual void OnUpdate_Fixed(float a_fTime_Delta)
	{
		// Do Something
	}
	#endregion // IUpdatable

	#region 함수
	/** 초기화 */
	public virtual void Awake()
	{
		// Do Something
	}

	/** 초기화 */
	public virtual void Start()
	{
		// Do Something
	}

	/** 상태를 리셋한다 */
	public virtual void Reset()
	{
		// Do Something
	}

	/** 제거되었을 경우 */
	public virtual void OnDestroy()
	{
		this.IsDestroy = true;

		this.Callback_Destroy?.Invoke(this);
		this.Callback_Schedule?.Invoke(this);
		this.Callback_NavStack?.Invoke(this);
	}

	/** 내비게이션 스택 이벤트를 처리한다 */
	public virtual void HandleOnEvent_NavStack(EEvent_NavStack a_eEvent)
	{
		// Do Something
	}

	/** 정보를 저장한다 */
	protected virtual void SaveInfo()
	{
		// Do Something
	}

	/** 상태를 갱신한다 */
	protected virtual void UpdateState()
	{
		// Do Something
	}

	/** 레이아웃을 재배치한다 */
	protected virtual void RebuildLayout()
	{
		// Do Something
	}
	#endregion // 함수

	#region 접근 함수
	/** 정보 저장 여부를 변경한다 */
	public void SetIsDirty_Info(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_Info = a_bIsDirty;
		}
		else
		{
			this.IsDirty_Info = this.IsDirty_Info || a_bIsDirty;
		}
	}

	/** 상태 갱신 여부를 변경한다 */
	public void SetIsDirty_State(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_State = a_bIsDirty;
		}
		else
		{
			this.IsDirty_State = this.IsDirty_State || a_bIsDirty;
		}
	}

	/** 레이아웃 재배치 여부를 변경한다 */
	public void SetIsDirty_Layout(bool a_bIsDirty, bool a_bIsForce = false)
	{
		// 강제 모드 일 경우
		if(a_bIsForce)
		{
			this.IsDirty_Layout = a_bIsDirty;
		}
		else
		{
			this.IsDirty_Layout = this.IsDirty_Layout || a_bIsDirty;
		}
	}

	/** 제거 콜백을 변경한다 */
	public void SetCallback_Destroy(System.Action<CComponent> a_oCallback)
	{
		this.Callback_Destroy = a_oCallback;
	}

	/** 스케줄 콜백을 변경한다 */
	public void SetCallback_Schedule(System.Action<CComponent> a_oCallback)
	{
		this.Callback_Schedule = a_oCallback;
	}

	/** 내비게이션 스택 콜백을 변경한다 */
	public void SetCallback_NavStack(System.Action<CComponent> a_oCallback)
	{
		this.Callback_NavStack = a_oCallback;
	}
	#endregion // 접근 함수
}
