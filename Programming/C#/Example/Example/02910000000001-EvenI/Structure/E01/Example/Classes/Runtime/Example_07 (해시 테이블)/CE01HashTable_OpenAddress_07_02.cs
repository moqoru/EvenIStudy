using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * 해시 테이블 - 개방 주소법
	 */
	class CE01HashTable_OpenAddress_07_02<T> where T : IComparable
	{
		/**
		 * 상태
		 */
		public enum EState
		{
			NONE = -1,
			USE,
			REMOVE,
			MAX_VAL
		}

		/**
		 * 슬롯
		 */
		public class CSlot : IComparable
		{
			public T m_tVal;
			public EState m_eState;

			/** 값을 비교한다 */
			public int CompareTo(object? a_oObj)
			{
				var oSlot = a_oObj as CSlot;

				// 값 비교가 불가능 할 경우
				if(oSlot == null)
				{
					return -1;
				}

				int nCompare_Val = m_tVal.CompareTo(oSlot.m_tVal);
				return (nCompare_Val == 0 && m_eState == oSlot.m_eState) ? 0 : -1;
			}
		}

		public int NumValues { get; private set; } = 0;
		public CSlot[] Slots { get; private set; } = null;

		/** 생성자 */
		public CE01HashTable_OpenAddress_07_02(int a_nSize = 5)
		{
			this.Slots = new CSlot[a_nSize];
		}

		/** 값을 추가한다 */
		public void AddVal(T a_tVal)
		{
			// 배열이 가득찼을 경우
			if(this.NumValues * 2 >= this.Slots.Length)
			{
				var oSlots = this.Slots;
				this.Slots = new CSlot[this.Slots.Length * 2];

				this.NumValues = 0;

				for(int i = 0; i < oSlots.Length; ++i)
				{
					// 값 추가가 불가능 할 경우
					if(oSlots[i] == null || oSlots[i].m_eState != EState.USE)
					{
						continue;
					}

					this.AddVal(oSlots[i].m_tVal);
				}
			}

			int nKey = this.MakeKey(a_tVal);

			for(int i = 0; i < this.Slots.Length; ++i)
			{
				int nIdx = (nKey + i) % this.Slots.Length;

				// 값 추가가 가능 할 경우
				if(this.Slots[nIdx] == null || this.Slots[nIdx].m_eState == EState.REMOVE)
				{
					this.Slots[nIdx] = new CSlot();
					this.Slots[nIdx].m_tVal = a_tVal;
					this.Slots[nIdx].m_eState = EState.USE;

					this.NumValues += 1;
					return;
				}
			}
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

			this.Slots[nResult].m_eState = EState.REMOVE;
			this.NumValues -= 1;
		}

		/** 값을 순회한다 */
		public void Enumerate(Action<int, T> a_oCallback)
		{
			for(int i = 0; i < this.Slots.Length; ++i)
			{
				// 순회가 불가능 할 경우
				if(this.Slots[i] == null || this.Slots[i].m_eState != EState.USE)
				{
					continue;
				}

				a_oCallback?.Invoke(i, this.Slots[i].m_tVal);
			}
		}

		/** 값을 탐색한다 */
		public int FindVal(T a_tVal)
		{
			int nKey = this.MakeKey(a_tVal);

			for(int i = 0; i < this.Slots.Length; ++i)
			{
				int nIdx = (nKey + i) % this.Slots.Length;

				// 탐색이 불가능 할 경우
				if(this.Slots[nIdx] == null)
				{
					return -1;
				}

				bool bIsValid = this.Slots[nIdx].m_eState == EState.USE;
				bIsValid = bIsValid && a_tVal.CompareTo(this.Slots[nIdx].m_tVal) == 0;

				// 값이 존재 할 경우
				if(bIsValid)
				{
					return nIdx;
				}
			}

			return -1;
		}

		/** 식별자를 생성한다 */
		private int MakeKey(T a_tVal)
		{
			int nKey = a_tVal.GetHashCode();
			return nKey % this.Slots.Length;
		}
	}
}
