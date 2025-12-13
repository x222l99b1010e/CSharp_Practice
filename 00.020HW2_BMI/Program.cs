using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

//流程雜亂 → 抽方法
//邏輯重複 → 抽方法
//規則穩定且可重用 → 抽類別
//跟 UI 無關 → 類別
//跟使用者互動 → 方法
namespace _00._020HW2_BMI
{
	//console application, 必需驗證輸入的身高, 體重必需是正整數, 顯示BMI值(有小數點), 以及肥胖呈度的文字說明
	//過重：24<=BMI<27
	//輕度肥胖：27 <= BMI< 30
	//中度肥胖：30 <= BMI < 35
	//重度肥胖：BMI >= 35
	internal class Program
	{
		static void Main(string[] args)
		{
			//(double)
			int height;
			while (true)
			{
				//輸入層（Input Responsibility）=>「確保使用者有輸入東西」
				//使用者有沒有輸入？
				//是不是只有空白？
				//如果錯了，我要不要給他再輸一次機會？
				Console.Write("請輸入身高(公分)：");
				
				string input = Console.ReadLine()?.Trim() ?? "";
				//驗證空白
				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("身高不可空白，請重新輸入。");
					continue;
				}
				//轉型與格式驗證層（Parsing / Validation Responsibility）
				//「這個字串，能不能變成我要的型別？」
				//業務規則驗證層（Business Rule Responsibility）
				//體重是不是 > 0？
				//身高是不是 > 0？
				//身高 1 公分或 1000 公分是不是合理？
				//解析成double，並驗證非正整數(如果解析不是double或是非正整數都會跳錯)
				if (!int.TryParse(input, out height) || height < 90)
				{
					Console.WriteLine("身高必須是大於90之正整數，請重新輸入。");
					continue;
				}
				break; // 通過所有驗證，跳出 while

				//如果這個錯誤是「使用者常犯的錯」，不要用 exception
				//如果這個錯誤是「理論上不應該發生的狀況」，才考慮 exception
				//輸入空值 ❌ 不該用 exception
				//輸入非數字 ❌ 不該用 exception
				//身高為 0 ❌ 不該用 exception
				//除以 0（理論上）✅ 才可能是 exception
			}
			//體重符合要求為正整數(int)
			int weight;
			while (true)
			{
				Console.Write("請輸入體重(公斤)：");
				string input = Console.ReadLine()?.Trim() ?? "";
				if (string.IsNullOrWhiteSpace(input))
				{
					Console.WriteLine("體重不可空白，請重新輸入。");
					continue;
				}
				if (!int.TryParse(input, out weight) || (weight < 30))
				{
					Console.WriteLine("體重必須為大於30之正整數，請重新輸入。");
					continue;
				}
				break;			
			}

			double heightM = height / 100;
			double bmi = (double)weight / Math.Pow(heightM, 2);

			if (bmi < 27 && bmi >= 24) Console.WriteLine($"BMI：{bmi},過重");
			else if (bmi < 30 && bmi >= 27) Console.WriteLine($"BMI：{bmi},輕度肥胖");
			else if (bmi < 35 && bmi >= 30) Console.WriteLine($"BMI：{bmi},中度肥胖");
			else if (bmi >= 35) Console.WriteLine($"BMI：{bmi},重度肥胖");
			else Console.WriteLine($"BMI：{bmi},體重適中");
		}

		//「我希望有一個方法，它可以＿＿＿＿＿＿＿＿」
		//這個方法「成功時給我什麼？」
		//「失敗時誰處理？」
		//Main 如果只剩 5～6 行，合理嗎？

		//判斷準則（符合越多，越適合方法）
		//只在同一支程式裡用
		//沒有狀態要保存
		//只是把一段流程包起來
		//不需要被測試或重用在其他專案
		//目的是讓 Main 變乾淨、好讀

		
	}

	//你應該開始考慮「抽成類別」的時機
	//驗證邏輯不再依賴 Console
	//資料是從不同來源進來的（API / 檔案 / UI）
	//同一套規則會被多個地方使用
	//你想替它寫單元測試
	//它有明確的業務角色
	//例如：
	//身高體重驗證 → 用在 Web API、Console、WinForm
	//BMI 計算 → 被多個系統使用
	//醫療或健康 domain 邏輯
	//👉 這時候「類別」才會帶來價值。
}
