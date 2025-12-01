using System.Diagnostics.CodeAnalysis;

namespace _01._70._10for的範例
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//顯示 1～ 10
			for (int i = 1; i < 11; i++) {
				//Console.WriteLine(i);
			}

			//顯示 1 ~20 的偶數
			for (int i = 2; i < 21; i += 2)
			{
				//Console.WriteLine(i);
			}

			for (int i = 1; i <= 20; i++)
			{
				if (i % 2 == 0) {
					//Console.WriteLine(i);
				}
			}

			//顯示 10 ~1, 遞減顯示
			for (int i = 10; i >= 1; i--)
			{
				//Console.WriteLine(i);
			}

			//顯示靠左，靠右，置中星號三角形
			int rows = 10;
			for (int i = 1; i <= rows; i++)
			{
				string row = new string('*', i);
				//Console.WriteLine(row);
			}

			for (int i = 1; i <= rows; i++)
			{
				//string row = new string (' ', rows - i) + new string ('*', i);
				string row = new string('*', i).PadLeft(rows, ' ');//PadLeft(int a , char)
				//Console.WriteLine(row);
			}
			//置中三角形
			for (int i = 1; i <= rows; i++)
			{
				string row = new string(' ', rows - i) + new string('*', 2*i-1);//i++寫法
				//Console.WriteLine(row);
			}

			for (int i = 1; i <= rows; i += 2)
			{
				string row = new string(' ', (rows - i) / 2) + new string('*', i);//rows = 7 => (1,3,5,7) => 只有4層
				//Console.WriteLine(row);
			}

			//用迴圈計算1～100總和
			int sum = 0;
			for (int i = 1; i < 101; i++)
			{
				sum += i;
			}
			//Console.WriteLine(sum);

			//顯示 2 * 1 ~2 * 9 的乘法表
			for (int i = 1; i <= 9; i++)
			{
				//Console.Write($"2 * {i} = {2 * i};  ");
			}
			//顯示 2 * 1 ~9 * 9 的乘法表
			for (int i = 1; i < 10; i++)
			{
				for (int j = 1; j <= 9; j++)
				{
					//Console.Write($"{i} * {j} = {i * j};  ");
				}
				//Console.WriteLine();
			}

			//倒星形三角形
			for (int i = rows; i >= 1; i--)
			{
				string row = new string('*', i);
				//Console.WriteLine(row);
			}

			//等腰星形三角形
			for (int i = rows; i >=1; i--)
			{
				string row = new string (' ',rows-i) + new string('*',2*i-1);
				//Console.WriteLine(row);
			}
			//右側對齊星形三角形
			for (int i = rows; i >=1; i--)
			{
				string row = new string (' ',rows-i) + new string('*',i);
				//Console.WriteLine(row);
			}

			//判斷某正整數是不是質數
			Console.WriteLine("請輸入一個正整數(否則會回傳false)：");
			int integer1 = int.Parse(Console.ReadLine());

			if (isPrime(integer1))
			{
				Console.WriteLine("此數為質數");
			}

			else {
				Console.WriteLine("此數非質數");
			}

		}

		static bool isPrime(int n)
		{
			if (n<1) return false;
			if (n == 2) return true;
			if (n % 2 ==0) return false;

			int limit = (int)Math.Sqrt(n);
			for (int i = 3; i < limit; i += 2)
			{
				if (n % i == 0)
				{
					Console.WriteLine(i);
					return false;
				}				
			}
			return true;
		}
	}
}
