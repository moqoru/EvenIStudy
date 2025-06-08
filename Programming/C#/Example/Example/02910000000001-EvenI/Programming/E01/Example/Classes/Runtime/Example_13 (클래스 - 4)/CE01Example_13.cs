//#define P_E01_EXAMPLE_13_01
//#define P_E01_EXAMPLE_13_02
#define P_E01_EXAMPLE_13_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 추상 클래스란?
 * - 일반적인 클래스와 달리 직접 객체화 시키는 것이 불가능한 클래스를 의미한다. (+ 즉, 
 * 추상 클래스는 new 키워드를 통해서 직접 객체화 시키는 것은 불가능하며 자식 클래스를 통해 
 * 간접적으로 객체화 시키는 것만 가능하다는 것을 알 수 있다.)
 * 
 * 따라서 추상 클래스는 다른 클래스에 의해 상속이 되기 위한 목적으로 주로 활용된다. (+ 즉, 
 * 추상 클래스는 상속을 전제로하는 클래스라는 것을 알 수 있다.)
 * 
 * C# 추상 클래스 정의 방법
 * - abstract + class + 클래스 이름 + 클래스 멤버
 * 
 * Ex)
 * abstract class CSomeClass
 * {
 *		// Do Something
 * }
 * 
 * 위와 같이 클래스 키워드 앞에 abstract 키워드를 명시하면 해당 클래스는 직접 객체화 시킬 수 없는 
 * 추상 클래스라는 것을 의미한다.
 * 
 * 정적 클래스란?
 * - 일반적인 클래스와 달리 정적 멤버만을 정의 할 수 있는 클래스를 의미한다. (+ 즉, 정적 클래스에 
 * 일반적인 멤버를 정의하면 컴파일 에러가 발생한다는 것을 알 수 있다.)
 * 
 * 따라서 정적 클래스는 new 키워드를 통해 객체화 시키는 것이 불가능하며 다른 클래스에서 상속을 하는 
 * 것도 불가능하다는 특징이 존재한다. (+ 즉, 정적 클래스는 상속을 통한 간접적인 객체화도 
 * 불가능하다는 것을 알 수 있다.)
 * 
 * C# 정적 클래스 정의 방법
 * - static + class + 클래스 + 클래스 멤버
 * 
 * Ex)
 * static class CSomeClass_Static
 * {
 *		// Do Something
 * }
 * 
 * 위와 같이 클래스 키워드 앞에 static 키워드를 명시하면 해당 클래스는 정적 클래스라는 것을 
 * 의미한다.
 * 
 * 정적 클래스는 주로 상수를 선언하거나 확장 메서드를 구현하는 활용된다.
 * 
 * 확장 메서드란?
 * - 특정 클래스가 지니고 있는 기능을 메서드의 형태로 확장 할 수 있는 기능을 의미한다. (+ 즉, 
 * 확장 메서드를 활용하면 기존 클래스를 수정하거나 상속하지 않고도 기존 클래스에 원하는 기능을 
 * 추가하는 것이 가능하다.)
 * 
 * 단, 확장 메서드는 클래스 내부에 존재하는 멤버가 아니기 때문에 클래스에 존재하는 protected 
 * 보호 수준 이상의 멤버에는 접근하는 것이 불가능하다. (+ 즉, 기존 클래스에 public 멤버가 없다면 
 * 확장 메서드를 통한 기능의 확장이 불가능하다는 것을 알 수 있다.)
 * 
 * Ex)
 * static class CSomeClass_Static
 * {
 *		static void SomeMethod_Extension(this int a_nSender)
 *		{
 *				// Do Something
 *		}
 * }
 * 
 * 위와 같이 확장 메서드는 정적 클래스 내부에만 구현하는 것이 가능하며 메서드의 첫번째 매개 변수는 
 * this 키워드를 명시함으로서 어떤 자료형의 확장 메서드라는 것을 알릴 필요가 있다. (+ 즉, 
 * this 키워드를 명시하지 않으면 단순한 정적 메서드라는 것을 알 수 있다.)
 * 
 * 이렇게 구현 된 확장 메서드는 마치 해당 클래스의 멤버 메서드인 것처럼 사용하는 것이 가능하다.
 * 
 * Ex)
 * int nVal = 0;
 * nVal.SomeMethod_Extension();
 * 
 * 위와 같이 확장 메서드는 . (멤버 지정 연산자) 를 통해 호출하는 것이 가능하다.
 * 
 * 연산자 오버로딩이란?
 * - 객체를 대상으로 산술 연산자와 같은 연산자를 사용할 수 있게 해주는 기능을 의미한다. (+ 즉, 
 * 연산자 오버로딩을 활용하면 객체를 일반적인 데이터처럼 제어하는 것이 가능하다.)
 * 
 * Ex)
 * class CSomeClass
 * {
 *		public static void operator +(CSomeClass a_oLhs, CSomeClass a_oRhs)
 *		{
 *			// Do Something
 *		}
 * }
 * 
 * CSomeClass oSomeObjA = new CSomeClass();
 * CSomeClass oSomeObjB = new CSomeClass();
 * 
 * CSomeClass oResult = oSomeObjA + oSomeObjB;
 * 
 * 위와 같이 연산자 오버로딩은 operator 계열의 메서드로 구현하는 것이 가능하며 특정 연산자에 대한 
 * operator 메서드가 구현되면 C# 컴파일러는 객체를 대상은 해당 연산자를 사용했을 때 매칭되는 
 * operator 메서드를 호출해준다.
 */
