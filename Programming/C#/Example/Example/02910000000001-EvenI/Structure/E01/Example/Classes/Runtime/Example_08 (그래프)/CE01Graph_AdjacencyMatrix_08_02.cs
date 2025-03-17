using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02;
using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_04;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_08
{
	/**
	 * 그래프 - 인접 행렬
	 */
	class CE01Graph_AdjacencyMatrix_08_02<TKey, TVal> where TKey : IComparable where TVal : IComparable
	{
		/**
		 * 순서
		 */
		public enum EOrder
		{
			NONE = -1,
			DEPTH_FIRST,
			BREADTH_FIRST,
			MAX_VAL
		}

		/**
		 * 정점
		 */
		public class CVertex : IComparable
		{
			public TKey m_tKey;
			public TVal m_tVal;

			/** 값을 비교한다 */
			public int CompareTo(object? a_oObj)
			{
				var oVertex = a_oObj as CVertex;

				// 값 비교가 불가능 할 경우
				if(oVertex == null)
				{
					return -1;
				}

				int nCompare_Key = m_tKey.CompareTo(oVertex.m_tKey);
				int nCompare_Val = m_tVal.CompareTo(oVertex.m_tVal);

				return (nCompare_Key == 0 && nCompare_Val == 0) ? 0 : -1;
			}
		}

		public CE01List_Array_02_01<CVertex> ListVertices { get; private set; } = null;
		public List<CE01List_Array_02_01<int>> ContainerListEdges { get; private set; } = null;

		public int NumVertices => this.ListVertices.NumValues;

		/** 생성자 */
		public CE01Graph_AdjacencyMatrix_08_02(int a_nSize = 5)
		{
			this.ListVertices = new CE01List_Array_02_01<CVertex>();
			this.ContainerListEdges = new List<CE01List_Array_02_01<int>>();
		}

		/** 비용을 반환한다 */
		public int GetCost(TKey a_tFrom, TKey a_tTo)
		{
			var oVertex_From = this.FindVertex(a_tFrom);
			var oVertex_To = this.FindVertex(a_tTo);

			// 정점이 없을 경우
			if(oVertex_From == null || oVertex_To == null)
			{
				return -1;
			}

			int nResult_From = this.FindVertexAt(a_tFrom);
			int nResult_To = this.FindVertexAt(a_tTo);

			return this.ContainerListEdges[nResult_From][nResult_To];
		}

		/** 간선을 반환한다 */
		public CE01List_Array_02_01<TKey> GetEdges(TKey a_tKey)
		{
			var oVertex = this.FindVertex(a_tKey);
			var oListEdges = new CE01List_Array_02_01<TKey>();

			// 정점이 없을 경우
			if(oVertex == null)
			{
				return oListEdges;
			}

			int nVertex_From = this.FindVertexAt(a_tKey);

			for(int i = 0; i < this.ContainerListEdges[nVertex_From].NumValues; ++i)
			{
				// 간선이 없을 경우
				if(this.ContainerListEdges[nVertex_From][i] < 0)
				{
					continue;
				}

				oListEdges.AddVal(this.ListVertices[i].m_tKey);
			}

			return oListEdges;
		}

		/** 정점을 추가한다 */
		public void AddVertex(TKey a_tKey, TVal a_tVal)
		{
			var oVertex = this.FindVertex(a_tKey);

			// 정점 추가가 불가능 할 경우
			if(oVertex != null)
			{
				return;
			}

			oVertex = this.CreateVertex(a_tKey, a_tVal);
			this.ListVertices.AddVal(oVertex);

			this.ContainerListEdges.Add(new CE01List_Array_02_01<int>());

			for(int i = 0; i < this.ContainerListEdges.Count; ++i)
			{
				for(int j = this.ContainerListEdges[i].NumValues; j < this.ListVertices.NumValues; ++j)
				{
					this.ContainerListEdges[i].AddVal(-1);
				}
			}
		}

		/** 간선을 추가한다 */
		public void AddEdge(TKey a_tFrom, TKey a_tTo, int a_nCost)
		{
			var oVertex_From = this.FindVertex(a_tFrom);
			var oVertex_To = this.FindVertex(a_tTo);

			// 정점 추가가 불가능 할 경우
			if(oVertex_From == null || oVertex_To == null || a_tFrom.CompareTo(a_tTo) == 0)
			{
				return;
			}

			int nResult_From = this.FindVertexAt(a_tFrom);
			int nResult_To = this.FindVertexAt(a_tTo);

			this.ContainerListEdges[nResult_From][nResult_To] = a_nCost;
		}

		/** 정점을 제거한다 */
		public void RemoveVertex(TKey a_tKey)
		{
			var oVertex = this.FindVertex(a_tKey);

			// 정점 제거가 불가능 할 경우
			if(oVertex == null)
			{
				return;
			}

			int nResult = this.FindVertexAt(a_tKey);

			this.ListVertices.RemoveVal(oVertex);
			this.ContainerListEdges.RemoveAt(nResult);

			for(int i = 0; i < this.ContainerListEdges.Count; ++i)
			{
				this.ContainerListEdges[i].RemoveVal_At(nResult);
			}
		}

		/** 간선을 제거한다 */
		public void RemoveEdge(TKey a_tFrom, TKey a_tTo)
		{
			var oVertex_From = this.FindVertex(a_tFrom);
			var oVertex_To = this.FindVertex(a_tTo);

			// 간선 제거가 불가능 할 경우
			if(oVertex_From == null || oVertex_To == null || a_tFrom.CompareTo(a_tTo) == 0)
			{
				return;
			}

			int nResult_From = this.FindVertexAt(a_tFrom);
			int nResult_To = this.FindVertexAt(a_tTo);

			this.ContainerListEdges[nResult_From][nResult_To] = -1;
		}

		/** 정점을 탐색한다 */
		public int FindVertexAt(TKey a_tKey)
		{
			for(int i = 0; i < this.ListVertices.NumValues; ++i)
			{
				// 정점이 존재 할 경우
				if(a_tKey.CompareTo(this.ListVertices[i].m_tKey) == 0)
				{
					return i;
				}
			}

			return -1;
		}

		/** 값을 순회한다 */
		public void Enumerate(EOrder a_eOrder,
			TKey a_tKey_Start, Action<TKey, TVal> a_oCallback)
		{
			var oVertex = this.FindVertex(a_tKey_Start);

			// 값 순회가 불가능 할 경우
			if(oVertex == null)
			{
				return;
			}

			var oListKeys_Visit = new List<TKey>();

			switch(a_eOrder)
			{
				case EOrder.DEPTH_FIRST:
					this.Enumerate_ByDepthFirst(a_tKey_Start,
						a_oCallback, oListKeys_Visit);

					break;

				case EOrder.BREADTH_FIRST:
					this.Enumerate_ByBreadthFirst(a_tKey_Start,
						a_oCallback, oListKeys_Visit);

					break;
			}
		}

		/** 정점을 탐색한다 */
		private CVertex FindVertex(TKey a_tKey)
		{
			int nResult = this.FindVertexAt(a_tKey);
			return (nResult >= 0) ? this.ListVertices[nResult] : null;
		}

		/** 값을 순회한다 */
		private void Enumerate_ByDepthFirst(TKey a_tKey,
			Action<TKey, TVal> a_oCallback, List<TKey> a_oOutListKeys_Visit)
		{
			var oVertex = this.FindVertex(a_tKey);
			int nResult = this.FindVertexAt(a_tKey);

			a_oOutListKeys_Visit.Add(oVertex.m_tKey);
			a_oCallback?.Invoke(oVertex.m_tKey, oVertex.m_tVal);

			for(int i = 0; i < this.ContainerListEdges[nResult].NumValues; ++i)
			{
				// 값 순회가 불가능 할 경우
				if(this.ContainerListEdges[nResult][i] < 0)
				{
					continue;
				}

				// 값 순회가 불가능 할 경우
				if(a_oOutListKeys_Visit.Contains(this.ListVertices[i].m_tKey))
				{
					continue;
				}

				this.Enumerate_ByDepthFirst(this.ListVertices[i].m_tKey,
					a_oCallback, a_oOutListKeys_Visit);
			}
		}

		/** 값을 순회한다 */
		private void Enumerate_ByBreadthFirst(TKey a_tKey,
			Action<TKey, TVal> a_oCallback, List<TKey> a_oOutListKeys_Visit)
		{
			var oQueueKeys = new CE01Queue_04<TKey>();
			oQueueKeys.Enqueue(a_tKey);

			while(oQueueKeys.NumValues > 0)
			{
				var tKey = oQueueKeys.Dequeue();
				var oVertex = this.FindVertex(tKey);

				// 값 순회가 가능 할 경우
				if(!a_oOutListKeys_Visit.Contains(tKey))
				{
					a_oCallback?.Invoke(oVertex.m_tKey, oVertex.m_tVal);
				}

				a_oOutListKeys_Visit.Add(oVertex.m_tKey);
				int nResult = this.FindVertexAt(tKey);

				for(int i = 0; i < this.ContainerListEdges[nResult].NumValues; ++i)
				{
					// 값 순회가 불가능 할 경우
					if(this.ContainerListEdges[nResult][i] < 0)
					{
						continue;
					}

					// 값 순회가 불가능 할 경우
					if(a_oOutListKeys_Visit.Contains(this.ListVertices[i].m_tKey))
					{
						continue;
					}

					oQueueKeys.Enqueue(this.ListVertices[i].m_tKey);
				}
			}
		}

		/** 정점을 생성한다 */
		private CVertex CreateVertex(TKey a_tKey, TVal a_tVal)
		{
			return new CVertex()
			{
				m_tKey = a_tKey,
				m_tVal = a_tVal
			};
		}
	}
}
