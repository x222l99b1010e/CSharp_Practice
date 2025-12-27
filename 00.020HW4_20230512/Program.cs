namespace _00._020HW4_20230512
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			DateTime date = new DateTime(2023, 5, 12);
			DateTime date1 = new DateTime(2023, 5, 13);
			Console.WriteLine(date.DayOfWeek);//星期幾
			Console.WriteLine(date1.DayOfWeek.ToString());//星期幾
		}
	}
}
