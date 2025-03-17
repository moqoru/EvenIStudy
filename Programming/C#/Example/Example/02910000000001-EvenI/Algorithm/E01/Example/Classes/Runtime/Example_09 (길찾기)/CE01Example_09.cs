//#define A_E01_EXAMPLE_09_01
#define A_E01_EXAMPLE_09_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_08;

/*
 * 길찾기 (Path Finding) 이란?
 * - 임의의 출발지에서 목적지로 이동하기 위한 경로를 계산하는 알고리즘을 의미한다. (+ 즉, 물체를
 * 특정 위치로 이동시키고 싶을 때 주로 사용한다는 것을 알 수 있다.)
 * 
 * 최단 경로 길찾기 알고리즘 종류
 * - 다익스트라 (Dijkstra)
 * - A* (A Star)
 * 
 * 위와 같이 최단 경로 길찾기 알고리즘에는 크게 2 가지가 존재하며 어떤 알고리즘을 사용하느냐에 따라
 * 최종 계산 된 경로는 달라질 수 있다.
 * 
 * 다익스트라 (Dijkstra) 란?
 * - 출발지에서부터 탐색의 범위를 주변으로 점점 넓혀가는 과정을 반복함으로서 최단 경로를 계산하는
 * 알고리즘을 의미한다. (+ 즉, 내부적으로 너비 우선 탐색이 활용된다는 것을 알 수 있다.)
 * 
 * A* (A Star) 란?
 * - 출발지에서부터 탐색의 범위를 목적지 방향으로 점점 넓혀가는 과정을 반복함으로서 최단 경로를
 * 계산하는 알고리즘을 의미한다. (+ 즉, 다익스트라와 달리 특정 위치가 목적지에 가까울수록 
 * 탐색의 우선 순위가 높다는 것을 알 수 있다.)
 * 
 * A* 알고리즘은 탐색 위치에 대한 우선 순위가 존재하며 우선 순위는 해당 위치와 목적지 간에 거리를
 * 통해 추청한다. (+ 즉, 정확한 거리가 아니라 추정치라는 것을 알 수 있다.)
 * 
 * 특정 위치와 목적지 간에 거리 계산법에는 주로 유클리디안 거리 계산법이 활용되며
 * 격자 형태의 이동일 경우에는 맨해튼 거리 계산법이 활용된다.
 * 
 * 유클리디안 거리 계산 공식 (피타고라스)
 * - A^2 + B^2 = C^2
 * 
 * 맨해튼 거리 계산 공식
 * - (Xa - Xb) + (Ya - Yb)
 * 
 * 위와 같이 특정 위치와 목적지 간에 거리를 추정하고 해당 거리를 이동 비용에 반영함으로서
 * 탐색 할 위치에 우선 순위를 부여하는 것이 A* 알고리즘에 핵심이라는 것을 알 수 있다.
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_09
{
	/**
	 * Example 9
	 */
	class CE01Example_09
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if A_E01_EXAMPLE_09_01
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
			oGraph_List.AddEdge('A', 'C', 2);
			oGraph_List.AddEdge('A', 'E', 3);

			oGraph_List.AddEdge('B', 'C', 1);
			oGraph_List.AddEdge('B', 'G', 2);

			oGraph_List.AddEdge('C', 'D', 1);

			oGraph_List.AddEdge('D', 'A', 1);
			oGraph_List.AddEdge('D', 'E', 2);

			oGraph_List.AddEdge('E', 'F', 1);
			oGraph_List.AddEdge('F', 'G', 2);
			oGraph_List.AddEdge('G', 'D', 3);

			var oListPath = E01FindPath_09(oGraph_List, 'A', 'G');
			Console.WriteLine("=====> 다익스트라 경로 탐색 - A -> G <=====");

			for(int i = 0; i < oListPath.Count; ++i)
			{
				Console.Write("{0}, ", oListPath[i]);
			}

			Console.WriteLine();
#elif A_E01_EXAMPLE_09_02
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
			oGraph_Matrix.AddEdge('A', 'C', 2);
			oGraph_Matrix.AddEdge('A', 'E', 3);

			oGraph_Matrix.AddEdge('B', 'C', 1);
			oGraph_Matrix.AddEdge('B', 'G', 2);

			oGraph_Matrix.AddEdge('C', 'D', 1);

			oGraph_Matrix.AddEdge('D', 'A', 1);
			oGraph_Matrix.AddEdge('D', 'E', 2);

			oGraph_Matrix.AddEdge('E', 'F', 1);
			oGraph_Matrix.AddEdge('F', 'G', 2);
			oGraph_Matrix.AddEdge('G', 'D', 3);

			var oListPath = E01FindPath_09(oGraph_Matrix, 'A', 'G');
			Console.WriteLine("=====> A* 경로 탐색 - A -> G <=====");

			for(int i = 0; i < oListPath.Count; ++i)
			{
				Console.Write("{0}, ", oListPath[i]);
			}

			Console.WriteLine();
