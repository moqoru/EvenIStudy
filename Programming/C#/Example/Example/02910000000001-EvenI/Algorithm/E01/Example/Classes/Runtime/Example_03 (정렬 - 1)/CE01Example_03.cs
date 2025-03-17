//#define A_E01_EXAMPLE_03_01
#define A_E01_EXAMPLE_03_02
#define A_E01_EXAMPLE_03_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 정렬 (Sorting) 이란?
 * - 데이터의 집합에 존재하는 데이터들을 일정 규칙 (+ Ex. 오른차순 등등...) 에 맞춰서 나열하는 것을 
 * 의미한다. (+ 즉, 정렬은 주로 데이터 탐색을 수월하게 하기 위해서 수행된다는 것을 알 수 있다.)
 * 
 * 정렬은 내부적으로 데이터가 정렬되는 결과에 따라 안정 정렬과 불안정 정렬로 구분된다. (+ 즉,
 * 정렬을 수행하기 이전의 정렬 상태가 정렬 후에도 유지가 되면 안정 정렬이며 유지되지 않으면
 * 불안정 정렬이라는 것을 알 수 있다.)
 * 
 * 안정 정렬 알고리즘 종류
 * - 버블 정렬 (Bubble Sorting)
 * - 삽입 정렬 (Insertion Sorting)
 * - 병합 정렬 (Merge Sorting)
 * 
 * 버블 정렬 (Bubble Sorting) 이란?
 * - 인접한 데이터를 비교 후 정렬 기준에 맞게 위치를 변경하는 과정을 반복함으로서 모든 데이터를
 * 정렬하는 알고리즘을 의미한다.
 * 
 * 삽입 정렬 (Insertion Sorting) 이란?
 * - 데이터를 정렬 기준에 맞게 특정 위치로 옮기는 과정을 반복함으로서 모든 데이터를 정렬하는
 * 알고리즘을 의미한다.
 * 
 * 병합 정렬 (Merge Sorting) 이란?
 * - 데이터를 더이상 나눌 수 없을때까지 절반씩 그룹을 지어준 후 그룹 하위에 있는 데이터를
 * 상위 그룹에 합치는 과정을 반복함으로서 모든 데이터를 정렬하는 알고리즘을 의미한다. (+ 즉, 
 * 하위 그룹의 데이터를 상위 그룹에 합치는 과정에서 데이터의 정렬이 이루어진다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_03
{
	/**
	 * Example 3
	 */
	class CE01Example_03
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
			E01PrintValues_03(oListValues);

			E01SortValues_03(oListValues, E01Compare_ByAscending_03);

			Console.WriteLine("\n=====> 리스트 요소 - 정렬 후 (오름차순) <=====");
			E01PrintValues_03(oListValues);

			E01SortValues_03(oListValues, E01Compare_ByDescending_03);

			Console.WriteLine("\n=====> 리스트 요소 - 정렬 후 (내림차순) <=====");
			E01PrintValues_03(oListValues);
		}

		/** 오름차순으로 비교한다 */
		private static int E01Compare_ByAscending_03(int a_nLhs, int a_nRhs)
		{
			return a_nLhs - a_nRhs;
		}

		/** 내림차순으로 비교한다 */
		private static int E01Compare_ByDescending_03(int a_nLhs, int a_nRhs)
		{
			return a_nRhs - a_nLhs;
		}

		/** 값을 출력한다 */
		private static void E01PrintValues_03(List<int> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}

#if A_E01_EXAMPLE_03_01
		/** 값을 정렬한다 */
		private static void E01SortValues_03(List<int> a_oListValues,
			Func<int, int, int> a_oCompare)
		{
			for(int i = 0; i < a_oListValues.Count - 1; ++i)
			{
				for(int j = 0; j < a_oListValues.Count - (i + 1); ++j)
				{
					// 정렬이 필요없을 경우
					if(a_oCompare(a_oListValues[j], a_oListValues[j + 1]) <= 0)
					{
						continue;
					}

					int nTemp = a_oListValues[j];
					a_oListValues[j] = a_oListValues[j + 1];
					a_oListValues[j + 1] = nTemp;
				}
			}
		}
#elif A_E01_EXAMPLE_03_02
		/** 값을 정렬한다 */
		private static void E01SortValues_03(List<int> a_oListValues,
			Func<int, int, int> a_oCompare)
		{
			for(int i = 1; i < a_oListValues.Count; ++i)
			{
				int j = 0;
				int nVal_Compare = a_oListValues[i];

				for(j = i - 1; j >= 0; --j)
				{
					// 정렬이 필요없을 경우
					if(a_oCompare(a_oListValues[j], nVal_Compare) <= 0)
					{
						break;
					}

					a_oListValues[j + 1] = a_oListValues[j];
				}

				a_oListValues[j + 1] = nVal_Compare;
			}
		}
#elif A_E01_EXAMPLE_03_03
		/** 값을 정렬한다 */
		private static void E01SortMerge_03(List<int> a_oListValues,
			int a_nLeft, int a_nRight, Func<int, int, int> a_oCompare, int[] a_oOutValues_Sort)
		{
			// 정렬이 불가능 할 경우
			if(a_nLeft >= a_nRight)
			{
				return;
			}

			int nMiddle = (a_nLeft + a_nRight) / 2;

			E01SortMerge_03(a_oListValues, a_nLeft, nMiddle, a_oCompare, a_oOutValues_Sort);
			E01SortMerge_03(a_oListValues, nMiddle + 1, a_nRight, a_oCompare, a_oOutValues_Sort);

			int nLeft = a_nLeft;
			int nRight = nMiddle + 1;
			int nIdx_SortVal = nLeft;

			while(true)
			{
				while(nLeft <= nMiddle && a_oCompare(a_oListValues[nLeft], a_oListValues[nRight]) <= 0)
				{
					a_oOutValues_Sort[nIdx_SortVal++] = a_oListValues[nLeft++];
				}

				while(nRight <= a_nRight && a_oCompare(a_oListValues[nLeft], a_oListValues[nRight]) > 0)
				{
					a_oOutValues_Sort[nIdx_SortVal++] = a_oListValues[nRight++];
				}

				// 정렬이 불가능 할 경우
				if(nLeft > nMiddle || nRight > a_nRight)
				{
					break;
				}
			}

			while(nLeft <= nMiddle)
			{
				a_oOutValues_Sort[nIdx_SortVal++] = a_oListValues[nLeft++];
			}

			while(nRight <= a_nRight)
			{
				a_oOutValues_Sort[nIdx_SortVal++] = a_oListValues[nRight++];
			}

			for(int i = a_nLeft; i <= a_nRight; ++i)
			{
				a_oListValues[i] = a_oOutValues_Sort[i];
			}
		}

		/** 값을 정렬한다 */
		private static void E01SortValues_03(List<int> a_oListValues,
			Func<int, int, int> a_oCompare)
		{
			var oListValues_Temp = new int[a_oListValues.Count];

			E01SortMerge_03(a_oListValues,
				0, a_oListValues.Count - 1, a_oCompare, oListValues_Temp);
		}
#endif // #if A_E01_EXAMPLE_03_01
	}
}
