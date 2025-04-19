using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 연산자란?
 * - 데이터를 제어하기 위한 특별한 의미를 지니는 기호 (심볼) 을 의미한다. (+ 즉, 연산자를 활용하면 
 * 데이터를 프로그램의 목적에 맞게 제어하는 것이 가능하다.)
 * 
 * C# 주요 연산자 종류
 * - 산술 연산자 (+, -, *, /, %)
 * - 관계 연산자 (<, >, <=, >=, ==, !=)
 * - 논리 연산자 (&&, ||, !)
 * - 증감 연산자 (++, --)
 * - 비트 연산자 (&, |, ^, <<, >>, ~)
 * - 할당 연산자 (=, +=, -=, *=, /= 등등...)
 * - 기타 연산자 (형 변환 연산자, 조건 연산자 등등...)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_03
{
	/**
	 * Example 3
	 */
	internal class CE01Example_03
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			/*
             * Console.ReadLine 메서드는 콘솔 창으로부터 데이터를 입력받는 역할을 수행한다.
             * 
             * 단, 해당 메서드를 통해서 반환되는 데이터를 문자열 데이터이기 때문에 해당 데이터를 
             * 적절하게 제어 할 필요가 있다.
             * 
             * Ex)
             * string oStr_Input = Console.ReadLine();
             * int.TryParse(oStr_Input, out int nVal);
             * 
             * 위의 경우 읽어들인 문자열을 정수 데이터로 변환한다는 것을 알 수 있다.
             * 
             * 만약, 여러 데이터를 읽어들일 경우 Split 메서드를 사용해서 문자열 데이터를 특정 
             * 문자를 기준으로 분할 시키는 것이 가능하다.
             * 
             * Split 메서드를 통해 분할 된 문자열은 배열의 형태로 반환되기 때문에 
             * [] (인덱스 연산자) 와 인덱스 번호를 통해서 특정 위치에 있는 데이터를 제어하는 것이 
             * 가능하다. (+ 단, 인덱스 번호는 0 부터 시작하기 때문에 주의가 필요하다.)
             */
			Console.Write("정수 (2 개) 입력 : ");
			string[] oTokens = Console.ReadLine().Split();

			/*
             * C# 의 기본 자료형은 문자열 데이터를 해당 자료형 데이터로 변환하기 위한 Parse 계열 
             * 메서드를 지원한다. (+ 즉, Parse 계열 메서드를 활용하면 문자열 데이터를 
             * 간단하게 원하는 자료형의 데이터로 변환하는 것이 가능하다.)
             * 
             * Parse 메서드 vs TryParse 메서드
             * - 두 메서드 모두 문자열 데이터를 특정 자료형 데이터로 변환하는 역할을 수행한다.
             * 
             * Parse 메서드는 데이터가 변환이 불가능 할 경우 내부적으로 런타임 에러가 발생하는 
             * 반면 TryParse 메서드는 변환이 불가능 할 경우 해당 변환을 무시하기 때문에 좀 더 
             * 안전하게 사용하는 것이 가능하다.
             * 
             * 또한 TryParse 메서드는 변환에 대한 성공 여부를 메서드의 반환 값으로 돌려주기 
             * 때문에 해당 값을 이용하면 간단하게 변환에 대한 성공 여부에 프로그램을 제어하는 것이 
             * 가능하다.
             * 
             * Ex)
             * int nValA = int.Parse("A");
             * bool bIsResult = int.TryParse("A", out int nValB);
             * 
             * 위의 경우 문자열 데이터를 정수로 변환하는 것이 불가능하기 때문에 Parse 메서드에서
             * 예외가 발생한다는 것을 알 수 있다.
             * 
             * 반면 TryParse 메서드는 변환 성공 여부를 메서드의 반환 값으로 돌려주기 때문에
             * Parse 메서드에 비해서 좀 더 안전하게 명령문을 작성하는 것이 가능하다.
             */
			int.TryParse(oTokens[0], out int nValA);
			int.TryParse(oTokens[1], out int nValB);

			/*
             * 산술 연산자 결과 값의 자료형은 피연산자의 자료형을 따라가기 때문에 나눗셈 연산자와 
             * 같이 결과 값을 제대로 연산하지 못하는 문제가 발생 할 수 있다.
             * 
             * 따라서 해당 경우에는 형 변환 연산자 등을 활용해서 올바른 결과가 값이 출력되도록 
             * 데이터를 제어 할 필요가 있다.
             * 
             * 만약, 피연산자의 자료형이 서로 다를 경우 내부적으로 자료형을 일치 시키기 위한 
             * 암시적인 형 변환이 발생하며 형 변환이 이루어지는 기준은 최대한 값이 손실 덜 발생하는 
             * 방향으로 이루어진다.
             * 
             * Ex)
             * int nVal = 10;
             * float fVal = 20.0f;
             * 
             * float fResult = nVal / fVal;
             * 
             * 위의 경우 실수를 정수로 바꾸는 것보다 정수를 실수로 바꾸는 것이 값의 손실이 덜 
             * 발생하기 때문에 결과 값이 실수가 된다는 것을 알 수 있다.
             */
			Console.WriteLine("=====> 산술 연산자 <=====");
			Console.WriteLine("{0} + {1} = {2}", nValA, nValB, nValA + nValB);
			Console.WriteLine("{0} - {1} = {2}", nValA, nValB, nValA - nValB);
			Console.WriteLine("{0} * {1} = {2}", nValA, nValB, nValA * nValB);
			Console.WriteLine("{0} / {1} = {2}", nValA, nValB, nValA / (float)nValB);
			Console.WriteLine("{0} % {1} = {2}", nValA, nValB, nValA % nValB);

			Console.WriteLine("\n=====> 관계 연산자 <=====");
			Console.WriteLine("{0} < {1} = {2}", nValA, nValB, nValA < nValB);
			Console.WriteLine("{0} > {1} = {2}", nValA, nValB, nValA > nValB);
			Console.WriteLine("{0} <= {1} = {2}", nValA, nValB, nValA <= nValB);
			Console.WriteLine("{0} >= {1} = {2}", nValA, nValB, nValA >= nValB);
			Console.WriteLine("{0} == {1} = {2}", nValA, nValB, nValA == nValB);
			Console.WriteLine("{0} != {1} = {2}", nValA, nValB, nValA != nValB);

			/*
             * 논리 연산자의 피연산자는 논리 (bool) 자료형 데이터만 사용가능하기 때문에 
             * 정수와 같은 데이터를 비교 연산 등을 통해서 논리 자료형으로 변환해 줄 필요가 있다.
             * 
             * 일반적으로 컴퓨터는 0 을 제외한 모든 데이터를 참으로 인식하지만 C# 은 참 or 거짓에 
             * 대한 자료형을 나타내는 bool 자료형이 존재하기 때문에 일반적인 숫자를 논리 데이터로 
             * 사용 할 경우 컴파일 에러가 발생한다.
             */
			Console.WriteLine("\n=====> 논리 연산자 <=====");
			Console.WriteLine("{0} && {1} = {2}", nValA, nValB, nValA != 0 && nValB != 0);
			Console.WriteLine("{0} || {1} = {2}", nValA, nValB, nValA != 0 || nValB != 0);
			Console.WriteLine("!{0} = {1}", nValA, !(nValA != 0));

			/*
             * 증감 연산자는 할당 연산자를 제외하고 변수가 지니고 있는 값을 변경 할 수 있는 유일한 
             * 연산자이다.
             * 
             * 단, 증감 연산자는 해당 연산자를 명시하는 위치에 따라 전위 증감 연산자와 
             * 후위 증감 연산자로 구분된다.
             * 
             * 전위 증감 연산자 vs 후위 증감 연산자
             * - 두 연산자 모두 변수가 지니고 있는 값을 변경하는 역할을 수행한다.
             * 
             * 전위 증감 연산자는 선 증감 후 연산에 순서로 사용되는 반면 후위 증감 연산자는 
             * 선 연산 후 증감 순서가 사용되는 차이점이 존재한다.
             * 
             * Ex)
             * int nValA = 0;
             * int nValB = 0;
             * 
             * int nResultA = ++nValA;      <- 1
             * int nResultB = nValB++;      <- 0
             * 
             * 위의 경우 nResultA 변수에는 값이 증가 된 1 값이 할당되는 반면 nResultB 변수에는 
             * 증가 되기 전인 0 이 할당된다는 것을 알 수 있다.
             * 
             * 증감 연산자는 동일한 라인에 여러번 명시 할 경우 컴파일러에 따라 결과가 달라질 수 
             * 있기 때문에 같은 라인에 증감 연산자를 사용하는 것은 좋은 습관이 아니다.
             * 
             * Ex)
             * int nVal = 0;
             * int nResult = ++nVal + nVal++ + nVal++;
             * 
             * 위의 경우 + 연산자의 실행 순서에 따라 결과가 달라 질 수 있기 때문에 정확한 결과를 
             * 산출하는 것이 불가능하다.
             */
			Console.WriteLine("\n=====> 증감 연산자 <=====");
			Console.WriteLine("++{0}, --{1} = {2}, {3}", nValA, nValB, ++nValA, --nValB);
			Console.WriteLine("{0}++, {1}-- = {2}, {3}", nValA, nValB, nValA++, nValB--);

			Console.WriteLine("\n=====> 후위 증감 연산자 결과 <=====");
			Console.WriteLine("{0}, {1}", nValA, nValB);

			int nResult = (nValA < nValB) ? nValA : nValB;

			/*
             * 조건 연산자는 C# 이 제공하는 연산자 중 유일하게 피연산자를 3 개 요구하기 때문에 
             * 삼항 연산자라고도 불린다.
             * 
             * 해당 연산자는 ? 기호 왼쪽에 존재하는 조건식을 기준으로 참 일 경우 : 기호의 왼쪽 
             * 데이터를 반환하는 반면 거짓 일 경우 : 기호의 오른쪽 데이터를 반환한다.
             * 
             * Ex)
             * int nValA = 10;
             * int nValB = 20;
             * 
             * int nResult = (nValA > nValB) ? nValA : nValB;
             * 
             * 위의 경우 조건 연산자에 의해 nResult 변수에는 nValA 변수와 nValB 변수가 
             * 지니고 있는 데이터 중 큰 데이터가 할당된다는 것을 알 수 있다.
             */
			Console.WriteLine("\n=====> 조건 연산자 <=====");
			Console.WriteLine("({0} < {1}) ? {0} : {1} = {2}", nValA, nValB, nResult);

			/*
			 * 컴퓨터는 음수에 대한 계산을 단순화 시키기 위해서 음수를 2 의 보수법으로 표현한다.
			 * (즉, 음수를 2 의 보수법으로 표현함으로서 덧셈 연산을 통해 간단하게 음수에 대한
			 * 결과를 계산하는 것이 가능하다.)
			 * 
			 * Ex)
			 * 0101			<- 5
			 * 1011			<- -5
			 * 
			 * 위와 같이 2 의 보수는 1 의 보수를 구한 다음에 +1 을 더해줌으로서 간단하게
			 * 계산하는 것이 가능하다.
			 */
			Console.WriteLine("\n=====> 비트 연산자 <=====");
			Console.WriteLine("{0} & {1} = {2}", nValA, nValB, nValA & nValB);
			Console.WriteLine("{0} | {1} = {2}", nValA, nValB, nValA | nValB);
			Console.WriteLine("{0} ^ {1} = {2}", nValA, nValB, nValA ^ nValB);
			Console.WriteLine("{0} << 1 = {1}", nValA, nValA << 1);
			Console.WriteLine("{0} >> 1 = {1}", nValB, nValB >> 1);
			Console.WriteLine("~{0} = {1}", nValA, ~nValA);
		}
	}
}
