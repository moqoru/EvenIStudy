using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 우선 순위 큐 (Priority Queue) 란?
 * - 일반적인 큐와 달리 데이터의 대소 여부에 따라 입/출력 순서가 결정되는 자료구조를 의미한다. 
 * (+ 즉, 데이터의 입력 순서와 출력 순서가 달라질 수 있다는 것을 알 수 있다.)
 * 
 * 우선 순위 큐는 내부적으로 힙을 통해 구현되며 데이터의 정렬 순서에 따라 최소 힙과 최대 힙으로
 * 구분된다.
 * 
 * 힙 (Heap) 이란?
 * - 이진 트리 중 하나로서 완전 이진 트리 구조를 지니고 있으며 데이터의 출력 순서에 따라 루트로부터
 * 멀어진다는 특징이 존재한다. (+ 즉, 출력 순서에 가까울수록 루트 근처에 있다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_06
{
	/**
	 * Example 6
	 */
	internal class CE01Example_06
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oRandom = new Random();
			var oPQueueValues = new CE01Queue_Priority_06<int>();

			Console.WriteLine("=====> 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				int nVal = oRandom.Next(1, 100);
				oPQueueValues.Enqueue(nVal);

				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine("\n\n=====> 우선 순위 큐 <=====");

			while(oPQueueValues.NumValues > 0)
			{
				Console.Write("{0}, ", oPQueueValues.Dequeue());
			}

			Console.WriteLine();
		}
	}
}
