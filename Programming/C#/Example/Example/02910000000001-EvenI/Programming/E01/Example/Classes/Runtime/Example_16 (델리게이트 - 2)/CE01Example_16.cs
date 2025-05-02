//#define P_E01_EXAMPLE_16_01
//#define P_E01_EXAMPLE_16_02
#define P_E01_EXAMPLE_16_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 람다 및 무명 메서드란?
 * - 일반적인 메서드와 달리 이름이 존재하지 않는 메서드를 의미한다.
 * 
 * 따라서 람다 및 무명 메서드를 활용하면 재사용성이 떨어지는 일회성 메서드를 손쉽게 구현하는 것이 
 * 가능하다.
 * 
 * 또한 람다 및 무명 메서드는 다른 메서드 내부에서 구현되는 내장 메서드이기 때문에 해당 메서드가
 * 선언 된 영역에 존재하는 지역 변수에 접근하는 것이 가능하다. (+ 즉, 지역 변수에 접근하기 위해서
 * 별도의 데이터를 전달 할 필요가 없다는 것을 의미한다.)
 * 
 * C# 람다 구현 방법
 * - 매개 변수 + 람다 몸체
 * 
 * Ex)
 * (int a_nValA, int a_nValB) => a_nValA + a_nValB						<- 람다식 (식 형식)
 * (int a_nValB, int a_nValB) => { return a_nValA + a_nValB; }			<- 람다문 (문 형식)
 * 
 * C# 람다는 식 형식과 문 형식 의 형태를 제공한다. 
 * 
 * 식 형식으로 주로 한줄로 처리되는 간단한 람다 메서드를 구현 할 때 활용되며 문 형식은 여러 라인을 
 * 지니는 복잡한 명령문을 지니는 람다 메서드를 구현 할 때 활용된다.
 * 
 * 또한 C# 람다는 입력으로 전달되는 자료형의 매개 변수를 생략하는 것이 가능하다.
 * 따라서 a_nValA, a_nValB 와 같은 매개 변수의 이름만 명시하는 것이 가능하다는 것을 알 수 있다.
 * 
 * C# 무명 메서드 구현 방법
 * - delegate + 매개 변수 + 메서드 몸체
 * 
 * Ex)
 * delegate (int a_nValA, int a_nValB)
 * {
 *		// Do Something
 * }
 * 
 * 무명 메서드는 C# 이 람다를 지원하기 이전에 사용하던 일회성 메서드이기 때문에 현재는 잘 활용되지
 * 않는다. (+ 즉, 해당 메서드는 C# 과거 버전과의 호환성을 위해서 존재 할 뿐 현재는 대부분 람다를
 * 사용하는 것이 일반적이다.)
 * 
 * C# 이 지원하는 델리게이트 종류
 * - Action			<- 반환 값이 없는 메서드에 대한 델리게이트
 * - Func			<- 반환 값이 존재하는 메서드에 대한 델리게이트
 * 
 * Ex)
 * Action<int, float>			<- 정수 1 개, 실수 1 개를 입력으로 받는 메서드에 대한 델리게이트
 * Func<int, float>				<- 정수 1 개를 입력으로 받고 실수를 출력하는 메서드에 대한 델리게이트
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_16
{
	/**
	 * Example 16
	 */
	internal class CE01Example_16
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_16_01
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");

			for(int i = 0; i < oListValues.Count; ++i)
			{
				Console.Write("{0}, ", oListValues[i]);
			}

			Console.Write("\n\n정수 입력 : ");
			int.TryParse(Console.ReadLine(), out int nVal);

			/*
			 * 람다 메서드는 해당 메서드가 구현 된 영역에 존재하는 지역 변수를 사용하는 것이
			 * 가능하다. (+ 즉, 람다 메서드 또한 특정 메서드의 일부로 인식한다는 것을 알 수 있다.)
			 */
			int nIdx = oListValues.FindIndex((a_nVal) =>
			{
				return a_nVal == nVal;
			});

			Action oActionA = () =>
			{
				Console.WriteLine("람다 메서드 호출!");
			};

			Action oActionB = E01GetAction_16(nVal);
			Console.WriteLine("결과 : {0}\n", (nIdx >= 0) ? "탐색 성공" : "탐색 실패");

			oActionA();
			oActionB();
#elif P_E01_EXAMPLE_16_02
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");

			for(int i = 0; i < oListValues.Count; ++i)
			{
				Console.Write("{0}, ", oListValues[i]);
			}

			Console.Write("\n\n정수 입력 : ");
			int.TryParse(Console.ReadLine(), out int nVal);

			/*
			 * 무명 메서드 또한 람다 메서드와 마찬가지로 메서드 외부에 존재하는 지역 변수에
			 * 접근하는 것이 가능하다.
			 */
			int nIdx = oListValues.FindIndex(delegate (int a_nVal)
			{
				return a_nVal == nVal;
			});

			Console.WriteLine("결과 : {0}\n", (nIdx >= 0) ? "탐색 성공" : "탐색 실패");
#elif P_E01_EXAMPLE_16_03
			/*
			 * 델리게이트 체인을 활용하면 특정 델리게이트 변수가 여러 메서드를 제어하는 것이 
			 * 가능하다.
			 * 
			 * 이때, 해당 델리게이트 변수를 통해 메서드를 호출하면 변수가 지니고 있던 메서드가 추가
			 * 된 순서에 따라 순차적으로 호출 된다는 특징이 존재한다.
			 * 
			 * 따라서 해당 특징을 활용하면 프로그램이 수행 중에 특정 작업을 여러 단계에 걸쳐서 
			 * 수행 할 필요가 있을 경우 델리게이트 체인을 통해 좀 더 수월하게 각 메서드를 
			 * 호출해주는 것이 가능하다.
			 * 
			 * 또한 델리게이트 변수에 = (할당 연산자) 를 사용 할 경우 기존에 지니고 있던 체인 
			 * 정보는 리셋이 된다는 특징이 존재하기 때문에 체인 정보를 유지하기 위해서는 
			 * = (할당 연산자) 가 아닌 +, - 연산자를 활용해서 특정 메서드를 추가하거나 
			 * 제거해야한다.
			 * 
			 * 만약, 델리게이트 체인에서 관리되고 있는 메서드가 반환 값이 존재 할 경우에는 가장 
			 * 마지막에 추가 된 메서드의 반환 값만 유효하며 나머지 메서드의 반환 값은 무시가 된다는 
			 * 특징이 존재한다.
			 * 
			 * 따라서 해당 결과를 유도한 경우가 아니라면 델리게이트 체인에는 가능하면 반환 값이 
			 * 존재하지 않는 메서드를 추가하거나 제거하는 것을 추천한다.
			 */
			E01Printer_16 oPrinter = E01PrintMsgA_16;
			oPrinter += E01PrintMsgB_16;
			oPrinter += E01PrintMsgC_16;

			oPrinter += () =>
			{
				Console.WriteLine("네번째 메서드 호출!");
				return 4;
			};

			Console.WriteLine("=====> 델리게이트 체인 <=====");
			Console.WriteLine("{0}", oPrinter());

			oPrinter -= E01PrintMsgB_16;

			Console.WriteLine("\n=====> 델리게이트 체인 - 제거 후 <=====");
			Console.WriteLine("{0}", oPrinter());

			oPrinter = E01PrintMsgA_16;

			Console.WriteLine("\n=====> 델리게이트 체인 - 할당 후 <=====");
			Console.WriteLine("{0}", oPrinter());
#endif // P_E01_EXAMPLE_16_01
		}

