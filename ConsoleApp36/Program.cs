using System.Globalization;

namespace ConsoleApp36
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string name = "Allen";
			int age = 18;
			string message = "Hi, " + name + ". You are " + age + " years old.";
			Console.WriteLine(message);
			message = $"Hi, {name}. You are {age} years old.";
			Console.WriteLine(message);
			message = string.Format("Hi, {0}. You are {1:000000} years old", name,age);
			//000000=>表示6位數，不足會補0
			Console.WriteLine(message);
		}
	}
}