/**
 * 확장 클래스
 */
public static class CE01Extension_13
{
	/** 합계를 반환한다 */
	public static int E01ExGetVal_Sum_13(this List<int> a_oSender)
	{
		int nVal_Sum = 0;

		for(int i = 0; i < a_oSender.Count; ++i)
		{
			nVal_Sum += a_oSender[i];
		}

		return nVal_Sum;
	}

	/** 값을 출력한다 */
	public static void E01ExPrintValues_13(this List<int> a_oSender)
	{
		for(int i = 0; i < a_oSender.Count; ++i)
		{
			Console.Write("{0}, ", a_oSender[i]);
		}

		Console.WriteLine();
	}
}

namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_13
{
	/**
	 * Example 13
	 */
	internal class CE01Example_13
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_13_01
			CE01Base_13 oDerivedA = new CE01Derived_13();
			oDerivedA.m_nVal = 10;

			CE01Derived_13 oDerivedB = new CE01Derived_13();
			oDerivedB.m_nVal = 20;
			oDerivedB.m_fVal = 3.14f;

			/*
			 * 아래와 같이 CE01Base_13 클래스는 추상 클래스이기 때문에 new 키워드를 통해 직접적으로 
			 * 객체화 시키는 것은 불가능하다는 것을 알 수 있다. (+ 즉, 컴파일 에러가 발생한다.)
			 */
			//CE01Base_13 oBase = new CE01Base_13();

			Console.WriteLine("=====> 자식 클래스 - A <=====");
			oDerivedA.ShowInfo();

			Console.WriteLine("=====> 자식 클래스 - B <=====");
			oDerivedB.ShowInfo();
#elif P_E01_EXAMPLE_13_02
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 리스트 <=====");
			oListValues.E01ExPrintValues_13();

			Console.WriteLine("\n합계 : {0}", oListValues.E01ExGetVal_Sum_13());
#elif P_E01_EXAMPLE_13_03
			CE01Vec_13 oVecA = new CE01Vec_13(10.0f, 0.0f, 0.0f);
			CE01Vec_13 oVecB = new CE01Vec_13(0.0f, 10.0f, 0.0f);

			oVecA.Normalize();
			oVecB.Normalize();

			Console.WriteLine("=====> 연산자 오버로딩 <=====");
			Console.WriteLine("{0} + {1} = {2}", oVecA, oVecB, oVecA + oVecB);
			Console.WriteLine("{0} - {1} = {2}", oVecA, oVecB, oVecA - oVecB);
			Console.WriteLine("{0} * {1} = {2}", oVecA, 10.0f, oVecA * 10.0f);
			Console.WriteLine("{0} / {1} = {2}", oVecA, 10.0f, oVecA / 10.0f);
#endif
		}

