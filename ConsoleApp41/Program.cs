namespace ConsoleApp41
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var allen = new Person("Allen Kuo",30);
			Console.WriteLine(allen.Introduce());

			var allen1 = new Person1();
			//allen1.Name = "Allen Kuo";
			//allen1.Age = 30;

			//看看沒賦值會跑什麼出來，Person1沒有使用建構函數
			Console.WriteLine(allen1.Introduce());

			//以下是微軟提供的新語法
			//直接後面賦值
			//Person1沒有建構函數
			var allen2 = new Person1() { Name = "Allen Kuo", Age = 30 };
			//這行括號被省略了(沒有建構子可以省略)
			var allen3 = new Person1{ Name = "Allen Kuo", Age = 30 };
			Console.WriteLine(allen2.Introduce());
			Console.WriteLine(allen3.Introduce());
		}
	}
	class Person {
		public string Name;
		public int Age;
		public Person( string name, int age)
		{
			Name = name;
			Age = age;
		}

		public string Introduce() {
			return $"Hi, my name is {Name} and I am {Age} years old.";
		}
	}
	class Person1 {
		public string? Name;
		public int Age;

		public string Introduce() {
			return $"Hi, my name is {Name} and I am {Age} years old.";
		}
	}

	
}
