namespace ConsoleApp45
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] items = { "Allen", "Taipei", "Allen@gmail.com" };

			int index = 0;
			string name = items[index++];//items[0]=>之後0再加1
			Console.WriteLine(name);
			string city = items[index++];
			Console.WriteLine(city);
			string email = items[index++];
			Console.WriteLine(email);
		}
	}
}
