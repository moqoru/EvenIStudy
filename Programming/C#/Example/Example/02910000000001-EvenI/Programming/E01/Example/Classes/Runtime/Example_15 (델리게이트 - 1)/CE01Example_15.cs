//#define P_E01_EXAMPLE_15_01
//#define P_E01_EXAMPLE_15_02
#define P_E01_EXAMPLE_15_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * using 키워드를 활용하면 특정 네임 스페이스 경로를 축약 시키는 것이 가능하다. (+ 해당 기능을
 * 활용하면 복잡한 네임 스페이스 경로에 좀 더 가독성을 부여하는 것이 가능하다.)
 */
using P_E01_EXAMPLE_15 = Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_15;

/*
 * 델리게이트란?
 * - 메서드를 데이터처럼 특정 메서드에 입력으로 전달하거나 출력으로 메서드를 반환 할 수 있게 해주는 
 * 기능을 의미한다. (+ 즉, 델리게이트를 활용하면 특정 발생되는 이벤트에 따라 객체의 상태를 처리하는 
 * 콜백 구조로 프로그램을 설계하는 것이 가능하다.)
 * 
 * 또한 C# 은 델리게이트를 활용해서 람다 (Lambda) or 무명 메서드 (Anonymous Method) 를 
 * 구현하는 것이 가능하다.
 * 
 * C# 델리게이트 선언 방법
 * - delegate + 반환 형 + 델리게이트 이름 + 매개 변수
 * 
 * Ex)
 * delegate void SomeDelegate(int a_nValA, int a_nValB)
 * 
 * 위의 경우 정수 2 개를 입력으로 받고 출력은 존재하지 않는 메서드에 대한 델리게이트를 선언이라는
 * 것을 알 수 있다.
 */

#if P_E01_EXAMPLE_15_03 && (!P_E01_EXAMPLE_15_01 && !P_E01_EXAMPLE_15_02)
/** 
 * 확장 클래스 
 */
public static partial class CE01Extension_15
{
	/** 값을 정렬한다 */
	public static void E01ExSortValues_15<T>(this List<T> a_oSender,
		P_E01_EXAMPLE_15.CE01Example_15.E01Compare_15<T> a_oCompare)
	{
		for(int i = 1; i < a_oSender.Count; ++i)
		{
			int j = 0;
			T tVal_Compare = a_oSender[i];

			for(j = i - 1; j >= 0; --j)
			{
				// 정렬이 필요없을 경우
				if(a_oCompare(a_oSender[j], tVal_Compare) <= 0)
				{
					break;
				}

				a_oSender[j + 1] = a_oSender[j];
			}

			a_oSender[j + 1] = tVal_Compare;
		}
	}
}
#endif // #if P_E01_EXAMPLE_15_03 && (!P_E01_EXAMPLE_15_01 && !P_E01_EXAMPLE_15_02)

namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_15
{
	/**
	 * Example 15
	 */
	public class CE01Example_15
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_15_01
			Console.Write("정수 (2 개) 입력 : ");
			var oTokens = Console.ReadLine().Split();

			int.TryParse(oTokens[0], out int nValA);
			int.TryParse(oTokens[1], out int nValB);

			E01Compare_15 oCompare = E01CompareVal_15;
			Console.WriteLine("\n=====> 비교 결과 <=====");

			int nResult = oCompare(nValA, nValB);
			Console.WriteLine("{0} Compare {1} = {2}", nValA, nValB, nResult);
#elif P_E01_EXAMPLE_15_02
			Console.Write("\n수식 입력 (+, -, *, /) : ");
			var oTokens = Console.ReadLine().Split();

			int.TryParse(oTokens[0], out int nValA);
			int.TryParse(oTokens[2], out int nValB);

			char.TryParse(oTokens[1], out char chOperator);
			E01Calculator_15 oCalc = E01GetCalc_15(chOperator);

			// 수식이 유효 할 경우
			if(oCalc != null)
			{
				decimal dmResult = oCalc(nValA, nValB);
				Console.WriteLine("{0} {1} {2} = {3}", nValA, chOperator, nValB, dmResult);
			}
			else
			{
				Console.WriteLine("잘못된 수식을 입력했습니다.");
			}
#elif P_E01_EXAMPLE_15_03
			var oRandom = new Random();

			var oListValuesA = new List<int>();
			var oListValuesB = new List<float>();

			for(int i = 0; i < 5; ++i)
			{
				oListValuesA.Add(oRandom.Next(1, 100));
				oListValuesB.Add((float)(oRandom.NextDouble() * 100.0));
			}

			Console.WriteLine("=====> 정렬 전 <=====");

			for(int i = 0; i < oListValuesA.Count; ++i)
			{
				Console.Write("{0}, ", oListValuesA[i]);
			}

			Console.WriteLine();

			for(int i = 0; i < oListValuesB.Count; ++i)
			{
				Console.Write("{0:0.00}, ", oListValuesB[i]);
			}

			oListValuesA.E01ExSortValues_15(E01Compare_ByAscending_15);
			oListValuesB.E01ExSortValues_15(E01Compare_ByDescending_15);

			Console.WriteLine("\n\n=====> 정렬 후 <=====");

			for(int i = 0; i < oListValuesA.Count; ++i)
			{
				Console.Write("{0}, ", oListValuesA[i]);
			}

			Console.WriteLine();

			for(int i = 0; i < oListValuesB.Count; ++i)
			{
				Console.Write("{0:0.00}, ", oListValuesB[i]);
			}

			Console.WriteLine();
#endif // P_E01_EXAMPLE_15_01
		}

#if P_E01_EXAMPLE_15_01
		/** 비교 델리게이트 */
		private delegate int E01Compare_15(int a_nLhs, int a_nRhs);

		/** 값을 비교한다 */
		private static int E01CompareVal_15(int a_nLhs, int a_nRhs)
		{
			return a_nLhs - a_nRhs;
		}
#elif P_E01_EXAMPLE_15_02
		/** 계산 델리게이트 */
		private delegate decimal E01Calculator_15(int a_nLhs, int a_nRhs);

		/** 덧셈 결과를 반환한다 */
		private static decimal E01GetVal_Sum_15(int a_nLhs, int a_nRhs)
		{
			return a_nLhs + a_nRhs;
		}

		/** 뺄셈 결과를 반환한다 */
		private static decimal E01GetVal_Sub_15(int a_nLhs, int a_nRhs)
		{
			return a_nLhs - a_nRhs;
		}

		/** 곱셈 결과를 반환한다 */
		private static decimal E01GetVal_Mul_15(int a_nLhs, int a_nRhs)
		{
			return a_nLhs * a_nRhs;
		}

		/** 나눗셈 결과를 반환한다 */
		private static decimal E01GetVal_Div_15(int a_nLhs, int a_nRhs)
		{
			return a_nLhs / (decimal)a_nRhs;
		}

		/** 계산 메서드를 반환한다 */
		private static E01Calculator_15 E01GetCalc_15(char a_chOperator)
		{
			switch(a_chOperator)
			{
				case '+':
					return E01GetVal_Sum_15;

				case '-':
					return E01GetVal_Sub_15;

				case '*':
					return E01GetVal_Mul_15;

				case '/':
					return E01GetVal_Div_15;
			}

			return null;
		}
#elif P_E01_EXAMPLE_15_03
		/** 비교 델리게이트 */
		public delegate int E01Compare_15<T>(T a_tLhs, T a_tRhs);

		/** 오름차순으로 비교한다 */
		private static int E01Compare_ByAscending_15<T>(T a_nLhs, T a_nRhs) where T : IComparable
		{
			return a_nLhs.CompareTo(a_nRhs);
		}

		/** 내림차순으로 비교한다 */
		private static int E01Compare_ByDescending_15<T>(T a_nLhs, T a_nRhs) where T : IComparable
		{
			return a_nRhs.CompareTo(a_nLhs);
		}
#endif // P_E01_EXAMPLE_15_01
	}
}
