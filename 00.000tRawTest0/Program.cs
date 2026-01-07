using System.Collections;

namespace _00._000RawTest0
{
	internal class Program
	{
		static void Main(string[] args)
		{
			TEST0.execute("I, Jimmy, saw a saw saw a saw");
			Console.ReadLine();
		}
	}
	public class TEST0
	{
		public static void execute(string stInp)
		{
			if (stInp == null)
				return;
			string[] word = stInp.Replace(",", " ").Replace(".", " ").Split(new char[] { ' ' });
			ArrayList arrWord = new ArrayList();
			Hashtable hm = new Hashtable();
			foreach (string st in word)
			{
				if (st != null && st.Length > 0)
				{
					arrWord.Insert(0, st);
					if (!hm.ContainsKey(st))
					{
						hm.Add(st, st);
					}
				}
			}
			Console.WriteLine("Reversed string=");
			foreach (string st in arrWord)
			{
				Console.Write(st + " ");
			}
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("All Words=");
			foreach (Object key in hm.Keys)
			{
				Console.Write(key + " ");
			}
		}
	}
}
