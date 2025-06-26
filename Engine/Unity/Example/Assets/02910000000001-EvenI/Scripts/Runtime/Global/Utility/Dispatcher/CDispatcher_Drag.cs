using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/**
 * 드래그 전달자 
 */
public partial class CDispatcher_Drag : CComponent,
	IBeginDragHandler, IDragHandler, IEndDragHandler, IScrollHandler
{
	#region 변수
	public System.Action<CDispatcher_Drag, PointerEventData> Callback_Begin { get; private set; } = null;
	public System.Action<CDispatcher_Drag, PointerEventData> Callback_Drag { get; private set; } = null;
	public System.Action<CDispatcher_Drag, PointerEventData> Callback_End { get; private set; } = null;
	public System.Action<CDispatcher_Drag, PointerEventData> Callback_Scroll { get; private set; } = null;
	#endregion // 변수

	#region IBeginDragHandler
	/** 드래그가 시작되었을 경우 */
	public virtual void OnBeginDrag(PointerEventData a_oEventData)
	{
		this.Callback_Begin?.Invoke(this, a_oEventData);
	}
	#endregion // IBeginDragHandler

	#region IDragHandler
	/** 드래그 중 일 경우 */
	public virtual void OnDrag(PointerEventData a_oEventData)
	{
		this.Callback_Drag?.Invoke(this, a_oEventData);
	}
	#endregion // IDragHandler

	#region IEndDragHandler
	/** 드래그가 종료되었을 경우 */
	public virtual void OnEndDrag(PointerEventData a_oEventData)
	{
		this.Callback_End?.Invoke(this, a_oEventData);
	}
	#endregion // IEndDragHandler

	#region IScrollHandler
	/** 스크롤 중 일 경우 */
	public virtual void OnScroll(PointerEventData a_oEventData)
	{
		this.Callback_Scroll?.Invoke(this, a_oEventData);
	}
	#endregion // IScrollHandler

	#region 접근 함수
	/** 시작 콜백을 변경한다 */
	public void SetCallback_Begin(System.Action<CDispatcher_Drag, PointerEventData> a_oCallback)
	{
		this.Callback_Begin = a_oCallback;
	}

	/** 드래그 콜백을 변경한다 */
	public void SetCallback_Drag(System.Action<CDispatcher_Drag, PointerEventData> a_oCallback)
	{
		this.Callback_Drag = a_oCallback;
	}

	/** 종료 콜백을 변경한다 */
	public void SetCallback_End(System.Action<CDispatcher_Drag, PointerEventData> a_oCallback)
	{
		this.Callback_End = a_oCallback;
	}

	/** 스크롤 콜백을 변경한다 */
	public void SetCallback_Scroll(System.Action<CDispatcher_Drag, PointerEventData> a_oCallback)
	{
		this.Callback_Scroll = a_oCallback;
	}
	#endregion // 접근 함수
}
