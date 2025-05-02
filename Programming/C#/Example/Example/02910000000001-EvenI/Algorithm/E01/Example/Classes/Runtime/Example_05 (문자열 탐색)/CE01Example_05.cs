//#define A_E01_EXAMPLE_05_01
//#define A_E01_EXAMPLE_05_02
#define A_E01_EXAMPLE_05_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 문자열 탐색 (String Search) 란?
 * - 문자열에서 특정 패턴을 탐색하는 행위를 의미한다. (+ 즉, 문자열 내부에 하위 문자열의 존재 여부를
 * 검사한다는 것을 알 수 있다.)
 * 
 * 문자열 탐색 알고리즘 종류
 * - 브루트 포스 (Brute Force)
 * - KMP (Knuth Morris Pratt)
 * - 보이어 무어 (Boyre Moore)
 * 
 * 브루트 포스 (Bruth Force) 란?
 * - 첫 문자부터 차례대로 문자를 비교하는 과정을 반복함으로서 문자열 패턴을 탐색하는 알고리즘이다.
 * (+ 즉, 가장 일반적인 알고리즘이라는 것을 알 수 있다.)
 * 
 * 문자열 패턴 탐색에 실패 할 경우 검사하는 문자를 한 문자씩 옮겨서 다시 문자열 패턴 검사를
 * 수행한다. (+ 즉, 이름 그대로 고지식하지만 쉽게 구현 가능하다는 것이 장점이다.)
 * 
 * KMP (Knuth Morris Pratt) 란?
 * - 부르트 포스와 마찬가지로 문자를 왼쪽에서 오른쪽 순으로 비교하는 과정을 반복함으로서
 * 문자열 패턴을 탐색하는 알고리즘이다.
 * 
 * 단, 브루트 포스와 달리 문자열 패턴 탐색에 실패했을 경우 현재까지 탐색했던 문자들을
 * 재활용함으로서 탐색의 성능을 높이는 장점이 존재한다. (+ 즉, 탐색했던 문자들을 기반으로
 * 탐색 범위를 줄이는 것이 핵심이라는 것을 알 수 있다.)
 * 
 * KMP 는 탐색 범위를 줄이기 위해 문자열 패턴의 접두부와 접미부를 비교해 경계를 계산하는 개념이
 * 존재하며 해당 경계를 통해 탐색 범위를 줄이는 것이 가능하다.
 * 
 * 보이어 무어 (Boyre Moore) 란?
 * - 다른 알고리즘과 달리 문자를 오른쪽에서 왼쪽 순으로 비교하는 과정을 반복함으로서 
 * 문자열 패턴을 탐색하는 알고리즘이다.
 * 
 * 보이어 무한 또한 KMP 와 마찬가지로 문자열 패턴 탐색에 실패했을 경우 탐색했던 문자들을 기반으로
 * 탐색 범위를 줄이는 장점이 존재한다.
 * 
 * 보이어 무어는 탐색 범위를 줄이기 위해 나쁜 문자 이동과 착한 접미부 이동의 개념이 존재하며
 * 해당 이동을 기반으로 빠르게 문자열 패턴을 탐색하는 것이 가능하다.
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_05
{
	/**
	 * Example 5
	 */
	internal class CE01Example_05
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			Console.Write("문자열 입력 : ");
			string oStr = Console.ReadLine();

			Console.Write("패턴 입력 : ");
			string oPattern = Console.ReadLine();

			Console.WriteLine("\n결과 : {0}", E01FindStr_05(oStr, oPattern));
		}

#if A_E01_EXAMPLE_05_01
		/** 문자열을 탐색한다 */
		private static int E01FindStr_05(string a_oStr, string a_oPattern)
		{
			for(int i = 0; i <= a_oStr.Length - a_oPattern.Length; ++i)
			{
				int j = 0;

				for(j = 0; j < a_oPattern.Length; ++j)
				{
					// 탐색이 불가능 할 경우
					if(a_oStr[i + j] != a_oPattern[j])
					{
						break;
					}
				}

				// 문자열이 존재 할 경우
				if(j >= a_oPattern.Length)
				{
					return i;
				}
			}

			return -1;
		}
#elif A_E01_EXAMPLE_05_02
		/** 문자열을 탐색한다 */
		private static int E01FindStr_05(string a_oStr, string a_oPattern)
		{
			int i = 0;
			int j = 0;

			var oTable = E01MakeTable_05(a_oPattern);

			while(i < a_oStr.Length)
			{
				while(j >= 0 && a_oStr[i] != a_oPattern[j])
				{
					j = oTable[j];
				}

				i += 1;
				j += 1;

				// 문자열이 존재 할 경우
				if(j >= a_oPattern.Length)
				{
					return i - j;
				}
			}

			return -1;
		}

		/** 테이블을 생성한다 */
		private static int[] E01MakeTable_05(string a_oPattern)
		{
			int i = 0;
			int j = -1;

			var oTable = new int[a_oPattern.Length + 1];
			oTable[0] = -1;

			while(i < a_oPattern.Length)
			{
				while(j >= 0 && a_oPattern[i] != a_oPattern[j])
				{
					j = oTable[j];
				}

				i += 1;
				j += 1;

				oTable[i] = j;
			}

			return oTable;
		}
#elif A_E01_EXAMPLE_05_03
		/** 문자열을 탐색한다 */
		private static int E01FindStr_05(string a_oStr, string a_oPattern)
		{
			int i = 0;
			var oTable_BadCharacter = E01MakeTable_BadCharacter_05(a_oPattern);

			while(i <= a_oStr.Length - a_oPattern.Length)
			{
				int j = a_oPattern.Length - 1;

				while(j >= 0 && a_oStr[i + j] == a_oPattern[j])
				{
					j -= 1;
				}

				// 문자열이 존재 할 경우
				if(j < 0)
				{
					return i;
				}

				i += Math.Max(1, j - oTable_BadCharacter[a_oStr[i + j]]);
			}

			return -1;
		}

		/** 나쁜 문자 테이블을 생성한다 */
		private static int[] E01MakeTable_BadCharacter_05(string a_oPattern)
		{
			var oTable_BadCharacter = new int[sbyte.MaxValue + 1];

			for(int i = 0; i < oTable_BadCharacter.Length; ++i)
			{
				oTable_BadCharacter[i] = -1;
			}

			for(int i = 0; i < a_oPattern.Length; ++i)
			{
				oTable_BadCharacter[a_oPattern[i]] = i;
			}

			return oTable_BadCharacter;
		}
#endif // #if A_E01_EXAMPLE_05_01
	}
}
