using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using System.IO;
using UnityEngine.SceneManagement;
using TMPro;

/*
 * Unity 란?
 * - 게임을 비롯한 다양한 비주얼 프로그램을 제작 할 수 있게 여러 기능을 제공하는 
 * 멀티 플랫폼 게임 엔진을 의미한다. (+ 즉, Unity 는 게임 이외에도 다양한 분야에 사용된다는 것을 
 * 알 수 있다.)
 * 
 * Unity 주요 기능
 * - 렌더링
 * - 물리
 * - 사운드
 * - 애니메이션
 * - 파티클
 * - 스크립트
 * - 프로파일링
 * - 네트워크 (소켓)
 * - 에셋 (리소스) 관리
 * - 등등...
 * 
 * 위와 같이 Unity 는 렌더링을 비롯한 다양한 기능을 제공하기 때문에 Unity 를 활용하면 
 * 다양한 비주얼 프로그램을 비교적 적은 작업량으로 제작하는 것이 가능하다. (+ 즉, 비주얼 프로그램을 
 * 제작 할 때 필요한 많은 과정을 생략하는 것이 가능하다.)
 * 
 * Unity 기본 요소
 * - 씬 (Scene)
 * - 게임 객체 (Game Object)
 * - 컴포넌트 (Component)
 * - 에셋 (Asset)
 * 
 * 씬 (Scene) 이란?
 * - 게임 객체를 배치 할 수 있는 가상의 공간을 의미한다. (+ 즉, 씬에 여러 게임 객체를 배치함으로서
 * 원하는 장면을 출력하는 것이 가능하다.)
 * 
 * Unity 는 특정 장면을 화면 상에 출력하기 위해서 씬을 활용하기 때문에 Unity 로 제작 된 프로그램은
 * 반드시 1 개 이상의 씬을 포함해야한다. (+ 즉, 필요에 따라 여러 씬을 활용하는 것도 가능하다.)
 * 
 * 게임 객체 (Game Object) 란?
 * - 씬 상에 직접적으로 배치 할 수 있는 기본 단위를 의미한다. (+ 즉, 씬에 게임 객체를 배치해서 특정
 * 장면을 출력한다는 것을 알 수 있다.)
 * 
 * Unity 는 3 차원 게임 엔진이기 때문에 게임 객체는 화면 상에 배치되기 위한 Transform 컴포넌트를
 * 항상 지니고 있다. (+ 즉, Transform 컴포넌트를 제외한 다른 컴포넌트는 필요에 따라 게임 객체에
 * 추가해서 활용하는 것이 가능하다.)
 * 
 * 또한 게임 객체는 필요에 따라 계층 구조를 형성하는 것이 가능하며 계층 구조를 형성 할 수 있는 것도
 * Transform 컴포넌트가 존재하기 때문이다. (+ 즉, Transform 컴포넌트는 공간 상에 게임 객체의 
 * 변환을 제어하는 컴포넌트라는 것을 알 수 있다.)
 * 
 * 컴포넌트 (Component) 란?
 * - 특정 기능을 수행하는 하나의 단위를 의미한다. 
 * 
 * 따라서 컴포넌트를 조합해서 특정 역할을 하는 대상을 표현하는 것이 가능하다. (+ 즉, 유니티는 
 * 컴포넌트를 기반으로 특정 목적을 달성 할 수 있는 프로그램을 제작하며 이러한 방식을 컴포넌트 기반 
 * 프로그래밍 방식이라고 한다.)
 * 
 * 객체 지향 프로그래밍 vs 컴포넌트 기반 프로그래밍
 * - 객체 지향 프로그래밍 특정 역할을 수행하는 대상을 먼저 정의한 후에 해당 대상에 기능을 확장 
 * 시켜나가는 반면 컴포넌트 기반 프로그래밍은 컴포넌트를 조합함으로써 특정 대상을 정의하는 차이점이 
 * 존재한다. (+ 즉, 둘 다 프로그램의 구조를 설계하는 방법이지만 해당 프로그램 구조를 이를 대상을 
 * 어떤 시선으로 바라보는지에 대한 차이점이 존재한다.)
 * 
 * 따라서 유니티는 게임 객체와 더불어 여러 컴포넌트를 제공하며 여러 컴포넌트를 게임 객체에 
 * 추가함으로서 특정 대상을 표현하는 것이 가능하다. (+ 즉, 게임 객체는 단순히 컴포넌트를 담기 위한 
 * 그릇에 불가하다는 것을 알 수 있다.)
 * 
 * 단, 유니티가 제공해주는 컴포넌트만으로는 다양한 목적에 맞는 프로그램을 제작하는 것이 불가능하기 
 * 때문에 유니티는 사용자가 직접 구현 할 수 있는 컴포넌트를 제공하며 이를 스크립트 컴포넌트라고 
 * 한다. (+ 즉, 스크립트 컴포넌트를 활용하면 특정 목적에 맞는 기능 을 커스텀하게 구현하는 것이 
 * 가능하다.)
 *
 * 스크립트 컴포넌트 구현 조건
 * - 스크립트 파일 이름과 클래스 이름이 일치해야한다. (+ Unity 2020 버전 이하)
 * - MonoBehaviour 클래스를 직/간접적으로 상속해야한다.
 * 
 * 위와 같이 C# 클래스가 스크립트 컴포넌트가 되기 위해서는 몇가지 조건을 만족해야되는 것을 알 수
 * 있다. (+ 즉, 위의 규칙을 만족하지 않을 경우 해당 클래스는 게임 객체에 추가하는 것이 불가능하지만
 * 내부적으로 해당 클래스를 사용하는데는 전혀 지장이 없다.)
 * 
 * 따라서 게임 객체에 직접적으로 추가하고 싶은 클래스만 컴포넌트가 되기 위한 조건을 만족 시키면 된다.
 * 
 * 에셋 (Asset) 이란?
 * - 프로그램을 제작하기 위해서 필요한 데이터 (+ Ex. 이미지, 모델링 파일 등등...) 를 의미한다. 
 * (+ 즉, 에셋은 프로그램을 제작 할 때 사용되는 모든 리소스를 통칭하는 용어라는 것을 알 수 있다.)
 * 
 * Unity 는 리소스라는 용어보다는 에셋이라는 용어를 사용하며 이는 Unity 내부적으로 다양한 리소스를
 * 관리하기 위한 별도의 메타 파일을 자동으로 생성하기 때문이다. (+ 즉, 
 * 리소스와 메타 파일은 1 : 1 로 대응되며 이 둘을 합쳐서 에셋이라고 부른다.)
 * 
 * 따라서 Unity 에서 리소스를 사용하기 위해서는 반드시 메타 파일이 필요하며 메타 파일이 없을 경우
 * 텍스트 파일과 일부 텍스처 타입을 제외하고는 사용하는 것이 불가능하다. (+ 즉, 프로그램이 실행 중에
 * 외부로부터 관련 에셋을 다운받는 형태로 프로그램을 배포 할 경우 반드시 리소스와 더불어 메타 파일을
 * 같이 패키징 해야한다는 것을 알 수 있다.)
 */
