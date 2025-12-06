namespace ConsoleApp43
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//字串轉成int
			string str = "123";

			int number = int.Parse(str);

			int number3 = Convert.ToInt32(str);

			bool isNumber = int.TryParse(str, out int number2);
			if (isNumber)
			{
				Console.WriteLine($"輸入的是數字{number2}");
			}
			else {
				Console.WriteLine("解析失敗不是整數");
			}
		}
	}
}
