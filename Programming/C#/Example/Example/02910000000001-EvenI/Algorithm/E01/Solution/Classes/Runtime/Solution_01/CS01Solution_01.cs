using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Algorithm.E01.Solution.Classes.Runtime.Solution_01
{
	/**
	 * Solution 1
	 */
	internal class CS01Solution_01
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			Console.Write("문자열 입력 : ");
			string oStr = Console.ReadLine();

			Console.Write("패턴 입력 : ");
			string oPattern = Console.ReadLine();

			Console.WriteLine("\n결과 : {0}", S01FindStr_01(oStr, oPattern));
		}

		/** 문자열을 탐색한다 */
		private static int S01FindStr_01(string a_oStr, string a_oPattern)
		{
			int i = 0;

			var oTable_GoodSuffix = S01MakeTable_GoodSuffix_01(a_oPattern);
			var oTable_BadCharacter = S01MakeTable_BadCharacter_01(a_oPattern);

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

				i += Math.Max(oTable_GoodSuffix[j], j - oTable_BadCharacter[a_oStr[i + j]]);
			}

			return -1;
		}

		/** 착한 접미부 테이블을 생성한다 */
		private static int[] S01MakeTable_GoodSuffix_01(string a_oPattern)
		{
			int i = a_oPattern.Length;
			int j = a_oPattern.Length + 1;

			var oTable_Border = new int[a_oPattern.Length + 1];
			var oTable_GoodSuffix = new int[a_oPattern.Length + 1];

			oTable_Border[i] = j;

			while(i > 0)
			{
				while(j <= a_oPattern.Length && a_oPattern[i - 1] != a_oPattern[j - 1])
				{
					// 거리 설정이 가능 할 경우
					if(oTable_GoodSuffix[j] == 0)
					{
						oTable_GoodSuffix[j] = j - i;
					}

					j = oTable_Border[j];
				}

				i -= 1;
				j -= 1;

				oTable_Border[i] = j;
			}

			j = oTable_Border[0];

			for(i = 0; i < a_oPattern.Length; ++i)
			{
				// 거리 설정이 가능 할 경우
				if(oTable_GoodSuffix[i] == 0)
				{
					oTable_GoodSuffix[i] = j;
				}

				j = (j == i) ? oTable_Border[i] : j;
			}

			return oTable_GoodSuffix;
		}

		/** 나쁜 문자 테이블을 생성한다 */
		private static int[] S01MakeTable_BadCharacter_01(string a_oPattern)
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
	}
}
