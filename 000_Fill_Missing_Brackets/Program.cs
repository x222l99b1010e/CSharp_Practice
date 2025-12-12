//給定一個包含字符 '('、')'、'['、']' 和 '?' 的字串，判斷有多少種方式可以將該字串分割成兩個非空子字串，使得每個子字串都能重新排列組成平衡括號字串。
//'?' 字符可以被替換為任何需要的字符來達成平衡。這兩個子字串合起來必須覆蓋整個原始字串。
//平衡括號字串 是指括號正確匹配，沒有交叉重疊。例如 "([])" 是平衡的，但 "([)]" 不是。

//字符定義
//'(' 和 ')' 是圓括號
//'[' 和 ']' 是方括號
//'?' 是萬用符號，可以替換為上述任何括號字符

//例子
//輸入：s = "(?[??'"

//字串可以分割成兩個平衡子字串的方式如下：
//**s1 = "(?)" 和 s2 = "[??'"`
//把 s1 中的 ? 替換為 ) 得到 "()" → 平衡 ✓
//把 s2 中的問號替換為 ] 和 [，然後重新排列得到 "[]" 或 "[]" → 平衡 ✓
//**s1 = "(?[?" 和 s2 = "?'"`
//把 s1 中的 ? 替換為 ) 得到 "()[()]" → 平衡 ✓
//把 s2 中的 ? 替換為 [得到 "[]" → 平衡 ✓
//輸出：1（只有一種有效分割方式）

//解釋
//只有一種可能的分割方式：
//s1 = "(" 替換問號得到 "()"
//s2 = "/" 重新排列得到 "()"

//約束條件
//字串 s 只包含 '('、')'、'['、']' 和 '?'

//4≤length of s≤10^5

//題目要你算的是：把原字串切成兩段的「切割位置」有幾種選擇，可以讓左右兩段各自（獨立地）透過「替換 ? 並重新排列」變成平衡字串。
//不是在問「某一種切法裡，左右兩段能排出多少種平衡括號組合」；那些組合不用數。

//只要某個切割位置「存在至少一種」替換 / 排列方式讓左、右都各自變平衡，就算這個切法「有效」，答案就對這個切法加 1。
//所以：
//問題是在數「有效切法的個數」，不是「所有可能排列組合的總數」。

//一個含有(, ), [,], ? 的字串能變成平衡括號字串，需要：
//長度是偶數（平衡括號必須成對）
//圓括號數量 + 方括號數量 ≤ 長度（用 ? 補足）
//圓括號和方括號的總數是偶數（才能配對）
namespace _000_Fill_Missing_Brackets
{
	internal class Program
	{
		class Solution
		{
			public static void Main(string[] args)
			{
				string s = Console.ReadLine();
				int res = Result.fillMissingBrackets(s);
				Console.WriteLine(res);
			}
		}
	}
	class Result
	{
		public static int fillMissingBrackets(string s)
		{
			int n = s.Length;
			// prefix counts: index i means count for s[0..i-1], length n+1
			int[] preOpenPar = new int[n + 1];
			int[] preClosePar = new int[n + 1];
			int[] preOpenSq = new int[n + 1];
			int[] preCloseSq = new int[n + 1];
			int[] preQ = new int[n + 1];

			for (int i = 0; i < n; i++)
			{
				preOpenPar[i + 1] = preOpenPar[i];
				preClosePar[i + 1] = preClosePar[i];
				preOpenSq[i + 1] = preOpenSq[i];
				preCloseSq[i + 1] = preCloseSq[i];
				preQ[i + 1] = preQ[i];

				char c = s[i];
				if (c == '(') preOpenPar[i + 1]++;
				else if (c == ')') preClosePar[i + 1]++;
				else if (c == '[') preOpenSq[i + 1]++;
				else if (c == ']') preCloseSq[i + 1]++;
				else if (c == '?') preQ[i + 1]++;
			}

			int ans = 0;
			// split between i and i+1 -> left = s[0..i-1] length i, right = s[i..n-1] length n-i
			// iterate i from 1..n-1 (two non-empty parts)
			for (int i = 1; i < n; i++)
			{
				if (IsBalancedByCounts(i, preOpenPar, preClosePar, preOpenSq, preCloseSq, preQ) &&
					IsBalancedByCounts(n - i, // length for right
											  // but we pass counts for right: counts = prefix at n minus prefix at i
									  preOpenPar, preClosePar, preOpenSq, preCloseSq, preQ, i, n))
				{
					ans++;
				}
			}

			return ans;
		}

		// overload: check left substring which is prefix of length len (i.e., counts at prefix[len])
		private static bool IsBalancedByCounts(int len,
											  int[] preOpenPar, int[] preClosePar, int[] preOpenSq, int[] preCloseSq, int[] preQ)
		{
			// counts come from prefix[len]
			int openPar = preOpenPar[len];
			int closePar = preClosePar[len];
			int openSq = preOpenSq[len];
			int closeSq = preCloseSq[len];
			int q = preQ[len];

			return CanBeBalancedCounts(len, openPar, closePar, openSq, closeSq, q);
		}

		// overload: check substring s[l..r-1] where 0<=l<r<=n; we pass prefix arrays and l,r
		private static bool IsBalancedByCounts(int len,
											  int[] preOpenPar, int[] preClosePar, int[] preOpenSq, int[] preCloseSq, int[] preQ,
											  int l, int r)
		{
			// len = r-l (caller passes n-i)
			int openPar = preOpenPar[r] - preOpenPar[l];
			int closePar = preClosePar[r] - preClosePar[l];
			int openSq = preOpenSq[r] - preOpenSq[l];
			int closeSq = preCloseSq[r] - preCloseSq[l];
			int q = preQ[r] - preQ[l];

			return CanBeBalancedCounts(len, openPar, closePar, openSq, closeSq, q);
		}

		// 檢查當前 counts 是否能構成平衡字串（必須使用全部字元，且長度偶數）
		private static bool CanBeBalancedCounts(int len, int openPar, int closePar, int openSq, int closeSq, int q)
		{
			if (len % 2 != 0) return false; // 長度必須是偶數（必要條件）

			int diffPar = Math.Abs(openPar - closePar);
			int diffSq = Math.Abs(openSq - closeSq);
			int need = diffPar + diffSq;

			if (q < need) return false;

			int rem = q - need;
			return rem % 2 == 0;
		}
	}	
}
