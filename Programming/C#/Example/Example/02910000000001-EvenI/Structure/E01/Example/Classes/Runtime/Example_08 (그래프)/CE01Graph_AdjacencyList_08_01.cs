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
	 * 그래프 - 인접 리스트
	 */
	class CE01Graph_AdjacencyList_08_01<TKey, TVal> where TKey : IComparable where TVal : IComparable
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

			public CE01List_Array_02_01<CEdge> m_oListEdges = new CE01List_Array_02_01<CEdge>();

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

		/**
		 * 간선
		 */
		public class CEdge : IComparable
		{
			public int m_nCost;

			public TKey m_tFrom;
			public TKey m_tTo;

			/** 값을 비교한다 */
			public int CompareTo(object? a_oObj)
			{
				var oEdge = a_oObj as CEdge;

				// 값 비교가 불가능 할 경우
				if(oEdge == null)
				{
					return -1;
				}

				int nCompare_From = m_tFrom.CompareTo(oEdge.m_tFrom);
				int nCompare_To = m_tTo.CompareTo(oEdge.m_tTo);

				return (nCompare_From == 0 && nCompare_To == 0) ? 0 : -1;
			}
		}

		public CE01List_Array_02_01<CVertex> ListVertices { get; private set; } = null;
		public int NumVertices => this.ListVertices.NumValues;

		/** 생성자 */
		public CE01Graph_AdjacencyList_08_01(int a_nSize = 5)
		{
			this.ListVertices = new CE01List_Array_02_01<CVertex>(a_nSize);
		}

		/** 비용을 반환한다 */
		public int GetCost(TKey a_tFrom, TKey a_tTo)
		{
			var oVertex = this.FindVertex(a_tFrom);
			var oEdge = this.FindEdge(a_tFrom, a_tTo);

			return (oVertex != null && oEdge != null) ? oEdge.m_nCost : -1;
		}

		/** 간선을 반환한다 */
		public CE01List_Array_02_01<CEdge> GetEdges(TKey a_tKey)
		{
			var oVertex = this.FindVertex(a_tKey);
			return (oVertex != null) ? oVertex.m_oListEdges : null;
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
		}

		/** 간선을 추가한다 */
		public void AddEdge(TKey a_tFrom, TKey a_tTo, int a_nCost)
		{
			var oVertex = this.FindVertex(a_tFrom);
			var oEdge = this.FindEdge(a_tFrom, a_tTo);

			// 간선 추가가 불가능 할 경우
			if(oVertex == null || oEdge != null || a_tFrom.CompareTo(a_tTo) == 0)
			{
				return;
			}

			oEdge = this.CreateEdge(a_tFrom, a_tTo, a_nCost);
			oVertex.m_oListEdges.AddVal(oEdge);
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

			for(int i = 0; i < this.ListVertices.NumValues; ++i)
			{
				this.RemoveEdge(this.ListVertices[i].m_tKey, a_tKey);
			}

			this.ListVertices.RemoveVal(oVertex);
		}

		/** 간선을 제거한다 */
		public void RemoveEdge(TKey a_tFrom, TKey a_tTo)
		{
			var oVertex = this.FindVertex(a_tFrom);
			var oEdge = this.FindEdge(a_tFrom, a_tTo);

			// 간선 제거가 불가능 할 경우
			if(oVertex == null || oEdge == null || a_tFrom.CompareTo(a_tTo) == 0)
			{
				return;
			}

			oVertex.m_oListEdges.RemoveVal(oEdge);
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
			for(int i = 0; i < this.ListVertices.NumValues; ++i)
			{
				// 정점이 존재 할 경우
				if(a_tKey.CompareTo(this.ListVertices[i].m_tKey) == 0)
				{
					return this.ListVertices[i];
				}
			}

			return null;
		}

		/** 간선을 탐색한다 */
		private CEdge FindEdge(TKey a_tFrom, TKey a_tTo)
		{
			var oVertex = this.FindVertex(a_tFrom);

			// 간선 탐색이 불가능 할 경우
			if(oVertex == null)
			{
				return null;
			}

			for(int i = 0; i < oVertex.m_oListEdges.NumValues; ++i)
			{
				// 간선이 존재 할 경우
				if(a_tTo.CompareTo(oVertex.m_oListEdges[i].m_tTo) == 0)
				{
					return oVertex.m_oListEdges[i];
				}
			}

			return null;
		}

		/** 값을 순회한다 */
		private void Enumerate_ByDepthFirst(TKey a_tKey,
			Action<TKey, TVal> a_oCallback, List<TKey> a_oOutListKeys_Visit)
		{
			var oVertex = this.FindVertex(a_tKey);
			a_oOutListKeys_Visit.Add(oVertex.m_tKey);

			a_oCallback?.Invoke(oVertex.m_tKey, oVertex.m_tVal);

			for(int i = 0; i < oVertex.m_oListEdges.NumValues; ++i)
			{
				// 값 순회가 불가능 할 경우
				if(a_oOutListKeys_Visit.Contains(oVertex.m_oListEdges[i].m_tTo))
				{
					continue;
				}

				this.Enumerate_ByDepthFirst(oVertex.m_oListEdges[i].m_tTo,
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

				for(int i = 0; i < oVertex.m_oListEdges.NumValues; ++i)
				{
					// 값 순회가 불가능 할 경우
					if(a_oOutListKeys_Visit.Contains(oVertex.m_oListEdges[i].m_tTo))
					{
						continue;
					}

					oQueueKeys.Enqueue(oVertex.m_oListEdges[i].m_tTo);
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

		/** 간선을 생성한다 */
		private CEdge CreateEdge(TKey a_tFrom, TKey a_tTo, int a_nCost)
		{
			return new CEdge()
			{
				m_nCost = a_nCost,

				m_tFrom = a_tFrom,
				m_tTo = a_tTo
			};
		}
	}
}
