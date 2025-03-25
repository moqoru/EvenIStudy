//#define P_E01_EXAMPLE_09_01
//#define P_E01_EXAMPLE_09_02
#define P_E01_EXAMPLE_09_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 가변 길이 매개 변수란?
 * - 일반적인 메서드는 입력 데이터을 전달 받기 위한 매개 변수의 개수가 정해져있지만 가변 길이 
 * 매개 변수를 활용하면 제한 없이 필요한만큼 데이터를 전달 받는 것이 가능하다.
 * 
 * 단, 가변 길이 매개 변수는 동일한 자료형의 데이터만 지원하기 때문에 서로 다른 자료형의 데이터는 
 * 가변 길이 매개 변수를 활용하는 것이 불가능하다.
 * 
 * Ex)
 * void SomeMethod(params int[] a_oValues)
 * {
 *		// Do Something
 * }
 * 
 * SomeMethod(1);
 * SomeMethod(1, 2);
 * SomeMethod(1, 2, 3);
 * 
 * 메서드 오버로딩이란?
 * - 동일한 이름의 메서드를 중복으로 구현 할 수 있는 기능을 의미한다.
 * 
 * 단, 메서드 오버로딩 규칙이 성립하기 위해서는 메서드의 매개 변수 정보가 달라야한다. (+ 즉, 
 * 동일한 이름의 메서드라고 하더라도 매개 변수 정보가 다르다면 메서드 오버로딩이 성립한다는 것을 
 * 알 수 있다.)
 * 
 * Ex)
 * void SomeMethod(int a_nVal);
 * void SomeMethod(int a_nValA, int a_nValA);
 * 
 * 위의 경우 매개 변수의 개수가 다르기 때문에 메서드 오버로딩 규칙이 성립한다.
 * 
 * void SomeMethod(int a_nVal);
 * void SomeMethod(float a_fVal);
 * 
 * 위의 경우 매개 변수의 개수는 동일하지만 매개 변수의 자료형이 서로 다르기 때문에 메서드 오버로딩 
 * 규칙이 성립한다.
 * 
 * int SomeMethod(int a_nVal);
 * float SomeMethod(int a_nVal);
 * 
 * 위의 경우 반환 값의 자료형이 다르지만 매개 변수 정보가 동일하기 때문에 메서드 오버로딩 규칙이 
 * 성립하지 않는다. (+ 즉, 컴파일 에러가 발생한다.)
 * 
 * 디폴트 매개 변수란?
 * - 매개 변수의 초기 값을 명시 할 수 있는 기능을 의미한다. (+ 즉, 디폴트 매개 변수를 활용하면 
 * 입력 데이터의 명시를 생략하는 것이 가능하다.)
 * 
 * 일반적으로 메서드에 매개 변수가 존재 할 경우 해당 매개 변수의 개수만큼 입력 데이터를 전달 할 
 * 필요가 있지만 디폴트 매개 변수를 활용하면 데이터의 입력을 생략하는 것이 이 경우 해당 매개 변수는 
 * 초기 값으로 설정된다는 특징이 존재한다.
 * 
 * Ex)
 * void SomeMethod(int a_nValA, int a_nValB = 0)
 * {
 *		// Do Something
 * }
 * 
 * SomeMethod(10);
 * SomeMethod(10, 20);
 * 
 * 위의 경우 ValB 매개 변수는 0 으로 초기 값이 명시되어있기 때문에 해당 메서드를 호출 할 때 
 * ValB 에 대한 입력 값을 전달하지 않을 경우 자동으로 0 으로 설정된다는 것을 알 수 있다.
 * 
 * 네임드 매개 변수란?
 * - 입력 데이터를 전달 받기 위한 매개 변수를 명시 할 수 있는 기능을 의미한다. (+ 즉, 
 * 네임드 매개 변수를 활용하면 입력 데이터의 순서와 매개 변수의 순서가 서로 달라질 수 있다는 것을 
 * 의미한다.)
 * 
 * Ex)
 * void SomeMethod(int a_nValA, int a_nValB)
 * {
 *		// Do Something
 * }
 * 
 * SomeMethod(a_nValB: 10, a_nValA: 20);
 * 
 * 위와 같이 입력 데이터를 전달 받을 매개 변수를 직접 명시하는 것이 가능하다.
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_09
{
	/**
	 * Example 9
	 */
	internal class CE01Example_09
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_09_01
			/*
			 * 가변 길이 매개 변수를 활용하면 C# 컴파일러가 메서드의 입력 데이터를 배열의 형태로 
			 * 전달해준다는 것을 알 수 있다.
			 */
			int nVal_SumA = E01GetVal_Sum_09(1, 2, 3);
			int nVal_SumB = E01GetVal_Sum_09(1, 2, 3, 4, 5, 6);
			int nVal_SumC = E01GetVal_Sum_09(1, 2, 3, 4, 5, 6, 7, 8, 9);

			Console.WriteLine("{0}, {1}, {2}", nVal_SumA, nVal_SumB, nVal_SumC);
#elif P_E01_EXAMPLE_09_02
			int nVal_MaxA = E01GetVal_Max_09(10, 20);
			int nVal_MaxB = E01GetVal_Max_09(10, 20, 30);

			Console.WriteLine("{0}, {1}", nVal_MaxA, nVal_MaxB);
#elif P_E01_EXAMPLE_09_03
			int nVal_SumA = E01GetVal_Sum_09(10);
			int nVal_SumB = E01GetVal_Sum_09(10, 20);

			/*
			 * 아래의 경우 네임드 매개 변수를 활용해서 입력 할 데이터를 전달 받을 매개 변수를 직접 
			 * 명시했다는 것을 알 수 있다. (+ 즉, 데이터의 입력 순서와 매개 변수의 순서가 
			 * 서로 다르다는 것을 알 수 있다.)
			 */
			int nVal_SumC = E01GetVal_Sum_09(a_nValB: 10, a_nValA: 20);

			Console.WriteLine("{0}, {1}, {2}", nVal_SumA, nVal_SumB, nVal_SumC);
#endif // #if P_E01_EXAMPLE_09_01
		}

#if P_E01_EXAMPLE_09_01
		/** 합계를 반환한다 */
		private static int E01GetVal_Sum_09(params int[] a_oValues)
		{
			int nVal_Sum = 0;

			for(int i = 0; i < a_oValues.Length; ++i)
			{
				nVal_Sum += a_oValues[i];
			}

			return nVal_Sum;
		}
#elif P_E01_EXAMPLE_09_02
		/** 최대 값을 반환한다 */
		private static int E01GetVal_Max_09(int a_nValA, int a_nValB)
		{
			return Math.Max(a_nValA, a_nValB);
		}

		/** 최대 값을 반환한다 */
		private static int E01GetVal_Max_09(int a_nValA, int a_nValB, int a_nValC)
		{
			int nVal_Max = Math.Max(a_nValA, a_nValB);
			return Math.Max(nVal_Max, a_nValC);
		}
#elif P_E01_EXAMPLE_09_03
		/** 합계를 반환한다 */
		private static int E01GetVal_Sum_09(int a_nValA, int a_nValB = 0)
		{
			return a_nValA + a_nValB;
		}
#endif // #if P_E01_EXAMPLE_09_01
	}
}