#endif // #if A_E01_EXAMPLE_09_01
		}

		/**
		 * 경로 정보
		 */
		private class CE01Info_Path_09 : IComparable
		{
			public int m_nCost = 0;
			public char m_chKey_Vertex = '\0';

			public CE01Info_Path_09 m_oInfo_PrevPath = null;

			/** 값을 비교한다 */
			public int CompareTo(object? a_oObj)
			{
				var oInfo_Path = a_oObj as CE01Info_Path_09;

				// 값 비교가 불가능 할 경우
				if(oInfo_Path == null)
				{
					return -1;
				}

				return (m_chKey_Vertex == oInfo_Path.m_chKey_Vertex) ? 0 : -1;
			}
		}

		/** 경로 정보를 생성한다 */
		private static CE01Info_Path_09 E01MakeInfo_Path_09(char a_chKey_Vertex,
			int a_nCost)
		{
			return new CE01Info_Path_09()
			{
				m_nCost = a_nCost,
				m_chKey_Vertex = a_chKey_Vertex
			};
		}

#if A_E01_EXAMPLE_09_01
		/** 경로를 탐색한다 */
		private static List<char> E01FindPath_09(CE01Graph_AdjacencyList_08_01<char, int> a_oGraph_List,
			char a_chFrom, char a_chTo)
		{
			var oListPath = new List<char>();
			var oListClose = new List<CE01Info_Path_09>();

			var oQueueOpen = new Queue<CE01Info_Path_09>();
			oQueueOpen.Enqueue(E01MakeInfo_Path_09(a_chFrom, 0));

			bool bIsSuccess = false;

			while(oQueueOpen.Count > 0)
			{
				var oInfo_FromPath = oQueueOpen.Dequeue();
				oListClose.Add(oInfo_FromPath);

				// 목적지 일 경우
				if(a_chTo == oInfo_FromPath.m_chKey_Vertex)
				{
					bIsSuccess = true;
					break;
				}

				var oListEdges = a_oGraph_List.GetEdges(oInfo_FromPath.m_chKey_Vertex);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					int nCost_To = oInfo_FromPath.m_nCost +
						a_oGraph_List.GetCost(oInfo_FromPath.m_chKey_Vertex, oListEdges[i].m_tTo);

					int nResult = oListClose.FindIndex((a_oInfo_Path) =>
					{
						return a_oInfo_Path.m_chKey_Vertex == oListEdges[i].m_tTo;
					});

					// 방문했을 경우
					if(nResult >= 0 && nResult < oListClose.Count)
					{
						oListClose[nResult].m_oInfo_PrevPath = (nCost_To < oListClose[nResult].m_nCost) ?
							oInfo_FromPath : oListClose[nResult].m_oInfo_PrevPath;

						oListClose[nResult].m_nCost = (nCost_To < oListClose[nResult].m_nCost) ?
							nCost_To : oListClose[nResult].m_nCost;

						continue;
					}

					var oInfo_ToPath = E01MakeInfo_Path_09(oListEdges[i].m_tTo, nCost_To);
					oInfo_ToPath.m_oInfo_PrevPath = oInfo_FromPath;

					oQueueOpen.Enqueue(oInfo_ToPath);
				}
			}

			// 탐색에 실패했을 경우
			if(!bIsSuccess)
			{
				return oListPath;
			}

			var oInfo_Path = oListClose[oListClose.Count - 1];

			while(oQueueOpen.Count > 0)
			{
				var oInfo_FromPath = oQueueOpen.Dequeue();
				var oListEdges = a_oGraph_List.GetEdges(oInfo_FromPath.m_chKey_Vertex);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					// 탐색이 불가능 할 경우
					if(oInfo_Path.m_chKey_Vertex != oListEdges[i].m_tTo)
					{
						continue;
					}

					int nCost_To = oInfo_FromPath.m_nCost +
						a_oGraph_List.GetCost(oInfo_FromPath.m_chKey_Vertex, oListEdges[i].m_tTo);

					oInfo_Path.m_oInfo_PrevPath = (nCost_To < oInfo_Path.m_nCost) ?
							oInfo_FromPath : oInfo_Path.m_oInfo_PrevPath;

					oInfo_Path.m_nCost = (nCost_To < oInfo_Path.m_nCost) ?
						nCost_To : oInfo_Path.m_nCost;
				}
			}

			while(oInfo_Path.m_oInfo_PrevPath != null)
			{
				oListPath.Insert(0, oInfo_Path.m_chKey_Vertex);
				oInfo_Path = oInfo_Path.m_oInfo_PrevPath;
			}

			oListPath.Insert(0, oInfo_Path.m_chKey_Vertex);
			return oListPath;
		}
