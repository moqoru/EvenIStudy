//#define P_E01_EXAMPLE_19_01
//#define P_E01_EXAMPLE_19_02
#define P_E01_EXAMPLE_19_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.CompilerServices;

/*
 * 애트리뷰트 (Attribute) 란?
 * - 명령문에 부가적인 정보를 명시 할 수 있는 기능을 의미한다. (+ 즉, 해당 기능을 활용하면
 * 특정 명령문에 명시한 부가적인 정보를 런타임에 가져와서 활용하는 것이 가능하다.)
 * 
 * C# 은 여러 애트리뷰트를 제공하지만 필요에 따라 애트리뷰트를 직접 정의하는 것이 가능하다. (+ 즉,
 * 제작하는 프로그램에 맞게 커스텀 애트리뷰트를 정의해서 활용하는 것이 가능하다.)
 * 
 * C# 애트리뷰트 정의 방법
 * - 클래스 정의 + Attribute 클래스 상속
 * 
 * Ex)
 * class CSomeAttribute : Attribute
 * {
 *		public string m_oInfo = string.Empty;
 *		
 *		public CSomeAttribute(string a_oInfo)
 *		{
 *			this.m_oInfo = a_oInfo;
 *		}
 * }
 * 
 * [CSomeAttribute("Attribute")]
 * class CSomeClass
 * {
 *		// Do Something
 * }
 * 
 * 위와 같이 정의 된 애트리뷰트는 클래스 등에 명시해서 활용하는 것이 가능하다. (+ 즉, 애트리뷰트가
 * 명시 된 클래스의 타입 정보를 통해 해당 애트리뷰트에 접근하는 것이 가능하다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_20
{
	/**
	 * Example 20
	 */
	internal class CE01Example_20
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_19_01
			var oCharacter = new CE01Character_20(10, 20, 30);

			/*
			 * 아래의 경우 Obsolete 애트리뷰트가 명시 된 메서드를 호출하기 때문에 컴파일 에러가
			 * 발생한다는 것을 알 수 있다.
			 */
			//oCharacter.ShowInfo_Old();

			Console.WriteLine("=====> 캐릭터 정보 <=====");
			oCharacter.ShowInfo_New();
#elif P_E01_EXAMPLE_19_02
			var oCharacter = new CE01Character_20(10, 20, 30);

			Console.WriteLine("=====> 캐릭터 정보 <=====");
			oCharacter.ShowInfo();
#elif P_E01_EXAMPLE_19_03
			var oCharacter = new CE01Character_20(10, 20, 30);

			Console.WriteLine("=====> 캐릭터 정보 <=====");
			oCharacter.ShowInfo();

			Console.WriteLine("\n=====> 애트리뷰트 <=====");

			/*
			 * GetCustomAttributes 메서드를 활용하면 특정 타입에 명시 된 커스텀 애트리뷰트를
			 * 가져오는 것이 가능하다. (+ 즉, 해당 메서드를 활용하면 특정 애트리뷰트의 존재 여부를
			 * 검사하는 것이 가능하다.)
			 */
			foreach(var oAttribute in Attribute.GetCustomAttributes(oCharacter.GetType()))
			{
				Console.WriteLine(oAttribute as CE01Attribute_20);
			}
#endif // P_E01_EXAMPLE_19_01
		}

#if P_E01_EXAMPLE_19_01
		/**
		 * 캐릭터
		 */
		private class CE01Character_20
		{
			private int m_nLv = 0;
			private int m_nHp = 0;
			private int m_nAtk = 0;

			/** 생성자 */
			public CE01Character_20(int a_nLv, int a_nHp, int a_nAtk)
			{
				this.m_nLv = a_nLv;
				this.m_nHp = a_nHp;
				this.m_nAtk = a_nAtk;
			}

			/*
			 * Obsolete 애트리뷰트란?
			 * - 클래스나 멤버 등의 사용을 금지 시키는 애트리뷰트이다. (+ 즉, 해당 애트리뷰트를
			 * 활용하면 특정 명령문의 사용을 사전에 차단하는 것이 가능하다.)
			 */
			/** 정보를 출력한다 */
			[Obsolete("해당 메서드는 더이상 사용되지 않습니다.", true)]
			public void ShowInfo_Old()
			{
				// Do Something
			}

			/** 정보를 출력한다 */
			public void ShowInfo_New()
			{
				Console.WriteLine("레벨 : {0}", m_nLv);
				Console.WriteLine("체력 : {0}", m_nHp);
				Console.WriteLine("공격력 : {0}", m_nAtk);
			}
		}
#elif P_E01_EXAMPLE_19_02
		/**
		 * 캐릭터
		 */
		private class CE01Character_20
		{
			private int m_nLv = 0;
			private int m_nHp = 0;
			private int m_nAtk = 0;

			/** 생성자 */
			public CE01Character_20(int a_nLv, int a_nHp, int a_nAtk)
			{
				this.m_nLv = a_nLv;
				this.m_nHp = a_nHp;
				this.m_nAtk = a_nAtk;
			}

			/** 정보를 출력한다 */
			public void ShowInfo([CallerLineNumber] int a_nNumber_Line = 0,
				[CallerFilePath] string a_oPath_File = "", [CallerMemberName] string a_oName_Member = "")
			{
				Console.WriteLine("레벨 : {0}", m_nLv);
				Console.WriteLine("체력 : {0}", m_nHp);
				Console.WriteLine("공격력 : {0}", m_nAtk);

				Console.WriteLine("\n-----> 호출 정보 <-----");

				Console.WriteLine("{0}({1}): {2}",
					a_oPath_File, a_nNumber_Line, a_oName_Member);
			}
		}
#elif P_E01_EXAMPLE_19_03
		/**
		 * 애트리뷰트
		 */
		private class CE01Attribute_20 : Attribute
		{
			public string Info { get; private set; } = string.Empty;

			/** 생성자 */
			public CE01Attribute_20(string a_oInfo)
			{
				this.Info = a_oInfo;
			}

			/** 문자열을 반환한다 */
			public override string ToString()
			{
				return this.Info;
			}
		}

		/**
		 * 캐릭터
		 */
		[CE01Attribute_20("Attribute")]
		private class CE01Character_20
		{
			private int m_nLv = 0;
			private int m_nHp = 0;
			private int m_nAtk = 0;

			/** 생성자 */
			public CE01Character_20(int a_nLv, int a_nHp, int a_nAtk)
			{
				this.m_nLv = a_nLv;
				this.m_nHp = a_nHp;
				this.m_nAtk = a_nAtk;
			}

			/** 정보를 출력한다 */
			public void ShowInfo()
			{
				Console.WriteLine("레벨 : {0}", m_nLv);
				Console.WriteLine("체력 : {0}", m_nHp);
				Console.WriteLine("공격력 : {0}", m_nAtk);
			}
		}
#endif // P_E01_EXAMPLE_19_01
	}
}
