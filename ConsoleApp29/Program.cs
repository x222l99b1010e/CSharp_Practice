namespace ConsoleApp29
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int rows = 9;
			for (int i = 1; i <= rows; i +=2)
			{
				//string row2 = new string (' ', (rows-i) / 2) + new string ('*', i) + new string(' ',(rows - i) / 2);
				string row = new string (' ', (rows-i) / 2) + new string ('*', i);
				Console.WriteLine (row);
			}
			Console.WriteLine("-----------------------");
			for (int i = 1; i <= rows; i++)
			{
				string row = new string(' ',rows-i) + new string('*',2*i-1);
				Console.WriteLine (row); 
			}
		}
	}
}
