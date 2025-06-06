/*
 * 전처리기 명령어란?
 * - 전처리 단계에서 실행되는 명령어로서 C# 으로 작성 된 명령문을 컴파일하기 전에 명령문을
 * 튜닝하는 역할을 수행한다. (+ 즉, 전처리 단계를 거치고 나면 작성 된 명령문이
 * 달라질 수 있다는 것을 의미한다.)
 * 
 * 전처리기 명령어는 모두 # 으로 시작하는 특징이 존재하며 C# 의 기능이 아니기 때문에
 * C# 과는 전혀 다른 문법을 지니고 있다.
 * 
 * 따라서 전처리기 명령문은 C# 컴파일러가 아닌 전처리기에 의해서 처리된다는 것을 알 수 있다.
 * 
 * C# 주요 전처리기 명령어
 * - define
 * - if ~ else ~ endif
 * 
 * define 명령어란?
 * - define 명령어는 특정 기호 (심볼) 를 정의하는 역할을 수행하며 해당 명령어로 정의 된 심볼을
 * 기반으로 조건문을 작성하면 특정 명령문을 활성화하거나 비활성화하는 것이 가능하다.
 * 
 * Ex)
 * #define PLATFORM_MOBILE
 *
 * #if PLATFORM_MOBILE
 *      // 모바일 플랫폼 관련 명령문
 * #else
 *      // 기타 플랫폼 관련 명령문
 * #endif
 * 
 * 위와 같이 전처리기 조건문을 활용하면 명령문을 특정 환경에서만 동작하도록 활성 및 비활성하는 것이
 * 가능하다. (+ 즉, 멀티 플랫폼 환경에서 동작하는 명령문을 작성 할 때 특히 유용하다는 것을
 * 알 수 있다.)
 * 
 * if ~ else ~ endif 명령어란?
 * - 전처리 단계에서 처리되는 조건문을 의미한다. (+ 즉, 해당 명령어를 활용하면 특정 명령문을
 * 컴파일 되지 않도록 비활성 시키는 것이 가능하다.)
 * 
 * 단, 전처리기 조건문은 특정 조건에 해당하는 영역을 명시하기 위해서 반드시 endif 명령어로
 * 종료되어야한다. (+ 즉, 전처리기 조건문에는 { } 기호를 사용하는 것이 불가능하다는 것을
 * 알 수 있다.)
 */
#define EXAMPLE
#define PRACTICE
#define SOLUTION

/*
 * 네임 스페이스란?
 * - C# 으로 작성 된 명령문을 구분하는 단위를 의미한다. (+ 즉, C# 은 C/C++ 과 달리 특정 파일에 
 * 존재하는 기능을 사용하기 위해서 해당 파일의 경로를 직접 명시하는 것이 아니라 네임 스페이스 경로를 
 * 명시해야한다.)
 * 
 * 따라서 네임 스페이스는 C# 에서 특정 기능을 포함하기 위한 논리적인 경로를 의미한다는 것을 
 * 알 수 있다.
 * 
 * 또한 네임 스페이스는 전역 공간 내에서 특정 영역을 생성하는 특징이 존재하기 때문에 관련 된 기능을 
 * 특정 네임 스페이스 내부에 선언 및 정의함으로서 관리의 용이성을 향상 시키는 것이 가능하다.
 */
