using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/** 
 * 터치 전달자 
 */
public partial class CDispatcher_Touch : CComponent,
	IPointerDownHandler, IDragHandler, IPointerUpHandler
{
	#region 변수
	public System.Action<CDispatcher_Touch, PointerEventData> Callback_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Touch, PointerEventData> Callback_Move { get; private set; } = null;
	public System.Action<CDispatcher_Touch, PointerEventData> Callback_End { get; private set; } = null;
	#endregion // 변수

	#region IPointerDownHandler
	/** 터치가 시작되었을 경우 */
	public virtual void OnPointerDown(PointerEventData a_oEventData)
	{
		this.Callback_Begin?.Invoke(this, a_oEventData);
	}
	#endregion // IPointerDownHandler

	#region IDragHandler
	/** 터치가 이동되었을 경우 */
	public virtual void OnDrag(PointerEventData a_oEventData)
	{
		this.Callback_Move?.Invoke(this, a_oEventData);
	}
	#endregion // IDragHandler

	#region IPointerUpHandler
	/** 터치가 종료되었을 경우 */
	public virtual void OnPointerUp(PointerEventData a_oEventData)
	{
		this.Callback_End?.Invoke(this, a_oEventData);
	}
	#endregion // IPointerUpHandler

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Touch, PointerEventData> a_oCallback)
	{
		this.Callback_Begin = a_oCallback;
	}

	/** 이동 콜백을 변경한다 */
	public void SetCallback_Move(System.Action<CDispatcher_Touch, PointerEventData> a_oCallback)
	{
		this.Callback_Move = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Touch, PointerEventData> a_oCallback)
	{
		this.Callback_End = a_oCallback;
	}
	#endregion // 접근 함수
}
