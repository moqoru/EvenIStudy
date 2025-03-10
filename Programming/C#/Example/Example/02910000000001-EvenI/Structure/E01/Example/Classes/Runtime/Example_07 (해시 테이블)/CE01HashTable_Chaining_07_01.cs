using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_02;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * 해시 테이블 - 체인법
	 */
	class CE01HashTable_Chaining_07_01<T> where T : IComparable
	{
		public CE01List_DLinked_02_02<T>[] ContainerLists { get; private set; } = null;

		/** 생성자 */
		public CE01HashTable_Chaining_07_01(int a_nSize = 5)
		{
			this.ContainerLists = new CE01List_DLinked_02_02<T>[a_nSize];

			for(int i = 0; i < a_nSize; ++i)
			{
				this.ContainerLists[i] = new CE01List_DLinked_02_02<T>();
			}
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			int nKey = this.MakeKey(a_tVal);
			this.ContainerLists[nKey].AddVal(a_tVal);
		}

		/** 값을 제거한다 */
		public void RemoveVal(T a_tVal)
		{
			int nKey = this.MakeKey(a_tVal);
			this.ContainerLists[nKey].RemoveVal(a_tVal);
		}

		/** 값을 순회한다 */
		public void Enumerate(Action<int, T> a_oCallback)
		{
			for(int i = 0; i < this.ContainerLists.Length; ++i)
			{
				for(int j = 0; j < this.ContainerLists[i].NumValues; ++j)
				{
					a_oCallback?.Invoke(i, this.ContainerLists[i][j]);
				}
			}
		}

		/** 식별자를 생성한다 */
		private int MakeKey(T a_tVal)
		{
			int nKey = a_tVal.GetHashCode();
			return nKey % this.ContainerLists.Length;
		}
	}
}