namespace Example
{
	internal class Program
	{
		/*
		 * C# 의 메서드는 C/C++ 과 달리 전역 영역에 구현하는 것이 불가능하며 항상 
		 * 특정 클래스 or 구조체 내부에서만 구현하는 것이 가능하다. 
		 * 
		 * 따라서 C# 의 메인 메서드는 반드시 특정 클래스 내부에 static 키워드로 
		 * 명시 되어있어야한다. (+ 즉, C/C++ 과 달리 메인 메서드 유형이 1 개만 지원한다는 것을
		 * 알 수 있다.)
		 * 
		 * 메인 메서드 (진입 메서드) 란?
		 * - C# 으로 제작 된 프로그램이 실행 될 때 가장 먼저 호출 (실행) 되는 메서드를 의미한다.
		 * (+ 즉, 가장 먼저 실행되기 때문에 진입 메서드라고도 불린다는 것을 알 수 있다.)
		 * 
		 * 메인 메서드는 운영체제에 의해서 호출되기 때문에 생략하는 것이 불가능하며 해당 메서드를
		 * 생략 할 경우 링크 에러가 발생한다. (+ 즉, 프로그램이 제작되지 않는다는 것을 의미한다.)
		 * 
		 * 또한 메인 메서드는 다른 메서드와 달리 중복이 불가능하다. (+ 즉, 일반적인 메서드는
		 * 서로 다른 영역 일 경우 동일한 이름의 메서드를 구현하는 것이 가능하다는 것을 알 수 있다.)
		 * 
		 * 따라서 메인 메서드는 C# 으로 제작 된 프로그램에서 유일해야하며 해당 메서드가
		 * 호출되었다는 것은 프로그램이 실행되었다는 것을 의미하며 해당 메서드가 종료되었다는 것은
		 * 프로그램이 종료되었다는 것을 의미한다. (+ 즉, 메인 메서드가 종료되면 프로그램도
		 * 종료된다는 것을 알 수 있다.)
		 */
		/** 메인 메서드 */
		static void Main(string[] args)
		{
			//Program.Main_Programming(args);
			//Program.Main_Structure(args);
			Program.Main_Algorithm(args);
		}

		/** 프로그래밍 메인 메서드 */
		private static void Main_Programming(string[] args)
		{
#if EXAMPLE
			/*
			 * C# 은 . (맴버 접근 연산자) 를 통해 특정 네임 스페이스나 클래스 하위에 접근하는 것이 
			 * 가능하다. (+ 즉, 해당 연산자를 활용하면 특정 클래스 내부에 존재하는 메서드를 
			 * 호출하는 것이 가능하다.)
			 * 
			 * 메서드 (함수) 란?
			 * - 특정 명령문을 포함하고 있는 기능을 의미한다. (+ 즉, 메서드를 실행하면 
			 * 메서드 내부에 존재하는 명령문이 동작한다는 것을 알 수 있다.)
			 * 
			 * 따라서 메서드를 활용하면 여러 기능들을 미리 만들어서 재사용하는 것이 가능하다.
			 */
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_01.CE01Example_01.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_02.CE01Example_02.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_03.CE01Example_03.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_04.CE01Example_04.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_05.CE01Example_05.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_06.CE01Example_06.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_07.CE01Example_07.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_08.CE01Example_08.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_09.CE01Example_09.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_10.CE01Example_10.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_11.CE01Example_11.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_12.CE01Example_12.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_13.CE01Example_13.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_14.CE01Example_14.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_15.CE01Example_15.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_16.CE01Example_16.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_17.CE01Example_17.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_18.CE01Example_18.Start(args);
			//_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_19.CE01Example_19.Start(args);
			_02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_20.CE01Example_20.Start(args);
#elif PRACTICE

#elif SOLUTION

#endif // #if EXAMPLE
		}

		/** 자료구조 메인 메서드 */
		private static void Main_Structure(string[] args)
		{
#if EXAMPLE
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_01.CE01Example_01.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02.CE01Example_02.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_03.CE01Example_03.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_04.CE01Example_04.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_05.CE01Example_05.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_06.CE01Example_06.Start(args);
			//_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_07.CE01Example_07.Start(args);
			_02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_08.CE01Example_08.Start(args);
#elif PRACTICE

#elif SOLUTION

#endif // #if EXAMPLE
		}

		/*
		 * 알고리즘 과제 1
		 * - 착한 접미부 테이블을 구현해서 보이어무어 성능 개선하기
		 * 
		 * 알고리즘 과제 2
		 * - 수식 트리 구축하기 (+ 2 가지 방식 모두 구현)
		 */
		/** 알고리즘 메인 메서드 */
		private static void Main_Algorithm(string[] args)
		{
#if EXAMPLE
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_01.CE01Example_01.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_02.CE01Example_02.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_03.CE01Example_03.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_04.CE01Example_04.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_05.CE01Example_05.Start(args);
			_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_06.CE01Example_06.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_07.CE01Example_07.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_08.CE01Example_08.Start(args);
			//_02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_09.CE01Example_09.Start(args);
#elif PRACTICE

#elif SOLUTION
			_02910000000001_EvenI.Algorithm.E01.Solution.Classes.Runtime.Solution_01.CS01Solution_01.Start(args);
#endif // #if EXAMPLE
		}
	}
}
