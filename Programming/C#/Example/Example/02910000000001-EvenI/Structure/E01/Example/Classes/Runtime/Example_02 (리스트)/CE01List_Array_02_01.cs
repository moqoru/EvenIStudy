using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * 배열 리스트
	 */
	class CE01List_Array_02_01<T> where T : IComparable
	{
		public int NumValues { get; private set; } = 0;
		public T[] Values { get; private set; } = null;

		/** 생성자 */
		public CE01List_Array_02_01(int a_nSize = 5)
		{
			this.Values = new T[a_nSize];
		}

		/** 인덱서 */
		public T this[int a_nIdx]
		{
			get
			{
				return this.Values[a_nIdx];
			}
			set
			{
				this.Values[a_nIdx] = value;
			}
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
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

		/** 값을 추가한다 */
		public void InsertVal(int a_nIdx, T a_tVal)
		{
			// 배열이 가득찼을 경우
			if(this.NumValues >= this.Values.Length)
			{
				var oValues = this.Values;
				Array.Resize(ref oValues, this.Values.Length * 2);

				this.Values = oValues;
			}

			for(int i = this.NumValues; i > a_nIdx; --i)
			{
				this.Values[i] = this.Values[i - 1];
			}

			this.Values[a_nIdx] = a_tVal;
			this.NumValues += 1;
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			int nResult = this.FindVal(a_tVal);

			// 값 제거가 불가능 할 경우
			if(nResult < 0)
			{
				return;
			}

			this.RemoveVal_At(nResult);
		}

		/** 값을 제거한다 */
		public void RemoveVal_At(int a_nIdx)
		{
			// 값 제거가 불가능 할 경우
			if(a_nIdx < 0 || a_nIdx >= this.NumValues)
			{
				return;
			}

			for(int i = a_nIdx; i < this.NumValues - 1; ++i)
			{
				this.Values[i] = this.Values[i + 1];
			}

			this.NumValues -= 1;
		}

		/** 값을 탐색한다 */
		private int FindVal(T a_tVal)
		{
			for(int i = 0; i < this.NumValues; ++i)
			{
				// 값이 존재 할 경우
				if(a_tVal.CompareTo(this.Values[i]) == 0)
				{
					return i;
				}
			}

			return -1;
		}
	}
}