namespace _6x_E01Example
{
	/**
	 * Example 1
	 */
	public partial class C6x_E01Example_01 : CManager_Scene
	{
		#region 변수
		[Header("=====> Example 1 - Game Objects <=====")]
		[SerializeField] private GameObject m_oTMP_UIPrefab_Text = null;
		[SerializeField] private GameObject m_oUIGameObj_ScrollViewContents = null;
		#endregion // 변수

		#region 클래스 변수
		private static float m_fUIPos_PrevScrollViewContents = 1.0f;
		#endregion // 클래스 변수

		#region 함수
		/** 초기화 */
		public override void Awake()
		{
			base.Awake();

			/*
			 * SceneManager 클래스란?
			 * - Unity 씬과 관련 된 여러 편리 기능을 제공하는 클래스를 의미한다. (+ 즉, 
			 * 해당 클래스를 활용하면 씬을 전환하거나 로드 된 씬을 제거하는 등의 기능을 
			 * 사용하는 것이 가능하다.)
			 */
			for(int i = 1; i < SceneManager.sceneCountInBuildSettings; ++i)
			{
				string oPath_Scene = SceneUtility.GetScenePathByBuildIndex(i);
				string oName_Scene = Path.GetFileNameWithoutExtension(oPath_Scene);
				string oUIName_Text = string.Format("Text_{0:00}", i);

				var oUIText = Factory.CreateGameObj_Clone<TMP_Text>(oUIName_Text,
					m_oTMP_UIPrefab_Text, m_oUIGameObj_ScrollViewContents);

				oUIText.text = oName_Scene;

				int nIdx = i;
				var oUIBtn = oUIText.GetComponentInChildren<Button>();

				/*
				 * 반복문 내부에서 람다와 같은 무명 메서드를 사용 할 경우 외부 변수 캡처를
				 * 조심해야 될 필요가 있다. (+ 즉, 반복문을 종료하기 위한 변수를 캡처 할 경우 
				 * 원치 않는 동작을 유발한다는 것을 알 수 있다.)
				 * 
				 * 상호 작용 이벤트 처리 메서드 설정 방법
				 * - Button 클래스와 같이 사용자와 상호 작용을 할 수 있는 UI 클래스들은 
				 * on 계열 프로퍼티를 제공하며 해당 프로퍼티를 활용하면 특정 이벤트를 
				 * 처리 할 수 있는 메서드를 설정하는 것이 가능하다. (+ 즉, UI 클래스들이 
				 * 제공하는 on 계열 프로퍼티를 활용하면 Unity 에디터가 아닌 스크립트에서 
				 * 동적으로 이벤트 처리 메서드를 설정 할 수 있다.)
				 */
				oUIBtn?.onClick.AddListener(() => this.UIHandleOnBtn_Text(nIdx));
			}
		}

