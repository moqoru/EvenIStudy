//#define P_E01_EXAMPLE_12_01
//#define P_E01_EXAMPLE_12_02
#define P_E01_EXAMPLE_12_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 객체 지향 프로그래밍 3 대 요소
 * - 캡슐화 (+ or 정보 은닉)
 * - 상속
 * - 다형성
 * 
 * 캡슐화 (+ or 정보 은닉) 란?
 * - 객체가 지니는 멤버를 외부로부터 안전하게 보호하는 개념을 의미한다. (+ 즉, 캡슐화는 
 * 접근 제어 지시자를 통해서 구현하는 것이 가능하다.)
 * 
 * 일반적으로 객체가 사용하는 데이터 중 민감한 데이터를 가능하면 외부로부터 안전하게 보호하는 것이 
 * 객체를 좀 더 안전하게 사용하는 개념이라는 것을 알 수 있다.
 * 
 * 상속이란?
 * - 클래스 간에 부모/자식 관계를 형성 시키는 개념을 의미한다. (+ 즉, 특정 클래스가 
 * 상속 관계에 놓여있다면 클래스가 간에 상/하 관계가 형성된다는 것을 알 수 있다.)
 * 
 * 자식 클래스는 부모 클래스에 존재하는 멤버를 사용하는 것이 가능하기 때문에 상속을 활용하면 클래스 
 * 간에 발생하는 중복적인 멤버를 줄이는 것이 가능하다.
 * 
 * 단, 상속을 무분별하게 사용 할 경우 오히려 클래스 간에 관계가 복잡해지기 때문에 지금은 is a 의 
 * 관계가 형성 되었을 경우에만 상속을 사용하는 것이 일반적인 관례이다.
 * 
 * 또한 has a 의 관계도 일부 인정하지만 해당 관계는 멤버를 통해서 표현하기 때문에 has a 의 관계는 
 * 가능하면 고려하지 않는 것을 추천한다.
 * 
 * Ex)
 * class CBase
 * {
 *		// Do Something
 * }
 * 
 * class CDerived : CBase
 * {
 *		// Do Something
 * }
 * 
 * 위와 CDerived 클래스는 CBase 클래스를 상속하고 있기 때문에 해당 클래스는 CBase 클래스에 존재하는 
 * 멤버를 사용하는 것이 가능하다.
 * 
 * 단, 상속은 단방향이기 때문에 두 클래스가 서로를 상속하는 것이 불가능하다. (+ 즉, 양방향 상속은 
 * 지원하지 않는다.)
 * 
 * 다형성이란?
 * - 사물을 바라보는 시선에 따라 다양한 형태를 지니는 개념을 의미한다. (+ 즉, 다형성을 활용하면 
 * 동일한 사물을 다른 형태로 인지하는 것이 가능하다.)
 * 
 * C# 은 상속을 통해서 다형성을 흉내내는 것이 가능하다.
 * 
 * Ex)
 * class CBase
 * {
 *		// Do Something
 * }
 * 
 * class CDerived : CBase
 * {
 *		// Do Something
 * }
 * 
 * CBase oBase = new CDerived();
 * 
 * 위와 같이 자식 클래스를 통해서 생성 된 객체는 부모 클래스 형으로 참조하는 것이 가능하다. (+ 즉, 
 * 자식 객체를 부모 객체로 인지하고 있다는 것을 알 수 있다.)
 * 
 * 단, 반대로 부모 클래스를 통해서 생성 된 객체를 자식 클래스 형으로 참조하는 것은 불가능하다.
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_12
{
	/**
	 * Example 12
	 */
	internal class CE01Example_12
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_12_01
			CE01Base_12 oBase = new CE01Base_12();
			oBase.m_nVal = 10;
			oBase.m_fVal = 3.14f;

			CE01Derived_12 oDerived = new CE01Derived_12();
			oDerived.m_nVal = 20;
			oDerived.m_fVal = 3.14f;
			oDerived.m_oStr = "ABC";

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 <=====");
			oDerived.ShowInfo();
#elif P_E01_EXAMPLE_12_02
			CE01Base_12 oBase = new CE01Base_12(10, 3.14f);
			CE01Base_12 oDerivedA = new CE01Derived_12(20, 3.14f, "ABC");

			CE01Derived_12 oDerivedB = new CE01Derived_12(30, 3.14f, "DEF");

			/*
			 * 아래와 같이 부모 클래스를 통해 생성 된 객체를 자식 클래스 형으로 참조하는 것은 
			 * 불가능하다. (+ 즉, 컴파일 에러가 발생한다.)
			 * 
			 * 이는 부모 클래스에는 자식 클래스에 대한 정보가 없기 때문이다. (+ 즉, 반대로 
			 * 자식 클래스에는 부모 클래스에 대한 정보가 존재하기 때문에 부모 클래스 형으로 
			 * 자식 객체를 참조하는 것이 가능하다.)
			 */
			//CE01Derived_12 oDerivedC = new CE01Base_12(40, 3.14f);

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 - A <=====");
			oDerivedA.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 - B <=====");
			oDerivedB.ShowInfo();
#elif P_E01_EXAMPLE_12_03
			CE01Base_12 oBase = new CE01Base_12(10, 3.14f);
			CE01Base_12 oDerivedA = new CE01Derived_12(20, 3.14f, "ABC");

			CE01Derived_12 oDerivedB = new CE01Derived_12(30, 3.14f, "DEF");

			Console.WriteLine("=====> 부모 클래스 <=====");
			oBase.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 - A <=====");
			oDerivedA.ShowInfo();

			Console.WriteLine("\n=====> 자식 클래스 - B <=====");
			oDerivedB.ShowInfo();
#endif
		}

