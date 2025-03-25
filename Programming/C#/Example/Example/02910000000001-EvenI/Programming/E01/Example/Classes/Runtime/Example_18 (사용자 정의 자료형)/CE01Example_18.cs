//#define P_E01_EXAMPLE_18_01
#define P_E01_EXAMPLE_18_02

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 사용자 정의 자료형이란?
 * - C# 이 제공하는 자료형 이외에 사용자 (프로그래머) 가 필요에 따라 직접 정의해서 사용하는
 * 자료형을 의미한다. (+ 즉, 사용자 정의 자료형을 활용하면 제작하는 프로그램에 특화 된 자료형을
 * 정의하는 것이 가능하다.)
 * 
 * C# 사용자 정의 자료형 종류
 * - 구조체 (Structure)
 * - 열거형 (Enumeration)
 * - 클래스 (Class)
 * - 인터페이스 (Interface)
 * 
 * 구조체 (Structure) 란?
 * - 여러 데이터를 묶어서 그룹화 시킬 수 있는 기능을 의미한다. (+ 즉, 구조체를 활용하면 연관 된
 * 데이터를 하나의 그룹으로 묶어서 제어하는 것이 가능하다.)
 * 
 * C# 구조체 선언 방법
 * - struct + 구조체 이름 + 구조체 멤버 (+ 변수, 메서드 등등...)
 * 
 * Ex)
 * struct STSomeStruct
 * {
 *		public int m_nVal;
 *		public foat m_fVal;
 * }
 * 
 * STSomeStruct stSomeStructVar;
 * stSomeStructVar.m_nVal = 10;
 * stSomeStructVar.m_fVal = 3.14f;
 * 
 * 위와 같이 구조체를 선언하면 해당 구조체를 자료형처럼 활용하는 것이 가능하다. (+ 즉,
 * 변수 선언 등에 활용하는 것이 가능하다.)
 * 
 * 구조체는 여러 데이터를 그룹화 시킬 수 있는 기능이기 때문에 
 * 구조체를 통해 선언 된 변수 (구조체 변수) 하위에는 여러 데이터가 존재하며 해당 데이터에
 * 접근하고 싶다면 . (멤버 지정 연산자) 를 사용하면 된다. (+ 즉, 구조체는 클래스와 유사하다는 것을
 * 알 수 있다.)
 * 
 * 구조체 (Structure) vs 클래스 (Class)
 * - 구조체와 클래스 모두 연관 된 데이터를 그룹화 시킬 수 있는 기능을 의미한다.
 * 
 * 단, 구조체는 값 형식 자료형이며 상속을 비롯한 다형성을 지원하지 않는다. (+ 즉, 객체 지향 개념과
 * 연관 된 기능을 지원하지 않는다는 것을 알 수 있다.)
 * 
 * 따라서 구조체는 주로 단순한 데이터의 집합을 표현 할 때 활용되며 클래스는 사물을 정의 할 때
 * 활용된다는 차이점이 존재한다.
 * 
 * C# 구조체 특징
 * - 값 형식 자료형이다.
 * 
 * - 기본 생성자를 구현하는 것이 불가능하다. (+ 즉, 구조체는 클래스와 달리 항상 기본 생성자가
 * 항상 존재하며 해당 생성자는 C# 컴파일러에 의해서 자동으로 구현된다.)
 * 
 * - 상속 및 다형성을 지원하지 않는다. (+ 즉, 구조체는 상속을 지원하지 않으며 따라서 상속을 기반으로
 * 지원하는 다형성 또한 지원하지 않는다는 것을 알 수 있다.)
 * 
 * - 인터페이스를 따르는 것이 가능하다. (+ 단, 인터페이스는 참조 형식 자료형이기 때문에 내부적으로
 * Boxing 에 의한 가비지 컬렉션 동작을 유발시킬 수 있다는 단점이 존재한다.)
 * 
 * 열거형 (Enumeration) 이란?
 * - 심볼릭 상수를 정의 할 수 있는 기능을 의미한다. (+ 즉, C# 이 제공하는 심볼릭 상수를
 * 정의 할 수 있는 여러 방법 중 하나라는 것을 알 수 있다.)
 * 
 * 열거형을 통해 정의 된 상수는 컴파일러에 의해서 자동으로 값이 할당되기 때문에 중복 된 값을
 * 지니고 있는 상수를 정의하는 실수를 줄이는 것이 가능하다. (+ 즉, 상수는 주로 특정 데이터를
 * 식별하기 위한 식별자로 활용되기 때문에 중복을 허용하지 않는 것이 일반적이다.)
 * 
 * C# 열거형 선언 방법
 * - enum + 열거형 이름 + 열거형 상수
 * 
 * Ex)
 * enum ESomeEnum
 * {
 *		ENUM_CONST_A,
 *		ENUM_CONST_B,
 *		ENUM_CONST_C
 * }
 * 
 * ESomeEnum eSomeEnumVar = ESomeEnum.ENUM_COSNT_A;
 * 
 * 위와 같이 열거형을 활용하면 간단하게 상수를 정의하는 것이 가능하다.
 * 
 * 또한 열거형 자체는 사용자 정의 자료형이기 때문에 열거형을 자료형처럼 활용하는 것이 가능하다.
 * (+ 즉, 열거형으로 선언 된 변수 (열거형 변수) 에는 열거형 하위에 정의한 상수를 할당하는 것이
 * 가능하다.)
 * 
 * C# 열거형 상수 값 할당 규칙
 * - 열거형 상수에 값을 할당하지 않으면 컴파일러에 의해서 자동으로 값이 할당되며 이때 할당되는 값은
 * 이전 열거형 상수 값에서 +1 을 증가시킨 값이 할당된다. (+ 즉, 이전 열거형 상수가 존재하지 않으면
 * 0 이 할당된다는 것을 알 수 있다.)
 * 
 * 열거형 상수는 필요에 따라 직접 값을 할당하는 것이 가능하며 직접 값을 할당 한 경우에는 값의 중복이
 * 발생 할 수 있다는 것에 주의해야한다. (+ 즉, C# 컴파일러는 단순하게 값을 할당만해준다는 것을
 * 알 수 있다.)
 * 
 * 또한 열거형은 정수 값만 명시하는 것이 가능하며 정수 이외에 데이터는 열거형 상수에 할당하는 것이
 * 불가능하다. (+ 즉, 정수 이외의 상수가 필요 할 경우에는 const 키워드 등을 활용해야한다는 것을
 * 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_18
{
	/**
	 * Example 18
	 */
	internal class CE01Example_18
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_18_01
			STE01Character_18 stCharacter = new STE01Character_18();
			stCharacter.m_nLv = 1;
			stCharacter.m_nHp = 50;
			stCharacter.m_nAtk = 15;

			Console.WriteLine("=====> 캐릭터 정보 - 레벨 업 전 <=====");
			E01ShowInfo_18(stCharacter);

			stCharacter = E01LevelUp_18(stCharacter);

			Console.WriteLine("\n=====> 캐릭터 정보 - 레벨 업 후 <=====");
			E01ShowInfo_18(stCharacter);
#elif P_E01_EXAMPLE_18_02
			EE01Type_Item_18 eItem_Acquire = E01GetItem_Acquire_18();
			Console.WriteLine("획득 아이템 : {0}", eItem_Acquire);
#endif // P_E01_EXAMPLE_18_01
		}

#if P_E01_EXAMPLE_18_01
		/**
		 * 캐릭터
		 */
		private struct STE01Character_18
		{
			public int m_nLv;
			public int m_nHp;
			public int m_nAtk;
		}

		/** 레벨을 증가시킨다 */
		private static STE01Character_18 E01LevelUp_18(STE01Character_18 a_stCharacter)
		{
			/*
			 * 구조체에 new 키워드를 명시하는 것은 해당 구조체의 생성자를 호출한다는 의미이다.
			 * (+ 즉, 객체를 생성한다는 의미가 아니라는 것을 알 수 있다.)
			 */
			return new STE01Character_18()
			{
				m_nLv = a_stCharacter.m_nLv + 1,
				m_nHp = a_stCharacter.m_nHp + 10,
				m_nAtk = a_stCharacter.m_nAtk + 5
			};
		}

		/** 정보를 출력한다 */
		private static void E01ShowInfo_18(STE01Character_18 a_stCharacter)
		{
			Console.WriteLine("레벨 : {0}", a_stCharacter.m_nLv);
			Console.WriteLine("체력 : {0}", a_stCharacter.m_nHp);
			Console.WriteLine("공격력 : {0}", a_stCharacter.m_nAtk);
		}
#elif P_E01_EXAMPLE_18_02
		/**
		 * 아이템 종류
		 */
		private enum EE01Type_Item_18
		{
			NONE = -1,
			GOLD,
			POTION,
			WEAPON,
			MAX_VAL
		}

		/** 획득 아이템을 반환한다 */
		private static EE01Type_Item_18 E01GetItem_Acquire_18()
		{
			var oRandom = new Random();

			/*
			 * 열거형 상수는 정수 값이 할당되어있기 때문에 형변환 연산자를 통해 간단하게 
			 * 정수로 변환하는 것이 가능하다. (+ 즉, 열거형 상수와 정수는 서로 호환된다는 것을 
			 * 알 수 있다.)
			 */
			return (EE01Type_Item_18)oRandom.Next((int)EE01Type_Item_18.GOLD,
				(int)EE01Type_Item_18.MAX_VAL);
		}
#endif // P_E01_EXAMPLE_18_01
	}
}
