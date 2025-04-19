//#define P_E01_EXAMPLE_08_01
//#define P_E01_EXAMPLE_08_02
#define P_E01_EXAMPLE_08_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 메서드 (함수) 란?
 * - 명령문의 일부 or 전체를 따로 때어내서 재사용 할 수 있는 기능을 의미한다. (+ 즉, 
 * 메서드를 활용하면 중복적으로 발생하는 명령문을 줄이는 것이 가능하다.)
 * 
 * 메서드는 내부적으로 메서드가 호출 될 때 실행되는 명령문을 포함하고 있으며 필요에 따라 메서드가 
 * 동작하기 위해서 필요한 데이터를 외부로부터 입력 받는 것이 가능하다. (+ 즉, 
 * 프로그래밍의 메서드 (함수) 는 수학의 함수와 조금 다르다는 것을 알 수 있다.)
 * 
 * C# 메서드 유형
 * - 입력 O, 출력 O			<- int SomeMethod(int a_nVal);
 * - 입력 O, 출력 X			<- void SomeMethod(int a_nVal);
 * - 입력 X, 출력 O			<- int SomeMethod();
 * - 입력 X, 출력 X			<- void SomeMethod();
 * 
 * 위와 같이 메서드는 입력 데이터와 출력 데이터의 존재 여부에 따라 크게 4 가지 유형으로 구분된다는 
 * 것을 알 수 있다.
 * 
 * C# 메서드 구현 방법
 * - 반환 형 (출력) + 메서드 이름 + 매개 변수 (입력) + 메서드 몸체
 * 
 * Ex)
 * void SomeMethod(int a_nValA, int a_nValB)
 * {
 *		// 메서드가 호출 될 때 실행 될 명령문
 * }
 * 
 * 단, 메서드의 입력 (매개 변수) 은 원하는 만큼 명시하는 것이 가능하지만 메서드의 출력은 하나만 
 * 명시하는 것이 가능하다. (+ 즉, 입력 데이터는 여러 개를 받는 것이 가능하지만 
 * 출력은 오직 하나의 데이터만 출력하는 것이 가능하다.)
 * 
 * 따라서 메서드의 여러 데이터를 출력하기 위해서는 컬렉션과 같은 기능을 활용해야한다.
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_08
{
	/**
	 * Example 8
	 */
	internal class CE01Example_08
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_08_01
			Console.Write("수식 입력 : ");
			var oTokens = Console.ReadLine().Split();

			int.TryParse(oTokens[0], out int nValA);
			int.TryParse(oTokens[2], out int nValB);

			char.TryParse(oTokens[1], out char chOperator);

			/*
			 * 호출 할 메서드가 입력 데이터를 요구 할 경우 반드시 요구하는 데이터만큼 입력 값을 
			 * 전달 할 필요가 있다. (+ 즉, 매개 변수의 개수와 입력 값의 개수는 동일해야한다는 것을 
			 * 알 수 있다.)
			 * 
			 * 또한 입력 값을 명시하는 순서는 메서드의 매개 변수의 순서와 동일해야한다. (+ 즉, 
			 * 입력 값은 차례대로 각 매개 변수에 전달 된다는 것을 알 수 있다.
			 */
			decimal dmResult = E01GetResult_Calc_08(nValA, chOperator, nValB);
			Console.WriteLine("결과 : {0}", dmResult);
#elif P_E01_EXAMPLE_08_02
			int nValA = 10;
			int nValB = 20;

			/*
			 * C# 의 메서드 호출 규칙은 기본적으로 값에 의한 호출이기 때문에 특정 메서드를 호출 
			 * 할 때 입력 값을 명시 할 경우 해당 값은 메서드의 매개 변수로 복사가 된다는 것을 
			 * 알 수 있다. (+ 즉, 메서드 내부에서는 원본 변수의 값을 변경하는 것이 
			 * 불가능하다는 것을 알 수 있다.)
			 * 
			 * 만약, 메서드에서 원본 변수에 값을 변경하고 싶다면 해당 변수의 참조 값을 전달 할 
			 * 필요가 있으며 이러한 호출 방식을 참조에 의한 호출이라고 한다.
			 * 
			 * C# 참조 호출 관련 키워드
			 * - ref
			 * - out
			 * 
			 * int nVal = 0;
			 * SomeMethod(ref nVal);
			 * 
			 * void SomeMethod(ref int a_rnVal)
			 * {
			 *		// Do Something
			 * }
			 * 
			 * 위와 같이 참조 키워드를 사용해서 메서드를 호출하면 변수가 지니고 있는 데이터를 
			 * 전달하는 것이 아니라 변수를 참조 할 수 있는 참조 값이 전달 된다는 것을 알 수 있다.
			 * 
			 * 또한 메서드 매개 변수에는 참조 키워드를 명시해서 단순한 데이터가 복사되는 것이 
			 * 아니라 참조를 전달 받을 수 있는 매개 변수라는 것을 C# 컴파일러에게 알려 줄 필요가 
			 * 있다.
			 */
			E01Swap_ByVal_08(nValA, nValB);

			Console.WriteLine("=====> 값에 의한 호출 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);

			E01Swap_ByRef_08(ref nValA, ref nValB);

			Console.WriteLine("\n=====> 참조에 의한 호출 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);
#elif P_E01_EXAMPLE_08_03
			int nValA = 0;
			int nValB = 0;

			/*
			 * ref 키워드 vs out 키워드
			 * - 두 키워드 모두 변수의 참조 값을 전달하는 역할을 수행한다.
			 * 
			 * ref 키워드는 단순히 참조 값을 전달하는 역할만을 수행하기 때문에 초기화 되지 않은 
			 * 변수에는 사용하는 것이 불가능하다. (+ 즉, 컴파일 에러가 발생한다는 것을 알 수 있다.)
			 * 
			 * 반면 out 키워드는 초기화되지 않은 변수에도 사용하는 것이 가능하다.
			 * 
			 * 이는 out 키워드로 참조를 전달 받을 경우 참조를 통해 대상의 값을 읽어오기 전에 반드시 
			 * 특정 값을 설정해줘야하기 때문이다. (+ 즉, out 키워드로 참조를 전달 받을 경우 반드시 
			 * 특정 값으로 설정해줘야하며 그렇지 않으면 컴파일 에러가 발생한다는 것을 알 수 있다.)
			 */
			E01SetVal_ByRef_08(ref nValA, 10);
			E01SetVal_ByOut_08(out nValB, 20);

			Console.WriteLine("{0}, {1}", nValA, nValB);
#endif
		}

#if P_E01_EXAMPLE_08_01
		/** 수식 결과를 반환한다 */
		private static decimal E01GetResult_Calc_08(int a_nValA, 
			char a_chOperator, int a_nValB)
		{
			switch(a_chOperator)
			{
				case '+':
					return a_nValA + a_nValB;

				case '-':
					return a_nValA - a_nValB;

				case '*':
					return a_nValA * a_nValB;

				case '/':
					return a_nValA / (decimal)a_nValB;
			}

			/*
			 * return 키워드란?
			 * - 프로그램의 흐름을 중단하고 해당 메서드를 호출한 곳으로 되돌리는 역할을 수행하는 
			 * 키워드를 의미한다. (+ 즉, 해당 키워드를 활용하면 특정 메서드의 실행을 중지 시키는 것이 
			 * 가능하다.)
			 * 
			 * 또한 메서드가 반환 값이 존재 할 경우 return 키워드에 반환 값을 반드시 명시해야되며 
			 * 명시 된 반환 값은 메서드를 호출한 곳으로 전달 된다는 특징이 존재한다. (+ 즉, 
			 * 메서드가 반환 값이 존재 할 경우 반드시 return 키워드를 사용해서 반환 값을 
			 * 명시해 줄 필요가 있다.)
			 */
			return 0;
		}
#elif P_E01_EXAMPLE_08_02
		/** 값을 교환한다 */
		private static void E01Swap_ByVal_08(int a_nValA, int a_nValB)
		{
			int nTemp = a_nValA;
			a_nValA = a_nValB;
			a_nValB = nTemp;
		}

		/** 값을 교환한다 */
		private static void E01Swap_ByRef_08(ref int a_rnValA, ref int a_rnValB)
		{
			int nTemp = a_rnValA;
			a_rnValA = a_rnValB;
			a_rnValB = nTemp;
		}
#elif P_E01_EXAMPLE_08_03
		/** 값을 변경한다 */
		private static void E01SetVal_ByRef_08(ref int a_rnTarget, int a_nVal)
		{
			a_rnTarget = a_nVal;
		}

		/** 값을 변경한다 */
		private static void E01SetVal_ByOut_08(out int a_rnTarget, int a_nVal)
		{
			a_rnTarget = a_nVal;
		}
#endif
	}
}