#if P_E01_EXAMPLE_13_01
		/**
		 * 부모 클래스
		 */
		private abstract class CE01Base_13
		{
			public int m_nVal = 0;

			/*
			 * 추상 (순수 가상) 메서드란?
			 * - 가상 메서드의 일종으로서 일반적인 가상 메서드와 달리 메서드 몸체를 지닐 수 없는 
			 * 메서드를 의미한다. (+ 즉, 메서드 몸체가 존재하기 않기 때문에 미완성 된 메서드라는 
			 * 것을 알 수 있다.)
			 * 
			 * 특정 클래스가 추상 메서드를 하나라도 지니고 있다면 해당 클래스는 직접적으로 객체화 
			 * 시키는 것이 불가능 한 추상 클래스가 되는 특징이 존재한다.
			 * 
			 * 따라서 추상 메서드는 자식 클래스에서 반드시 재정의 할 필요가 있다. (+ 즉, 
			 * 자식 클래스에서 부모 클래스의 추상 메서드를 재정의 함으로서 해당 메서드가 
			 * 호출되었을 때 어떤 동작을 할지를 결정해줘야한다는 것을 알 수 있다.)
			 */
			/** 정보를 출력한다 */
			public abstract void ShowInfo();
		}

		/**
		 * 자식 클래스
		 */
		private class CE01Derived_13 : CE01Base_13
		{
			public float m_fVal = 0.0f;

			/** 정보를 출력한다 */
			public override void ShowInfo()
			{
				Console.WriteLine("정수 : {0}", m_nVal);
				Console.WriteLine("실수 : {0}", m_fVal);
			}
		}
#elif P_E01_EXAMPLE_13_03
		/**
		 * 벡터
		 */
		private class CE01Vec_13
		{
			public float X { get; private set; } = 0.0f;
			public float Y { get; private set; } = 0.0f;
			public float Z { get; private set; } = 0.0f;

			public float Length =>
				(float)Math.Sqrt(Math.Pow(this.X, 2.0) + Math.Pow(this.Y, 2.0));

			/** 생성자 */
			public CE01Vec_13(float a_fX = 0.0f, float a_fY = 0.0f, float a_fZ = 0.0f)
			{
				this.X = a_fX;
				this.Y = a_fY;
				this.Z = a_fZ;
			}

			/** 정규화한다 */
			public void Normalize()
			{
				float fLength = this.Length;

				this.X /= fLength;
				this.Y /= fLength;
				this.Z /= fLength;
			}

			/** 문자열로 변환한다 */
			public override string ToString()
			{
				return string.Format("({0}, {1}, {2})", this.X, this.Y, this.Z);
			}

			/** operator + */
			public static CE01Vec_13 operator +(CE01Vec_13 a_oLhs, CE01Vec_13 a_oRhs)
			{
				return new CE01Vec_13(a_oLhs.X + a_oRhs.X,
					a_oLhs.Y + a_oRhs.Y, a_oLhs.Z + a_oRhs.Z);
			}

			/** operator - */
			public static CE01Vec_13 operator -(CE01Vec_13 a_oLhs, CE01Vec_13 a_oRhs)
			{
				return new CE01Vec_13(a_oLhs.X - a_oRhs.X,
					a_oLhs.Y - a_oRhs.Y, a_oLhs.Z - a_oRhs.Z);
			}

			/** operator * */
			public static CE01Vec_13 operator *(CE01Vec_13 a_oLhs, float a_fRhs)
			{
				return new CE01Vec_13(a_oLhs.X * a_fRhs,
					a_oLhs.Y * a_fRhs, a_oLhs.Z * a_fRhs);
			}

			/** operator / */
			public static CE01Vec_13 operator /(CE01Vec_13 a_oLhs, float a_fRhs)
			{
				return new CE01Vec_13(a_oLhs.X / a_fRhs,
					a_oLhs.Y / a_fRhs, a_oLhs.Z / a_fRhs);
			}
		}
#endif
	}
}
