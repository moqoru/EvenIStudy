using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 스택 (Stack) 이란?
 * - LIFO (Last In First Out) or FILO (First In Last Out) 구조로 동작하는 자료구조를 의미한다.
 * (+ 즉, 스택은 데이터의 입력 순서와 출력 순서가 반대라는 것을 알 수 있다.)
 * 
 * 스택은 데이터의 입/출력 순서가 엄격하게 관리되기 때문에 특정 위치에 존재하는 데이터에 접근하기
 * 위해서는 반드시 이전 데이터를 제거해야되는 특징이 존재한다. (+ 즉, 스택은 임의 접근이 불가능하며
 * 특정 위치에 존재하는 데이터에 접근하기 위한 선형 접근도 허용되지 않는다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_03
{
	/**
	 * Example 3
	 */
	internal class CE01Example_03
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			var oStackValues = new CE01Stack_03<int>();
			Console.WriteLine("=====> 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				oStackValues.Push(i + 1);
				Console.Write("{0}, ", i + 1);
			}

			Console.WriteLine("\n\n=====> 스택 <=====");

			while(oStackValues.NumValues > 0)
			{
				Console.Write("{0}, ", oStackValues.Pop());
			}

			Console.WriteLine();
		}
	}
}