#if P_E01_EXAMPLE_12_01
		/**
		 * 부모 클래스
		 */
		private class CE01Base_12
		{
			public int m_nVal = 0;
			public float m_fVal = 0.0f;

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("정수 : {0}", m_nVal);
				Console.WriteLine("실수 : {0}", m_fVal);
			}
		}

		/**
		 * 자식 클래스
		 */
		private class CE01Derived_12 : CE01Base_12
		{
			public string m_oStr = string.Empty;

			/*
			 * 부모 클래스와 자식 클래스에 동일한 이름의 멤버가 존재 할 경우 C# 컴파일러에 의해서 
			 * 경고가 발생한다.
			 * 
			 * 따라서 해당 경고를 제거하기 위해서는 new 키워드를 사용해야한다. (+ 즉, new 키워드를 
			 * 사용하면 C# 컴파일러에게 의도적으로 동일한 이름의 멤버를 정의했다는 것을 알리는 
			 * 의미라는 것을 알 수 있다.)
			 */
			/** 정보를 출력한다 */
			public new void ShowInfo()
			{
				/*
				 * base 키워드는 부모 클래스를 지칭하는 역할을 수행한다. (+ 즉, 해당 키워드를 
				 * 활용하면 부모 클래스에 존재하는 멤버에 접근하는 것이 가능하다.)
				 * 
				 * C# 클래스는 동일한 이름의 멤버를 부모 클래스와 자식 클래스에 모두 정의하는 것이 
				 * 가능하기 때문에 이 경우 우선 순위는 자식 클래스 더 높다. (+ 즉, 해당 경우 
				 * base 키워드를 생략하면 항상 자식에 존재하는 멤버에 접근한다는 것을 알 수 있다.)
				 */
				base.ShowInfo();
				Console.WriteLine("문자열 : {0}", m_oStr);
			}
		}
