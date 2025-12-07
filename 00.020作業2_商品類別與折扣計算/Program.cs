namespace _00._020作業2_商品類別與折扣計算
{
	internal class Program
	{
		//商品類別與折扣計算：
		//建立一個 Product 類別，包含欄位：Name(字串)、Price(雙精度浮點數)。
		//提供方法 ApplyDiscount(double percentage)，根據給定的折扣百分比計算折扣後的價格，並回傳結果。
		static void Main(string[] args)
		{
			Product p = new Product("Banana",46);
			Console.WriteLine(p.ApplyDiscount(12)); // 40.48

		}
	}

	public class Product {
		public string Name;
		public double Price;
		public Product(string name, double price)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentException("Name is required.", nameof(name));
			if (price < 0)
				throw new ArgumentOutOfRangeException(nameof(price), "Price cannot be negative.");

			Name = name;
			Price = price;
		}
		/// <summary>
		/// 計算折扣後價格，但不會修改原 Price。
		/// percentage 必須介於 0 到 100（包含）。
		/// 回傳結果已用兩位小數四捨五入（AwayFromZero）。
		/// </summary>
		public double ApplyDiscount(double percentage)
		{
			if (percentage < 0 || percentage > 100)
				throw new ArgumentOutOfRangeException(nameof(percentage), "Percentage must be between 0 and 100.");
			double discounted = Price * (1 - percentage / 100);
			// 選擇四捨五入到兩位數：AwayFromZero(銀行家舍入ToEven也常見)
			return Math.Round(discounted,2, MidpointRounding.AwayFromZero);
		}
	}

}
