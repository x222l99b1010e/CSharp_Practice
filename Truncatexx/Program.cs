using System;
using System.Data.SqlTypes;

namespace _01._30._10_Output
{
	//請設法找出以下程式的所有錯誤之處, 並讓它能順利執行
	//void Main()
	//{
	//	var value = string.Empty;
	//	var result = Truncatexx(value, -2);
	//	Console.WriteLine(result);
	//}
	//string Truncatexx(string value, int lenght)
	//{
	//	return value.Substring(0, lenght);
	//}
	//提示:
	//所謂的錯誤, 包含程式無法順利運行, 也可能拼錯字或命名不恰當
	internal class Program
	{
		static void Main(string[] args)
		{
				var value = "hello";
				var result = Truncatexx(value, 3);
				Console.WriteLine(result);		
		}
		static string Truncatexx(string value, int length)
		{
			if (string.IsNullOrEmpty(value)) return string.Empty;
			if (length <= 0) return string.Empty;
			return length >= value.Length ? value : value.Substring(0, length);
		}
		//靜態（static）在類別層級，共用；非靜態在實例（object）層級，需要 new 出來後才能使用。
		//所以錯誤就是在提醒你：「要先有物件參考（例如 new Program()）才能使用這個非靜態的方法，或改成 static。」
	}
	//這一題老師到底在考你什麼？
	//這題是典型「找錯題」，想考以下概念：

	//✅ 1. C# 方法不能這樣宣告
	//不能在方法中直接宣告另一個方法（除非使用 local function，但也要注意命名衝突）
	//函式位置要正確放在 class 內，而不是方法內

	//✅ 2. Main 的意義（程式入口點）
	//老師希望你知道：
	//static void Main(string[] args) 才是入口
	//不是你想叫 Main 就叫 Main

	//✅ 3. 拼字與命名規範
	//lenght → length
	//大量初學者常犯錯，老師刻意放進題目

	//✅ 4. Substring 可能引發例外
	//第二個參數不能是負數
	//字串長度不足也會例外
	//老師想看你會不會處理：
	//邏輯錯誤
	//邊界條件（boundary cases）

	//✅ 5. 作用域（Scope）與命名衝突（CS0136）
	//外層變數 vs 內層參數的名字不能衝突
	//能不能理解區域範圍與遮蔽（shadowing）
}
