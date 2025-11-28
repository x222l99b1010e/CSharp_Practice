using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiLineStringExec
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//撰寫一個 Console Application(名稱為 MultiLineStringExec), 執行之後, 呈現以下文字
			//包含換行, 空白行都要相同
			//限制:
			//只使用一個字串型別的變數, 直接宣告多行文字
			//提示: 
			//中文名稱：床前明月光
			//作者：李白
			//出處：靜夜思
			//朝代：唐朝
			//文學體裁：五言絕句
			//床前明月光，疑是地上霜。
			//舉頭望明月，低頭思故鄉。
			string poem = @"中文名稱：床前明月光
作者：李白
出處：靜夜思
朝代：唐朝
文學體裁：五言絕句

床前明月光，疑是地上霜。

舉頭望明月，低頭思故鄉。";
			Console.WriteLine(poem);
		}	
	}
}
