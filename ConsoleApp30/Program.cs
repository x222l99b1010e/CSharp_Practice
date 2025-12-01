namespace ConsoleApp30
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int sum = 0;
			int counts = 0;
			for (int i = 1; i <= 100; i++) 
			{
				sum += i;
				counts++;
			}
			Console.WriteLine(sum);
			Console.WriteLine(counts);//共加了幾次

			int sum2 = (1 + 100) * 100/2;
			Console.WriteLine(sum2);
		}
	}
}
