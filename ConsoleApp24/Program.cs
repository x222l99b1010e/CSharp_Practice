namespace ConsoleApp24
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//int[] numbers = { 1, 2, 3, 4, 5, 6 };
			//for (int index = 0; index < numbers.Length; index++)
			//{ 
			//	Console.WriteLine(numbers[index]);
			//}

			// 讀姓名（不可為空）
			string readName;
			do
			{
				Console.Write("請輸入姓名：");
				readName = Console.ReadLine()?.Trim() ?? "";
				if (string.IsNullOrWhiteSpace(readName))
				{
					Console.WriteLine("姓名不可空白，請重新輸入。");
				}
			} while (string.IsNullOrWhiteSpace(readName));

			// 讀身高（必須用 int.Parse 並處理錯誤，直到輸入正確）
			int readHeight;
			while (true)
			{
				Console.Write("請輸入身高：");
				string? input = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("身高不可空白，請重新輸入。");
					continue;
				}

				try
				{
					// 要求使用 int.Parse（若格式錯誤會丟例外，我們用 try/catch 來重試）
					readHeight = int.Parse(input.Trim());
					break; // 解析成功，離開迴圈
				}
				catch (FormatException)
				{
					Console.WriteLine("身高格式錯誤，請輸入整數（例如 170）。");
				}
				catch (OverflowException)
				{
					Console.WriteLine("身高數值不合理，請輸入合理範圍內的整數。");
				}
			}

			// 讀性別（0 = male, 1 = female），不可為空且需為 0 或 1
			int readGender;
			while (true)
			{
				Console.Write("請輸入性別(0=male/1=female)：");
				string? g = Console.ReadLine();
				if (string.IsNullOrWhiteSpace(g))
				{
					Console.WriteLine("性別不可空白，請輸入 0 或 1。");
					continue;
				}

				// 這裡使用 TryParse 來檢查輸入是否為整數，之後用 if 判斷是 0 或 1
				if (!int.TryParse(g.Trim(), out readGender))
				{
					Console.WriteLine("性別請輸入數字 0 或 1。");
					continue;
				}

				if (readGender == 0 || readGender == 1)
				{
					break;
				}
				else
				{
					Console.WriteLine("性別只接受 0 或 1，請重新輸入。");
				}
			}

			// 用 if 判斷性別顯示 "先生" 或 "女士"
			string gender = "";
			if (readGender == 0)
			{
				gender = "先生";
			}
			else
			{
				gender = "女士";
			}

			// 最終訊息
			string message = $@"您好，{readName}{gender}
您的身高為 {readHeight}";
			Console.WriteLine(message);
		}
	}
}
