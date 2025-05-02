//#define A_E01_EXAMPLE_02_01
#define A_E01_EXAMPLE_02_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 탐색 (Search) 이란?
 * - 데이터의 집합으로부터 특정 데이터를 찾는 행위를 의미한다. (+ 즉, 탐색은 프로그램 제작 과정에서
 * 빈번하게 발생한다는 것을 알 수 있다.)
 * 
 * 탐색 알고리즘 종류
 * - 선형 탐색 (Linear Search)
 * - 이진 탐색 (Binary Search)
 * - 해시 탐색 (Hash Search)
 * 
 * 선형 탐색 (Linear Search) 이란?
 * - 데이터의 집합에 존재하는 모든 데이터를 하나씩 차례대로 검사하는 알고리즘을 의미한다. (+ 즉,
 * 특정 데이터를 찾는 가장 일반적인 방법이라는 것을 알 수 있다.)
 * 
 * 데이터를 차례대로 모두 검사하는 방법이기 때문에 일정한 규칙 없이 존재하는 데이터의 집합에도
 * 사용 가능한 장점이 존재하지만 데이터가 많을수록 검사 횟수가 선형적으로 늘어나는 단점이 존재한다.
 * (+ 즉, 데이터가 많을수록 성능이 떨어진다는 것을 알 수 있다.)
 * 
 * 이진 탐색 (Binary Search) 이란?
 * - 데이터를 검사하는 행위를 할때마다 탐색의 범위를 절반씩 줄여나가는 알고리즘을 의미한다. (+ 즉,
 * 선형 탐색에 비해 빠르게 데이터를 탐색하는 것이 가능하다.)
 * 
 * 이진 탐색은 데이터의 집합에 많은 데이터가 존재하는 상황에서도 빠르게 특정 데이터를 탐색하는 것이
 * 가능하지만 탐색의 범위를 줄여나가기 위해 데이터를 특정 규칙 (+ Ex. 오름차순 등등...) 에 맞게
 * 정렬해야되는 단점이 존재한다. (+ 즉, 무작위로 나열 된 데이터의 집합에는 사용이 불가능하다.)
 * 
 * 해시 탐색 (Hash Search) 이란?
 * - 데이터가 존재하는 위치를 계산해서 빠르게 데이터를 탐색하는 알고리즘을 의미한다. (+ 즉,
 * 이진 탐색과 마찬가지로 무작위로 나열 된 데이터의 집합에는 사용이 불가능하다.)
 * 
 * 해시 탐색은 특정 데이터를 데이터의 집합에 추가 할 때 계산 된 위치에 추가함으로서 이후 데이터의 
 * 탐색을 빠르게 수행하는 것이 가능하다. (+ 즉, 이론적으로 데이터의 탐색을 상수 시간에 처리하는 것이
 * 가능하다.)
 * 
 * 단, 해시 탐색은 내부적으로 충돌과 클러스터 현상이 발생하면 탐색의 성능이 떨어지기 때문에
 * 해당 현상을 줄이기 위해 많은 메모리가 사용되는 단점이 존재한다. (+ 즉, 관리되는 데이터의 개수보다
 * 더 많은 메모리를 사용한다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * Example 2
	 */
	internal class CE01Example_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			E01SortValues_02(oListValues);

			Console.WriteLine("=====> 리스트 <=====");
			E01PrintValues_02(oListValues);

			Console.Write("\n정수 입력 : ");
			int.TryParse(Console.ReadLine(), out int nVal);

			int nResult = E01FindVal_02(oListValues, nVal);
			Console.WriteLine("결과 : {0}", nResult);
		}

		/** 값을 출력한다 */
		private static void E01PrintValues_02(List<int> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}

#if A_E01_EXAMPLE_02_01
		/** 값을 탐색한다 */
		private static int E01FindVal_02(List<int> a_oListValues, int a_nVal)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				// 값이 존재 할 경우
				if(a_nVal == a_oListValues[i])
				{
					return i;
				}
			}

			return -1;
		}
#elif A_E01_EXAMPLE_02_02
		/** 값을 탐색한다 */
		private static int E01FindVal_02(List<int> a_oListValues, int a_nVal)
		{
			int nLeft = 0;
			int nRight = a_oListValues.Count - 1;

			while(nLeft <= nRight)
			{
				int nMiddle = (nLeft + nRight) / 2;

				// 값이 존재 할 경우
				if(a_nVal == a_oListValues[nMiddle])
				{
					return nMiddle;
				}

				// 값이 왼쪽에 존재 할 경우
				if(a_nVal < a_oListValues[nMiddle])
				{
					nRight = nMiddle - 1;
				}
				else
				{
					nLeft = nMiddle + 1;
				}
			}

			return -1;
		}

		/** 값을 정렬한다 */
		private static void E01SortValues_02(List<int> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count - 1; ++i)
			{
				for(int j = 0; j < a_oListValues.Count - (i + 1); ++j)
				{
					// 정렬이 필요없을 경우
					if(a_oListValues[j] < a_oListValues[j + 1])
					{
						continue;
					}

					int nTemp = a_oListValues[j];
					a_oListValues[j] = a_oListValues[j + 1];
					a_oListValues[j + 1] = nTemp;
				}
			}
		}
#endif // #if A_E01_EXAMPLE_02_01
	}
}
