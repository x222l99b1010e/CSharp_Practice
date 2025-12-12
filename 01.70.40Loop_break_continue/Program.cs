namespace _01._70._40Loop_break_continue
{
	internal class Program
	{

		//找出108 ~3000之間所有99的倍數
		//找出108~3000之間第一個99的倍數
		static void Main(string[] args)
		{
			foreach (int i in Find99(108, 3000))
			{ 
				//Console.WriteLine(i);
			}
			Console.WriteLine(FindOne99(-3000, -108));
			Console.WriteLine(FindOne99(108, 3000));
			
		}
		//1.邊界/參數驗證：應該明確處理 a > b 或負數等情況（決定是回空集合、互換、或丟例外）。
		//2.效能：你目前的做法每 99 跳一次，時間複雜度 O((b-a)/99)，這已經是最佳時間複雜度（必須把每個倍數輸出），
		//	沒有必要再做更快。若不需要全部結果，可只找第一個（O(1) 計算第一個，或 O(1) 回傳），
		//	或用 yield return 做延遲列舉以節省記憶體。
		//3.一般性 / 符號行為：a % 99 在 C# 對負數的行為可能不是你預期的（餘數會帶負號），
		//	如果要支援負區間，計算第一個可被 99 整除的數時應稍微小心。
		static List<int> Find99(int start, int end)
		{
			if (start > end) return new List<int>();

			// 調整 start 到該區間內的第一個 99 的倍數（若 start 本身就是倍數就保留）
			int remainder = start % 99;
			int first = remainder == 0 ? start : start + (99 - remainder);

			var list = new List<int>();
			for (int i = first; i <= end; i += 99)
			{
				list.Add(i);
			}
			return list;
		}

		static int FindOne99(int start, int end)
		{
			if (start > end) return -1;
			int remainder = ((start % 99) + 99) % 99;//=>測試-3000/99=-30...-30=>第一個應該是-2970
													 //int remainder = (start % 99);=>用在負數範圍會錯誤
													 //((start % 99) + 99) % 99; =>轉正抓餘數
													 //(-30%99)=>-30
													 //-30+99=69
													 //69%99=69 =>99-69 =30
													 //-3000 + 30 = -2970
			int firstNum = remainder == 0 ? start : start + (99 - remainder);

			// 必須確認算出來的 firstNum 在 end 範圍內；超過的話代表找不到
			return firstNum <= end ? firstNum : -1;
		}

		// 回傳在 [start, end] 範圍內的第一個 99 的倍數（包含邊界）
		// 若找不到或 start > end 則回傳 -1
		static int FindOne99_1(int start, int end)
		{
			if (start > end) return -1;

			// 這一行把取餘數結果轉為非負 (0..98)，對負數也正確
			int rem = ((start % 99) + 99) % 99;

			// 如果 rem == 0，start 已經是 99 的倍數；否則把它往上推到下一個倍數
			int first = rem == 0 ? start : start + (99 - rem);

			// 若第一個倍數在範圍外（大於 end），則代表找不到
			return first <= end ? first : -1;
		}


		/// <summary>
		/// 產生 [start, end] 區間內的 n 的倍數（包含邊界）。
		/// 傳回 IEnumerable，採延遲列舉。
		/// </summary>
		static IEnumerable<int> FindMultiplesOf(int n, int start, int end)
		{
			if (n == 0) throw new ArgumentException("n 不能為 0", nameof(n));
			if (start > end) yield break;

			// 計算第一個 >= start 的 n 的倍數（支援負數）
			int remainder = Math.Abs(start) % n;
			// 更穩健的方法：用整數數學求 ceil(start / n) * n
			// 注意 C# 的整數除法向 0 捨入，故用 Math.DivRem 或 double 計算較直觀
			int div = (int)Math.Floor(start / (double)n); // 可能為負
			int first = div * n;
			if (first < start) first += Math.Abs(n);

			for (int i = first; i <= end; i += Math.Abs(n))
			{
				yield return i;
			}
		}
	}
}
