namespace ConsoleApp25
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string[] name1 = { "ray", "321", "123", "wqe", "lke", "1111", "December" };
			int name1Length = name1.Length;
			Console.WriteLine("陣列長度為" + name1Length);
			for (int i = 0; i < name1.Length; i++)
			{
				string[] name2 = name1;
				//name2[i] = name2[i].ToUpper();//Copy by reference
				string[] name3 = name1.ToArray();
				name3[i] = name3[i].ToUpper();//Copy by value
				Console.WriteLine(name3[i]);
			}
			Console.WriteLine("--------------------------------------");
			foreach (string name in name1)
			{
				Console.WriteLine(name);
			}
			Console.WriteLine("--------------------------------------");
			
		}
	}
}
