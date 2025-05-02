//#define A_E01_EXAMPLE_08_01
#define A_E01_EXAMPLE_08_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_08;

/*
 * 최소 비용 신장 트리 (Minimum Cost Spanning Tree) 란?
 * - 가중치 그래프에 존재하는 간선을 최소화시켜서 모든 정점을 연결하는 그래프를 의미한다. (+ 즉,
 * 가중치 그래프를 최소 비용 신장 트리 구조로 변경하고 나면 가장 최소한의 비용으로 모든 정점을
 * 연결하는 것이 가능하다.)
 * 
 * 최소 비용 신장 트리는 최소한의 간선으로 모든 정점을 연결하기 때문에 사이클이 발생하지 않는 것이
 * 특징이다. (+ 즉, 간선을 따라 이동하면 특정 정점을 다시 방문하지 않는다는 것을 알 수 있다.)
 * 
 * 따라서 특정 가중치 그래프를 최소 비용 신장 트리로 변경하고 나면 간선의 개수는
 * 정점 개수 - 1 이라는 것을 알 수 있다.
 * 
 * 최소 비용 신장 트리 알고리즘 종류
 * - 프림 (Prim) 알고리즘
 * - 크루스칼 (Kruskal) 알고리즘
 * 
 * 위와 같이 무방향 가중치 그래프를 최소 비용 신장 트리로 변경하는 알고리즘에는 
 * 크게 2 가지가 존재하며 어떤 알고리즘을 사용하느냐에 따라 최종적으로 만들어지는 트리의 모양은 
 * 달라질 수 있다. (+ 즉, 경우에 따라 서로 다른 결과물이 만들어진다는 것을 알 수 있다.)
 * 
 * 프림 (Prim) 알고리즘이란?
 * - 탐욕 (Greedy) 알고리즘 중 하나로서 특정 정점에서 시작해 가장 작은 간선을 선택하는 과정을
 * 반복함으로서 최소 비용 신장 트리를 완성하는 알고리즘을 의미한다. (+ 즉, 최초 시작하는 정점에
 * 따라 완성되는 최소 비용 신장 트리 모양이 달라질 수 있다는 것을 의미한다.)
 * 
 * 크루스칼 (Kruskal) 알고리즘이란?
 * - 가장 가중치가 낮은 간선을 추가하거나 가장 가중치가 높은 간선을 제거하는 과정을 반복함으로서
 * 최소 비용 신장 트리를 완성하는 알고리즘을 의미한다. (+ 즉, 프림 알고리즘과 달리 시작 정점이
 * 필요하지 않기 때문에 만들어지는 최소 비용 신장 트리의 모양이 항상 동일하다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_08
{
	/**
	 * Example 8
	 */
	internal class CE01Example_08
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if A_E01_EXAMPLE_08_01
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
			oGraph_List.AddEdge('A', 'D', 1);
			oGraph_List.AddEdge('A', 'C', 2);
			oGraph_List.AddEdge('A', 'E', 3);

			oGraph_List.AddEdge('B', 'A', 1);
			oGraph_List.AddEdge('B', 'C', 1);
			oGraph_List.AddEdge('B', 'G', 2);

			oGraph_List.AddEdge('C', 'B', 1);
			oGraph_List.AddEdge('C', 'D', 1);
			oGraph_List.AddEdge('C', 'A', 2);

			oGraph_List.AddEdge('D', 'A', 1);
			oGraph_List.AddEdge('D', 'C', 1);
			oGraph_List.AddEdge('D', 'E', 2);
			oGraph_List.AddEdge('D', 'G', 3);

			oGraph_List.AddEdge('E', 'F', 1);
			oGraph_List.AddEdge('E', 'D', 2);
			oGraph_List.AddEdge('E', 'A', 3);

			oGraph_List.AddEdge('F', 'E', 1);
			oGraph_List.AddEdge('F', 'G', 2);

			oGraph_List.AddEdge('G', 'B', 2);
			oGraph_List.AddEdge('G', 'F', 2);
			oGraph_List.AddEdge('G', 'D', 3);

			var oTree_MinCostSpanning = E01CreateTree_MinCostSpanning_08(oGraph_List, 'A');

			Console.WriteLine("=====> 최소 비용 신장 트리 - 프림 <=====");
			E01PrintTree_MinCostSpanning_08(oTree_MinCostSpanning, 'A');
