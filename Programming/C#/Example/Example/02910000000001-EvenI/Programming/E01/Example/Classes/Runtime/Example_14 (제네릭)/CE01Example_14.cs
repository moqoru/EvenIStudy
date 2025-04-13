//#define P_E01_EXAMPLE_14_01
//#define P_E01_EXAMPLE_14_02
#define P_E01_EXAMPLE_14_03

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * 제네릭 (Generic) 이란?
 * - 자료형을 명시하지 않고 메서드 or 클래스를 정의 할 수 있는 기능을 의미한다. (+ 즉, 
 * 제네릭을 활용하면 여러 자료형에 동작하는 메서드 or 클래스를 구현하는 것이 가능하다.)
 * 
 * 제네릭을 통해 정의 된 메서드 or 클래스는 사용 될 때 자료형이 결정되는 특징이 존재한다. (+ 즉, 
 * 메서드는 호출되는 시점에 자료형이 결정되고 클래스는 객체로 생성되는 시점에 자료형이 결정된다는 
 * 것을 알 수 있다.)
 * 
 * 따라서 각 자료형마다 별도로 메서드 or 클래스를 제작 할 필요없이 제네릭은 
 * 하나의 메서드 or 클래스만을 제작하면 된다는 장점이 존재한다.
 * 
 * Ex)
 * void Swap(ref int a_rnValA, ref int a_rnValB)
 * {
 *		// Do Something
 * }
 * 
 * 위의 경우 Swap 메서드는 정수형 데이터만을 전달 받을 수 있기 때문에 만약 다른 자료형에 동작 할 
 * 필요가 있다면 별도의 메서드를 구현해야된다는 단점이 존재한다는 것을 알 수 있다.
 * 
 * C# 제네릭 메서드 구현 방법
 * - 반환 형 + 메서드 이름 + 제네릭 형식 인자 + 매개 변수 + 메서드 몸체
 * 
 * Ex)
 * void Swap<T>(ref T a_rtValA, ref T a_rtValB)
 * {
 *		// Do Something
 * }
 * 
 * int nValA = 10;
 * int nValB = 20;
 * 
 * float fValA = 10.0f;
 * float fValB = 20.0f;
 * 
 * Swap(ref nValA, ref nValB);
 * Swap(ref fValA, ref fValB);
 * 
 * 위와 같은 제네릭 메서드를 구현하면 자료형에 종속되지 않는 메서드를 구현하는 것이 가능하다.
 * 
 * 제네릭 형식 인자란?
 * - 메서드 or 클래스를 정의하는데 필요한 자료형을 임시적으로 대체하기 위한 자료형을 의미한다. 
 * (+ 즉, 제네릭 형식 인자는 메서드 or 클래스가 동작 할 때 실제 자료형은 치환된다는 것을 알 수 
 * 있다.)
 */
namespace Example._02910000000001_EvenI.Programming.E01.Example.Classes.Runtime.Example_14
{
	/**
	 * Example 14
	 */
	internal class CE01Example_14
	{
		/** 초기화 */
		public static void Start(string[] args)
		{
#if P_E01_EXAMPLE_14_01
			int nValA = 10;
			int nValB = 20;

			float fValA = 10.0f;
			float fValB = 20.0f;

			Console.WriteLine("=====> 교환 전 <=====");
			Console.WriteLine("정수 : {0}, {1}", nValA, nValB);
			Console.WriteLine("실수 : {0}, {1}", fValA, fValB);

			/*
			 * 제네릭 메서드는 호출 시점에 자료형을 명시 할 필요가 있다.
			 * 
			 * 만약, 자료형을 명시하지 않으면 C# 컴파일러에 의해서 자동으로 자료형이 명시되며 이때 
			 * C# 컴파일러는 매개 변수에 전달되는 데이터를 기반으로 자료형을 결정한다. (+ 즉, 
			 * 매개 변수의 데이터를 통해 자료형을 결정 할 수 없을 경우에는 반드시 명시적으로 
			 * 자료형을 지정해줘야한다는 것을 알 수 있다.)
			 */
			E01Swap_14(ref nValA, ref nValB);
			E01Swap_14<float>(ref fValA, ref fValB);

			Console.WriteLine("\n=====> 교환 후 <=====");
			Console.WriteLine("정수 : {0}, {1}", nValA, nValB);
			Console.WriteLine("실수 : {0}, {1}", fValA, fValB);
#elif P_E01_EXAMPLE_14_02
			var oRandom = new Random();
			var oListValues = new List<int>();

			for(int i = 0; i < 10; ++i)
			{
				oListValues.Add(oRandom.Next(1, 100));
			}

			Console.WriteLine("=====> 정렬 전 <=====");
			E01PrintValues_14(oListValues);

			E01SortValues_14(oListValues);

			Console.WriteLine("\n=====> 정렬 후 <=====");
			E01PrintValues_14(oListValues);
#elif P_E01_EXAMPLE_14_03
			IE01Writer_Data_14 oWriter_File = new CE01Writer_File_14("../../Resources/Example_14/Example_14_03.txt");
			IE01Writer_Data_14 oWriter_Console = new CE01Writer_Console_14();

			for(int i = 0; i < 10; ++i)
			{
				oWriter_File.WriteStr("Hello, World!");
				oWriter_Console.WriteStr("Hello, World!");
			}
#endif // #if P_E01_EXAMPLE_14_01
		}

#if P_E01_EXAMPLE_14_01
		/** 값을 교환한다 */
		private static void E01Swap_14<T>(ref T a_rtValA, ref T a_rtValB)
		{
			T tTemp = a_rtValA;
			a_rtValA = a_rtValB;
			a_rtValB = tTemp;
		}
#elif P_E01_EXAMPLE_14_02
		/*
		 * C# 제네릭 형식 인자 제한 방법
		 * - where T : class				<- 참조 형식 자료형으로 제한
		 * - where T : struct				<- 값 형식 자료형으로 제한
		 * - where T : SomeClass			<- 해당 클래스를 상속하는 자료형으로 제한
		 * - where T : SomeInterface	<- 해당 인터페이스를 따르는 자료형으로 제한
		 * 
		 * C# 제네릭 메서드 or 제네릭 클래스는 기본적으로 모든 자료형에 동작하도록 정의 될 필요가 
		 * 있다.
		 * 
		 * 따라서 특정 자료형에만 동작하는 메서드 or 클래스를 정의하고 싶다면 where 키워드를 
		 * 이용해서 제네릭 형식 인자의 타입을 제한 할 필요가 있다.
		 */
		/** 값을 오름차순 정렬한다 */
		private static void E01SortValues_14<T>(List<T> a_oListValues) where T : IComparable
		{
			for(int i = 0; i < a_oListValues.Count - 1; ++i)
			{
				int nIdx = i;

				for(int j = i; j < a_oListValues.Count; ++j)
				{
					// 정렬이 필요 할 경우
					if(a_oListValues[j].CompareTo(a_oListValues[nIdx]) < 0)
					{
						nIdx = j;
					}
				}

				T tTemp = a_oListValues[i];
				a_oListValues[i] = a_oListValues[nIdx];
				a_oListValues[nIdx] = tTemp;
			}
		}

