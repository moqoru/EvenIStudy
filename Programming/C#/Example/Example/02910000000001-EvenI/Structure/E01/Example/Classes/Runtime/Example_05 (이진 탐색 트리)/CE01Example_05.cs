using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 트리 (Tree) 란?
 * - 데이터 간에 상/하 관계를 형성 할 수 있는 자료구조를 의미한다. (+ 즉, 데이터 간에 
 * 부모/자식 관계를 형성 할 수 있다는 것을 의미한다.)
 * 
 * 트리는 내부적인 구현 방식에 따라 배열 or 참조를 통해 구현하는 것이 가능하며 참조를 통해 구현되는
 * 방식에는 N 링크 방식과 왼쪽 자식 - 오른쪽 형제 방식이 존재한다. (+ 즉, 배열 or N 링크 방식은 
 * 자식 데이터의 최대 개수가 정해져있는 방식이라는 것을 의미한다.)
 * 
 * 이진 탐색 트리 (Binary Search Tree) 란?
 * - 이진 탐색을 트리를 통해 표현한 자료구조로서 탐색에 특화 된 자료구조를 의미한다. (+ 즉,
 * 이진 탐색 트리는 내부적으로 트리 구조로 데이터를 관리한다는 것을 알 수 있다.)
 * 
 * 이진 탐색 트리는 특정 규칙을 기반으로 데이터를 추가 or 제거함으로서 빠르게 특정 데이터를 탐색하는
 * 것이 가능하다. (+ 즉, 트리의 균형이 잘 유지 될 경우 O(log N) 의 성능이 지니고 있다.)
 * 
 * 단, 이진 탐색 트리의 탐색 성능은 트리의 균형에 의해 결정되기 때문에 트리의 균형이 무너 질 경우
 * 탐색 성능이 O(N) 으로 떨어지는 단점이 존재한다.
 * 
 * 따라서 이진 탐색 트리는 데이터가 추가되거나 제거 될 때 트리의 균형을 유지하기 위한 추가적인
 * 연산이 필요하다. (+ 즉, 데이터가 빈번하게 추가되거나 제거 될 경우 프로그램 성능이 저하된다는 것을
 * 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_05
{
	/**
	 * Example 5
	 */
	internal class CE01Example_05
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var oTreeValues = new CE01Tree_BinarySearch_05<int>();

			for(int i = 0; i < 10; ++i)
			{
				oTreeValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 이진 탐색 트리 <=====");

			oTreeValues.Enumerate(CE01Tree_BinarySearch_05<int>.EOrder.IN, (a_nVal) =>
			{
				Console.Write("{0}, ", a_nVal);
			});

			oTreeValues.AddVal(100);
			Console.WriteLine("\n\n=====> 이진 탐색 트리 - 추가 후 <=====");

			oTreeValues.Enumerate(CE01Tree_BinarySearch_05<int>.EOrder.IN, (a_nVal) =>
			{
				Console.Write("{0}, ", a_nVal);
			});

			oTreeValues.RemoveVal(100);
			Console.WriteLine("\n\n=====> 이진 탐색 트리 - 제거 후 <=====");

			oTreeValues.Enumerate(CE01Tree_BinarySearch_05<int>.EOrder.IN, (a_nVal) =>
			{
				Console.Write("{0}, ", a_nVal);
			});

			Console.WriteLine();
		}
	}
}
