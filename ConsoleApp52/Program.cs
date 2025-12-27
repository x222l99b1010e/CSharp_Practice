namespace ConsoleApp52
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			Student allen = new Student("Allen",65);

		}
	}

	class Student
	{
		public string Name { get; set; }
		public int Score { get; set; }
		public Student(string name)
		{
			Name = name;
		}
		public Student(string name, int score) : this(name) 
		{
			//Name = name;
			Score = score;
		}
	}
}
