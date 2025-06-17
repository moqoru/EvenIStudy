using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Algorithm.E01.Solution.Classes.Runtime.Solution_02
{
	/**
	 * 이진 트리
	 */
	class CS01Tree_Binary_02<T> where T : IComparable
	{
		/**
		 * 순서
		 */
		public enum EOrder
		{
			NONE = -1,
			PRE,
			IN,
			POST,
			LEVEL,
			MAX_VAL
		}

		/**
		 * 노드
		 */
		public class CNode : IComparable
		{
			public T Val { get; set; }

			public CNode Node_LChild { get; set; } = null;
			public CNode Node_RChild { get; set; } = null;

			/** 값을 비교한다 */
			public int CompareTo(object? a_oObj)
			{
				var oNode = a_oObj as CNode;

				// 값 비교가 불가능 할 경우
				if(oNode == null)
				{
					return -1;
				}

				return this.Val.CompareTo(oNode.Val);
			}
		}

		public CNode Node_Root { get; private set; } = null;

		/** 루트 노드를 추가한다 */
		public void AddNode_Root(CNode a_oNode)
		{
			// 노드 추가가 불가능 할 경우
			if(this.Node_Root != null)
			{
				return;
			}

			this.Node_Root = a_oNode;
		}

		/** 왼쪽 노드를 추가한다 */
		public static void AddNode_LChild(CNode a_oNode_Root, CNode a_oNode)
		{
			// 노드 추가가 불가능 할 경우
			if(a_oNode_Root.Node_LChild != null)
			{
				return;
			}

			a_oNode_Root.Node_LChild = a_oNode;
		}

		/** 오른쪽 노드 값을 추가한다 */
		public static void AddNode_RChild(CNode a_oNode_Root, CNode a_oNode)
		{
			// 노드 추가가 불가능 할 경우
			if(a_oNode_Root.Node_RChild != null)
			{
				return;
			}

			a_oNode_Root.Node_RChild = a_oNode;
		}

		/** 값을 순회한다 */
		public void Enumerate(EOrder a_eOrder, Action<int, T> a_oCallback)
		{
			switch(a_eOrder)
			{
				case EOrder.PRE:
					this.Enumerate_ByPreOrder(this.Node_Root, 0, a_oCallback);
					break;

				case EOrder.IN:
					this.Enumerate_ByInOrder(this.Node_Root, 0, a_oCallback);
					break;

				case EOrder.POST:
					this.Enumerate_ByPostOrder(this.Node_Root, 0, a_oCallback);
					break;

				case EOrder.LEVEL:
					this.Enumerate_ByLevelOrder(this.Node_Root, 0, a_oCallback);
					break;
			}
		}

		/** 노드를 생성한다 */
		public static CNode CreateNode(T a_tVal)
		{
			return new CNode()
			{
				Val = a_tVal
			};
		}

		/** 전위 순회한다 */
		private void Enumerate_ByPreOrder(CNode a_oNode,
			int a_nDepth, Action<int, T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			a_oCallback?.Invoke(a_nDepth, a_oNode.Val);

			this.Enumerate_ByPreOrder(a_oNode.Node_LChild, a_nDepth + 1, a_oCallback);
			this.Enumerate_ByPreOrder(a_oNode.Node_RChild, a_nDepth + 1, a_oCallback);
		}

		/** 중위 순회한다 */
		private void Enumerate_ByInOrder(CNode a_oNode,
			int a_nDepth, Action<int, T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			this.Enumerate_ByInOrder(a_oNode.Node_LChild, a_nDepth + 1, a_oCallback);
			a_oCallback?.Invoke(a_nDepth, a_oNode.Val);

			this.Enumerate_ByInOrder(a_oNode.Node_RChild, a_nDepth + 1, a_oCallback);
		}

		/** 후위 순회한다 */
		private void Enumerate_ByPostOrder(CNode a_oNode,
			int a_nDepth, Action<int, T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			this.Enumerate_ByPostOrder(a_oNode.Node_LChild, a_nDepth + 1, a_oCallback);
			this.Enumerate_ByPostOrder(a_oNode.Node_RChild, a_nDepth + 1, a_oCallback);

			a_oCallback?.Invoke(a_nDepth, a_oNode.Val);
		}

		/** 레벨 순회한다 */
		private void Enumerate_ByLevelOrder(CNode a_oNode,
			int a_nDepth, Action<int, T> a_oCallback)
		{
			var oQueueNodes = new Queue<(CNode, int)>();
			oQueueNodes.Enqueue((a_oNode, 0));

			while(oQueueNodes.Count > 0)
			{
				var stInfo_Node = oQueueNodes.Dequeue();
				a_oCallback?.Invoke(stInfo_Node.Item2, stInfo_Node.Item1.Val);

				// 왼쪽 노드가 존재 할 경우
				if(stInfo_Node.Item1.Node_LChild != null)
				{
					var stInfo_LChildNode = (stInfo_Node.Item1.Node_LChild,
						stInfo_Node.Item2 + 1);

					oQueueNodes.Enqueue(stInfo_LChildNode);
				}

				// 오른쪽 노드가 존재 할 경우
				if(stInfo_Node.Item1.Node_RChild != null)
				{
					var stInfo_RChildNode = (stInfo_Node.Item1.Node_RChild,
						stInfo_Node.Item2 + 1);

					oQueueNodes.Enqueue(stInfo_RChildNode);
				}
			}
		}
	}
}
