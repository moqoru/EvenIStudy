using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_03;

/*
 * 후위 표기법 (Postfix Expression) 이란?
 * - 연산자를 피연산자 중간에 명시하는 중위 표기법 (Infix Expression) 과 달리 오른쪽에 명시하는
 * 표기법을 의미한다. (+ Ex. 32+ 5* 2/)
 * 
 * 컴퓨터는 수식을 계산하는 과정에서 계산 중인 값을 보관하기 위해 스택 구조를 활용하며 이때
 * 중위 표기법은 계산하는 과정이 복잡해지는 단점이 존재한다. (+ 즉, 연산자 우선 순위에 의해
 * 계산 과정이 복잡해진다는 것을 알 수 있다.)
 * 
 * 따라서 컴퓨터는 계산 과정을 단순화 시키기 위해 중위 표기법을 후위 표기법으로 변환 후 수식 계산을
 * 수행한다. (+ 즉, 후위 표기법은 컴퓨터에게 익숙한 표기법이라는 것을 알 수 있다.)
 * 
 * 중위 표기법 (Infix Expression) -> 후위 표기법 (Postfix Expression) 변환 방법
 * - 수식에 피연산자가 존재 할 경우 피연산자를 표기법에 추가
 * 
 * - 연산자 일 경우 해당 연산자를 스택에 추가 (+ 단, 기존 스택에 우선 순위가 높은 연산자가
 * 존재 할 경우 해당 연산자를 꺼내 표기법에 추가)
 * 
 * - ( 연산자는 스택에 추가되는 과정 일 때는 가장 높은 우선 순위 (+ 즉, ( 연산자는 기존 연산자를
 * 스택에서 꺼내는 과정 없이 바로 추가 된다는 것을 의미한다.)
 * 
 * - ) 연산자 일 경우 스택에 존재하는 모든 연산자를 꺼내서 표기법에 추가 (+ 단, ( 연산자는
 * 표기법에 추가하지 않는다.)
 * 
 * - ( 연산자를 스택에서 꺼냈을 경우 스택에서 연산자를 꺼내는 과정 종료
 * 
 * 후위 표기법으로 명시 된 수식 계산하는 방법
 * - 수식에 피연산자가 존재 할 경우 피연산자를 스택에 추가
 * 
 * - 연산자 일 경우 스택에서 피연산자를 2 개 꺼내서 연산 후 해당 결과를 다시 스택에 추가 (+ 즉,
 * 스택은 LIFO 이기 때문에 먼저 꺼낸 피연산자가 우항이라는 것을 알 수 있다.)
 * 
 * - 위의 과정을 반복하면 스택에는 수식에 대한 최종 연산 결과만 담겨 있다. (+ 즉, 결과 값을
 * 스택에서 꺼낸 후 해당 스택이 비어있다면 수식 계산이 완료되었다는 것을 의미한다.)
 */
// namespace Example._02910000000001_EvenI.Algorithm.E01.Example.Classes.Runtime.Example_06
namespace Example._02910000000001_EvenI.Algorithm.E01.Practice.Classes.Runtime.Example_06
{
	/**
	 * Example 6
	 */
	internal class CE01Example_06
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			Console.Write("수식 입력 : ");
			string oExpression = Console.ReadLine();