#if P_E01_EXAMPLE_16_01
		/** 람다를 반환한다 */
		private static Action E01GetAction_16(int a_nVal)
		{
			/*
			 * 람다 메서드는 해당 메서드가 구현되어있는 지역 변수에 접근하는 것이 가능하며
			 * 만약 해당 지역이 더이상 유효하지 않더라도 람다 메서드 내부에서는 여전히 필요에 따라
			 * 해당 지역에 존재했던 지역 변수를 사용하는 것이 가능하다.
			 * 
			 * (+ 즉, 개념적으로 람다 메서드가 외부에 존재하는 지역 변수의 사본을 가지고 있는 
			 * 개념과 비슷한 의미이다.)
			 * 
			 * 따라서 특정 고수준 언어에서는 람다를 클로저라고도 부른다. (+ 즉, 클로저라는 단어는 
			 * 외부에서는 닫혀 있는 영역이지만 내부에서 여전히 열려 있는 영역이라는 의미를 내포하고 
			 * 있다.)
			 */
			return () =>
			{
				Console.WriteLine("람다 메서드 호출 : {0}", a_nVal);
			};
		}
#elif P_E01_EXAMPLE_16_03
		/** 출력 델리게이트 */
		private delegate int E01Printer_16();

		/** 메세지를 출력한다 */
		private static int E01PrintMsgA_16()
		{
			Console.WriteLine("첫번째 메서드 호출!");
			return 1;
		}

		/** 메세지를 출력한다 */
		private static int E01PrintMsgB_16()
		{
			Console.WriteLine("두번째 메서드 호출!");
			return 2;
		}

		/** 메세지를 출력한다 */
		private static int E01PrintMsgC_16()
		{
			Console.WriteLine("세번째 메서드 호출!");
			return 3;
		}
#endif // #if P_E01_EXAMPLE_16_03
	}
}
