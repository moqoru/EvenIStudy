using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 풀 관리자
 */
public abstract partial class CManager_Pool<TSingleton, TTarget> : CSingleton<TSingleton>
	where TSingleton : CManager_Pool<TSingleton, TTarget> where TTarget : class
{
	#region 변수
	private Dictionary<object, CWrapper_ListQueue<TTarget>> m_oDictWrappers_ListQueue = new Dictionary<object, CWrapper_ListQueue<TTarget>>();
	#endregion // 변수

	#region 함수
	/** 상태를 리셋한다 */
	public override void Reset()
	{
		base.Reset();
		m_oDictWrappers_ListQueue.Clear();
	}

	/** 대상을 반환한다 */
	protected TTarget Spawn(System.Func<TTarget> a_oCreator)
	{
		Debug.Assert(a_oCreator != null);
		return this.Spawn(typeof(TTarget), a_oCreator);
	}

	/** 대상을 반환한다 */
	protected TTarget Spawn(object a_oKey, System.Func<TTarget> a_oCreator)
	{
		Debug.Assert(a_oCreator != null);
		return this.Spawn<TTarget>(typeof(TTarget), a_oCreator);
	}

	/** 대상을 비활성화한다 */
	protected void Despawn(TTarget a_tTarget, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_tTarget != null;
		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		this.Despawn(a_tTarget?.GetType(), a_tTarget, a_bIsAssert);
	}

	/** 대상을 비활성화한다 */
	protected void Despawn(object a_oKey, TTarget a_tTarget, bool a_bIsAssert = true)
	{
		bool bIsValid_Assert = a_oKey != null;
		bIsValid_Assert = bIsValid_Assert && a_tTarget != null;

		Debug.Assert(!a_bIsAssert || bIsValid_Assert);

		// 비활성이 불가능 할 경우
		if(!bIsValid_Assert)
		{
			return;
		}

		m_oDictWrappers_ListQueue.TryGetValue(a_oKey,
			out CWrapper_ListQueue<TTarget> oWrapper_ListQueue);

		oWrapper_ListQueue.m_oList.Remove(a_tTarget);
		oWrapper_ListQueue.m_oQueue.Enqueue(a_tTarget);
	}
	#endregion // 함수

	#region 제네릭 함수
	/** 대상을 반환한다 */
	protected T Spawn<T>(System.Func<TTarget> a_oCreator) where T : class, TTarget
	{
		Debug.Assert(a_oCreator != null);
		return this.Spawn<T>(typeof(T), a_oCreator);
	}

	/** 대상을 반환한다 */
	protected T Spawn<T>(object a_oKey,
		System.Func<TTarget> a_oCreator) where T : class, TTarget
	{
		bool bIsValid_Assert = a_oKey != null;
		bIsValid_Assert = bIsValid_Assert && a_oCreator != null;

		Debug.Assert(bIsValid_Assert);

		var oWrapper_ListQueue = m_oDictWrappers_ListQueue.ExGetVal(a_oKey) ??
			new CWrapper_ListQueue<TTarget>();

		m_oDictWrappers_ListQueue.ExAddVal(a_oKey, oWrapper_ListQueue);

		var tTarget = oWrapper_ListQueue.m_oQueue.ExDequeueVal(null) ?? a_oCreator();
		oWrapper_ListQueue.m_oList.ExAddVal(tTarget);

		return tTarget as T;
	}
	#endregion // 제네릭 함수
}
