using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 자료형 (Data Type) 이란?
 * - 데이터를 해석하는 방법을 의미한다. (+ 즉, 동일한 형태의 데이터라고 하더라도 자료형에 따라 
 * 처리되는 방식이 달라진다는 것을 알 수 있다.)
 * 
 * 또한 자료형은 데이터가 표현 할 수 있는 최대 범위를 제한하는 역할도 수행한다. (+ 즉, 
 * 제작하는 프로그램의 목적에 맞게 적절한 자료형을 사용 할 필요가 있다.)
 * 
 * C# 의 자료형은 크게 값 형식 자료형과 참조 형식 자료형으로 구분된다.
 * 
 * 값 형식 자료형이란?
 * - 데이터 자체를 다루는 자료형을 의미한다. (+ 즉, 해당 자료형으로 선언 된 변수를 
 * 다른 변수에 할당하면 사본이 만들어진다는 것을 알 수 있다.)
 * 
 * 또한 값 형식 자료형은 시스템 (운영체제) 에 의해서 관리되기 때문에 해당 자료형은 데이터는 
 * 메모리 관리 측면에서 상대적으로 부하가 적다는 것을 알 수 있다.
 * 
 * 참조 형식 자료형이란?
 * - 데이터를 지니고 있는 대상은 따로 존재하고 해당 대상의 대한 참조 값을 다루는 자료형을 의미한다. 
 * (+ 즉, 해당 자료형으로 선언 된 변수를 다른 변수에 할당하면 얕은 복사가 발생한다는 것을 
 * 알 수 있다.)
 * 
 * 또한 참조 형식 자료형은 가비지 컬렉션에 의해서 관리되기 때문에 해당 자료형의 데이터를 빈번하게 
 * 사용 할 경우 프로그램의 성능이 저하되는 단점이 존재한다. (+ 즉, 가비지 컬렉션은 
 * 메모리를 관리해주는 별도의 기능이기 때문에 운영체제에 비해서 메모리를 관리하기 위한 자원이 
 * 많이 소비된다는 것을 알 수 있다.)
 * 
 * C# 값 형식 자료형 종류
 * // 정수
 * - byte or sbyte : 1 Byte
 * - short or ushort : 2 Byte
 * - int or uint : 4 Byte
 * - long or ulong : 8 Byte
 * 
 * // 실수
 * - float : 4 Byte (부동 소수점)
 * - double : 8 Byte (부동 소수점)
 * - decimal : 16 Byte (고정 소수점)
 * 
 * // 논리
 * - bool : 1 Byte
 * 
 * // 문자
 * - char : 2 Byte
 * 
 * // 기타
 * - enum
 * - struct
 * 
 * C# 참조 형식 자료형 종류
 * - class
 * - object
 * - string
 * 
 * 부호 있음 (Signed) vs 부호 없음 (Unsigned)
 * - 컴퓨터는 양수와 음수를 구분하기 위해서 부호 비트를 요구하며 해당 비트는 데이터를 표현하는
 * 비트의 가장 왼쪽에 존재하는 비트를 사용한다. (즉, 부호 비트가 0 일 경우 양수를 의미하며
 * 1 일 경우 음수를 의미한다.)
 * 
 * Signed 는 부호 비트를 사용하기 때문에 양수와 음수를 모두 표현하는 것이 가능하지만
 * 최대 표현 할 수 있는 양수의 범위가 절반으로 줄어드는 단점이 존재한다.
 * 
 * 반면 Unsigned 는 부호 비트 또한 데이터를 표현하는데 사용하기 때문에 Signed 에 비해서
 * 표현 할 수 있는 양수의 범위가 2 배 증가하지만 음수를 표현하는 것이 불가능하다. (즉, 부호 비트를
 * 양수 or 음수를 표현하는데 사용하지 않고 수의 범위를 표현하는데 사용한다는 것을 알 수 있다.)
 * 
 * 부동 소수점 (Floating Point) vs 고정 소수점 (Fixed Point)
 * - 부동 소수점은 비트 패턴을 기반으로 공식을 통해 최종적으로 값을 산출하기 때문에 적은 비트를
 * 가지고도 넓은 범위의 수를 표현하는 것이 가능하지만 표현하는 수의 정밀도가 떨어지는 단점이
 * 존재한다. (즉, 최종적으로 산출 된 값에 오차가 존재 할 수 있다는 것을 의미한다.)
 * 
 * 반면 고정 소수점은 부동 소수점에 비해 많은 비트를 요구하지만 값에 오차가 존재하지 않기 때문에
 * 특정 값을 정확하게 표현하는 것이 가능하다.
 * 
 * 단, 고정 소수점 방식은 부동 소수점과 달리 해당 데이터를 빠르게 연산하기 위한 전용 유닛이
 * 없기 때문에 연산 속도가 느리기 때문에 성능을 요구하는 프로그램을 제작 할 때는 사용에
 * 주의가 필요하다. (즉, 부동 소수점은 해당 데이터를 빠르게 연산하기 위한 전용 유닛이 
 * 존재하기 때문에 연산 속도가 빠르다는 것을 알 수 있다.)
 * 
 * 따라서 값을 정확하게 표현해야되는 특정 분야를 제외하고는 일반적으로 부동 소수점 방식이 많이
 * 사용된다.
 * 
 * object 자료형이란?
 * - C# 에 존재하는 모든 자료형이 직/간접적으로 상속받는 최상위 자료형을 의미한다. (+ 즉, 해당 
 * 자료형으로 모든 데이터를 제어하는 것이 가능하다.)
 * 
 * 단, object 자료형은 참조 형식 자료형이기 때문에 해당 자료형 변수에 값 형식 데이터를 할당 할 경우 
 * 내부적으로 Boxing/Unboxing 이 발생한다.(+ 즉, 데이터를 지니는 임시적인 메모리가 내부적으로 
 * 발생하기 때문에 빈번하게 사용 할 경우 가비지 컬렉션의 동작을 유발시킨다.)
 * 
 * 가비지 컬렉션 (Garbage Collection) 이란?
 * - 힙 메모리 영역을 관리해주는 기능을 의미한다. (+ 즉, C# 은 힙 메모리 영역을 직접 관리하는 것이
 * 불가능하며 해당 영역은 가비지 컬렉션에 의해서 자동으로 관리된다는 것을 알 수 있다.)
 * 
 * 가비지 컬렉션은 0 ~ 2 세대로 구분해서 힙 메모리 영역을 관리한다. (+ 즉, 각 세대 별로 위치하는 
 * 데이터에 특징이 존재한다는 것을 알 수 있다.)
 * 
 * 가비지 컬렉션은 각 세대 별로 메모리 관리를 수행하며 상위 세대 컬렉션은 하위 세대 컬렉션을 
 * 포함한다. (+ 즉, 2 세대 가비지 컬렉션이 동작 할 경우 힙 영역의 모든 데이터를 관리하기 때문에
 * 성능 저하가 발생한다는 것을 알 수 있다.)
 * 
 * 특정 세대 가비지 컬렉션을 수행한 후 해당 세대에 여전히 사용되는 데이터가 있다면 해당 데이터는
 * 상위 세대로 이동한다. (+ 즉, 상위 세대에 존재하는 데이터 일 수록 오래 유지되는 데이터라는 것을
 * 알 수 있다.)
 * 
 * 가비지 컬렉션은 사용되지 않는 데이터 정리 이외에도 메모리 파현화 (Memory Fragmentation) 를
 * 해결하는 작업도 수행하기 때문에 힙 메모리 영역에 할당 된 데이터 간에 관계가 복잡 할 경우
 * 이를 추적하는 과정에서 성능 저하가 발생 할 수도 있다. (+ 즉, 데이터 간에 관계를 단순화
 * 시킬수록 메모리 파편화를 해결하는 과정에서 불필요한 연산이 발생하지 않는다는 것을 알 수 있다.)
 * 
 * 변수란?
 * - 데이터를 저장하거나 읽어들일 수 있는 공간을 의미한다. (+ 즉, 변수를 활용하면 특정 데이터를 
 * 저장하거나 필요에 따라 재사용하는 것이 가능하다.)
 * 
 * 변수는 메모리의 특정 영역에 생성 되기 때문에 해당 변수에 접근하기 위한 방법이 필요하며 C# 은 변수 
 * 이름을 제공함으로서 변수에 접근하는 것이 가능하다.
 * 
 * C# 변수 선언 방법
 * - 자료형 + 변수 이름
 * 
 * Ex)
 * int nVal = 0;
 * float fVal = 0.0f;
 * 
 * C# 변수 이름 작성 규칙
 * - C# 은 다국어를 지원하기 때문에 영어를 비롯한 여러 문자를 가지고 변수 이름을 작성하는 것이 
 * 가능하다.
 * 
 * 단, 전통적으로 변수 이름에 사용 할 수 있는 문자의 종류는 
 * 알파벳 대/소문자, _ (언더 스코어), 숫자 만을 사용하는 것이기 때문에 가능하면 해당 문자만을 
 * 사용하는 것은 추천한다.
 * 
 * 단, 변수 이름의 첫 문자는 숫자를 사용하는 것이 불가능하기 때문에 주의가 필요하며 알파벳 대문자와 
 * 소문자를 구분하기 때문에 같은 단어라고 하더라도 대/소문자의 조합이 다르다면 다른 변수 이름으로
 * 구분된다.
 * 
 * Ex)
 * int nVal01 = 0;
 * int 01nVal = 0;      <- 컴파일 에러
 * 
 * float ffloat = 0.0f;
 * float fFloat = 0.0f;     <- 대/소문자가 구분되기 때문에 다른 변수
 * 
 * 상수란?
 * - 변수와 마찬가지로 데이터를 저장하거나 읽어들일 수 있는 공간을 의미한다.
 * 
 * 단, 변수는 자유롭게 데이터를 저장 할 수 있는 반면 상수는 한번 데이터가 저장되고 나면 더이상 
 * 변경하는 것은 불가능하다. (+ 즉, 읽어들이는 것만 가능하다.)
 * 
 * C# 상수 종류
 * - 리터널 상수			<- 이름이 없는 상수 (+ Ex. 0, "A" 등등...)
 * - 심볼릭 상수			<- 이름이 존재하는 상수
 * 
 * C# 심볼릭 상수 선언 방법
 * - const + 자료형 + 상수 이름
 * 
 * Ex)
 * const int nVal = 10;
 * 
 * 위와 같이 상수를 선언하고 나면 이후 해당 상수에 저장 된 데이터를 변경하는 것은 불가능하다. (+ 즉,
 * 상수에는 초기화 시점에만 데이터를 할당 할 수 있다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_02
{
	/**
	 * Example 2
	 */
	internal class CE01Example_02
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
			byte nByteA = byte.MaxValue;
			sbyte nByteB = sbyte.MaxValue;

			short nShortA = short.MaxValue;
			ushort nShortB = ushort.MaxValue;

			int nIntA = int.MaxValue;
			int nIntB = int.MaxValue;

			long nLongA = long.MaxValue;
			ulong nLongB = long.MaxValue;

			Console.WriteLine("=====> 정수 <=====");
			Console.WriteLine("Byte : {0}, {1}", nByteA, nByteB);
			Console.WriteLine("Short : {0}, {1}", nShortA, nShortB);
			Console.WriteLine("Int : {0}, {1}", nIntA, nIntB);
			Console.WriteLine("Long : {0}, {1}", nLongA, nLongB);

			float fFloat = float.MaxValue;
			double dblDouble = double.MaxValue;
			decimal dmDecimal = decimal.MaxValue;

			Console.WriteLine("\n=====> 실수 <=====");
			Console.WriteLine("Float : {0}", fFloat);
			Console.WriteLine("Double : {0}", dblDouble);
			Console.WriteLine("Decimal : {0}", dmDecimal);

			char chLetterA = 'A';
			char chLetterB = 'B';
			char chLetterC = 'C';

			/*
             * C# 의 문자열은 변경이 불가능한 데이터이기 때문에 해당 문자열 중 특정 문자를 변경하고 
             * 싶다면 새로운 문자열 데이터를 생성 할 필요가 있다.
             * 
             * 따라서 문자열의 일부를 빈번하게 수정 할 경우 string 자료형보다는 StringBuilder 를 
			 * 사용하는 것이 좋다. (+ 즉, StringBuilder 는 내부적으로 임시적인 문자열 데이터를 
			 * 생성하지 않는다는 것을 알 수 있다.)
             */
			string oStr = "ABC";
			oStr = oStr.Replace("A", "a");

			//StringBuilder oStrBuilder = new StringBuilder();

			Console.WriteLine("\n=====> 문자 <=====");
			Console.WriteLine("Char : {0}, {1}, {2}", chLetterA, chLetterB, chLetterC);
			Console.WriteLine("String : {0}, {1}, {2}", oStr, oStr[0], oStr[1]);

			/*
             * object 자료형 변수에 값 형식 데이터를 할당 할 경우 Boxing 이 발생한다는 것을 
             * 알 수 있다.
             */
			object oObjA = 10;
			object oObjB = 3.14f;
			object oObjC = "Hello, World!";

			/*
             * object 자료형 변수로부터 데이터를 가져올 때 Unboxing 이 발생한다는 것을 
             * 알 수 있다. 
             * 
             * 단, Unboxing 은 단순히 데이터를 가져오는 것이기 때문에 크게 성능 저하가 발생하지
             * 않는다.
             * 
             * Unboxing 을 하기 위해서는 특정 자료형으로 형 변환 할 필요가 있다. (+ 즉, 
             * 잘못된  자료형을 명시 할 경우 내부적으로 런타임 에러가 발생한다는 것을 알 수 있다.)
             */
			Console.WriteLine("\n=====> Object <=====");
			Console.WriteLine("Object A : {0}", (int)oObjA);
			Console.WriteLine("Object B : {0}", (float)oObjB);
			Console.WriteLine("Object C : {0}", (string)oObjC);
		}
	}
}
