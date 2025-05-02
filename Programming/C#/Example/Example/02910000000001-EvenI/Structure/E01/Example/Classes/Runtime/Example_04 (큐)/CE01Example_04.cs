using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 큐 (Queue) 란?
 * - FIFO (First In First Out) or LILO (Last In Last Out) 구조로 동작하는 자료구조를 의미한다.
 * (+ 즉, 큐는 데이터의 입력 순서와 출력 순서가 동일하다는 것을 알 수 있다.)
 * 
 * 큐 또한 스택처럼 데이터의 입/출력 순서가 엄격하게 관리되기 때문에 특정 위치에 존재하는 데이터에
 * 접근하기 위해서는 반드시 이번 데이터를 제거해야된다는 특징이 존재한다.
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_04
{
	/**
	 * Example 4
	 */
	internal class CE01Example_04
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oQueueValues = new CE01Queue_04<int>();
			Console.WriteLine("=====> 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				oQueueValues.Enqueue(i + 1);
				Console.Write("{0}, ", i + 1);
			}

			Console.WriteLine("\n\n=====> 큐 <=====");

			while(oQueueValues.NumValues > 0)
			{
				Console.Write("{0}, ", oQueueValues.Dequeue());
			}

			Console.WriteLine();
		}
	}
}
