namespace ConsoleApp49
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			Program pg = new Program();
			int tax = pg.CalculateTax(123);
			Console.WriteLine(tax);

			Result finalResult = 總和超過指定值(250);
			Console.WriteLine(finalResult.Count);
			Console.WriteLine(finalResult.Sum);
		}

		/// <summary>
		/// 計算營業稅
		/// </summary>
		/// <param name="price">未稅價</param>
		/// <returns>傳回營業稅</returns>
		public int CalculateTax(int price)
		{
			return (int)Math.Round(price * 0.05m,MidpointRounding.AwayFromZero);
		}

		static Result 總和超過指定值(int max)
		{
			var obj = new Result();
			obj.Count = 31;
			obj.Sum = 256;
			return obj;
			//示範回傳型別=>超過250後加上的第一個數字
			//以及總和
			//只示範用法不示範正確流程
		}

		static void CreateMember(Member member)
		{
			//取得新會員各式欄位值
			string account = member.Account;

			//判斷Account是否已存在
			//...

		}
	}

	class Result
	{
		public int Count;
		public int Sum;
	}

	class Member
	{
		public string Name, Account, Password, Address;
		public int Height, Weight;
		public string CreditCardNumber;
	}
}
