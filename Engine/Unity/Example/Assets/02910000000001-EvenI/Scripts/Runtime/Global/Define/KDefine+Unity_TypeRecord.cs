using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

#region 타입 - 레코드
/** 매개 변수 */
public abstract partial record REParams
{
	// Do Something
}

/** 매개 변수 */
public partial record REParams<TSender> : REParams
{
	public System.Action<TSender> m_oCallbackA = null;
}

/** 매개 변수 */
public partial record REParams<TSender, TParams> : REParams<TSender>
{
	public System.Action<TSender, TParams> m_oCallbackB = null;
}

/** 매개 변수 */
public partial record REParams<TSender, TParams, TOwner> : REParams<TSender, TParams> where TOwner : class
{
	public TOwner m_tOwner = null;
}
#endregion // 타입 - 레코드
