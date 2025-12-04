namespace _00._020作業1_05
{
	internal class Program
	{

		//寫一個主控台應用程式, 由使用者輸入二次字串, 並顯示二次字串內容是否相同(不拘大小寫,
		//例如 Allen, ALLEN, allen , 都視為相同),若不會,可以問ChatGPT
		static void Main(string[] args)
		{
			Console.Write("請輸入第1個字串(英文，不論大小寫視為相同)：");
			string? string1 = Console.ReadLine();
			Console.Write("請輸入第2個字串(英文，不論大小寫視為相同)：");
			string? string2 = Console.ReadLine();

			if (String.IsNullOrWhiteSpace(string2) || String.IsNullOrWhiteSpace(string1))
			{ 
				Console.WriteLine("內容空白。"); 
			}
			else if (string1.ToUpper() == string2.ToUpper()) Console.WriteLine("兩次輸入相同");
			else Console.WriteLine("兩次輸入不相同");

			//較好的寫法
			// 第1個字串輸入
			do
			{
				Console.Write("請輸入第1個字串(英文，不論大小寫視為相同)：");
				string1 = Console.ReadLine()?.Trim() ?? "";
				//?? 表示「如果左邊是 null，就用右邊的值」。
				//所以如果前面得到 null，就改成空字串 ""。
				//Console.ReadLine()?.Trim() ?? ""
				//→ 讀取使用者輸入，去掉前後空白，如果是 null 就給空字串。
				//1.Console.ReadLine() → 取得使用者輸入(可能為 null)
				//2. ?.Trim()           → 如果不為 null，就去掉前後空白
				//3. ?? ""              → 如果結果是 null，就改成空字串 ""
				if (string.IsNullOrWhiteSpace(string1))
					Console.WriteLine("第1個字串不可空白，請重新輸入。");
			} while (string.IsNullOrWhiteSpace(string1));

			// 第2個字串輸入
			do
			{
				Console.Write("請輸入第2個字串(英文，不論大小寫視為相同)：");
				string2 = Console.ReadLine()?.Trim() ?? "";
				if (string.IsNullOrWhiteSpace(string2))
					Console.WriteLine("第2個字串不可空白，請重新輸入。");
			} while (string.IsNullOrWhiteSpace(string2));

			// 比較字串是否相同（忽略大小寫）
			if (string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase))
				Console.WriteLine("兩次輸入相同");
			else
				Console.WriteLine("兩次輸入不相同");

			//一次迴圈同時輸入兩個字串
			while (true)
			{
				// 輸入第一個字串
				Console.Write("請輸入第1個字串(英文，不論大小寫視為相同)：");
				string1 = Console.ReadLine()?.Trim() ?? "";

				// 輸入第二個字串
				Console.Write("請輸入第2個字串(英文，不論大小寫視為相同)：");
				string2 = Console.ReadLine()?.Trim() ?? "";

				// 判斷是否為空白
				if (string.IsNullOrWhiteSpace(string1) || string.IsNullOrWhiteSpace(string2))
				{
					Console.WriteLine("輸入不可空白，請重新輸入。\n");
					continue; // 重新迴圈
				}

				// 比較字串是否相同（忽略大小寫）
				if (string.Equals(string1, string2, StringComparison.OrdinalIgnoreCase))
					Console.WriteLine("兩次輸入相同");
				else
					Console.WriteLine("兩次輸入不相同");

				break; // 比對完成，跳出迴圈
			}
		}
	}
}
