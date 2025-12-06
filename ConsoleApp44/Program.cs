namespace ConsoleApp44
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int num = 1;
			num++;//這時，num = 2
			++num;//這時，num = 3

			num = 1;
			int num2 = num++;//num2會被賦值為1，然後num變成2
			Console.WriteLine(num);
			Console.WriteLine(num2);

			num = 1;
			int num3 = ++num;//num3會被賦值為2，因為先增加num的值再賦值給num3
			Console.WriteLine(num);
			Console.WriteLine(num3);			
		}
	}
}
