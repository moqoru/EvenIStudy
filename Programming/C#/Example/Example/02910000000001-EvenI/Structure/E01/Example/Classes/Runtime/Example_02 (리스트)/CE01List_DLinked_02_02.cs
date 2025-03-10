using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * 연결 리스트
	 */
	class CE01List_DLinked_02_02<T> where T : IComparable
	{
		/**
		 * 노드
		 */
		public class CNode
		{
			public T Val { get; set; }

			public CNode Node_Prev { get; set; } = null;
			public CNode Node_Next { get; set; } = null;
		}

		public int NumValues { get; private set; } = 0;
		public CNode Node_Head { get; private set; } = null;

		/** 인덱서 */
		public T this[int a_nIdx]
		{
			get
			{
				return this.FindNode_At(a_nIdx).Val;
			}
			set
			{
				var oNode = this.FindNode_At(a_nIdx);
				oNode.Val = value;
			}
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			var oNode = this.CreateNode(a_tVal);

			// 헤드 노드가 없을 경우
			if(this.Node_Head == null)
			{
				this.Node_Head = oNode;
			}
			else
			{
				var oNode_Tail = this.Node_Head;

				while(oNode_Tail.Node_Next != null)
				{
					oNode_Tail = oNode_Tail.Node_Next;
				}

				oNode_Tail.Node_Next = oNode;
				oNode.Node_Prev = oNode_Tail;
			}

			this.NumValues += 1;
		}

		/** 값을 추가한다 */
		public void InsertVal(int a_nIdx, T a_tVal)
		{
			var oNode_Next = this.FindNode_At(a_nIdx);

			// 값 추가가 불가능 할 경우
			if(oNode_Next == null)
			{
				return;
			}

			var oNode = this.CreateNode(a_tVal);
			var oNode_Prev = oNode_Next.Node_Prev;

			oNode.Node_Prev = oNode_Prev;
			oNode.Node_Next = oNode_Next;

			oNode_Next.Node_Prev = oNode;

			// 이전 노드가 존재 할 경우
			if(oNode_Prev != null)
			{
				oNode_Prev.Node_Next = oNode;
			}

			// 헤드 노드 일 경우
			if(this.Node_Head == oNode_Next)
			{
				this.Node_Head = oNode;
			}

			this.NumValues += 1;
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			var oNode_Remove = this.FindNode(a_tVal);
			this.RemoveNode(oNode_Remove);
		}

		/** 값을 제거한다 */
		public void RemoveVal_At(int a_nIdx)
		{
			var oNode_Remove = this.FindNode_At(a_nIdx);
			this.RemoveNode(oNode_Remove);
		}

		/** 노드를 제거한다 */
		private void RemoveNode(CNode a_oNode_Remove)
		{
			// 노드 제거가 불가능 할 경우
			if(a_oNode_Remove == null)
			{
				return;
			}

			var oNode_Prev = a_oNode_Remove.Node_Prev;
			var oNode_Next = a_oNode_Remove.Node_Next;

			// 이전 노드가 존재 할 경우
			if(oNode_Prev != null)
			{
				oNode_Prev.Node_Next = oNode_Next;
			}

			// 다음 노드가 존재 할 경우
			if(oNode_Next != null)
			{
				oNode_Next.Node_Prev = oNode_Prev;
			}

			// 헤드 노드 일 경우
			if(a_oNode_Remove == this.Node_Head)
			{
				this.Node_Head = oNode_Next;
			}

			this.NumValues -= 1;
		}

		/** 노드를 탐색한다 */
		private CNode FindNode(T a_tVal)
		{
			var oNode = this.Node_Head;

			while(oNode != null && oNode.Val.CompareTo(a_tVal) != 0)
			{
				oNode = oNode.Node_Next;
			}

			return oNode;
		}

		/** 노드를 탐색한다 */
		private CNode FindNode_At(int a_nIdx)
		{
			var oNode = this.Node_Head;

			for(int i = 0; i < a_nIdx; ++i)
			{
				oNode = oNode.Node_Next;
			}

			return oNode;
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
