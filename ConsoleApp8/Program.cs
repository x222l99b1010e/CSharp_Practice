using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool isMale = true;
			bool isFemale = false;

			if (isMale && isFemale)
			{
				Console.WriteLine("先生小姐您好!");
			}
			else if (isMale && !isFemale)
			{
				Console.WriteLine("先生您好，這裡沒有女士!");
			}

			else if (isFemale && !isMale)
			{
				Console.WriteLine("女士您好，這裡沒有先生!");
			}
			else
			{
				Console.WriteLine("你不是先生&&女士!");
			}
		}
	}
}