#elif A_E01_EXAMPLE_09_02
		/** 경로를 탐색한다 */
		private static List<char> E01FindPath_09(CE01Graph_AdjacencyMatrix_08_02<char, int> a_oGraph_Matrix,
			char a_chFrom, char a_chTo)
		{
			var oListPath = new List<char>();
			var oListClose = new List<CE01Info_Path_09>();

			var oPQueueOpen = new PriorityQueue<CE01Info_Path_09, int>();
			oPQueueOpen.Enqueue(E01MakeInfo_Path_09(a_chFrom, 0), 0);

			bool bIsSuccess = false;

			while(oPQueueOpen.Count > 0)
			{
				var oInfo_FromPath = oPQueueOpen.Dequeue();
				oListClose.Add(oInfo_FromPath);

				// 목적지 일 경우
				if(a_chTo == oInfo_FromPath.m_chKey_Vertex)
				{
					bIsSuccess = true;
					break;
				}

				var oListEdges = a_oGraph_Matrix.GetEdges(oInfo_FromPath.m_chKey_Vertex);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					int nVertex_To = a_oGraph_Matrix.FindVertexAt(oListEdges[i]);
					var oVertex_To = a_oGraph_Matrix.ListVertices[nVertex_To];

					int nCost_To = oInfo_FromPath.m_nCost +
						a_oGraph_Matrix.GetCost(oInfo_FromPath.m_chKey_Vertex, oVertex_To.m_tKey);

					int nResult = oListClose.FindIndex((a_oInfo_Path) =>
					{
						return a_oInfo_Path.m_chKey_Vertex == oVertex_To.m_tKey;
					});

					// 방문했을 경우
					if(nResult >= 0 && nResult < oListClose.Count)
					{
						oListClose[nResult].m_oInfo_PrevPath = (nCost_To < oListClose[nResult].m_nCost) ?
							oInfo_FromPath : oListClose[nResult].m_oInfo_PrevPath;

						oListClose[nResult].m_nCost = (nCost_To < oListClose[nResult].m_nCost) ?
							nCost_To : oListClose[nResult].m_nCost;

						continue;
					}

					var oInfo_ToPath = E01MakeInfo_Path_09(oVertex_To.m_tKey, nCost_To);
					oInfo_ToPath.m_oInfo_PrevPath = oInfo_FromPath;

					oPQueueOpen.Enqueue(oInfo_ToPath, nCost_To + ('Z' - oVertex_To.m_tKey));
				}
			}

			// 탐색에 실패했을 경우
			if(!bIsSuccess)
			{
				return oListPath;
			}

			var oInfo_Path = oListClose[oListClose.Count - 1];

			while(oPQueueOpen.Count > 0)
			{
				var oInfo_FromPath = oPQueueOpen.Dequeue();
				var oListEdges = a_oGraph_Matrix.GetEdges(oInfo_FromPath.m_chKey_Vertex);

				for(int i = 0; i < oListEdges.NumValues; ++i)
				{
					int nVertex_To = a_oGraph_Matrix.FindVertexAt(oListEdges[i]);
					var oVertex_To = a_oGraph_Matrix.ListVertices[nVertex_To];

					// 탐색이 불가능 할 경우
					if(oInfo_Path.m_chKey_Vertex != oVertex_To.m_tKey)
					{
						continue;
					}

					int nCost_To = oInfo_FromPath.m_nCost +
						a_oGraph_Matrix.GetCost(oInfo_FromPath.m_chKey_Vertex, oVertex_To.m_tKey);

					oInfo_Path.m_oInfo_PrevPath = (nCost_To < oInfo_Path.m_nCost) ?
							oInfo_FromPath : oInfo_Path.m_oInfo_PrevPath;

					oInfo_Path.m_nCost = (nCost_To < oInfo_Path.m_nCost) ?
						nCost_To : oInfo_Path.m_nCost;
				}
			}

			while(oInfo_Path.m_oInfo_PrevPath != null)
			{
				oListPath.Insert(0, oInfo_Path.m_chKey_Vertex);
				oInfo_Path = oInfo_Path.m_oInfo_PrevPath;
			}

			oListPath.Insert(0, oInfo_Path.m_chKey_Vertex);
			return oListPath;
		}
#endif // #if A_E01_EXAMPLE_09_01
	}
}
