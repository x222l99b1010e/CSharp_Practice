using System.Globalization;

namespace ConsoleApp28
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int rows = 10;
			for (int i = 1; i <= rows; i++)
			{
				string row = new string(' ', rows - i) + new string('*', i);
				Console.WriteLine(row);
			}
			Console.WriteLine("-------------------------------");
			for (int i = 1; i <= rows; i++)
			{
				//string row = new string('*', i);
				//string row2 = row.PadLeft(rows, ' ');//將row的星星往左邊補空白補到 = rows
				//Console.WriteLine(row2);

				string row = new string('*', i).PadLeft(rows, ' ');//將row的星星往左邊補空白補到 = rows
				Console.WriteLine(row);
			}
		}
	}
}
