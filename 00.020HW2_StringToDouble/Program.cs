namespace _00._020HW2_StringToDouble
{
	internal class Program
	{
		//字串轉數值, 數值計算
		//寫一個主控台應用程式, 由使用者輸入字串, 並顯示它是否能順利轉型為 double, 如果可以, 顯示其數字乘以 2 的值
		static void Main(string[] args)
		{
			//將顯示結果交由Main
			//if (StringToDouble(out double finalResult))
			//{
			//	Console.WriteLine($"轉換結果為{finalResult}");
			//}
			//else
			//{
			//	Console.WriteLine("轉換失敗，請輸入數字！");
			//}

			//=============================================================//
			double finalResult2 = StringToDouble2();//非null之作法

			if (!double.IsNaN(finalResult2)) // 判斷「不是 NaN」才代表成功
			{
				Console.WriteLine($"計算結果：{finalResult2}");
			}
			else
			{
				Console.WriteLine("轉換失敗，輸入無效。");
			}
			//=============================================================//
			double? finalResult21 = StringToDouble21();//允許null之作法

			if (finalResult21.HasValue) // 判斷「不是 NaN」才代表成功
			{
				Console.WriteLine($"計算結果：{finalResult21}");
			}
			else
			{
				Console.WriteLine("轉換失敗，輸入無效。");
			}

			//=============================================================//
			//string finalMessage = StringToDouble3(); // 接收字串
			//Console.WriteLine(finalMessage);        // 直接印出結果
		}

		public static bool StringToDouble(out double result)
		{
			Console.Write("請輸入欲轉換字串：");
			string input = Console.ReadLine()?.Trim() ?? "";

			bool isSuccess = double.TryParse(input, out result);
			if (isSuccess)
			{
				result *= 2;
			}
			return isSuccess; // 回傳成功或失敗
		}

		// 方法定義
		public static double StringToDouble2()
		{
			Console.Write("請輸入字串：");
			string input = Console.ReadLine()?.Trim() ?? "";

			if (double.TryParse(input, out double result))
			{
				return result * 2;
			}

			return double.NaN; // 代表失敗
		}
		public static double? StringToDouble21() // 注意這裡要有問號
		{
			Console.Write("請輸入字串：");
			string input = Console.ReadLine()?.Trim() ?? "";

			if (double.TryParse(input, out double result))
			{
				return result * 2;
			}

			return null; // 既然是 double?，失敗就該回傳 null
		}
		public static string StringToDouble3()
		{
			Console.Write("請輸入一個字串嘗試是否能轉為Double(無視字串前後空白鍵)：");
			string input = Console.ReadLine()?.Trim() ?? "";//將前後空白鍵去除
			bool isSuccess = double.TryParse(input, out double result);
			string finalResult;
			if (isSuccess)
			{
				result *= 2;
				finalResult = $"輸出結果：{result.ToString()}";
			}
			else
			{
				finalResult =  "輸入非有效數字!";
			}
			return finalResult;
		}
	}
}
