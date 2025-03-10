using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * AVL 트리
	 */
	class CE01Tree_AVL_07<T> where T : IComparable
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
		public class CNode
		{
			public T Val { get; set; }

			public CNode Node_Parent { get; set; } = null;
			public CNode Node_LChild { get; set; } = null;
			public CNode Node_RChild { get; set; } = null;
		}

		public CNode Node_Root { get; private set; } = null;

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			var oNode = this.CreateNode(a_tVal);

			// 루트 노드가 없을 경우
			if(this.Node_Root == null)
			{
				this.Node_Root = oNode;
				return;
			}

			var oNode_Child = this.Node_Root;
			CNode oNode_Parent = null;

			while(oNode_Child != null)
			{
				oNode_Parent = oNode_Child;

				// 왼쪽 노드로 이동해야 될 경우
				if(a_tVal.CompareTo(oNode_Child.Val) < 0)
				{
					oNode_Child = oNode_Child.Node_LChild;
				}
				else
				{
					oNode_Child = oNode_Child.Node_RChild;
				}
			}

			oNode.Node_Parent = oNode_Parent;

			// 왼쪽 노드에 추가되어야 할 경우
			if(a_tVal.CompareTo(oNode_Parent.Val) < 0)
			{
				oNode_Parent.Node_LChild = oNode;
			}
			else
			{
				oNode_Parent.Node_RChild = oNode;
			}

			this.Rebalance(oNode_Parent);
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			var oNode_Remove = this.Node_Root;
			CNode oNode_Parent = null;

			while(oNode_Remove != null && a_tVal.CompareTo(oNode_Remove.Val) != 0)
			{
				oNode_Parent = oNode_Remove;

				// 왼쪽 노드로 이동해야 될 경우
				if(a_tVal.CompareTo(oNode_Remove.Val) < 0)
				{
					oNode_Remove = oNode_Remove.Node_LChild;
				}
				else
				{
					oNode_Remove = oNode_Remove.Node_RChild;
				}
			}

			// 값 제거가 불가능 할 경우
			if(oNode_Remove == null)
			{
				return;
			}

			// 자식 노드가 모두 존재 할 경우
			if(oNode_Remove.Node_LChild != null && oNode_Remove.Node_RChild != null)
			{
				oNode_Parent = oNode_Remove;
				var oNode_Descendants = oNode_Remove.Node_RChild;

				while(oNode_Descendants.Node_LChild != null)
				{
					oNode_Parent = oNode_Descendants;
					oNode_Descendants = oNode_Descendants.Node_LChild;
				}

				oNode_Remove.Val = oNode_Descendants.Val;
				oNode_Remove = oNode_Descendants;
			}

			// 루트 노드 일 경우
			if(oNode_Remove == this.Node_Root)
			{
				this.Node_Root = (this.Node_Root.Node_LChild != null) ?
					this.Node_Root.Node_LChild : this.Node_Root.Node_RChild;

				return;
			}

			// 왼쪽 노드가 존재 할 경우
			if(oNode_Remove.Node_LChild != null)
			{
				// 왼쪽 노드 일 경우
				if(oNode_Remove == oNode_Parent.Node_LChild)
				{
					oNode_Parent.Node_LChild = oNode_Remove.Node_LChild;
				}
				else
				{
					oNode_Parent.Node_RChild = oNode_Remove.Node_LChild;
				}
			}
			else
			{
				// 왼쪽 노드 일 경우
				if(oNode_Remove == oNode_Parent.Node_LChild)
				{
					oNode_Parent.Node_LChild = oNode_Remove.Node_RChild;
				}
				else
				{
					oNode_Parent.Node_RChild = oNode_Remove.Node_RChild;
				}
			}

			this.Rebalance(oNode_Parent);
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

		/** 높이를 반환한다 */
		private int GetHeight(CNode a_oNode)
		{
			// 높이 반환이 불가능 할 경우
			if(a_oNode == null)
			{
				return 0;
			}

			int nHeight_Left = this.GetHeight(a_oNode.Node_LChild);
			int nHeight_Right = this.GetHeight(a_oNode.Node_RChild);

			return 1 + Math.Max(nHeight_Left, nHeight_Right);
		}

		/** 균형을 회복한다 */
		private void Rebalance(CNode a_oNode)
		{
			// 균형 회복이 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			int nHeight_Left = this.GetHeight(a_oNode.Node_LChild);
			int nHeight_Right = this.GetHeight(a_oNode.Node_RChild);

			var oNode_Parent = a_oNode.Node_Parent;

			// 균형 회복이 필요없을 경우
			if(Math.Abs(nHeight_Left - nHeight_Right) < 2)
			{
				this.Rebalance(oNode_Parent);
				return;
			}

			// 왼쪽 서브 트리 균형이 무너졌을 경우
			if(nHeight_Left - nHeight_Right > 0)
			{
				this.RebalanceSubtree_Left(a_oNode);
			}
			else
			{
				this.RebalanceSubtree_Right(a_oNode);
			}

			this.Rebalance(oNode_Parent);
		}

		/** 하위 트리 균형을 회복한다 */
		private CNode RebalanceSubtree_Left(CNode a_oNode)
		{
			int nHeight_Left = this.GetHeight(a_oNode.Node_LChild.Node_LChild);
			int nHeight_Right = this.GetHeight(a_oNode.Node_LChild.Node_RChild);

			// LR 상태 일 경우
			if(nHeight_Left - nHeight_Right < 0)
			{
				this.RebalanceSubtree_RightRight(a_oNode.Node_LChild);
			}

			return this.RebalanceSubtree_LeftLeft(a_oNode);
		}

		/** 하위 트리 균형을 회복한다 */
		private CNode RebalanceSubtree_LeftLeft(CNode a_oNode)
		{
			var oNode_Parent = a_oNode.Node_Parent;
			var oNode_LChild = a_oNode.Node_LChild;
			var oNode_LRChild = oNode_LChild.Node_RChild;

			a_oNode.Node_LChild = oNode_LRChild;

			oNode_LChild.Node_Parent = oNode_Parent;
			oNode_LChild.Node_RChild = a_oNode;

			// LR 자식이 존재 할 경우
			if(oNode_LRChild != null)
			{
				oNode_LRChild.Node_Parent = a_oNode;
			}

			// 루트 노드 일 경우
			if(oNode_LChild.Node_Parent == null)
			{
				this.Node_Root = oNode_LChild;
			}
			else
			{
				// 부모 노드의 왼쪽 자식 일 경우
				if(a_oNode == oNode_Parent.Node_LChild)
				{
					oNode_Parent.Node_LChild = oNode_LChild;
				}
				else
				{
					oNode_Parent.Node_RChild = oNode_LChild;
				}
			}

			a_oNode.Node_Parent = oNode_LChild;
			return oNode_LChild;
		}

		/** 하위 트리 균형을 회복한다 */
		private CNode RebalanceSubtree_Right(CNode a_oNode)
		{
			int nHeight_Left = this.GetHeight(a_oNode.Node_RChild.Node_LChild);
			int nHeight_Right = this.GetHeight(a_oNode.Node_RChild.Node_RChild);

			// RL 상태 일 경우
			if(nHeight_Left - nHeight_Right > 0)
			{
				this.RebalanceSubtree_LeftLeft(a_oNode.Node_RChild);
			}

			return this.RebalanceSubtree_RightRight(a_oNode);
		}

		/** 하위 트리 균형을 회복한다 */
		private CNode RebalanceSubtree_RightRight(CNode a_oNode)
		{
			var oNode_Parent = a_oNode.Node_Parent;
			var oNode_RChild = a_oNode.Node_RChild;
			var oNode_RLChild = oNode_RChild.Node_LChild;

			a_oNode.Node_RChild = oNode_RLChild;

			oNode_RChild.Node_Parent = oNode_Parent;
			oNode_RChild.Node_LChild = a_oNode;

			// RL 자식이 존재 할 경우
			if(oNode_RLChild != null)
			{
				oNode_RLChild.Node_Parent = a_oNode;
			}

			// 루트 노드 일 경우
			if(oNode_RChild.Node_Parent == null)
			{
				this.Node_Root = oNode_RChild;
			}
			else
			{
				// 부모 노드의 왼쪽 자식 일 경우
				if(a_oNode == oNode_Parent.Node_LChild)
				{
					oNode_Parent.Node_LChild = oNode_RChild;
				}
				else
				{
					oNode_Parent.Node_RChild = oNode_RChild;
				}
			}

			a_oNode.Node_Parent = oNode_RChild;
			return oNode_RChild;
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

		/** 노드를 생성한다 */
		private CNode CreateNode(T a_tVal)
		{
			return new CNode()
			{
				Val = a_tVal
			};
		}
	}
}
