//#define P_E01_EXAMPLE_06_01
//#define P_E01_EXAMPLE_06_02
#define P_E01_EXAMPLE_06_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 컬렉션 (Collection) 이란?
 * - 여러 데이터를 관리 할 수 있는 기능을 의미한다. (+ 즉, 컬렉션을 활용하면 
 * 여러 데이터를 좀 더 효율적으로 제어하는 것이 가능하다.)
 * 
 * C# 은 크게 선형 컬렉션과 비선형 컬렉션을 지원한다.
 * 
 * 선형 컬렉션 vs 비선형 컬렉션
 * - 두 컬렉션 모두 여러 데이터를 관리하는 기능을 의미한다.
 * 
 * 선형 컬렉션은 내부적으로 1 차원의 형태로 데이터를 관리하기 때문에 비교적 구현 난이도가 쉽다는 
 * 장점이 존재한다. 
 * 
 * 반면 비선형 컬렉션은 선형 컬렉션에 비해 복잡한 형태로 데이터를 관리하지만 데이터의 개수가 
 * 많아질수록 선형 컬렉션에 비해 성능이 뛰어나다는 장점이 존재한다. (+ 즉, 적은 데이터를 
 * 관리 할 때는 선형 컬렉션과 비선형 컬렉션간에 성능 차이가 거의 없다는 것을 알 수 있다.)
 * 
 * C# 주요 선형 컬렉션 종류
 * - 배열 (Array)
 * - 리스트 (List)
 * - 스택 (Stack)
 * - 큐 (Queue)
 * 
 * 배열 (Array) 이란?
 * - 동일한 자료형의 데이터를 여러개 관리 할 수 있는 컬렉션을 의미한다.
 * 
 * 또한 배열은 데이터의 순서가 존재하기 때문에 관리 되고 있는 특정 데이터에 접근하기 위해서는 
 * [] (인덱스 연산자) 와 인덱스 번호를 조합하면 된다.
 * 
 * 인덱스 번호 범위
 * - 0 ~ 컬렉션 길이 - 1
 * 
 * C# 배열 선언 방법
 * - 자료형 + [] (배열 기호) + 배열 이름
 * 
 * Ex)
 * int[] oValuesA = new int[5];
 * float[] oValuesB = new float[5];
 * 
 * 리스트 (List) 란?
 * - 관리되는 데이터에 순서가 존재하는 컬렉션을 의미한다. (+ 즉, 리스트는 배열과 같이 데이터의 
 * 순서가 존재하기 때문에 특정 위치에 데이터를 가져오기 위해서는 [] (인덱스 연산자) 와 
 * 인덱스 번호가 사용 된다는 것을 알 수 있다.)
 * 
 * 단, 배열은 처음 생성되었때 명시된 길이를 초과하는 데이터는 관리 할 수 없는 반면 리스트는 길이 
 * 제한이 없기 때문에 원하는만큼 데이터를 추가하거나 제거하는 것이 가능하다.
 * 
 * C# 리스트 선언 방법
 * - List + 자료형 + 리스트 이름
 * 
 * Ex)
 * List<int> oListValuesA = new List<int>();
 * List<float> oListValuesB = new List<float>();
 * 
 * 리스트는 내부적인 구현 방식에 따라 배열 기반 리스트와 연결 기반 리스트로 구분된다.
 * 
 * 배열 기반 리스트 vs 연결 기반 리스트
 * - 배열 기반 리스트는 배열을 이용해서 데이터의 순서를 만들어내기 때문에 특정 데이터가 위치한 
 * 순서를 알고 있다면 [] (인덱스 연산자) 를 사용해서 한번에 접근하는 것이 가능하다. (+ 즉, 
 * 임의 접근이 가능하다는 것을 알 수 있다.)
 * 
 * 단, 배열은 크기가 미리 정해져 있기 때문에 새로운 데이터를 추가하기 위한 공간이 부족 할 경우 
 * 새로운 공간을 만들어서 기존 데이터를 이동시켜야하는 단점이 존재한다. 
 * 
 * 또한 관리하고 있는 데이터의 특정 위치에 새로운 데이터를 추가하거나 제거 할 경우 데이터의 이동이 
 * 발생한다. (+ 즉, 배열 리스트는 데이터의 삽입/제거가 빈번하게 발생 할 경우 프로그램의 성능이 
 * 저하된다는 것을 알 수 있다.)
 * 
 * 반면 연결 리스트는 참조에 의해서 데이터의 순서를 만들어내기 때문에 중간에 데이터가 추가되거나 
 * 제거 된다하더라도 데이터의 이동이 발생하지 않는다. (+ 즉, 데이터의 삽입/제거가 빈번하게 발생 할 
 * 경우 배열 리스트에 비해 효율적으로 동작한다는 것을 알 수 있다.)
 * 
 * 단, 연결 리스트는 임의 접근이 불가능하기 때문에 특정 데이터의 위치를 알고 있다 하더라도 항상 
 * 처음부터 차례대로 접근해야되는 단점이 존재한다. (+ 즉, 데이터의 탐색이 빈번 할 경우 연결 리스트는 
 * 프로그램의 성능이 저하된다는 것을 알 수 있다.)
 * 
 * 스택 (Stack) 이란?
 * - LIFO (Last In First Out) 순서로 데이터를 관리하는 컬렉션을 의미한다. (+ 즉, 스택이 관리하는 
 * 데이터는 입/출력에 순서가 엄격하게 제한된다는 것을 알 수 있다.)
 * 
 * 큐 (Queue) 란?
 * - FIFO (First In First Out) 순서로 데이터를 관리하는 컬렉션을 의미한다. (+ 즉, 큐 또한 스택처럼 
 * 데이터의 순서가 엄격하게 관리 된다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_06
{
	/**
	 * Example 6
	 */
	internal class CE01Example_06
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_06_01
			int[] oValuesA = new int[5];
			oValuesA[0] = 1;
			oValuesA[1] = 2;
			oValuesA[2] = 3;

			int[] oValuesB = new int[5]
			{
				1, 2, 3, 4, 5
			};

			int[] oValuesC = new int[]
			{
				1, 2, 3
			};

			int[,] oMatrixA = new int[3, 3];
			oMatrixA[0, 0] = 1;
			oMatrixA[0, 1] = 2;
			oMatrixA[0, 2] = 3;

			int[,] oMatrixB = new int[3, 3]
			{
				{ 1, 2, 3 },
				{ 4, 5, 6 },
				{ 7, 8, 9 }
			};

			int[,] oMatrixC = new int[,]
			{
				{ 1, 2 },
				{ 4, 5 },
				{ 7, 8 }
			};

			Console.WriteLine("=====> 1 차원 배열 - A <=====");

			for(int i = 0; i < oValuesA.Length; ++i)
			{
				Console.Write("{0}, ", oValuesA[i]);
			}

			Console.WriteLine("\n\n=====> 1 차원 배열 - B <=====");

			for(int i = 0; i < oValuesB.Length; ++i)
			{
				Console.Write("{0}, ", oValuesB[i]);
			}

			Console.WriteLine("\n\n=====> 1 차원 배열 C <=====");

			for(int i = 0; i < oValuesC.Length; ++i)
			{
				Console.Write("{0}, ", oValuesC[i]);
			}

			Console.WriteLine("\n\n=====> 2 차원 배열 - A <=====");

			for(int i = 0; i < oMatrixA.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixA.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixA[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 2 차원 배열 - B <=====");

			for(int i = 0; i < oMatrixB.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixB.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixB[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine("\n=====> 2 차원 배열 C <=====");

			for(int i = 0; i < oMatrixC.GetLength(0); ++i)
			{
				for(int j = 0; j < oMatrixC.GetLength(1); ++j)
				{
					Console.Write("{0}, ", oMatrixC[i, j]);
				}

				Console.WriteLine();
			}

			Console.WriteLine();
#elif P_E01_EXAMPLE_06_02
			List<int> oListValuesA = new List<int>();
			oListValuesA.Add(1);
			oListValuesA.Add(2);
			oListValuesA.Add(3);

			List<int> oListValuesB = new List<int>()
			{
				1, 2, 3, 4, 5
			};

			Console.WriteLine("=====> 리스트 - A <=====");

			for(int i = 0; i < oListValuesA.Count; ++i)
			{
				Console.Write("{0}, ", oListValuesA[i]);
			}

			Console.WriteLine("\n\n=====> 리스트 - B <=====");

			for(int i = 0; i < oListValuesB.Count; ++i)
			{
				Console.Write("{0}, ", oListValuesB[i]);
			}

			Console.WriteLine();
#elif P_E01_EXAMPLE_06_03
			Stack<int> oStackValues = new Stack<int>();
			Queue<int> oQueueValues = new Queue<int>();

			Console.WriteLine("=====> 데이터 입력 순서 <=====");

			for(int i = 0; i < 10; ++i)
			{
				oStackValues.Push(i + 1);
				oQueueValues.Enqueue(i + 1);

				Console.Write("{0}, ", i + 1);
			}

			Console.WriteLine("\n\n=====> 스택 <=====");

			/*
			 * 스택과 큐에 존재하는 데이터를 가져오고 나면 해당 데이터는 컬렉션으로부터 제거되는 
			 * 특징이 존재한다. (+ 즉, 일반적인 컬렉션을 데이터에 접근한다하더라도 해당 데이터는 
			 * 여전히 컬렉션에 존재하지만 스택과 큐는 다르다는 것을 알 수 있다.)
			 */
			while(oStackValues.Count >= 1)
			{
				Console.Write("{0}, ", oStackValues.Pop());
			}

			Console.WriteLine("\n\n=====> 큐 <=====");

			while(oQueueValues.Count >= 1)
			{
				Console.Write("{0}, ", oQueueValues.Dequeue());
			}

			Console.WriteLine();
#endif // #if P_E01_EXAMPLE_06_01
		}
	}
}