		/** 값을 출력한다 */
		private static void E01PrintValues_14<T>(List<T> a_oListValues)
		{
			for(int i = 0; i < a_oListValues.Count; ++i)
			{
				Console.Write("{0}, ", a_oListValues[i]);
			}

			Console.WriteLine();
		}
#elif P_E01_EXAMPLE_14_03
		/*
		 * 인터페이스란?
		 * - 특정 대상과 상호 작용을 할 수 있는 수단을 의미한다. (+ 즉, 객체 지향 프로그래밍에서 
		 * 인터페이스는 특정 객체가 지니고 있는 메서드라는 것을 알 수 있다.)
		 * 
		 * C# 은 메서드를 통해서 특정 객체와 상호 작용을 하기 때문에 C# 에서 인터페이스는 단순한 
		 * 메서드의 목록이라는 것을 알 수 있다.
		 * 
		 * C# 인터페이스 정의 방법
		 * - interface + 인터페이스 이름 + 메서드 목록
		 * 
		 * Ex)
		 * inteface ISomeInterface
		 * {
		 *		void SomeMethod();
		 * }
		 * 
		 * 위와 같이 인터페이스는 단순한 메서드의 목록이기 때문에 메서드 몸체를 정의하는 것이 
		 * 불가능하다. (+ 즉, 추상 메서드와 같이 메서드의 선언만 존재한다는 것을 알 수 있다.)
		 * 
		 * C# 의 클래스는 특정 인터페이스를 따르는 (상속) 것이 가능하며 클래스가 특정 인터페이스를 
		 * 따르고 있을 경우 해당 클래스는 반드시 인터페이스에 존재하는 모든 메서드를 구현해줘야한다. 
		 * (+ 즉, 하나라도 구현하지 않으면 컴파일 에러가 발생한다는 것을 알 수 있다.)
		 * 
		 * 또한 인터페이스는 상속과 달리 여러 인터페이스를 따르는 것이 가능하다.
		 * (+ 즉, 하나의 클래스가 여러 인터페이스를 따르는 것이 가능하다.)
		 * 
		 * Ex)
		 * interface ISomeInterfaceA
		 * {
		 *		// Do Something
		 * }
		 * 
		 * interface ISomeInterfaceB
		 * {
		 *		// Do Something
		 * }
		 * 
		 * class CSomeClass : ISomeInterfaceA, ISomeInterfaceB
		 * {
		 *		// Do Something
		 * }
		 * 
		 * 위와 같이 클래스가 여러 인터페이스를 따름으로서 여러가지 방식으로 해당 클래스를 통해 
		 * 생성 된 객체와 상호 작용을 하는 것이 가능하다.
		 */
		/**
		 * 데이터 출력 인터페이스
		 */
		private interface IE01Writer_Data_14
		{
			/** 문자열을 출력한다 */
			void WriteStr(string a_oStr);
		}

		/**
		 * 파일 출력자
		 */
		private class CE01Writer_File_14 : IE01Writer_Data_14
		{
			private StreamWriter m_oWriter = null;

			/** 생성자 */
			public CE01Writer_File_14(string a_oPath_File)
			{
				var oPath_Dir = Path.GetDirectoryName(a_oPath_File);
				Directory.CreateDirectory(oPath_Dir);

				var oWStream_File = File.Open(a_oPath_File,
					FileMode.Create, FileAccess.Write);

				this.m_oWriter = new StreamWriter(oWStream_File);
			}

			/** 문자열을 출력한다 */
			public void WriteStr(string a_oStr)
			{
				m_oWriter.WriteLine(a_oStr);
				m_oWriter.Flush();
			}
		}

		/**
		 * 콘솔 출력자
		 */
		private class CE01Writer_Console_14 : IE01Writer_Data_14
		{
			/** 문자열을 출력한다 */
			public void WriteStr(string a_oStr)
			{
				Console.WriteLine(a_oStr);
			}
		}
#endif // #if P_E01_EXAMPLE_14_01
	}
}
