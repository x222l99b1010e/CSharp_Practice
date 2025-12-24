namespace _00._020HW2_isPrime
{
	internal class Program
	{
		//撰寫一支函數 IsPrime(int number), 傳回 bool, 表示 number 是不是質數, 若是質數, 傳回true, 例如
		//- 輸入 負數, 0, 或1, 傳回 false
		//- 輸入 2, 3, 5, 7, 或 11, 傳回 true
		//- 輸入 4, 6, 8, 9, 10, 12, 傳回 false
		//- 利用迴圈, 顯示 3~100中的質數, 在迴圈裡叫用上述函數來判斷是否為質數
		static void Main(string[] args)
		{
			int count = 0;
			Console.WriteLine("2~1000 之間的質數有：");

			for (int i = 2; i <= 1000; i++)
			{
				if (IsPrime(i))
				{
					// 使用 {0, 4} 讓數字對齊（佔 4 格寬度）
					Console.Write($"{i,4} ");
					count++;

					// 每印 10 個數字就換行，畫面更整齊
					if (count % 10 == 0) Console.WriteLine();
				}
			}
			Console.WriteLine("\n\n-----------------------------");
			Console.WriteLine($"統計結果：2~1000 之間共有 {count} 個質數。");

			int target = 937427;
			if (IsPrime(target))
			{
				Console.WriteLine($"{target}質數");
			}
			else
			{
				Console.WriteLine($"{target}非質數");
			}
			//============================================
			int target1 = 937427;
			string result = IsPrime(target1) ? "是質數" : "不是質數";

			Console.WriteLine($"{target1} {result}");
			//============================================
			Console.Write("請輸入一個數字來檢查是否為質數: ");
			string input = Console.ReadLine();

			if (int.TryParse(input, out int number)) // 嘗試將字串轉為數字
			{
				string status = IsPrime(number) ? "是質數" : "非質數";//使用三元運算子做處理
				Console.WriteLine($"檢查結果：{number} => {status}");
			}
			else
			{
				Console.WriteLine("輸入錯誤，請輸入整數數字。");
			}
		}
		static bool IsPrime(int n)
		{			
			if (n <= 1) return false;
			if (n == 2) return true;
			if (n % 2 == 0) return false;

			int limit = (int)Math.Sqrt(n);
			for (int i = 3; i <= limit; i += 2)
			{
				if (n % i == 0) return false;
			}
			return true;			
		}
	}
}
