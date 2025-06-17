//#define A_S01_SOLUTION_02_01
#define A_S01_SOLUTION_02_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Example._02910000000001_EvenI.Structure.E01.Example.Classes.Runtime.Example_03;

namespace Example._02910000000001_EvenI.Algorithm.E01.Solution.Classes.Runtime.Solution_02
{
	/**
	 * Solution 2
	 */
	internal class CS01Solution_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			Console.Write("수식 입력 : ");

			string oExpression = Console.ReadLine();
			string oPostfix = S01InfixToPostfix_02(oExpression);

#if A_S01_SOLUTION_02_01
			Console.WriteLine("결과 : {0}", S01GetResult_Expression_02_01(oExpression));

			var oTreeExpression = S01CreateTree_Expression_02_01(oPostfix);
			Console.WriteLine("\n=====> 수식 트리 <=====");

			oTreeExpression.Enumerate(CS01Tree_Binary_02<string>.EOrder.IN,
				(a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});
#elif A_S01_SOLUTION_02_02
			Console.WriteLine("결과 : {0}", S01GetResult_Expression_02_02(oExpression));

			var oTreeExpression = S01CreateTree_Expression_02_02(oPostfix);
			Console.WriteLine("\n=====> 수식 트리 <=====");

			oTreeExpression.Enumerate(CS01Tree_Binary_02<string>.EOrder.IN,
				(a_nDepth, a_nVal) =>
			{
				for(int i = 0; i < a_nDepth; ++i)
				{
					Console.Write("\t");
				}

				Console.WriteLine("[{0}]", a_nVal);
			});
#endif // #if A_S01_SOLUTION_02_01
		}

		/** 우선 순위를 반환한다 */
		private static int S01GetPriority_02(string a_oOperator, bool a_bIsPush)
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
		private static string S01GetToken_02(string a_oExpression, int a_nStart)
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
		private static decimal S01GetResult_ExpressionTree_02(CS01Tree_Binary_02<string>.CNode a_oNode_Root)
		{
			// 결과 반환이 불가능 할 경우
			if(a_oNode_Root == null)
			{
				return 0;
			}

			string oOperators = "+-*/";

			// 연산자 일 경우
			if(oOperators.Contains(a_oNode_Root.Val))
			{
				decimal dmLhs = S01GetResult_ExpressionTree_02(a_oNode_Root.Node_LChild);
				decimal dmRhs = S01GetResult_ExpressionTree_02(a_oNode_Root.Node_RChild);

				switch(a_oNode_Root.Val)
				{
					case "+":
						return dmLhs + dmRhs;

					case "-":
						return dmLhs - dmRhs;

					case "*":
						return dmLhs * dmRhs;

					case "/":
						return dmLhs / dmRhs;
				}
			}

			decimal.TryParse(a_oNode_Root.Val, out decimal dmVal);
			return dmVal;
		}

		/** 중위 표기법 -> 후위 표기법으로 변환한다 */
		private static string S01InfixToPostfix_02(string a_oExpression)
		{
			int nIdx = 0;
			string oOperators = "+-*/()";

			var oStrBuilder = new StringBuilder();
			var oStackOperators = new CE01Stack_03<string>();

			while(nIdx < a_oExpression.Length)
			{
				string oToken = S01GetToken_02(a_oExpression, nIdx);
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

				int nPriority_Token = S01GetPriority_02(oToken, true);

				while(oStackOperators.NumValues > 0)
				{
					string oOperator = oStackOperators.Pop();
					int nPriority_Operator = S01GetPriority_02(oOperator, false);

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

#if A_S01_SOLUTION_02_01
		/** 수식 결과를 반환한다 */
		private static decimal S01GetResult_Expression_02_01(string a_oExpression)
		{
			string oPostfix = S01InfixToPostfix_02(a_oExpression);
			var oTreeExpression = S01CreateTree_Expression_02_01(oPostfix);

			return S01GetResult_ExpressionTree_02(oTreeExpression.Node_Root);
		}

		/** 수식 트리를 생성한다 */
		private static CS01Tree_Binary_02<string> S01CreateTree_Expression_02_01(string a_oPostfix)
		{
			var oStackNodes = new CE01Stack_03<CS01Tree_Binary_02<string>.CNode>();
			var oTreeExpression = new CS01Tree_Binary_02<string>();

			int nIdx = 0;
			string oOperators = "+-*/";

			while(nIdx < a_oPostfix.Length)
			{
				var oToken = S01GetToken_02(a_oPostfix, nIdx);
				nIdx += oToken.Length;

				// 공백 일 경우
				if(char.IsWhiteSpace(oToken[0]))
				{
					continue;
				}

				var oNode_Token = CS01Tree_Binary_02<string>.CreateNode(oToken);

				// 연산자 일 경우
				if(oOperators.Contains(oToken))
				{
					var oNode_RChild = oStackNodes.Pop();
					var oNode_LChild = oStackNodes.Pop();

					CS01Tree_Binary_02<string>.AddNode_RChild(oNode_Token, oNode_RChild);
					CS01Tree_Binary_02<string>.AddNode_LChild(oNode_Token, oNode_LChild);
				}

				oStackNodes.Push(oNode_Token);
			}

			oTreeExpression.AddNode_Root(oStackNodes.Pop());
			return oTreeExpression;
		}
#elif A_S01_SOLUTION_02_02
		/** 토큰을 반환한다 */
		private static string S01GetToken_Prev_02_02(string a_oExpression, int a_nStart)
		{
			var oStrBuilder = new StringBuilder();
			string oDigits = "0123456789.";

			for(int i = a_nStart; i >= 0; --i)
			{
				oStrBuilder.Insert(0, a_oExpression[i]);

				bool bIsNumber = i - 1 >= 0;
				bIsNumber = bIsNumber && oDigits.Contains(a_oExpression[i]);
				bIsNumber = bIsNumber && oDigits.Contains(a_oExpression[i - 1]);

				// 숫자가 아닐 경우
				if(!bIsNumber)
				{
					break;
				}
			}

			return oStrBuilder.ToString();
		}

		/** 수식 결과를 반환한다 */
		private static decimal S01GetResult_Expression_02_02(string a_oExpression)
		{
			string oPostfix = S01InfixToPostfix_02(a_oExpression);
			var oTreeExpression = S01CreateTree_Expression_02_02(oPostfix);

			return S01GetResult_ExpressionTree_02(oTreeExpression.Node_Root);
		}

		/** 수식 트리를 생성한다 */
		private static CS01Tree_Binary_02<string> S01CreateTree_Expression_02_02(string a_oPostfix)
		{
			int nIdx_Start = a_oPostfix.Length - 1;

			var oNode_Root = S01CreateTree_Expression_Internal_02_02(a_oPostfix,
				ref nIdx_Start);

			var oTreeExpression = new CS01Tree_Binary_02<string>();
			oTreeExpression.AddNode_Root(oNode_Root);

			return oTreeExpression;
		}

		private static CS01Tree_Binary_02<string>.CNode S01CreateTree_Expression_Internal_02_02(string a_oPostfix,
			ref int a_rnOutIdx_Start)
		{
			string oToken = string.Empty;
			string oOperators = "+-*/";

			while(true)
			{
				oToken = S01GetToken_Prev_02_02(a_oPostfix, a_rnOutIdx_Start);
				a_rnOutIdx_Start -= oToken.Length;

				// 공백이 아닐 경우
				if(!char.IsWhiteSpace(oToken[0]))
				{
					break;
				}
			}

			var oNode = CS01Tree_Binary_02<string>.CreateNode(oToken);

			// 숫자 일 경우
			if(!oOperators.Contains(oToken))
			{
				return oNode;
			}

			var oNode_RChild = S01CreateTree_Expression_Internal_02_02(a_oPostfix,
				ref a_rnOutIdx_Start);

			var oNode_LChild = S01CreateTree_Expression_Internal_02_02(a_oPostfix,
				ref a_rnOutIdx_Start);

			CS01Tree_Binary_02<string>.AddNode_LChild(oNode, oNode_LChild);
			CS01Tree_Binary_02<string>.AddNode_RChild(oNode, oNode_RChild);

			return oNode;
		}
#endif // #if A_S01_SOLUTION_02_01
	}
}
