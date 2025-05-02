#define S_E01_EXAMPLE_06_01
#define S_E01_EXAMPLE_06_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 해시 테이블 (Hash Table) 이란?
 * - 탐색에 특화 된 자료구조를 의미한다. (+ 즉, 해시 테이블은 이진 탐색 트리와 더불어 특정 데이터를 
 * 빠르게 탐색하기 위한 목적으로 주로 활용된다는 것을 알 수 있다.)
 * 
 * 해시 테이블은 데이터 탐색을 위해 특정 규칙에 맞춰서 데이터를 추가하거나 제거하는 특징이 존재한다. 
 * (+ 즉, 이진 탐색 트리와 같이 특정 규칙을 기반으로 데이터를 제어함으로서 빠르게 데이터를 
 * 탐색하는 것이 가능하다.)
 * 
 * 해시 테이블은 내부적으로 데이터를 제어하기 위한 기반 데이터를 필요로 하며 
 * 이를 해시 값이라고 한다. (+ 즉, 해시 값을 기반으로 데이터의 위치가 결정된다는 것을 알 수 있다.)
 * 
 * 해시 값은 해시 함수에 의해 생성되기 때문에 해시 함수의 성능이 따라 해시 테이블의 탐색 성능이 
 * 결정된다. (+ 즉, 해시 함수의 성능이 떨어진다면 해시 테이블의 성능도 떨어진다는 것을 알 수 있다.)
 * 
 * 해시 테이블은 내부적인 구현 방법에 따라 체인법 기반 해시 테이블과 
 * 개방 주소법 기반 해시 테이블로 구분된다.
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * Example 7
	 */
	internal class CE01Example_07
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if S_E01_EXAMPLE_06_01
			var oRandom = new Random();
			var oHashValues = new CE01HashTable_Chaining_07_01<int>();

			for(int i = 0; i < 10; ++i)
			{
				oHashValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 해시 <=====");

			oHashValues.Enumerate((a_nIdx, a_nVal) =>
			{
				Console.Write("{0}:{1}, ", a_nIdx, a_nVal);
			});

			Console.WriteLine();
#elif S_E01_EXAMPLE_06_02
			var oRandom = new Random();
			var oHashValues = new CE01Hash_OpenAddress_06<int>();

			for(int i = 0; i < 20; ++i)
			{
				oHashValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 해시 <=====");

			oHashValues.Enumerate((a_nIdx, a_nVal) =>
			{
				Console.Write("{0}:{1}, ", a_nIdx, a_nVal);
			});

			Console.WriteLine();
#endif // #if S_E01_EXAMPLE_06_01
		}
	}
}
