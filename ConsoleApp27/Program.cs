namespace ConsoleApp27
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int rows = 5;
			for (int i = 1; i <= rows; i++) 
			{
				for (int j = 1; j <= i; j++)
				{
					Console.Write("*");
				}
				Console.WriteLine();//跑完換行
			}

			Console.WriteLine("-----------------------------------------");

			for (int i = 1; i <= rows; i++)
			{
				string row = new string('*', i);
				Console.WriteLine(row);
			}
		}
	}
}
