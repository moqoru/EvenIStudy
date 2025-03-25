//#define P_E01_EXAMPLE_07_01
#define P_E01_EXAMPLE_07_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * C# 주요 비선형 컬렉션 종류
 * - 셋 (Set)
 * - 딕셔너리 (Dictionary)
 * 
 * 셋 (Set) 이란?
 * - 데이터의 중복을 허용하지 않는 컬렉션을 의미한다. (+ 즉, 해당 컬렉션은 수학의 집합과 같은 특징을 
 * 지니고 있다는 것을 알 수 있다.)
 * 
 * 딕셔너리 (Dictionary) 란?
 * - 데이터를 키와 벨류의 쌍으로 관리하는 컬렉션을 의미한다. (+ 즉, 딕셔너리는 탐색에 
 * 특화 된 컬렉션이라는 것을 알 수 있다.)
 * 
 * 키 (Key) vs 벨류 (Value)
 * - 키는 데이터를 탐색하기 위한 식별자의 역할을 하기 때문에 중복을 허용하지 않는 특징이 존재한다. 
 * (+ 즉, 딕셔너리에 동일한 키를 사용 할 경우 내부적으로 문제가 될 수 있다는 것을 알 수 있다.)
 * 
 * 반면 벨류는 실제 관리되는 데이터를 의미하기 때문에 중복이 가능하다는 차이점이 존재한다. (+ 즉, 
 * 딕셔너리는 키를 통해서 사용자가 원하는 벨류를 탐색하는 컬렉션이라는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * Example 7
	 */
	internal class CE01Example_07
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_07_01
			Random oRandom = new Random();
			HashSet<int> oSetValues = new HashSet<int>();

			Console.WriteLine("=====> 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				int nVal = oRandom.Next(0, 10);
				oSetValues.Add(nVal);

				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine("\n\n=====> 셋 <=====");

			/*
			 * foreach 반복문은 열거 가능한 데이터를 대상으로 동작하는 반복문을 의미한다. (+ 즉, 
			 * 해당 반복문을 활용하면 컬렉션과 같이 여러 데이터를 포함하고 있는 대상에게 사용하는 
			 * 것이 가능하다.)
			 * 
			 * 따라서 foreach 반복문은 순회문이라고도 불린다. (+ 즉, 일반적인 반복문과 달리
			 * 반복이 끝나는 조건을 따로 명시 할 필요가 없다.)
			 */
			foreach(int nVal in oSetValues)
			{
				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine("\n\n개수 : {0}", oSetValues.Count);
#elif P_E01_EXAMPLE_07_02
			Dictionary<string, int> oDictValuesA = new Dictionary<string, int>();
			Dictionary<string, float> oDictValuesB = new Dictionary<string, float>();

			for(int i = 0; i < 10; ++i)
			{
				string oKey = $"Key_{i + 1:00}";

				oDictValuesA.Add(oKey, i + 1);
				oDictValuesB.Add(oKey, i + 1.0f);
			}

			Console.WriteLine("=====> 딕셔너리 - A <=====");

			foreach(KeyValuePair<string, int> stKeyVal in oDictValuesA)
			{
				Console.Write("{0}:{1}, ",
					stKeyVal.Key, stKeyVal.Value);
			}

			Console.WriteLine("\n\n=====> 딕셔너리 - B <=====");

			foreach(KeyValuePair<string, float> stKeyVal in oDictValuesB)
			{
				Console.Write("{0}:{1}, ",
					stKeyVal.Key, stKeyVal.Value);
			}

			Console.WriteLine();
#endif // #if P_E01_EXAMPLE_07_01
		}
	}
}