#elif P_E01_EXAMPLE_12_02
		/**
		 * 부모 클래스
		 */
		private class CE01Base_12
		{
			public int m_nVal = 0;
			public float m_fVal = 0.0f;

			/** 생성자 */
			public CE01Base_12() : this(0, 0.0f)
			{
				// Do Something
			}

			/** 생성자 */
			public CE01Base_12(int a_nVal, float a_fVal)
			{
				this.m_nVal = a_nVal;
				this.m_fVal = a_fVal;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("정수 : {0}", m_nVal);
				Console.WriteLine("실수 : {0}", m_fVal);
			}
		}

		/**
		 * 자식 클래스
		 */
		private class CE01Derived_12 : CE01Base_12
		{
			public string m_oStr = string.Empty;
			
			/*
			 * 특정 클래스가 상속 관계에 놓여있을 때 해당 클래스를 통해 생성 된 객체의 생성자 호출 
			 * 순서는 반드시 부모 -> 자식 순으로 이루어져야한다. (+ 즉, 자식 클래스는 
			 * 반드시 부모 클래스의 생성자를 호출해줘야한다.)
			 * 
			 * 부모 클래스의 생성자는 자식 클래스의 생성자에서 반드시 호출해줘야하며 
			 * 이는 base 키워드를 사용하면 가능하다.
			 * 
			 * 만약, 자식 클래스의 생성자에서 부모 클래스의 생성자를 호출하지 않았을 경우 C# 
			 * 컴파일러에 의해서 자동으로 부모 클래스의 기본 생성자를 호출하는 명령문이 추가된다.
			 * 
			 * 따라서 부모 클래스에 기본 생성자가 없을 경우에는 반드시 자식 클래스 생성자에서 
			 * 명시적으로 부모 클래스 생성자를 호출해줘야한다.
			 */
			/** 생성자 */
			public CE01Derived_12(int a_nVal, 
				float a_fVal, string a_oStr) : base(a_nVal, a_fVal)
			{
				this.m_oStr = a_oStr;
			}

			/** 정보를 출력한다 */
			public new void ShowInfo()
			{
				base.ShowInfo();
				Console.WriteLine("문자열 : {0}", m_oStr);
			}
		}
#elif P_E01_EXAMPLE_12_03
		/**
		 * 부모 클래스
		 */
		private class CE01Base_12
		{
			public int m_nVal = 0;
			public float m_fVal = 0.0f;

			/** 생성자 */
			public CE01Base_12() : this(0, 0.0f)
			{
				// Do Something
			}

			/** 생성자 */
			public CE01Base_12(int a_nVal, float a_fVal)
			{
				this.m_nVal = a_nVal;
				this.m_fVal = a_fVal;
			}

			/*
			 * 가상 메서드란?
			 * - 실제 호출되는 메서드가 프로그램이 실행 중에 결정되는 기능을 의미한다. (+ 즉, 
			 * 가상 메서드를 호출했을 경우 참조하는 객체에 따라 호출 결과가 달라진다는 것을 
			 * 의미한다.)
			 * 
			 * 가상 메서드는 호출 될 메서드를 실행 중에 결정하는 동적 바인딩을 지원하는 기능이라는 
			 * 것을 알 수 있다.
			 * 
			 * 자식 클래스가 부모 클래스에 존재하는 가상 메서드를 재정의 할 경우 자식 클래스의 
			 * 메서드가 부모 클래스의 메서드 대신에 호출되는 것이 가능하다. (+ 즉, 
			 * 가상 메서드를 활용하면 특정 객체를 참조하는 자료형에 상관없이 항상 동일한 결과를 
			 * 만들어내는 것이 가능하다.)
			 */
			/** 정보를 출력한다 */
			public virtual void ShowInfo()
			{
				Console.WriteLine("정수 : {0}", m_nVal);
				Console.WriteLine("실수 : {0}", m_fVal);
			}
		}

		/**
		 * 자식 클래스
		 */
		private class CE01Derived_12 : CE01Base_12
		{
			public string m_oStr = string.Empty;

			/** 생성자 */
			public CE01Derived_12(int a_nVal,
				float a_fVal, string a_oStr) : base(a_nVal, a_fVal)
			{
				this.m_oStr = a_oStr;
			}

			/** 정보를 출력한다 */
			public override void ShowInfo()
			{
				base.ShowInfo();
				Console.WriteLine("문자열 : {0}", m_oStr);
			}
		}
#endif
	}
}
