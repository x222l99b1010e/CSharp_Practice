using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp12
{
	internal class Program
	{
		static void Main(string[] args)
		{
			bool gender = true;//性別true=male,false=female
			int height = 170;

			if (!gender && height >= 170){
				Console.WriteLine("妳好高啊!");
			}else if (height < 100 || height > 180){
				Console.WriteLine("你好，很高興你來參加活動");
			}else if (gender && (height >= 170 || height < 180)) {
				Console.WriteLine("先生您好!");
			}else if (height >= 190){
				Console.WriteLine("你也太高了吧!");
			}
		}
	}
}
