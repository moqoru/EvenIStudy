using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_04
{
	/**
	 * 큐
	 */
	class CE01Queue_04<T> where T : IComparable
	{
		public int Rear { get; private set; } = 0;
		public int Front { get; private set; } = 0;
		public int NumValues { get; private set; } = 0;

		public T[] Values { get; private set; } = null;

		/** 생성자 */
		public CE01Queue_04(int a_nSize = 5)
		{
			this.Values = new T[a_nSize];
		}

		/** 값을 추가한다 */
		public void Enqueue(T a_tVal)
		{
			// 배열이 가득찼을 경우
			if(this.NumValues >= this.Values.Length)
			{
				int i = 0;
				var oValues = new T[this.Values.Length * 2];

				while(this.NumValues > 0)
				{
					oValues[i++] = this.Dequeue();
				}

				this.Rear = i;
				this.Front = 0;
				this.NumValues = i;

				this.Values = oValues;
			}

			this.Values[this.Rear] = a_tVal;

			this.Rear = (this.Rear + 1) % this.Values.Length;
			this.NumValues += 1;
		}

		/** 값을 제거한다 */
		public T Dequeue()
		{
			int nFront = this.Front;

			this.Front = (this.Front + 1) % this.Values.Length;
			this.NumValues -= 1;

			return this.Values[nFront];
		}
	}
}
