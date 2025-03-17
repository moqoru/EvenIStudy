//#define A_E01_EXAMPLE_04_01
#define A_E01_EXAMPLE_04_02
#define A_E01_EXAMPLE_04_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 불안정 정렬 알고리즘 종류
 * - 선택 정렬 (Selection Sorting)
 * - 힙 정렬 (Heap Sorting)
 * - 퀵 정렬 (Qucik Sorting)
 * 
 * 선택 정렬 (Selection Sorting) 이란?
 * - 데이터 집합에 존재하는 모든 데이터를 검사 후 정렬 기준에 부합하는 데이터를 찾아 올바른 위치로
 * 옮기는 과정을 반복함으로서 모든 데이터를 정렬하는 의미한다. (+ 즉, 모든 데이터를 검사하는 과정이
 * 완료 될 때마다 데이터가 하나씩 정렬된다는 것을 알 수 있다.)
 * 
 * 힙 정렬 (Heap Sorting) 이란?
 * - 데이터 집합에 존재하는 모든 데이터를 힙 구조로 정렬 후 루트 노드에 존재하는 데이터를
 * 가져오는 행위를 반복함으로서 모든 데이터를 정렬하는 알고리즘을 의미한다. (+ 즉, 힙을 구성하는
 * 방법에 따라 오름차순 or 내림차순으로 정렬 된 결과를 얻을 수 있다.)
 * 
 * 퀵 정렬 (Quick Sorting) 이란?
 * - 특정 데이터를 기준으로 삼아 해당 데이터를 기점으로 그룹을 나누는 행위를 반복함으로서
 * 모든 데이터를 정렬하는 알고리즘을 의미한다. (+ 즉, 데이터를 더이상 나눌 수 없는 시점에 도달하면
 * 데이터의 정렬이 완료된다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_04
{
	/**
	 * Example 4
	 */
	class CE01Example_04
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

			Console.WriteLine("=====> 리스트 요소 - 정렬 전 <=====");
			E01PrintValues_04(oListValues);

			E01SortValues_04(oListValues, E01Compare_ByAscending_04);

			Console.WriteLine("\n=====> 리스트 요소 - 정렬 후 (오름차순) <=====");
			E01PrintValues_04(oListValues);

			E01SortValues_04(oListValues, E01Compare_ByDescending_04);

			Console.WriteLine("\n=====> 리스트 요소 - 정렬 후 (내림차순) <=====");
			E01PrintValues_04(oListValues);
		}

		/** 오름차순으로 비교한다 */
		private static int E01Compare_ByAscending_04(int a_nLhs, int a_nRhs)
		{
			return a_nLhs - a_nRhs;
		}

		/** 내림차순으로 비교한다 */
		private static int E01Compare_ByDescending_04(int a_nLhs, int a_nRhs)
		{
			return a_nRhs - a_nLhs;
		}

		/** 값을 출력한다 */
		private static void E01PrintValues_04(List<int> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}

#if A_E01_EXAMPLE_04_01
		/** 값을 정렬한다 */
		private static void E01SortValues_04(List<int> a_oListValues,
			Func<int, int, int> a_oCompare)
		{
			for(int i = 0; i < a_oListValues.Count - 1; ++i)
			{
				int nIdx_Compare = i;

				for(int j = i + 1; j < a_oListValues.Count; ++j)
				{
					// 정렬이 필요없을 경우
					if(a_oCompare(a_oListValues[nIdx_Compare], a_oListValues[j]) <= 0)
					{
						continue;
					}

					nIdx_Compare = j;
				}

				int nTemp = a_oListValues[i];
				a_oListValues[i] = a_oListValues[nIdx_Compare];
				a_oListValues[nIdx_Compare] = nTemp;
			}
		}
#elif A_E01_EXAMPLE_04_02
		/** 값을 정렬한다 */
		private static void E01SortHeap_04(List<int> a_oListValues,
			int a_nIdx_Start, int a_nNumValues, Func<int, int, int> a_oCompare)
		{
			int nIdx = a_nIdx_Start;

			while(nIdx < a_nNumValues / 2)
			{
				int nIdx_Compare = (nIdx * 2) + 1;

				// 오른쪽 노드가 존재 할 경우
				if(nIdx_Compare + 1 < a_nNumValues)
				{
					int nIdx_RChild = nIdx_Compare + 1;

					nIdx_Compare = (a_oCompare(a_oListValues[nIdx_Compare], a_oListValues[nIdx_RChild]) >= 0) ?
						nIdx_Compare : nIdx_RChild;
				}

				// 정렬이 필요없을 경우
				if(a_oCompare(a_oListValues[nIdx], a_oListValues[nIdx_Compare]) >= 0)
				{
					break;
				}

				int nTemp = a_oListValues[nIdx];
				a_oListValues[nIdx] = a_oListValues[nIdx_Compare];
				a_oListValues[nIdx_Compare] = nTemp;

				nIdx = nIdx_Compare;
			}
		}

		/** 값을 정렬한다 */
		private static void E01SortValues_04(List<int> a_oListValues,
			Func<int, int, int> a_oCompare)
		{
			for(int i = a_oListValues.Count / 2 - 1; i >= 0; --i)
			{
				E01SortHeap_04(a_oListValues, i, a_oListValues.Count, a_oCompare);
			}

			for(int i = a_oListValues.Count - 1; i > 0; --i)
			{
				int nTemp = a_oListValues[0];
				a_oListValues[0] = a_oListValues[i];
				a_oListValues[i] = nTemp;

				E01SortHeap_04(a_oListValues, 0, i, a_oCompare);
			}
		}
#elif A_E01_EXAMPLE_04_03
		/** 값을 정렬한다 */
		private static void E01SortQuick_04(List<int> a_oListValues,
			int a_nLeft, int a_nRight, Func<int, int, int> a_oCompare)
		{
			// 정렬이 불가능 할 경우
			if(a_nLeft >= a_nRight)
			{
				return;
			}

			int nLeft = a_nLeft + 1;
			int nRight = a_nRight;
			int nPivot = a_nLeft;

			while(true)
			{
				while(nLeft < nRight && a_oCompare(a_oListValues[nPivot], a_oListValues[nLeft]) >= 0)
				{
					nLeft += 1;
				}

				while(nLeft <= nRight && a_oCompare(a_oListValues[nPivot], a_oListValues[nRight]) <= 0)
				{
					nRight -= 1;
				}

				// 정렬이 불가능 할 경우
				if(nLeft >= nRight)
				{
					break;
				}

				int nTemp = a_oListValues[nLeft];
				a_oListValues[nLeft] = a_oListValues[nRight];
				a_oListValues[nRight] = nTemp;
			}

			// 정렬이 필요 할 경우
			if(a_oCompare(a_oListValues[nPivot], a_oListValues[nRight]) > 0)
			{
				int nTemp = a_oListValues[nRight];
				a_oListValues[nRight] = a_oListValues[nPivot];
				a_oListValues[nPivot] = nTemp;
			}

			E01SortQuick_04(a_oListValues, a_nLeft, nRight - 1, a_oCompare);
			E01SortQuick_04(a_oListValues, nRight + 1, a_nRight, a_oCompare);
		}

		/** 값을 정렬한다 */
		private static void E01SortValues_04(List<int> a_oListValues, 
			Func<int, int, int> a_oCompare)
		{
			E01SortQuick_04(a_oListValues, 0, a_oListValues.Count - 1, a_oCompare);
		}
#endif // #if A_E01_EXAMPLE_04_01
	}
}
