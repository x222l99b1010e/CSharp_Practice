using System.ComponentModel.DataAnnotations;

namespace ConsoleApp48
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			string content = "0123456789";

			string value = Left(content, 20);
			Console.WriteLine(value);

			string replaceString = content.Replace("012", "2020");
			Console.WriteLine(replaceString);

			string testUpper = "abc";
			string testLower = "ABC";
			string stringUpper1 = testUpper.ToUpper();
			string stringLower1 = testLower.ToLower();
			Console.WriteLine(stringUpper1);
			Console.WriteLine(stringLower1);
		}
		static string Left(string value, int length)
		{
			if (value == null)
			{
				return "";
			}
			if (length < 0)
			{
				throw new ArgumentException(nameof(length), "Length cannot be negitive.");
			}
			if (length > value.Length)
			{
				return value;
			}
			return value.Substring(0,length);
		}
	}
}
