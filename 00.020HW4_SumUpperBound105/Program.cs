namespace _00._020HW4_SumUpperBound105
{
	internal class Program
	{
		//1+ 2 + 3 + 4 + .... + N<105請問 N 是多少?
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			int finalResult = GetMaxNUnder105(105);
			Console.WriteLine(finalResult);
		}

		public static int GetMaxNUnder105(int input)
		{
			//(n+1)*n/2 < input
			// n^2 + n < 2 * input
			//=> 以國中公式推導出求根公式 n = [-b + sqrt(b^2 - 4ac)]/2(負號不取  負項在此無意義)
			//1n^2 + n - 210 = 0 => n = [-1 + sqrt(1 - 4*1+(-210))]/2 => 可以修改成input版本 不限定數字
			// => n = [-1 + 29 ]/2 ， n = 14

			// 使用 double 確保計算過程不會溢位
			double inputVal = (double)input;
			double n = (-1.0 + Math.Sqrt(1.0 - 4 * 1 * -( 2 * inputVal))) / 2;//求出n為第幾項
			//記住  上面一定要*2 !!!!!!!!!!!!!!!!!!!!!!!!!  因為梯形公式有除以2  所以要回乘
			if (n % 1 == 0)
			{
				return (int)n -1;//這是加上去 "超過" 或 "等於" input的第n項  還需要再-1;
			}

			return (int)Math.Floor(n);//這是n.XXX  直接無條件捨去
									  //如果是要求負數，會有巨大差異
									  //(int)-13.65：一樣是「切掉」小數點，結果是 - 13。
										//Math.Floor(-13.65)：要找「比它小」的整數，結果會變成 - 14。
										//這就是為什麼在處理座標或物理運算時，大家偏好使用 Math.Floor。
		}
	}
}
