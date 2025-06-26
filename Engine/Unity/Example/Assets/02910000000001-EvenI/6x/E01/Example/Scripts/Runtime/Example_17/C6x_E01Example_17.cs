#define E_E01_EXAMPLE_17_01
#define E_E01_EXAMPLE_17_02

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

/*
 * Unity UI 시스템 종류
 * - ImGUI				<- Unity 초기 버전부터 활용되던 UI 시스템
 * - Unity GUI			<- 현재 가장 많이 활용되는 UI 시스템
 * - UI Toolkit			<- XML 및 CSS 기반의 UI 시스템
 * 
 * ImGUI 란?
 * - Unity 초기 버전부터 현재 버전까지 활용되는 UI 시스템을 의미한다. (+ 즉, 과거부터 사용되었기
 * 때문에 호환성이 가장 좋다는 것을 알 수 있다.)
 * 
 * ImGUI 는 스크립트만으로 UI 를 제작하기 때문에 프로그래밍 언어를 공부해야되는 단점이 존재하며
 * 따라서 현재는 에디터 UI 를 제작 할 때를 제외하고는 거의 사용되지 않는다. (+ 즉, 해당 시스템을
 * 활용하면 제작하는 프로그램에 맞춰 에디터 UI 를 커스터마이징하는 것이 가능하다.)
 * 
 * Unity GUI 란?
 * - 현재 가장 많이 활용되는 UI 시스템을 의미한다. (+ 즉, 현재 제작되는 유니티 프로그램의 대부분이
 * 사용하는 시스템이라는 것을 알 수 있다.)
 * 
 * Unity GUI 는 ImGUI 와 달리 비주얼 에디터 기능을 지원하기 때문에 스크립트를 통하지 않고
 * Unity 에디터 상에서 배치 및 결과물을 확인하는 것이 가능하다. (+ 즉, 플레이 모드로 전환하지
 * 않아도 배치 된 UI 의 레이아웃을 확인 할 수 있다.)
 * 
 * 단, Unity UI 는 에디터 UI 를 제작하는 것이 불가능하다는 단점이 존재한다. (+ 즉, 런타임 UI 만을
 * 지원한다는 것을 알 수 있다.)
 * 
 * UI Toolkit 이란?
 * - 차세대 UI 시스템을 의미한다. (+ 즉, 현재 개발 진행 중이라는 것을 알 수 있다.)
 * 
 * UI Toolkit 은 기존 UI 시스템과 달리 런타임과 에디터에서 모두 동작하는 UI 를 제작하는 것이
 * 가능하다. (+ 즉, 해당 시스템을 활용하면 통일 된 방법으로 런타임 UI 와 에디터 UI 를 제작 할 수
 * 있다.)
 * 
 * 단, UI Toolkit 은 현재 개발이 진행 중인 시스템으로서 안전성이 검증되지 않았다는 단점이 존재한다.
 * (+ 즉, 실제 상용 프로그램을 제작하는데는 위험 요소가 있다는 것을 알 수 있다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 17
	 */
	public partial class C6x_E01Example_17 : CManager_Scene
	{
		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();
		}

#if UNITY_EDITOR && E_E01_EXAMPLE_17_01
		/** GUI 를 그린다 */
		protected override void OnGUI()
		{
			base.OnGUI();

			var stRect_Btn = new Rect(0.0f,
				0.0f, Access.Size_DeviceScreen.x, Access.Size_DeviceScreen.y * 0.1f);

			/*
			 * GUI 클래스란?
			 * - 화면 상에 그래픽을 출력하기 위한 역할을 수행하는 클래스를 의미한다. (+ 즉,
			 * 해당 클래스를 활용하면 다양한 그래픽을 화면 상에 렌더링하는 것이 가능하다.)
			 * 
			 * 단, 해당 클래스는 OnGUI 메서드 내부에서만 사용 가능하다. (+ 즉, 다른 메서드에서
			 * 해당 클래스에 접근하면 예외가 발생한다는 것을 알 수 있다.)
			 */
			// 버튼을 눌렀을 경우
			if(GUI.Button(stRect_Btn, "Button"))
			{
				Func.ShowLog("GUI 버튼을 눌렀습니다.");
			}
		}
#endif // #if UNITY_EDITOR && E_E01_EXAMPLE_17_01
		#endregion // 함수
	}
}
