//#define A_E01_EXAMPLE_07_01
#define A_E01_EXAMPLE_07_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 밸런스 이진 탐색 트리 (Balance Binary Search Tree) 란?
 * - 이진 탐색 트리의 일종으로 트리의 균형이 무너지는 것을 방지함으로서 O(logN) 의 탐색 성능을
 * 유지하는 이진 탐색 트리를 의미한다. (+ 즉, 데이터가 추가되거나 제거 될 때마다 트리의 균형을
 * 파악해 밸런스를 유지한다는 것을 알 수 있다.)
 * 
 * 밸런스 이진 탐색 트리는 특정 노드를 기준으로 하위 트리의 균형이 무너졌을 경우 회전을 통해
 * 균형을 회복하는 특징이 존재한다. (+ 즉, 회전은 노드의 순서를 변경하는 행위라는 것을 알 수 있다.)
 * 
 * 트리의 회전에는 왼쪽 방향 회전과 오른쪽 방향 회전이 존재하며 회전 후에도 이진 탐색 트리의 조건을
 * 만족하는 성질이 있다. (+ 즉, 특정 노드를 기준으로 작은 값은 왼쪽 서브 트리에 위치하고
 * 크거나 같은 값은 오른쪽 서브 트리에 위치한다는 것을 알 수 있다.)
 * 
 * 밸런스 이진 탐색 트리 종류
 * - AVL 트리 (Adelson Velsky Landis Tree)
 * - 레드 블랙 트리 (Red Black Tree)
 * 
 * AVL (Adelson Velsky Landis Tree) 트리란?
 * - 특정 노드를 기준으로 왼쪽 서브 트리와 오른쪽 서브 트리의 균형 인수 비교를 통해 트리의 균형을
 * 유지하는 이진 탐색 트리를 의미한다. (+ 즉, 왼쪽 서브 트리와 오른쪽 서브 트리의 균형 인수가
 * 2 이상 차이가 날 경우 회전을 통해 균형을 회복한다는 것을 알 수 있다.)
 * 
 * AVL 트리의 서브 트리는 노드의 순서에 따라 LL (Left Left), LR (Left Right), RR (Right Right), 
 * RL (Right Left) 상태 중 하나의 상태가 될 수 있으며 해당 상태가 되었을 경우 각 상태를 벗어나기
 * 위한 회전을 통해 트리의 균형을 유지하는 것이 AVL 트리의 핵심이다.
 * 
 * AVL 트리 LL 상태 회복 방법
 * - 트리를 오른쪽 방향으로 회전함으로서 균형을 회복한다.
 * 
 * AVL 트리 LR 상태 회복 방법
 * - 왼쪽 하위 트리를 RR 상태로 간주하고 왼쪽 방향으로 회전
 * - 회전이 완료되면 LL 상태가 되기 때문에 LL 상태를 회복하는 절차를 수행한다.
 * 
 * AVL 트리 RR 상태 회복 방법
 * - 트리를 왼쪽 방향으로 회전함으로서 균형을 회복한다.
 * 
 * AVL 트리 RL 상태 회복 방법
 * - 오른쪽 하위 트리를 LL 상태로 간주하고 오른쪽 방향으로 회전
 * - 회전이 완료되며 RR 상태가 되기 때문에 RR 상태를 회복하는 절차를 수행한다.
 * 
 * 레드 블랙 트리 (Red Black Tree) 란?
 * - 트리에 존재하는 노드에 빨간색 or 검은색 색상을 부여 후 특정 규칙에 맞춰 노드의 순서를
 * 변경함으로서 트리의 균형을 유지하는 이진 탐색 트리를 의미한다.
 * 
 * 레드 블랙 트리 규칙
 * - 루트 노드는 검은색이다.
 * - 리프 노드는 모두 검은색이다.
 * - 트리에 존재하는 노드는 모두 빨간색 or 검은색이다.
 * 
 * - 빨간색 노드의 자식은 모두 검은색이다. (+ 즉, 빨간색 노드가 연속으로 존재 할 수 없다는 것을
 * 의미한다.)
 * 
 * - 임의의 노드에서 리프 노드까지 존재하는 검은색 노드 개수는 모두 동일하다. (+ 단,
 * 임의의 노드 자신은 카운팅에서 제외)
 * 
 * 위와 같이 레드 블랙 트리는 여러가지 규칙이 존재하며 해당 규칙이 위반되었을 경우 규칙에 맞춰 
 * 노드의 순서를 변경함으로서 트리의 균형이 회복되는 특징이 존재한다.
 * 
 * 레드 블랙 트리에 데이터 추가 규칙
 * - 새로 추가되는 데이터는 빨간색 노드이다. (+ 즉, 빨간색 노드를 추가함으로서 주의 해야 될 규칙을
 * 4 번 규칙만으로 단순화 시키는 것이 가능하다.)
 * 
 * - 새로 추가 된 노드의 부모 노드가 검은색 일 경우 레드 블랙 트리의 모든 규칙을 만족한다. (+ 즉,
 * 부모 노드가 검은색 일 경우 별도의 처리 과정이 필요없다는 것을 의미한다.)
 * 
 * 새로 추가 된 노드의 부모가 빨간색 일 경우
 * - 부모의 형제 (삼촌) 노드의 색상을 확인 후 3 가지 경우에 따라 처리한다.
 * 
 * 1. 삼촌 노드가 빨간색 일 경우
 * - 부모 노드와 삼촌 노드를 모두 검은색으로 변경
 * 
 * - 부모의 부모 (할아버지) 노드를 빨간색으로 변경 후 해당 문제를 할아버지 노드에게 넘긴다. (+ 즉,
 * 할아버지 노드를 기준으로 레드 블랙 트리의 규칙을 검사하면 된다는 것을 알 수 있다.)
 * 
 * 2. 삼촌 노드가 검은색이고 새로 추가 된 노드가 부모의 오른쪽 자식 일 경우
 * - 부모 노드를 기준으로 왼쪽 방향으로 회전한다.
 * 
 * - 부모 노드를 새롭게 추가 된 노드로 인식해서 문제 해결을 다시 시도한다. (+ 즉, 3 번 경우로
 * 일치시켜서 문제 해결을 단순화시킨다는 것을 알 수 있다.)
 * 
 * 3. 삼촌 노드가 검은색이고 새로 추가 된 노드가 부모의 왼쪽 자식 일 경우
 * - 부모 노드를 검은색으로 변경
 * - 할아버지 노드를 빨간색으로 변경
 * 
 * - 할아버지 노드를 기준으로 오른쪽 방향으로 회전한다. (+ 즉, 회전이 완료되고 나면
 * 레드 블랙 트리의 규칙을 모두 만족한다는 것을 알 수 있다.)
 * 
 * 레드 블랙 트리의 데이터 제거 규칙
 * - 제거 된 노드가 빨간색 일 경우 레드 블랙 트리의 모든 규칙을 만족한다. (+ 즉, 별도의 처리 과정이
 * 필요없다는 것을 의미한다.)
 * 
 * 제거 된 노드가 검은색 일 경우
 * - 후손 노드의 색상을 확인 후 2 가지 경우에 따라 처리한다.
 * 
 * 1. 후손 노드가 빨간색 일 경우
 * - 후손 노드의 색상을 검은색으로 변경 (+ 즉, 색상을 변경하고 나면 레드 블랙 트리의 규칙을 모두
 * 만족한다는 것을 알 수 있다.)
 * 
 * 2. 후손 노드가 검은색 일 경우
 * - 후손 노드가 검은색 일 경우 형제 노드의 색상을 확인 후 다시 4 가지 경우에 따라 처리한다.
 * 
 * 2 - 1. 형제 노드가 빨간색 일 경우
 * - 부모 노드의 색상을 빨간색으로 변경
 * - 형재 노드의 색상을 검은색으로 변경
 * 
 * - 부모 노드를 기준으로 왼쪽 방향으로 회전한다. (+ 즉, 형제 노드가 검은색 일 경우로 일치시켜서
 * 문제 해결을 단순화시킨다는 것을 알 수 있다.)
 * 
 * 2 - 2. 형제 노드가 검은색이고 형제 노드의 자식 노드가 모두 검은색 일 경우
 * - 형제 노드 색상을 빨간색으로 변경 후 해당 문제를 부모 노드에게 넘긴다. (+ 즉, 부모 노드를
 * 기준으로 레드 블랙 트리의 규칙을 검사하면 된다는 것을 알 수 있다.)
 * 
 * 2 - 3. 형제 노드가 검은색이고 형제 노드의 왼쪽 자식 노드가 빨간색 일 경우
 * - 형제 노드의 색상을 빨간색으로 변경
 * - 형제 노드의 왼쪽 자식 노드를 검은색으로 변경
 * 
 * - 형제 노드를 기준으로 오른쪽 방향으로 회전한다. (+ 즉, 형제 노드를 기준으로 회전시킴으로서
 * 2 - 4 번 경우로 일치시켜 문제 해결을 단순화시킨다는 것을 알 수 있다.)
 * 
 * 2 - 4. 형제 노드가 검은색이고 형제 노드의 오른쪽 자식 노드가 빨간색 일 경우
 * - 형제 노드의 색상을 부모 노드의 색상을 변경
 * - 부모 노드와 형제 노드의 오른쪽 자식 노드의 색상을 검은색으로 변경
 * 
 * - 부모 노드를 기준으로 왼쪽 방향으로 회전한다. (+ 즉, 회전이 완료되고 나면
 * 레드 블랙 트리의 규칙을 모두 만족한다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_07
{
	/**
	 * Example 7
	 */
	internal class CE01Example_07
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if A_E01_EXAMPLE_07_01
			var oRandom = new Random();
			var oTreeValues = new CE01Tree_AVL_07<int>();

			for(int i = 0; i < 10; ++i)
			{
				oTreeValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> AVL 트리 요소 <=====");

			oTreeValues.Enumerate(CE01Tree_AVL_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});

			oTreeValues.AddVal(100);
			Console.WriteLine("\n=====> AVL 트리 요소 - 추가 후 <=====");

			oTreeValues.Enumerate(CE01Tree_AVL_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});

			oTreeValues.RemoveVal(100);
			Console.WriteLine("\n=====> AVL 트리 요소 - 제거 후 <=====");

			oTreeValues.Enumerate(CE01Tree_AVL_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});
#elif A_E01_EXAMPLE_07_02
			var oRandom = new Random();
			var oTreeValues = new CE01Tree_RedBlack_07<int>();

			for(int i = 0; i < 10; ++i)
			{
				oTreeValues.AddVal(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 레드 블랙 트리 요소 <=====");

			oTreeValues.Enumerate(CE01Tree_RedBlack_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});

			oTreeValues.AddVal(100);
			Console.WriteLine("\n=====> 레드 블랙 트리 요소 - 추가 후 <=====");

			oTreeValues.Enumerate(CE01Tree_RedBlack_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});

			oTreeValues.RemoveVal(100);
			Console.WriteLine("\n=====> 레드 블랙 트리 요소 - 제거 후 <=====");

			oTreeValues.Enumerate(CE01Tree_RedBlack_07<int>.EOrder.IN, (a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});
#endif // #if A_E01_EXAMPLE_07_01
		}
	}
}
