//#define P_E01_EXAMPLE_19_01
//#define P_E01_EXAMPLE_19_02
#define P_E01_EXAMPLE_19_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

/*
 * 리플렉션 (Reflection) 이란?
 * - 클래스의 정보를 기반으로 대상을 제어 할 수 있는 기능을 의미한다. (+ 즉, 리플렉션을 활용하면 
 * 특정 객체의 멤버 존재 여부를 검사하는 등의 명령문을 작성하는 것이 가능하다.)
 * 
 * C# 의 자료형은 모두 클래스이기 때문에 C# 의 모든 데이터는 리플렉션을 지원하며 해당 기능을
 * 통해 특정 데이터를 동적으로 제어하는 것이 가능하다. (+ Ex. 메서드 호출 등등...)
 * 
 * C# 리플렉션 관련 기능
 * - typeof 키워드
 * - GetType 메서드
 * 
 * 위와 같이 C# 에서 특정 데이터의 정보를 가져오고 싶을 경우 typeof 키워드 or GetType 메서드를
 * 활용하면 된다. (+ 즉, typeof 키워드는 정보를 가져오고 싶은 자료형을 직접 명시하는 것이고
 * GetType 메서드는 정보를 가져오고 싶은 데이터를 대상으로 호출한다는 것을 알 수 있다.)
 * 
 * Ex)
 * CSomeClass oSomeObj = new CSomeClass();
 * 
 * Type oTypeA = typeof(CSomeClass);
 * Type oTypeB = oSomeObj.GetType();
 * 
 * 위와 같이 typeof 키워드 or GetType 메서드를 활용하면 Type 클래스 객체가 반환되며 해당 객체를
 * 통해 특정 데이터를 동적으로 제어하는 것이 가능하다.
 * 
 * 단, 특정 데이터를 동적으로 제어하는 것은 해당 데이터를 직접 제어하는 것에 비해 성능이
 * 저하 될 수 있으며 이는 특정 데이터를 동적으로 제어함으로서 C# 컴파일러 최적화가 이루어지지
 * 않기 때문이다. (+ 즉, 동적으로 특정 대상을 제어하는 것은 런타임에 관련 명령문이 동작하기 때문에
 * 최적화 된 명령문을 만들어내지 못한다는 것을 알 수 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_19
{
	/**
	 * Example 19
	 */
	internal class CE01Example_19
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_19_01
			Type oType = typeof(CE01Character_19);

			/*
			 * Binding Flags 를 조합함으로서 다양한 유형의 멤버를 가져오는 것이 가능하다. (+ 즉, 해당 플래그를
			 * 통해 특정 유형의 멤버 정보를 가져와서 제어 할 수 있다는 것을 의미한다.)
			 */
			FieldInfo[] oInfos_PublicField = oType.GetFields(BindingFlags.Public | BindingFlags.Instance);
			FieldInfo[] oInfos_PrivateField = oType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

			MethodInfo[] oInfos_PublicMethod = oType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
			MethodInfo[] oInfos_PrivateMethod = oType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

			Console.WriteLine("=====> 타입 - Public 필드 <=====");

			foreach(var oInfo_Field in oInfos_PublicField)
			{
				Console.WriteLine("{0}", oInfo_Field);
			}

			Console.WriteLine("\n=====> 타입 - Private 필드 <=====");

			foreach(var oInfo_Field in oInfos_PrivateField)
			{
				Console.WriteLine("{0}", oInfo_Field);
			}

			Console.WriteLine("\n=====> 타입 - Public 메서드 <=====");

			foreach(var oInfo_Method in oInfos_PublicMethod)
			{
				Console.WriteLine("{0}", oInfo_Method);
			}

			Console.WriteLine("\n=====> 타입 - Private 메서드 <=====");

			foreach(var oInfo_Method in oInfos_PrivateMethod)
			{
				Console.WriteLine("{0}", oInfo_Method);
			}
