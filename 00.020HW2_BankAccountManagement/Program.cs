using System.ComponentModel;
using System.Globalization;

namespace _00._020HW2_BankAccountManagement
{
	internal class Program
	{
		//建立一個 BankAccount 類別，包含欄位：AccountHolder(字串)、Balance(雙精度浮點數)。
		//提供以下方法：
		//Deposit(double amount)：存款，增加餘額。
		//Withdraw(double amount)：提款，扣除餘額（餘額不足則拒絕交易）。
		//DisplayBalance()：顯示目前餘額。
		static void Main(string[] args)
		{
			BankAccount allen = new BankAccount("Allen",0);
			allen.Deposit(300);
			allen.Deposit(600);
			if (allen.Withdraw(300, out double res))
			{
				Console.WriteLine($"提款了{300}元整");
			}
			else { Console.WriteLine("餘額不足，提款失敗!"); }
			Console.WriteLine(allen.DisplayBalance());


			// 範例：建立帳戶並存款
			var simon = new BankAccount("Simon");
			allen.Deposit(820);
			allen.Deposit(12045);

			// 顯示目前餘額
			Console.WriteLine(simon.DisplayBalance());

			// 範例：從使用者讀取提款金額（呼叫端輸入）
			Console.Write("請輸入要提款的金額：");
			string input = Console.ReadLine();

			//NumberStyles.Number是一個 enum（位旗標），用來告訴解析方法（例如 double.Parse / double.TryParse）
			//允許輸入字串包含哪些格式元素。
			//NumberStyles.Number 是常用的一組預設旗標，包含的特性大致有：
			//允許前後空白（leading / trailing white space）
			//允許正 / 負號（+或 -）
			//允許小數點
			//允許群組分隔符（thousands separator，例如英文的 ,）
			//允許小數（fraction）
			//換句話說，NumberStyles.Number 允許像 " +1,234.56 " 這種典型的數字字串被成功解析成 1234.56。
			//如果你要更嚴格或更寬鬆，可以使用其他旗標或自己組合，例如：
			//NumberStyles.Integer（只允許整數、可有符號）
			//NumberStyles.Float | NumberStyles.AllowThousands（允許小數與千位分隔）
			//NumberStyles.Currency（允許貨幣符號、千分位、括號負數等）
			//===============================================================================================
			//CultureInfo 決定「字串中的符號代表什麼」。不同文化（地區）對小數點與千位分隔符的表示不同，例如：
			//英語（美國）習慣：小數點.，千位分隔 , → 1,234.56
			//台灣 / 大多數中文環境（或德語）習慣：小數點 ,、千位分隔.
			//（德語為 1.234,56；台灣通常也是使用 1,234.56 與.為小數點，但文化差異仍存在）
			//CultureInfo.InvariantCulture 是一個不依賴特定區域的固定文化，
			//使用小數點.與千位逗號 , 的格式（類似 en-US 的數字格式），常用於程式內 / 交換資料時保證一致性。
			//因此，當你用 TryParse(..., CultureInfo.InvariantCulture, out ...)，
			//你是在告訴解析器：請用「不變文化」的規則來解釋字串（小數點是.、千位分隔是 ,）。
			//若使用 CultureInfo.CurrentCulture（或不傳入文化參數的 Parse），
			//解析規則會依執行環境的區域設定而定（例如 Windows 的地區設定）。
			if (double.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out double amount))
			{
				// 呼叫 Withdraw，方法會在成功時扣款並回傳 true
				if (allen.Withdraw(amount, out double remaining))
				{
					Console.WriteLine($"提款了 {amount} 元整。");
					Console.WriteLine($"提款後餘額：{remaining}"); // 使用區域化的貨幣格式
				}
				else
				{
					Console.WriteLine("餘額不足，提款失敗！");
				}
			}
			else
			{
				Console.WriteLine("輸入金額格式不正確。");
			}
		}
	}

	public class BankAccount
	{
		public string AccountHolder;
		public double Balance;

		// 建構子 
		//補強邏輯性
		public BankAccount(string accountHolder, double initialBalance = 0)
		{
			AccountHolder = accountHolder ?? throw new ArgumentNullException(nameof(accountHolder));
			if (initialBalance < 0) throw new ArgumentException("初始餘額不可為負數。", nameof(initialBalance));
			Balance = initialBalance;
		}

		public void Deposit(double a)
		{
			//補強邏輯性
			if (a <= 0) throw new ArgumentException("存款金額必須大於 0。", nameof(a));
			Balance += a;//注意這邊Balance要寫回去Balance
			Console.WriteLine($"您存入了{a}元");
		}

		// 提款：成功回傳 true 並同時扣款；失敗回傳 false 並以 out 回傳目前餘額
		public bool Withdraw(double b, out double result)
		{
			if (b <= 0) throw new ArgumentException("提款金額必須大於 0。", nameof(b));

			if (Balance >= b)
			{
				Balance -= b;//注意這邊Balance要寫回去Balance
				result = Balance;//!!!!!!!!!!!!!!!!!!!!!!!!!!
				return true;
			}
			else
			{
				result = Balance;
				return false;
			}
			//if (Balance - b < 0) 
			//{
			//	result = Balance;
			//	return false;
			//}

			//Balance -= b;//注意這邊Balance要寫回去Balance
			//result = Balance;//!!!!!!!!!!!!!!!!!!!!!!!!!!
			//return true;
		}
		public string DisplayBalance()
		{
			return $"{AccountHolder} 您目前帳戶餘額為 {Balance}";
		}

	}

}
