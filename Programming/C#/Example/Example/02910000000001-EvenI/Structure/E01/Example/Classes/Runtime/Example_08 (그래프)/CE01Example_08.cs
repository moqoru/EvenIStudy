//#define S_E01_EXAMPLE_07_01
#define S_E01_EXAMPLE_07_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 그래프 (Graph) 란?
 * - 정점과 정점을 연결하는 간선을 통해 데이터 간에 관계를 표현 할 수 있는 자료구조를 의미한다. 
 * (+ 즉, 그래프를 활용하면 데이터 간에 복잡한 관계도 표현하는 것이 가능하다.)
 * 
 * 그래프는 간선의 표현 방식에 따라 방향성 그래프와 무방향성 그래프로 구분된다. (+ 즉, 
 * 방향성 그래프는 간선에 방향이 존재하기 때문에 정점이 연결되어있더라도 방향에 따라 
 * 이동이 불가능 할 수 있다는 것을 알 수 있다.)
 * 
 * 그래프는 정점의 관계를 나타내는 간선을 표현하는 방법에 따라 행렬 기반 그래프와 리스트 기반 
 * 그래프로 나뉜다. (+ 즉, 행렬 기반을 간선을 2 차원 배열을 통해 표현하고 리스트 기반 그래프는
 * 리스트로 간선을 표현한다는 것을 알 수 잇다.)
 * 
 * 행렬 기반 그래프 vs 리스트 기반 그래프
 * - 행렬 기반 그래프는 정점 개수가 늘어나는만큼 2 차원 배열의 크기도 같이 커지기 때문에 간선이
 * 경우 불필요한 메모리가 낭비되는 단점이 존재한다. (+ 즉, 간선이 개수가 많아질수록 
 * 행렬 기반 그래프가 효율적이라는 것을 알 수 있다.)
 * 
 * 반면 리스트 기반 그래프는 정점 개수가 늘어난다고 하더라도 간선을 표현하는 리스트는 늘어나지 않기
 * 때문에 정점이 많고 간선의 개수가 작을 경우 메모리를 효율적으로 사용하는 장점이 존재한다. (+ 단,
 * 간선의 개수가 많아질수록 효율성이 떨어지는 단점이 존재한다.)
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_08
{
	/**
	 * Example 7
	 */
	internal class CE01Example_08
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if S_E01_EXAMPLE_07_01
			var oRandom = new Random();
			var oGraph_List = new CE01Graph_AdjacencyList_08_01<char, int>();

			oGraph_List.AddVertex('A', oRandom.Next(1, 100));
			oGraph_List.AddVertex('B', oRandom.Next(1, 100));
			oGraph_List.AddVertex('C', oRandom.Next(1, 100));
			oGraph_List.AddVertex('D', oRandom.Next(1, 100));
			oGraph_List.AddVertex('E', oRandom.Next(1, 100));
			oGraph_List.AddVertex('F', oRandom.Next(1, 100));
			oGraph_List.AddVertex('G', oRandom.Next(1, 100));

			oGraph_List.AddEdge('A', 'B', 1);
			oGraph_List.AddEdge('A', 'C', 1);
			oGraph_List.AddEdge('A', 'E', 1);

			oGraph_List.AddEdge('B', 'C', 1);
			oGraph_List.AddEdge('B', 'G', 1);

			oGraph_List.AddEdge('C', 'D', 1);

			oGraph_List.AddEdge('D', 'A', 1);
			oGraph_List.AddEdge('D', 'E', 1);

			oGraph_List.AddEdge('E', 'F', 1);
			oGraph_List.AddEdge('F', 'G', 1);
			oGraph_List.AddEdge('G', 'D', 1);

			Console.WriteLine("=====> 그래프 <=====");

			oGraph_List.Enumerate(CE01Graph_AdjacencyList_08_01<char, int>.EOrder.DEPTH_FIRST, 
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			oGraph_List.RemoveEdge('A', 'B');
			Console.WriteLine("\n\n=====> 그래프 - 간선 제거 후 <=====");

			oGraph_List.Enumerate(CE01Graph_AdjacencyList_08_01<char, int>.EOrder.DEPTH_FIRST, 
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			oGraph_List.RemoveVertex('C');
			Console.WriteLine("\n\n=====> 그래프 - 정점 제거 후 <=====");

			oGraph_List.Enumerate(CE01Graph_AdjacencyList_08_01<char, int>.EOrder.DEPTH_FIRST, 
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			Console.WriteLine();
#elif S_E01_EXAMPLE_07_02
			var oRandom = new Random();
			var oGraph_Matrix = new CE01Graph_AdjacencyMatrix_08_02<char, int>();

			oGraph_Matrix.AddVertex('A', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('B', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('C', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('D', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('E', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('F', oRandom.Next(1, 100));
			oGraph_Matrix.AddVertex('G', oRandom.Next(1, 100));

			oGraph_Matrix.AddEdge('A', 'B', 1);
			oGraph_Matrix.AddEdge('A', 'C', 1);
			oGraph_Matrix.AddEdge('A', 'E', 1);

			oGraph_Matrix.AddEdge('B', 'C', 1);
			oGraph_Matrix.AddEdge('B', 'G', 1);

			oGraph_Matrix.AddEdge('C', 'D', 1);

			oGraph_Matrix.AddEdge('D', 'A', 1);
			oGraph_Matrix.AddEdge('D', 'E', 1);

			oGraph_Matrix.AddEdge('E', 'F', 1);
			oGraph_Matrix.AddEdge('F', 'G', 1);
			oGraph_Matrix.AddEdge('G', 'D', 1);

			Console.WriteLine("=====> 그래프 <=====");

			oGraph_Matrix.Enumerate(CE01Graph_AdjacencyMatrix_08_02<char, int>.EOrder.BREADTH_FIRST,
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			oGraph_Matrix.RemoveEdge('A', 'B');
			Console.WriteLine("\n\n=====> 그래프 - 간선 제거 후 <=====");

			oGraph_Matrix.Enumerate(CE01Graph_AdjacencyMatrix_08_02<char, int>.EOrder.BREADTH_FIRST,
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			oGraph_Matrix.RemoveVertex('C');
			Console.WriteLine("\n\n=====> 그래프 - 정점 제거 후 <=====");

			oGraph_Matrix.Enumerate(CE01Graph_AdjacencyMatrix_08_02<char, int>.EOrder.BREADTH_FIRST,
				'A', (a_chKey, a_nVal) =>
			{
				Console.Write("{0}, ", a_chKey);
			});

			Console.WriteLine();
#endif // #if S_E01_EXAMPLE_07_01
		}
	}
}
