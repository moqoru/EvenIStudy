//#define P_E01_EXAMPLE_04_01
#define P_E01_EXAMPLE_04_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 조건문이란?
 * - 특정 조건에 따라 프로그램의 흐름을 분산 시키는 기능을 의미한다. (+ 즉, 조건문을 활용하면 
 * 다양한 결과를 만들어내는 프로그램을 제작하는 것이 가능하다.)
 * 
 * C# 조건문 종류
 * - if ~ else
 * - switch ~ case
 * 
 * Ex)
 * if(조건식 A)
 * {
 *      // 조건식 A 를 만족 할 경우 실행 할 명령문
 * }
 * else if(조건식 B)
 * {
 *      // 조건식 B 를 만족 할 경우 실행 할 명령문
 * }
 * else
 * {
 *      // 조건식 A 와 B 를 모두 만족하지 않았을 경우 실행 할 명령문
 * }
 * 
 * switch(조건 값)
 * {
 *     case 조건 A:
 *          // 조건 A 를 만족 할 경우 실행 할 명령문
 *          
 *     case 조건 B:
 *          // 조건 B 를 만족 할 경우 실행 할 명령문
 *          
 *     default:
 *          // 조건 A 와 조건 B 를 모두 만족하지 않았을 경우 실행 할 명령문
 * }
 * 
 * if ~ else 조건문 vs switch ~ case 조건문
 * - if ~ else 조건문은 동등 비교를 비롯한 복잡한 조건문을 작성하는 것이 가능하지만 
 * switch ~ case 조건문은 동등 비교만 처리하는 것이 가능하다. (+ 즉, if ~ else 조건문은 범용적인
 * 조건문이라는 것을 알 수 있다.)
 * 
 * 단, switch ~ case 조건문은 간단한 비교 처리만 가능하지만 이로 인해 컴파일러에 의해서 
 * 좀 더 빠르게 최적화 될 여지가 있다. (+ 즉, 두 조건문은 어떤 것을 사용해도 상관 없는 상황이라면
 * switch ~ case 조건문을 사용하는 것이 좀 더 성능 향상에 이점이 있다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_04
{
	/**
	 * Example 4
	 */
	internal class CE01Example_04
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_04_01
			int nScore = 0;

			Console.Write("점수 입력 : ");
			int.TryParse(Console.ReadLine(), out nScore);

			// F 학점 일 경우
			if(nScore < 60)
			{
				Console.WriteLine("F 학점입니다.");
			}
			else
			{
				// A 학점 일 경우
				if(nScore >= 90)
				{
					Console.WriteLine("A 학점입니다.");
				}
				// B 학점 일 경우
				else if(nScore >= 80)
				{
					Console.WriteLine("B 학점입니다.");
				}
				// C 학점 일 경우
				else if(nScore >= 70)
				{
					Console.WriteLine("C 학점입니다.");
				}
				// D 학점 일 경우
				else
				{
					Console.WriteLine("D 학점입니다.");
				}
			}
#elif P_E01_EXAMPLE_04_02
			int nScore = 0;

			Console.Write("점수 입력 : ");
			int.TryParse(Console.ReadLine(), out nScore);

			switch(nScore / 10)
			{
				case 9:
				case 10:
					Console.WriteLine("A 학점입니다.");
					break;

				case 8:
					Console.WriteLine("B 학점입니다.");
					break;

				case 7:
					Console.WriteLine("C 학점입니다.");
					break;

				case 6:
					Console.WriteLine("D 학점입니다.");
					break;

				default:
					Console.WriteLine("F 학점입니다.");
					break;
			}
#endif // #if P_E01_EXAMPLE_04_01
		}
	}
}
