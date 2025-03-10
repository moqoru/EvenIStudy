using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_05
{
	/**
	 * 이진 탐색 트리
	 */
	class CE01Tree_BinarySearch_05<T> where T : IComparable
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
		}

		/** 값을 순회한다 */
		public void Enumerate(EOrder a_eOrder, Action<T> a_oCallback)
		{
			switch(a_eOrder)
			{
				case EOrder.PRE:
					this.Enumerate_ByPreOrder(this.Node_Root, a_oCallback);
					break;

				case EOrder.IN:
					this.Enumerate_ByInOrder(this.Node_Root, a_oCallback);
					break;

				case EOrder.POST:
					this.Enumerate_ByPostOrder(this.Node_Root, a_oCallback);
					break;

				case EOrder.LEVEL:
					this.Enumerate_ByLevelOrder(this.Node_Root, a_oCallback);
					break;
			}
		}

		/** 전위 순회한다 */
		private void Enumerate_ByPreOrder(CNode a_oNode, Action<T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			a_oCallback?.Invoke(a_oNode.Val);

			this.Enumerate_ByPreOrder(a_oNode.Node_LChild, a_oCallback);
			this.Enumerate_ByPreOrder(a_oNode.Node_RChild, a_oCallback);
		}

		/** 중위 순회한다 */
		private void Enumerate_ByInOrder(CNode a_oNode, Action<T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			this.Enumerate_ByInOrder(a_oNode.Node_LChild, a_oCallback);
			a_oCallback?.Invoke(a_oNode.Val);

			this.Enumerate_ByInOrder(a_oNode.Node_RChild, a_oCallback);
		}

		/** 후위 순회한다 */
		private void Enumerate_ByPostOrder(CNode a_oNode, Action<T> a_oCallback)
		{
			// 순회가 불가능 할 경우
			if(a_oNode == null)
			{
				return;
			}

			this.Enumerate_ByPostOrder(a_oNode.Node_LChild, a_oCallback);
			this.Enumerate_ByPostOrder(a_oNode.Node_RChild, a_oCallback);

			a_oCallback?.Invoke(a_oNode.Val);
		}

		/** 레벨 순회한다 */
		private void Enumerate_ByLevelOrder(CNode a_oNode, Action<T> a_oCallback)
		{
			var oQueueNodes = new Queue<CNode>();
			oQueueNodes.Enqueue(a_oNode);

			while(oQueueNodes.Count > 0)
			{
				var oNode = oQueueNodes.Dequeue();
				a_oCallback?.Invoke(oNode.Val);

				// 왼쪽 노드가 존재 할 경우
				if(oNode.Node_LChild != null)
				{
					oQueueNodes.Enqueue(oNode.Node_LChild);
				}

				// 오른쪽 노드가 존재 할 경우
				if(oNode.Node_RChild != null)
				{
					oQueueNodes.Enqueue(oNode.Node_RChild);
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