#elif A_E01_EXAMPLE_08_02
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
			oGraph_Matrix.AddEdge('A', 'D', 1);
			oGraph_Matrix.AddEdge('A', 'C', 2);
			oGraph_Matrix.AddEdge('A', 'E', 3);

			oGraph_Matrix.AddEdge('B', 'A', 1);
			oGraph_Matrix.AddEdge('B', 'C', 1);
			oGraph_Matrix.AddEdge('B', 'G', 2);

			oGraph_Matrix.AddEdge('C', 'B', 1);
			oGraph_Matrix.AddEdge('C', 'D', 1);
			oGraph_Matrix.AddEdge('C', 'A', 2);

			oGraph_Matrix.AddEdge('D', 'A', 1);
			oGraph_Matrix.AddEdge('D', 'C', 1);
			oGraph_Matrix.AddEdge('D', 'E', 2);
			oGraph_Matrix.AddEdge('D', 'G', 3);

			oGraph_Matrix.AddEdge('E', 'F', 1);
			oGraph_Matrix.AddEdge('E', 'D', 2);
			oGraph_Matrix.AddEdge('E', 'A', 3);

			oGraph_Matrix.AddEdge('F', 'E', 1);
			oGraph_Matrix.AddEdge('F', 'G', 2);

			oGraph_Matrix.AddEdge('G', 'B', 2);
			oGraph_Matrix.AddEdge('G', 'F', 2);
			oGraph_Matrix.AddEdge('G', 'D', 3);

			var oTree_MinCostSpanning = E01CreateTree_MinCostSpanning_08(oGraph_Matrix);

			Console.WriteLine("=====> 최소 비용 신장 트리 - 크루스칼 <=====");
			E01PrintTree_MinCostSpanning_08(oTree_MinCostSpanning, 'A');
#endif // #if A_E01_EXAMPLE_08_01
		}

		/**
		 * 간선 정보
		 */
		private struct STE01Info_Edge_08
		{
			public char m_chFrom;
			public char m_chTo;

			public int m_nCost;
		}

		/** 간선 정보를 생성한다 */
		private static STE01Info_Edge_08 E01MakeInfo_Edge_08(char a_chFrom,
			char a_chTo, int a_nCost)
		{
			return new STE01Info_Edge_08()
			{
				m_chFrom = a_chFrom,
				m_chTo = a_chTo,

				m_nCost = a_nCost
			};
		}

#if A_E01_EXAMPLE_08_01
		/** 정점 포함 여부를 검사한다 */
		private static bool E01IsContains_Vertex_08(CE01Graph_AdjacencyList_08_01<char, int> a_oTree_MinCostSpanning,
			char a_chKey_Vertex)
		{
			for(int i = 0; i < a_oTree_MinCostSpanning.NumVertices; ++i)
			{
				// 정점이 존재 할 경우
				if(a_chKey_Vertex == a_oTree_MinCostSpanning.ListVertices[i].m_tKey)
				{
					return true;
				}
			}

			return false;
		}

		/** 최소 비용 신장 트리를 출력한다 */
		private static void E01PrintTree_MinCostSpanning_08(CE01Graph_AdjacencyList_08_01<char, int> a_oTree_MinCostSpanning,
			char a_chStart)
		{
			a_oTree_MinCostSpanning.Enumerate(CE01Graph_AdjacencyList_08_01<char, int>.EOrder.BREADTH_FIRST,
				a_chStart, (a_chKey, a_nVal) =>
			{
				var oListEdges = a_oTree_MinCostSpanning.GetEdges(a_chKey);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					Console.WriteLine("{0} -> {1} : {2}",
						a_chKey, oListEdges[i].m_tTo, oListEdges[i].m_nCost);
				}
			});
		}

		/** 최소 비용 신장 트리를 생성한다 */
		private static CE01Graph_AdjacencyList_08_01<char, int> E01CreateTree_MinCostSpanning_08(CE01Graph_AdjacencyList_08_01<char, int> a_oGraph_List,
			char a_chStart)
		{
			var oPQueueInfos_Edge = new PriorityQueue<STE01Info_Edge_08, int>();
			oPQueueInfos_Edge.Enqueue(E01MakeInfo_Edge_08(a_chStart, a_chStart, 0), 0);

			var oTree_MinCostSpanning = new CE01Graph_AdjacencyList_08_01<char, int>();

			while(oPQueueInfos_Edge.Count > 0)
			{
				var stInfo_Edge = oPQueueInfos_Edge.Dequeue();

				// 정점이 존재 할 경우
				if(E01IsContains_Vertex_08(oTree_MinCostSpanning, stInfo_Edge.m_chTo))
				{
					continue;
				}

				oTree_MinCostSpanning.AddVertex(stInfo_Edge.m_chTo, 0);

				oTree_MinCostSpanning.AddEdge(stInfo_Edge.m_chFrom,
					stInfo_Edge.m_chTo, stInfo_Edge.m_nCost);

				oTree_MinCostSpanning.AddEdge(stInfo_Edge.m_chTo,
					stInfo_Edge.m_chFrom, stInfo_Edge.m_nCost);

				var oListEdges = a_oGraph_List.GetEdges(stInfo_Edge.m_chTo);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					stInfo_Edge = E01MakeInfo_Edge_08(oListEdges[i].m_tFrom,
						oListEdges[i].m_tTo, oListEdges[i].m_nCost);

					oPQueueInfos_Edge.Enqueue(stInfo_Edge, stInfo_Edge.m_nCost);
				}
			}

			return oTree_MinCostSpanning;
		}
