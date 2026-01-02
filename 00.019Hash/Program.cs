using Microsoft.AspNetCore.Identity; // 引用命名空間

namespace _00._019Hash
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 實例化雜湊工具
			var hasher = new PasswordHasher<string>();

			// 產生雜湊密碼
			// 第一個參數是 User 物件（在 Console 練習中可以隨便給個字串）
			// 第二個參數是原始密碼
			string hash = hasher.HashPassword("user123", "123456");

			// 輸出結果到螢幕，方便你複製
			System.Console.WriteLine("產出的雜湊值為：");
			System.Console.WriteLine(hash);

			// 避免程式跑完立刻關閉
			System.Console.ReadKey();
		}
	}
}