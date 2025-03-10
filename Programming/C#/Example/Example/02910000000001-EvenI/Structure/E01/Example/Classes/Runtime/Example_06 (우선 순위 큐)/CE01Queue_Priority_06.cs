using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_06
{
	/**
	 * 우선 순위 큐
	 */
	class CE01Queue_Priority_06<T> where T : IComparable
	{
		public int NumValues { get; private set; } = 0;
		public T[] Values { get; private set; } = null;

		/** 생성자 */
		public CE01Queue_Priority_06(int a_nSize = 5)
		{
			this.Values = new T[a_nSize];
		}

		/** 값을 추가한다 */
		public void Enqueue(T a_tVal)
		{
			// 배열이 가득찼을 경우
			if(this.NumValues >= this.Values.Length)
			{
				var oValues = this.Values;
				Array.Resize(ref oValues, this.Values.Length * 2);

				this.Values = oValues;
			}

			this.Values[this.NumValues++] = a_tVal;
			int nIdx = this.NumValues - 1;

			while(nIdx > 0)
			{
				int nIdx_Parent = (nIdx - 1) / 2;

				// 정렬이 완료되었을 경우
				if(this.Values[nIdx_Parent].CompareTo(this.Values[nIdx]) < 0)
				{
					break;
				}

				T tTemp = this.Values[nIdx];
				this.Values[nIdx] = this.Values[nIdx_Parent];
				this.Values[nIdx_Parent] = tTemp;

				nIdx = nIdx_Parent;
			}
		}

		/** 값을 제거한다 */
		public T Dequeue()
		{
			T tVal = this.Values[0];
			this.Values[0] = this.Values[this.NumValues - 1];

			this.NumValues -= 1;
			int nIdx = 0;

			while(nIdx < this.NumValues / 2)
			{
				int nIdx_Compare = (nIdx * 2) + 1;

				// 오른쪽 노드가 존재 할 경우
				if(nIdx_Compare + 1 < this.NumValues)
				{
					int nIdx_RChild = nIdx_Compare + 1;

					nIdx_Compare = (this.Values[nIdx_Compare].CompareTo(this.Values[nIdx_RChild]) < 0) ?
						nIdx_Compare : nIdx_RChild;
				}

				// 정렬이 완료되었을 경우
				if(this.Values[nIdx].CompareTo(this.Values[nIdx_Compare]) < 0)
				{
					break;
				}

				T tTemp = this.Values[nIdx];
				this.Values[nIdx] = this.Values[nIdx_Compare];
				this.Values[nIdx_Compare] = tTemp;

				nIdx = nIdx_Compare;
			}

			return tVal;
		}
	}
}