#elif A_E01_EXAMPLE_08_02
		/** 정점 연결 여부를 검사한다 */
		private static bool E01IsConnect_Vertex_08(CE01Graph_AdjacencyMatrix_08_02<char, int> a_oTree_MinCostSpanning,
			char a_chFrom, char a_chTo)
		{
			bool bIsConnect = false;

			a_oTree_MinCostSpanning.Enumerate(CE01Graph_AdjacencyMatrix_08_02<char, int>.EOrder.BREADTH_FIRST,
				a_chFrom, (a_chKey, a_nVal) =>
			{
				bIsConnect = bIsConnect || a_chTo == a_chKey;
			});

			return bIsConnect;
		}

		/** 최소 비용 신장 트리를 출력한다 */
		private static void E01PrintTree_MinCostSpanning_08(CE01Graph_AdjacencyMatrix_08_02<char, int> a_oTree_MinCostSpanning,
			char a_chStart)
		{
			a_oTree_MinCostSpanning.Enumerate(CE01Graph_AdjacencyMatrix_08_02<char, int>.EOrder.BREADTH_FIRST,
				a_chStart, (a_chKey, a_nVal) =>
			{
				var oListEdges = a_oTree_MinCostSpanning.GetEdges(a_chKey);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					Console.WriteLine("{0} -> {1} : {2}",
						a_chKey, oListEdges[i], a_oTree_MinCostSpanning.GetCost(a_chKey, oListEdges[i]));
				}
			});
		}

		/** 최소 비용 신장 트리를 생성한다 */
		private static CE01Graph_AdjacencyMatrix_08_02<char, int> E01CreateTree_MinCostSpanning_08(CE01Graph_AdjacencyMatrix_08_02<char, int> a_oGraph_Matrix)
		{
			var oTree_MinCostSpanning = new CE01Graph_AdjacencyMatrix_08_02<char, int>();

			for(int i = 0; i < a_oGraph_Matrix.NumVertices; ++i)
			{
				oTree_MinCostSpanning.AddVertex(a_oGraph_Matrix.ListVertices[i].m_tKey, 0);
			}

			var oPQueueInfos_Edge = new PriorityQueue<STE01Info_Edge_08, int>();

			for(int i = 0; i < a_oGraph_Matrix.NumVertices; ++i)
			{
				var oListEdges = a_oGraph_Matrix.GetEdges(a_oGraph_Matrix.ListVertices[i].m_tKey);

				for(int j = 0; j < oListEdges.NumValues; ++j)
				{
					var stInfo_Edge = E01MakeInfo_Edge_08(a_oGraph_Matrix.ListVertices[i].m_tKey,
						oListEdges[j], a_oGraph_Matrix.GetCost(a_oGraph_Matrix.ListVertices[i].m_tKey, oListEdges[j]));

					oTree_MinCostSpanning.AddEdge(stInfo_Edge.m_chFrom,
						stInfo_Edge.m_chTo, stInfo_Edge.m_nCost);

					oPQueueInfos_Edge.Enqueue(stInfo_Edge, -stInfo_Edge.m_nCost);
				}
			}

			while(oPQueueInfos_Edge.Count > 0)
			{
				var stInfo_Edge = oPQueueInfos_Edge.Dequeue();
				oTree_MinCostSpanning.RemoveEdge(stInfo_Edge.m_chFrom, stInfo_Edge.m_chTo);
				oTree_MinCostSpanning.RemoveEdge(stInfo_Edge.m_chTo, stInfo_Edge.m_chFrom);

				bool bIsConnect = E01IsConnect_Vertex_08(oTree_MinCostSpanning,
					stInfo_Edge.m_chFrom, stInfo_Edge.m_chTo);

				// 간선 제거가 불가능 할 경우
				if(!bIsConnect)
				{
					oTree_MinCostSpanning.AddEdge(stInfo_Edge.m_chFrom,
						stInfo_Edge.m_chTo, stInfo_Edge.m_nCost);

					oTree_MinCostSpanning.AddEdge(stInfo_Edge.m_chTo,
						stInfo_Edge.m_chFrom, stInfo_Edge.m_nCost);
				}
			}

			return oTree_MinCostSpanning;
		}
#endif // #if A_E01_EXAMPLE_08_01
	}
}
