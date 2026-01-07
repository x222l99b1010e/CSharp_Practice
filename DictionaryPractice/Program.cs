using System.Xml.Linq;

namespace DictionaryPractice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Console.WriteLine("Hello, World!");
			Dictionary<string, int> ages = new Dictionary<string, int>
			{
				{"Frank", 40 },
				{"Andy", 35 }
			};
			ages.Add("Allen", 60);
			ages["Adam"] = 40;// 另一種方式，若 Key 不存在則新增，存在則更新
			ages["Alice"] = 32;
			int aliceAge = ages["Alice"];//直接透過 Key 來存取。如果 Key 不存在，會報錯。
			ages.Remove("Alice");       // 刪除 Key 為 Alice 的資料
			bool hasBob = ages.ContainsKey("Bob"); // 檢查是否存在某個 Key
			Console.WriteLine(hasBob);

			if (ages.TryGetValue("Charlie", out int result))
			{
				Console.WriteLine($"找到 Charlie，年齡是 {result}");
			}
			else
			{
				Console.WriteLine("找不到該位使用者。");
			}

			// 僅遍歷所有 Key
			foreach (string name in ages.Keys)
			{
				Console.WriteLine($"{name}");
			}

			// 同時取得 Key 和 Value
			foreach (KeyValuePair<string, int> name in ages)
			{
				Console.WriteLine($"姓名: {name.Key}, 年齡: {name.Value}");
			}
			foreach (var (name, age) in ages)
			{
				Console.WriteLine($"姓名: {name}, 年齡: {age}");
			}
			foreach (var kvp in ages)
			{
				Console.WriteLine($"姓名: {kvp.Key}, 年齡: {kvp.Value}");
			}

		}
	}
}
