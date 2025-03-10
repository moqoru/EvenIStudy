using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * 레드 블랙 트리
	 */
	class CE01Tree_RedBlack_07<T> where T : IComparable
	{
		/**
		 * 색상
		 */
		public enum EColor
		{
			NONE = -1,
			RED,
			BLACK,
			MAX_VAL
		}

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
			public EColor Color { get; set; } = EColor.NONE;

			public CNode Node_Parent { get; set; } = null;
			public CNode Node_LChild { get; set; } = null;
			public CNode Node_RChild { get; set; } = null;
		}

		public CNode Node_Nil { get; private set; } = null;
		public CNode Node_Root { get; private set; } = null;

		/** 생성자 */
		public CE01Tree_RedBlack_07()
		{
			this.Node_Nil = this.CreateNode(default);
			this.Node_Nil.Color = EColor.BLACK;

			this.Node_Root = this.Node_Nil;
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			var oNode = this.CreateNode(a_tVal);

			// 루트 노드가 없을 경우
			if(this.Node_Root == this.Node_Nil)
			{
				this.Node_Root = oNode;
			}
			else
			{
				var oNode_Child = this.Node_Root;
				CNode oNode_Parent = null;

				while(oNode_Child != this.Node_Nil)
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
			}

			this.Rebalance_ByAdd(oNode);
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			var oNode_Remove = this.Node_Root;
			CNode oNode_Parent = null;

			while(oNode_Remove != this.Node_Nil && a_tVal.CompareTo(oNode_Remove.Val) != 0)
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
			if(oNode_Remove == this.Node_Nil)
			{
				return;
			}

			// 자식 노드가 모두 존재 할 경우
			if(oNode_Remove.Node_LChild != this.Node_Nil && oNode_Remove.Node_RChild != this.Node_Nil)
			{
				oNode_Parent = oNode_Remove;
				var oNode_Descendants = oNode_Remove.Node_RChild;

				while(oNode_Descendants.Node_LChild != this.Node_Nil)
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
				this.Node_Root = (this.Node_Root.Node_LChild != this.Node_Nil) ?
					this.Node_Root.Node_LChild : this.Node_Root.Node_RChild;

				return;
			}

			CNode oNode_Successor = null;

			// 왼쪽 노드가 존재 할 경우
			if(oNode_Remove.Node_LChild != this.Node_Nil)
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

				oNode_Successor = oNode_Remove.Node_LChild;
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

				oNode_Successor = oNode_Remove.Node_RChild;
			}

			// 검은색 노드를 제거했을 경우
			if(oNode_Remove.Color == EColor.BLACK)
			{
				this.Rebalance_ByRemove(oNode_Successor);
			}
		}

		/** 값을 순회한다 */
		public void Enumerate(EOrder a_eOrder, Action<int, T> a_oCallback)
		{
			// 값 순회가 불가능 할 경우
			if(this.Node_Root == null)
			{
				return;
			}

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

		/** 균형을 회복한다 */
		private void Rebalance_ByAdd(CNode a_oNode)
		{
			while(a_oNode.Node_Parent != null && a_oNode.Node_Parent.Color == EColor.RED)
			{
				bool bIsNode_LParent = a_oNode.Node_Parent ==
					a_oNode.Node_Parent.Node_Parent.Node_LChild;

				var oNode_Uncle = bIsNode_LParent ?
					a_oNode.Node_Parent.Node_Parent.Node_RChild : a_oNode.Node_Parent.Node_Parent.Node_LChild;

				// 삼촌 노드의 색상이 빨간색 일 경우
				if(oNode_Uncle.Color == EColor.RED)
				{
					oNode_Uncle.Color = EColor.BLACK;
					a_oNode.Node_Parent.Color = EColor.BLACK;

					a_oNode.Node_Parent.Node_Parent.Color = EColor.RED;
					a_oNode = a_oNode.Node_Parent.Node_Parent;

					continue;
				}

				// 부모 노드가 할아버지 노드의 왼쪽 자식 일 경우
				if(bIsNode_LParent)
				{
					// 부모 노드의 오른쪽 자식 일 경우
					if(a_oNode == a_oNode.Node_Parent.Node_RChild)
					{
						a_oNode = a_oNode.Node_Parent;
						this.RebalanceSubtree_RightRight(a_oNode);
					}

					a_oNode.Node_Parent.Color = EColor.BLACK;
					a_oNode.Node_Parent.Node_Parent.Color = EColor.RED;

					this.RebalanceSubtree_LeftLeft(a_oNode.Node_Parent.Node_Parent);
				}
				else
				{
					// 부모 노드의 왼쪽 자식 일 경우
					if(a_oNode == a_oNode.Node_Parent.Node_LChild)
					{
						a_oNode = a_oNode.Node_Parent;
						this.RebalanceSubtree_LeftLeft(a_oNode);
					}

					a_oNode.Node_Parent.Color = EColor.BLACK;
					a_oNode.Node_Parent.Node_Parent.Color = EColor.RED;

					this.RebalanceSubtree_RightRight(a_oNode.Node_Parent.Node_Parent);
				}
			}

			this.Node_Root.Color = EColor.BLACK;
		}

		/** 균형을 회복한다 */
		private void Rebalance_ByRemove(CNode a_oNode)
		{
			while(a_oNode.Node_Parent != null && a_oNode.Color == EColor.BLACK)
			{
				bool bIsNode_LChild = a_oNode == a_oNode.Node_Parent.Node_LChild;

				var oNode_Sibling = bIsNode_LChild ?
					a_oNode.Node_Parent.Node_RChild : a_oNode.Node_Parent.Node_LChild;

				// 형제 노드가 빨간색 일 경우
				if(oNode_Sibling.Color == EColor.RED)
				{
					oNode_Sibling.Color = EColor.RED;
					a_oNode.Node_Parent.Color = EColor.BLACK;

					// 부모 노드의 왼쪽 자식 일 경우
					if(bIsNode_LChild)
					{
						this.RebalanceSubtree_RightRight(a_oNode.Node_Parent);
					}
					else
					{
						this.RebalanceSubtree_LeftLeft(a_oNode.Node_Parent);
					}

					continue;
				}

				// 형제 노드의 자식 노드가 모두 검은색 일 경우
				if(oNode_Sibling.Node_LChild.Color == EColor.BLACK &&
					oNode_Sibling.Node_RChild.Color == EColor.BLACK)
				{
					a_oNode = a_oNode.Node_Parent;
					oNode_Sibling.Color = EColor.RED;

					continue;
				}

				// 부모 노드의 왼쪽 자식 일 경우
				if(bIsNode_LChild)
				{
					// 형제 노드의 왼쪽 자식 노드가 빨간색 일 경우
					if(oNode_Sibling.Node_LChild.Color == EColor.RED)
					{
						oNode_Sibling.Color = EColor.RED;
						oNode_Sibling.Node_LChild.Color = EColor.BLACK;

						oNode_Sibling = this.RebalanceSubtree_LeftLeft(oNode_Sibling);
					}

					oNode_Sibling.Color = a_oNode.Node_Parent.Color;

					a_oNode.Node_Parent.Color = EColor.BLACK;
					oNode_Sibling.Node_RChild.Color = EColor.BLACK;

					this.RebalanceSubtree_RightRight(a_oNode.Node_Parent);
					a_oNode = this.Node_Root;
				}
				else
				{
					// 형제 노드의 오른쪽 자식 노드가 빨간색 일 경우
					if(oNode_Sibling.Node_RChild.Color == EColor.RED)
					{
						oNode_Sibling.Color = EColor.RED;
						oNode_Sibling.Node_RChild.Color = EColor.BLACK;

						oNode_Sibling = this.RebalanceSubtree_RightRight(oNode_Sibling);
					}

					oNode_Sibling.Color = a_oNode.Node_Parent.Color;

					a_oNode.Node_Parent.Color = EColor.BLACK;
					oNode_Sibling.Node_LChild.Color = EColor.BLACK;

					this.RebalanceSubtree_LeftLeft(a_oNode.Node_Parent);
					a_oNode = this.Node_Root;
				}
			}

			a_oNode.Color = EColor.BLACK;
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
			if(oNode_LRChild != this.Node_Nil)
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
		private CNode RebalanceSubtree_RightRight(CNode a_oNode)
		{
			var oNode_Parent = a_oNode.Node_Parent;
			var oNode_RChild = a_oNode.Node_RChild;
			var oNode_RLChild = oNode_RChild.Node_LChild;

			a_oNode.Node_RChild = oNode_RLChild;

			oNode_RChild.Node_Parent = oNode_Parent;
			oNode_RChild.Node_LChild = a_oNode;

			// RL 자식이 존재 할 경우
			if(oNode_RLChild != this.Node_Nil)
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
			if(a_oNode == this.Node_Nil)
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
			if(a_oNode == this.Node_Nil)
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
			if(a_oNode == this.Node_Nil)
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
				if(stInfo_Node.Item1.Node_LChild != this.Node_Nil)
				{
					var stInfo_LChildNode = (stInfo_Node.Item1.Node_LChild,
						stInfo_Node.Item2 + 1);

					oQueueNodes.Enqueue(stInfo_LChildNode);
				}

				// 오른쪽 노드가 존재 할 경우
				if(stInfo_Node.Item1.Node_RChild != this.Node_Nil)
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
				Val = a_tVal,
				Color = EColor.RED,

				Node_LChild = this.Node_Nil,
				Node_RChild = this.Node_Nil
			};
		}
	}
}
