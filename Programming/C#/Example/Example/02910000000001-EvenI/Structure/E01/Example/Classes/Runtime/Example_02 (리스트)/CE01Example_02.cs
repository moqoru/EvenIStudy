//#define S_E01_EXAMPLE_02_01
#define S_E01_EXAMPLE_02_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 리스트 (List) 란?
 * - 관리되는 데이터에 순서가 존재하는 자료구조를 의미한다. (+ 즉, 리스트 자료구조에 추가 된 순서에
 * 따라 각 데이터를 식별하기 위한 번호가 부여된다는 것을 알 수 있다.)
 * 
 * 리스트 자료구조는 내부적인 구현 방식에 따라 배열 리스트와 연결 리스트로 구분된다.
 * 
 * 배열 리스트 (Array List) 란?
 * - 배열 기반으로 구현 된 리스트를 의미한다. (+ 즉, 배열은 메모리의 물리적인 순서를 기반으로 
 * 동작하기 때문에 배열 리스트 또한 메모리의 물리적인 순서에 의해 각 데이터에 번호가 부여된다는 것을 
 * 알 수 있다.)
 * 
 * 연결 리스트 (Linked List) 란?
 * - 참조 기반으로 구현 된 리스트를 의미한다. (+ 즉, 참조에 의해 데이터의 순서를 만들어내기 때문에
 * 메모리의 물리적인 순서와 데이터의 순서가 동일하지 않을 수 있다는 것을 의미한다.)
 * 
 * 연결 리스트는 데이터를 저장하는 공간 이외에도 참조를 저장하기 위한 공간이 추가적으로 필요하기
 * 때문에 배열 리스트에 비해 좀 더 많은 메모리 공간을 사용한다는 특징이 존재한다.
 * 
 * 배열 리스트 vs 연결 리스트
 * - 배열 리스트는 배열을 기반으로 구현되기 때문에 데이터의 순서를 알고 있다면 상수 시간에 접근
 * 가능한 장점이 존재한다. (+ 즉, 배열은 임의 접근을 지원하기 때문에 원하는 데이터에 
 * 한번에 접근 할 수 있다는 것을 의미한다.)
 * 
 * 단, 배열 리스트는 배열을 기반으로 구현되기 때문에 특정 위치에 데이터를 추가하거나 제거 할 경우
 * 데이터의 이동이 발생하는 단점이 존재한다. (+ 즉, 데이터의 추가 or 제거가 빈번 할 경우 성능 저하가
 * 발생 할 수 있다는 것을 의미한다.)
 * 
 * 반면 연결 리스트는 참조에 의해 데이터의 순서를 만들어내기 때문에 특정 데이터의 위치를 알고 있다
 * 하더라도 항상 첫 데이터부터 순차적으로 접근해야되는 단점이 존재한다. (+ 즉, 임의 접근이 불가능하기
 * 때문에 데이터의 접근 속도가 떨어진다는 것을 알 수 있다.)
 * 
 * 단, 연결 리스트는 참조에 의해 데이터의 순서를 만들어내기 때문에 특정 위치에 데이터가 추가되거나
 * 제거 된다 하더라도 불필요한 데이터 이동이 발생하지 않는 장점이 존재한다. (+ 즉, 데이터의
 * 추가 or 제거 과정이 배열 리스트에 비해 용이하다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * Example 2
	 */
	internal class CE01Example_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if S_E01_EXAMPLE_02_01
			var oRandom = new Random();
			var oListValues = new CE01List_Array_02_01<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");
			E01PrintValues_02(oListValues);

			oListValues.InsertVal(0, 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			E01PrintValues_02(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			E01PrintValues_02(oListValues);
#elif S_E01_EXAMPLE_02_02
			var oRandom = new Random();
			var oListValues = new CE01List_DLinked_02_02<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");
			E01PrintValues_02(oListValues);

			oListValues.InsertVal(0, 100);

			Console.WriteLine("\n=====> 리스트 - 추가 후 <=====");
			E01PrintValues_02(oListValues);

			oListValues.RemoveVal(100);

			Console.WriteLine("\n=====> 리스트 - 제거 후 <=====");
			E01PrintValues_02(oListValues);
#endif // #if S_E01_EXAMPLE_02_01
		}

#if S_E01_EXAMPLE_02_01
		/** 값을 출력한다 */
		private static void E01PrintValues_02<T>(CE01List_Array_02_01<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.NumValues; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}
#elif S_E01_EXAMPLE_02_02
		/** 값을 출력한다 */
		private static void E01PrintValues_02<T>(CE01List_DLinked_02_02<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.NumValues; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}
#endif // #if S_E01_EXAMPLE_02_01
	}
}
