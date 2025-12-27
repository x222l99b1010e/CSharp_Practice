namespace ConsoleApp47
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string mystring = "Allenqwerttt";
			int i = mystring.IndexOf('e');
			int i1 = mystring.IndexOf("len");
			Console.WriteLine(i1);
			string i2 = mystring.Substring(3,5);
			Console.WriteLine(i2);
		}
	}
}