#elif P_E01_EXAMPLE_19_02
			var oCharacter = new CE01Character_19(10, 20, 30);
			Type oType = oCharacter.GetType();

			FieldInfo oInfo_HpField = oType.GetField("m_nHp", 
				BindingFlags.NonPublic | BindingFlags.Instance);

			FieldInfo oInfo_AtkField = oType.GetField("m_nAtk",
				BindingFlags.NonPublic | BindingFlags.Instance);

			MethodInfo oInfo_Method = oType.GetMethod("ShowInfo", 
				BindingFlags.Public | BindingFlags.Instance);

			Console.WriteLine("=====> 캐릭터 정보 - 변경 전 <=====");

			/*
			 * C# 리플렉션을 활용하면 메서드 정보만으로 특정 클래스에 존재하는 메서드를 호출하는
			 * 것이 가능하다. (+ 즉, 해당 메서드가 Private 보호 수준으로 명시되어있어도 클래스
			 * 외부에서 해당 메서드를 호출하는 것이 가능하다.)
			 */
			oInfo_Method.Invoke(oCharacter, null);

			/*
			 * 메서드와 마찬가지로 변수 정보를 통해 특정 클래스에 존재하는 멤버 변수를 제어하는
			 * 것이 가능하다. (+ 즉, 해당 정보를 활용하면 특정 멤버 변수에 데이터를 설정하거나
			 * 가져오는 것이 가능하다.)
			 * 
			 * C# 리플렉션을 활용하면 변수 뿐만 아니라 프로퍼티 등 다양한 정보를 가져와서 동적으로
			 * 특정 대상을 제어하는 것이 가능하다.
			 */
			oInfo_HpField.SetValue(oCharacter, 
				(int)oInfo_HpField.GetValue(oCharacter) * 2);

			oInfo_AtkField.SetValue(oCharacter,
				(int)oInfo_AtkField.GetValue(oCharacter) * 2);

			Console.WriteLine("\n=====> 캐릭터 정보 - 변경 후 <=====");
			oInfo_Method.Invoke(oCharacter, null);
#elif P_E01_EXAMPLE_19_03
			/*
			 * Activator 클래스를 이용하면 타입 정보를 기반으로 특정 객체를 생성하는 것이 
			 * 가능하다. (+ 즉, 해당 클래스를 활용하면 리플렉션 시스템 기반으로 객체를 동적으로
			 * 생성한다는 것을 알 수 있다.)
			 * 
			 * 단, 해당 클래스를 통해 생성 할 객체는 반드시 기본 생성자가 구현되어있어야한다.
			 * (+ 즉, 해당 클래스를 통해 생성 할 객체의 특정 생성자를 호출하는 것이 불가능하다는
			 * 것을 알 수 있다.)
			 * 
			 * as 키워드란?
			 * - 참조 형식 데이터를 대상으로 사용 가능한 키워드로서 안전한 다운 캐스팅을 지원한다.
			 * (+ 즉, 다운 캐스팅이 불가능 할 경우 null 참조가 반환된다는 것을 알 수 있다.)
			 * 
			 * 또한 해당 키워드와 유사한 동작을 하는 키워드에는 is 키워드가 존재하며 해당 키워드는
			 * as 키워드와 달리 값 형식과 참조 형식 데이터에 모두 사용하는 것이 가능하며 결과 값이
			 * 참 or 거짓으로 반환된다는 차이점이 존재한다. (+ 즉, is 키워드는 형 변환 가능 여부를
			 * 검사하는 키워드라는 것을 알 수 있다.)
			 */
			var oCharacter = Activator.CreateInstance(typeof(CE01Character_19)) as CE01Character_19;
			oCharacter.m_nLv = 10;

			FieldInfo oInfo_HpField = oCharacter.GetType().GetField("m_nHp",
				BindingFlags.NonPublic | BindingFlags.Instance);

			FieldInfo oInfo_AtkField = oCharacter.GetType().GetField("m_nAtk",
				BindingFlags.NonPublic | BindingFlags.Instance);

			oInfo_HpField.SetValue(oCharacter, 20);
			oInfo_AtkField.SetValue(oCharacter, 30);

			Console.WriteLine("=====> 캐릭터 정보 <=====");
			oCharacter.ShowInfo();
#endif // P_E01_EXAMPLE_19_01
		}

		/**
		 * 캐릭터
		 */
		private class CE01Character_19
		{
			public int m_nLv = 0;
			private int m_nHp = 0;
			private int m_nAtk = 0;

			/** 생성자 */
			public CE01Character_19() : this(0, 0, 0)
			{
				// Do Something
			}

			/** 생성자 */
			public CE01Character_19(int a_nLv, int a_nHp, int a_nAtk)
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
	}
}