			Console.WriteLine("결과 : {0}", E01GetResult_Expression_06(oExpression));
		}

		/** 우선 순위를 반환한다 */
		private static int E01GetPriority_06(string a_oOperator, bool a_bIsPush)
		{
			switch(a_oOperator[0])
			{
				case '+':
				case '-':
					return 2;

				case '*':
				case '/':
					return 1;
			}

			return (a_bIsPush && a_oOperator[0] == '(') ? 0 : 3;
		}

		/** 토큰을 반환한다 */
		private static string E01GetToken_06(string a_oExpression, int a_nStart)
		{
			var oStrBuilder = new StringBuilder();
			string oDigits = "0123456789.";

			for(int i = a_nStart; i < a_oExpression.Length; ++i)
			{
				oStrBuilder.Append(a_oExpression[i]);

				bool bIsNumber = i + 1 < a_oExpression.Length;
				bIsNumber = bIsNumber && oDigits.Contains(a_oExpression[i]);
				bIsNumber = bIsNumber && oDigits.Contains(a_oExpression[i + 1]);

				// 숫자가 아닐 경우
				if(!bIsNumber)
				{
					break;
				}
			}

			return oStrBuilder.ToString();
		}

		/** 수식 결과를 반환한다 */
		private static decimal E01GetResult_Expression_06(string a_oExpression)
		{
			int nIdx = 0;
			string oPostfix = E01InfixToPostfix_06(a_oExpression);

			CNode oNode = E01ExpressionTree_Stack(oPostfix);
			Eumerate_ByLevelOrder(oNode);

			string oOperators = "+-*/";

			var oStackOperands = new CE01Stack_03<decimal>();

			while(nIdx < oPostfix.Length)
			{
				string oToken = E01GetToken_06(oPostfix, nIdx);
				nIdx += oToken.Length;

				// 공백 일 경우
				if(char.IsWhiteSpace(oToken[0]))
				{
					continue;
				}

				// 연산자 일 경우
				if(oOperators.Contains(oToken[0]))
				{
					decimal dmRhs = oStackOperands.Pop();
					decimal dmLhs = oStackOperands.Pop();

					switch(oToken[0])
					{
						case '+':
							oStackOperands.Push(dmLhs + dmRhs);
							break;

						case '-':
							oStackOperands.Push(dmLhs - dmRhs);
							break;

						case '*':
							oStackOperands.Push(dmLhs * dmRhs);
							break;

						case '/':
							oStackOperands.Push(dmLhs / dmRhs);
							break;
					}
				}
				else
				{
					decimal.TryParse(oToken, out decimal dmOperand);
					oStackOperands.Push(dmOperand);
				}
			}

			return oStackOperands.Pop();
		}

		/** 중위 표기법 -> 후위 표기법으로 변환한다 */
		private static string E01InfixToPostfix_06(string a_oExpression)
		{
			int nIdx = 0;
			string oOperators = "+-*/()";

			var oStrBuilder = new StringBuilder();
			var oStackOperators = new CE01Stack_03<string>();

			while(nIdx < a_oExpression.Length)
			{
				string oToken = E01GetToken_06(a_oExpression, nIdx);
				nIdx += oToken.Length;

				// 공백 일 경우
				if(char.IsWhiteSpace(oToken[0]))
				{
					continue;
				}

				// 연산자가 아닐 경우
				if(!oOperators.Contains(oToken[0]))
				{
					oStrBuilder.Append($"{oToken} ");
					continue;
				}

				// ) 기호 일 경우
				if(oToken[0] == ')')
				{
					while(oStackOperators.NumValues > 0)
					{
						string oOperator = oStackOperators.Pop();

						// ( 기호 일 경우
						if(oOperator[0] == '(')
						{
							break;
						}

						oStrBuilder.Append(oOperator);
					}

					continue;
				}

				int nPriority_Token = E01GetPriority_06(oToken, true);

				while(oStackOperators.NumValues > 0)
				{
					string oOperator = oStackOperators.Pop();
					int nPriority_Operator = E01GetPriority_06(oOperator, false);

					// 우선 순위가 낮을 경우
					if(nPriority_Token < nPriority_Operator)
					{
						oStackOperators.Push(oOperator);
						break;
					}

					oStrBuilder.Append(oOperator);
				}

				oStackOperators.Push(oToken);
			}

			while(oStackOperators.NumValues > 0)
			{
				oStrBuilder.Append(oStackOperators.Pop());
			}

			return oStrBuilder.ToString();
		}

		public class CNode
		{
			public string Val { get; set; }
			public CNode Node_LChild { get; set; } = null;
			public CNode Node_RChild { get; set; } = null;
		}

		public static CNode Node_Root { get; private set; } = null;

		public static CNode E01ExpressionTree_Stack(string a_oExpression)
		{
			int nIdx = 0;
			string oOperators = "+-*/";
			var oTreeStack = new Stack<CNode>();

			while(nIdx < a_oExpression.Length)
			{
				string oToken = E01GetToken_06(a_oExpression, nIdx);
				nIdx += oToken.Length;

				if(char.IsWhiteSpace(oToken[0]))
				{
					continue;
				}
				var oNode = CreateNode(oToken);

				// 연산자 일 경우
				if(oOperators.Contains(oToken[0]))
				{
					oNode.Node_RChild = oTreeStack.Pop();
					oNode.Node_LChild = oTreeStack.Pop();
					oTreeStack.Push(oNode);
				}
				else
				{
					oTreeStack.Push(oNode);
				}
			}
			Node_Root = oTreeStack.Pop();
			return Node_Root;
		}
		public static void Eumerate_ByLevelOrder(CNode a_oNode)
		{
			Console.WriteLine("만들어진 노드 레벨 순회");
			var oQueueNodes = new Queue<CNode>();
			oQueueNodes.Enqueue(a_oNode);
			while(oQueueNodes.Count > 0)
			{
				var oNode = oQueueNodes.Dequeue();
				Console.Write("값 : {0}", oNode.Val);
				// 왼쪽 노드가 존재 할 경우
				if(oNode.Node_LChild != null)
				{
					oQueueNodes.Enqueue(oNode.Node_LChild);
					Console.Write(" | 왼쪽 자식 노드 값 : {0}", oNode.Node_LChild.Val);
				}

				// 오른쪽 노드가 존재 할 경우
				if(oNode.Node_RChild != null)
				{
					oQueueNodes.Enqueue(oNode.Node_RChild);
					Console.Write(" | 오른쪽 자식 노드 값 : {0}", oNode.Node_RChild.Val);
				}
				Console.WriteLine();
			}
		}
		/** 노드를 생성한다 */
		private static CNode CreateNode(string a_tVal)
		{
			return new CNode()
			{
				Val = a_tVal
			};
		}
	}
}
