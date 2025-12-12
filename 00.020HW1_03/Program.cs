using System.Text;

namespace _00._020HW1_03
{
	internal class Program
	{
		//呈現1 ~20 中, 
		//若是3的倍數顯示 foo,
		//若是5的倍數顯示bar,
		//若是15的倍數顯示foobar, 其餘顯示數值
		static void Main(string[] args)
		{
			Console.WriteLine(FooBar(20));


			//優點：簡潔、直覺，沒有額外記憶體開銷（每次只印一行）。
			//缺點：可重用性較弱（函式化能讓你在不同地方復用邏輯或測試）。
			for (int i = 1; i <= 20; i++)
			{
				if (i % 15 == 0) Console.WriteLine("foobar");
				else if (i % 5 == 0) Console.WriteLine("bar");
				else if (i % 3 == 0) Console.WriteLine("foo");
				else Console.WriteLine(i);
			}


			// 既可以印出，也能在測試中取用
			foreach (var line in FooBarStream(20))
				Console.WriteLine(line);
		}

		static string FooBar(int x)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 1; i <= x; i++) 
			{
				int foo = 3;
				int bar = 5;
				int foobar = foo * bar;
				
				if (i % foobar == 0)
				{
					sb.AppendLine("foobar");
				}
				else if (i % bar == 0)
				{
					sb.AppendLine("bar");
				}
				else if (i % foo == 0)
				{
					sb.AppendLine("foo");
				}
				else 
				{
					sb.AppendLine(i.ToString());
				}						
			}
			return sb.ToString();		
		}
		/// <summary>
		/// 更靈活且記憶體友善：回傳 IEnumerable<string>（yield）
		/// </summary>
		/// <param name="x"></param>
		/// <returns></returns>
		static IEnumerable<string> FooBarStream(int x)
		{
			for (int i = 1; i <= x; i++)
			{
				if (i % 15 == 0) yield return "foobar";
				else if (i % 5 == 0) yield return "bar";
				else if (i % 3 == 0) yield return "foo";
				else yield return i.ToString();
			}
		}
	}
}
