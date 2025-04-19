//#define P_E01_EXAMPLE_05_01
//#define P_E01_EXAMPLE_05_02
#define P_E01_EXAMPLE_05_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 반복문이란?
 * - 특정 조건을 만족 할 동안 명령문의 일부 or 전체를 반복해서 실행하는 기능을 의미한다. (+ 즉, 
 * 반복문은 프로그램의 흐름을 제어해서 같은 동작을 지속적으로 실행한다는 것을 알 수 있다.)
 * 
 * 반복문은 프로그램의 흐름을 특정 부분에 잡아두는 역할을 하기 때문에 해당 기능을 이용하면 사용자가 
 * 원할 때 종료되는 프로그램을 제작하는 것이 가능하다. (+ 즉, 반영구적으로 동작하는 프로그램을 
 * 제작 할 수 있다.)
 * 
 * C# 반복문 종류
 * - while
 * - for
 * - do ~ while
 * - foreach
 * 
 * Ex)
 * while(조건문)
 * {
 *      // 조건문을 만족 할 동안 실행 할 명령문
 * }
 * 
 * for(초기절; 조건절; 반복절)
 * {   
 *      // 조건절을 만족 할 동안 실행 할 명령문
 * }
 * 
 * do {
 *      // 조건문을 만족 할 동안 실행 할 명령문
 * } while(조건문)
 *
 * while, for 반복문 vs do ~ while 반복문
 * - 해당 반복문 모두 프로그램의 흐름을 반복하는 것이 가능하다.
 * 
 * while, for 반복문 반복 할 명령문을 실행하기 전에 조건을 먼저 검사하는 사전 판단 반복문이기 때문에 
 * 처음부터 조건이 거짓이라면 명령문이 한번도 실행되지 않는다.
 * 
 * 반면 do ~ while 반복문은 사후 판단 반복문이기 때문에 처음부터 조건이 거짓이라고 하더라도 반드시 
 * 한번은 실행된다는 것을 알 수 있다.
 * 
 * 점프문이란?
 * - 프로그램의 흐름을 특정 위치로 이동 시키는 기능을 의미한다. (+ 즉, 점프문을 활용하면 
 * 프로그램의 흐름을 제한적으로 제어하는 것이 가능하다.)
 * 
 * C# 점프문 종류
 * - break
 * - continue
 * - goto
 * - return
 * 
 * break 문이란?
 * - 프로그램의 흐름을 제어문 밖으로 이동 시키는 기능을 의미한다. (+ 즉, break 문은 
 * 반복문과 switch ~ case 조건문 내부에서만 사용하는 것이 가능하다.)
 * 
 * continue 문이란?
 * - 프로그램의 현재 흐름을 생략하고 다음 흐름으로 이동 시키는 기능을 의미한다.
 * 단, continue 문은 break 문과 달리 반복문 내부에서만 사용하는 것이 가능하다.
 * 
 * goto 문이란?
 * - 가장 강력한 점프문으로서 프로그램의 흐름을 제한없이 특정 위치로 이동 시키는 기능을 의미한다. 
 * (+ 즉, goto 문을 활용하면 프로그램의 흐름을 마음대로 제어하는 것이 가능하다.)
 * 
 * 따라서 goto 문을 남발 할 경우 프로그램의 흐름 복잡해질 수 있기 때문에 오늘날 프로그램을 제작하는 
 * 환경에서는 거의 사용되지 않는다.
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_05
{
	/**
	 * Example 5
	 */
	internal class CE01Example_05
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_05_01
			int nNum = 0;

			Console.Write("숫자 입력 : ");
			int.TryParse(Console.ReadLine(), out nNum);

			int i = 0;

			while(i < nNum)
			{
				int nVal = i + 1;

				// 짝수 일 경우
				if(nVal % 2 == 0)
				{
					++i;

					/*
                     * continue 키워드는 프로그램의 현재 흐름을 생략하고 다음 흐름으로 이동 시키는 
					 * 역할을 수행한다. 
                     * 
                     * 따라서 while 반복문 내부에 해당 키워드를 사용 할 경우 반복을 깨기 위한 
					 * 명령문이 생략되었는지 주의 할 필요가 있다. (+ 즉, continue 키워드에 의해서
                     * 반복을 깨기 위한 명령문을 생략 할 경우 의도치 않게 무한 루프를 만들 수 있기 
					 * 때문에 주의가 필요하다.)
                     */
					continue;
				}

				Console.Write("{0}, ", nVal);
				++i;
			}

			Console.WriteLine();
#elif P_E01_EXAMPLE_05_02
			int nNum = 0;

			Console.Write("숫자 입력 : ");
			int.TryParse(Console.ReadLine(), out nNum);

			for(int i = 0; i < nNum; ++i)
			{
				int nVal = i + 1;

				// 짝수 일 경우
				if(nVal % 2 == 0)
				{
					/*
                     * for 반복문 내부에서 continue 키워드는 while 반복문에 비해 좀 더 안전하게 
					 * 작성하는 것이 가능하다. (+ 즉, for 반복문에서 실행 명령문의 흐름을 
					 * 생략한다 하더라도 조건을 깨기 위한 반복절이 실행되기 때문에 
					 * while 문에 비해 의도치않게 무한 루프를 만들어내는 실수를 줄이는 것이 
					 * 가능하다.)
                     */
					continue;
				}

				Console.Write("{0}, ", nVal);
			}

			Console.WriteLine();
#elif P_E01_EXAMPLE_05_03
			do
			{
				Console.WriteLine("Hello, World!");
			} while(false);

			Console.WriteLine();
			int i = 0;

/*
 * goto 키워드를 사용하기 위해서는 목적지에 해당하는 위치 정보를 명시해줘야하며
 * 위치는 레이블을 통해 명시하는 것이 가능하다. (+ 즉, switch ~ case 조건문에서
 * case 도 레이블을 명시하는 방법 중 하나라는 것을 알 수 있다.)
 */
P_E01_EXAMPLE_05_03_LOOP_START:
			Console.WriteLine("{0}, ", i + 1);
			i += 1;

			// 반복이 가능 할 경우
			if(i < 10)
			{
				goto P_E01_EXAMPLE_05_03_LOOP_START;
			}
			else
			{
				goto P_E01_EXAMPLE_05_03_LOOP_END;
			}

P_E01_EXAMPLE_05_03_LOOP_END:
			Console.WriteLine();
#endif // #if P_E01_EXAMPLE_05_01
		}
	}
}