		/** 초기화 */
		public override void Start()
		{
			base.Start();

			var oUIScrollRect = m_oUIGameObj_ScrollViewContents.GetComponentInParent<ScrollRect>();
			oUIScrollRect.verticalNormalizedPosition = m_fUIPos_PrevScrollViewContents;
		}

		/** 내비게이션 스택 이벤트를 처리한다 */
		public override void HandleOnEvent_NavStack(EEvent_NavStack a_eEvent)
		{
			switch(a_eEvent)
			{
				case EEvent_NavStack.BACK_KEY_DOWN:
					Func.UIShowPopup_Alert("게임을 종료하시겠습니까?",
						this.UIHandleOnCallback_AlertPopup);

					break;
			}
		}

		/** 알림 팝업 콜백을 처리한다 */
		private void UIHandleOnCallback_AlertPopup(CUIPopup_Alert a_oSender, bool a_bIsOK)
		{
			// 콜백 처리가 불가능 할 경우
			if(!a_bIsOK)
			{
				return;
			}

#if UNITY_EDITOR
			UnityEditor.EditorApplication.ExitPlaymode();
#endif // #if UNITY_EDITOR
		}

		/** 텍스트 버튼을 처리한다 */
		private void UIHandleOnBtn_Text(int a_nIdx)
		{
			var oUIScrollRect = m_oUIGameObj_ScrollViewContents.GetComponentInParent<ScrollRect>();
			m_fUIPos_PrevScrollViewContents = oUIScrollRect.verticalNormalizedPosition;

			string oPath_Scene = SceneUtility.GetScenePathByBuildIndex(a_nIdx);
			CLoader_Scene.Inst.LoadScene(oPath_Scene);
		}
		#endregion // 함수
	}
}
