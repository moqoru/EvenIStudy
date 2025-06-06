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
namespace Example._02910000000001_EvenI.Practice.E01.Example.Classes.Runtime.Example_05
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
			var oTable_GoodSuffix = E01MakeTable_GoodSuffix_05(a_oPattern);

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

				// 불일치 했을 경우 나쁜 문자와 좋은 접미사가 알려주는 값 중 더 큰 값으로 이동한다.
				// 나쁜 문자 : 원본 문자열에서 i+j 위치, 즉 원본 문자열에서 처음으로 불일치가 뜬 문자열을 보고, 그 문자열의 위치만큼 뒤로 민다.
				// 좋은 접미사 : 패턴의 j번째 칸에서 불일치했다면, j+1의 값을 보고 그 값만큼 뒤로 밀어준다.
				// 나쁜 문자는 글자의 종류만큼 배열을 만든다면, 좋은 접미사는 패턴의 길이만큼 배열을 만든다.
				// 나쁜 문자만 사용하면 1칸만 뒤로 미는 경우가 생기지만, 그 상황에서 좋은 접미사를 이용하면 최대 이동 거리를 알 수 있다.

				//i += Math.Max(1, j - oTable_BadCharacter[a_oStr[i + j]]);
				i += Math.Max(j - oTable_BadCharacter[a_oStr[i + j]], oTable_GoodSuffix[j + 1]);

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

			// 패턴 : 찾으려 하는 거, 중복되는 문자들에 대해 가장 오른쪽에 있는 문자 저장
			for(int i = 0; i < a_oPattern.Length; ++i)
			{
				oTable_BadCharacter[a_oPattern[i]] = i;
			}

			return oTable_BadCharacter;
		}

		// 참조 블로그 : https://yoongrammer.tistory.com/95
		private static int[] E01MakeTable_GoodSuffix_05(string a_oPattern)
		{

			// Case #1 : Good Suffix가 패턴의 다른 곳에도 있는 경우
			var oTable_GoodSuffix_BorderIndex = new int[a_oPattern.Length + 1];
			var oTable_GoodSuffix_Shift = new int[a_oPattern.Length + 1];
			int i = a_oPattern.Length, j = i + 1;

			oTable_GoodSuffix_BorderIndex[i] = j;
			//Console.WriteLine("i={0}, j={1}, B_Idx[{0}]={1}", i, j);
			while(i > 0)
			{
				// j가 탐색 문자열 밖에 있는 것을 방지, 반복문이 끝나면 패턴이 일치 하는 곳으로 가게 됨
				while(j <= a_oPattern.Length && a_oPattern[i - 1] != a_oPattern[j - 1])
				{
					if(oTable_GoodSuffix_Shift[j] == 0)
					{
						oTable_GoodSuffix_Shift[j] = j - i;
						//Console.WriteLine("i={0}, j={1}, Shift[{1}]={2}", i, j, j - i);
					}
					//Console.WriteLine("j={0}, j는 B_Idx[j] 값으로 변함={1}", j, oTable_GoodSuffixCase01_BorderIndex[j]);
					j = oTable_GoodSuffix_BorderIndex[j];
				}
				i--;
				j--;
				oTable_GoodSuffix_BorderIndex[i] = j;
				//Console.WriteLine("i={0}, j={1}, B_Idx[{0}]={1}", i, j);
			}

			// Case #2 : Good Suffix의 일부만 패턴의 시작 지점에 있는 경우 (아예 패턴이 없는 경우는 Good Suffix 이후로 이동시킨다)
			j = oTable_GoodSuffix_BorderIndex[0];
			for(i = 0; i <= a_oPattern.Length; i++)
			{
				// Case #1에서 미처 처리하지 못한 구간도 채워 준다.
				if(oTable_GoodSuffix_Shift[i] == 0)
				{
					oTable_GoodSuffix_Shift[i] = j;
				}
				if(i == j)
				{
					j = oTable_GoodSuffix_BorderIndex[j];
				}
			}

			return oTable_GoodSuffix_Shift;
		}
#endif // #if A_E01_EXAMPLE_05_01
	}
}
