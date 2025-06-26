using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * 빌보드란?
 * - 카메라의 방향과 상관없이 항상 동일한 각도로 화면 상에 출력되는 물체를 의미한다. (+ 즉, 
 * 빌보드를 활용하면 HUD 형태의 UI 와 같이 항상 화면 상에 고정되어있는 물체를 출력하는 것이 
 * 가능하다.)
 * 
 * 빌보드 종류
 * - 구형 빌보드
 * - 원통형 빌보드
 * 
 * 위와 같이 빌보드는 내부적으로 처리하는 방식에 따라 크게 구형 빌보드와 원통형 빌보드로 구분된다.
 * 
 * 구형 빌보드는 X, Y, Z 축을 모두 회전시켜서 물체의 방향을 제어하는 반면 원통형 빌보드는 Y 축만을
 * 회전시켜서 물체의 방향을 제어하는 차이점이 존재한다. (+ 즉, 화면 상에 항상 
 * 고정되는 UI 를 제외하면 일반적으로 원통형 빌보드가 주로 활용된다는 것을 알 수 있다.)
 */

/**
 * 빌보드
 */
public partial class CBillboard : CComponent
{
	#region 변수
	[Header("=====> Billboard - Etc <=====")]
	[SerializeField] private bool m_bIsBillboard_Cylinder = false;
	#endregion // 변수

	#region 함수
	/** 상태를 갱신한다 */
	public void LateUpdate()
	{
		var stDirection_Forward = Camera.main.transform.forward;
		stDirection_Forward.y = m_bIsBillboard_Cylinder ? 0.0f : stDirection_Forward.y;

		this.transform.forward = stDirection_Forward.normalized;
	}
	#endregion // 함수
}
