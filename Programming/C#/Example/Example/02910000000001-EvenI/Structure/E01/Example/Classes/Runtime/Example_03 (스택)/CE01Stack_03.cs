using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_03
{
	/**
	 * 스택
	 */
	class CE01Stack_03<T> where T : IComparable
	{
		public int NumValues { get; private set; } = 0;
		public T[] Values { get; private set; } = null;

		/** 생성자 */
		public CE01Stack_03(int a_nSize = 5)
		{
			this.Values = new T[a_nSize];
		}

		/** 값을 추가한다 */
		public void Push(T a_tVal)
		{
			// 배열이 가득찼을 경우
			if(this.NumValues >= this.Values.Length)
			{
				var oValues = this.Values;
				Array.Resize(ref oValues, this.Values.Length * 2);

				this.Values = oValues;
			}

			this.Values[this.NumValues++] = a_tVal;
		}

		/** 값을 제거한다 */
		public T Pop()
		{
			this.NumValues -= 1;
			return this.Values[this.NumValues];
		}
	}
}
