using System.Linq;
using System.Numerics;
using System.Text;

namespace LeetCode;

public class Program
{
	private static readonly Solution S = new Solution();

	public static void Main(string[] args)
	{
		Console.WriteLine(S.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2 }));
		Console.WriteLine(S.FindMedianSortedArrays(new[] { 1, 2 }, new[] { 3,4 }));
		Console.WriteLine(S.FindMedianSortedArrays(new[] { 1, 3 }, new[] { 2,7 }));
	}
}

public class Solution
{
	/// <summary>
	/// https://leetcode.com/problems/two-sum/description/
	/// </summary>
	public int[] TwoSum(int[] nums, int target)
	{
		for (int i = 0; i < nums.Length - 1; i++) {
			var s = nums[i];

			var seq = nums[(i + 1)..];

			for (int j = 0; j < seq.Length; j++) {
				if (s + seq[j] == target) {
					return new[] { i, i + 1 + j };
				}
			}

		}

		return null;
	}

	public class ListNode
	{
		public int      val;
		public ListNode next;

		public ListNode(int val = 0, ListNode next = null)
		{
			this.val  = val;
			this.next = next;
		}
	}

	public static IEnumerable<int> ToArray(ListNode l)
	{
		ListNode lp = l;

		while (lp != null) {
			yield return lp.val;
			lp = lp.next;
		}
	}

	public ListNode Add(ListNode head, int i)
	{
		ListNode tmp, p;
		tmp = new ListNode(i);

		if (head == null) {
			head = tmp;
		}
		else {
			p = head;

			while (p.next != null) {
				p = p.next;
			}

			p.next = tmp;
		}

		return head;
	}

	/// <summary>
	/// https://leetcode.com/problems/add-two-numbers/description/
	/// </summary>
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		ListNode l3 = null, p = null;

		IEnumerable<int> r1  = ToArray(l1).Reverse().ToArray(),     r2  = ToArray(l2).Reverse().ToArray();
		BigInteger       rr1 = BigInteger.Parse(string.Concat(r1)), rr2 = BigInteger.Parse(string.Concat(r2));
		var              ns  = rr1 + rr2;
		var              nss = new string(ns.ToString().Reverse().ToArray());

		for (int i = 0; i < nss.Length; i++) {
			var s = int.Parse(nss[i].ToString());
			l3 = Add(l3, s);

		}

		return l3;
	}

	public int LengthOfLongestSubstring(string str)
	{
		var seen = new HashSet<char>();

		int l = 0;
		int m = 0;

		for (int i = 0; i < str.Length; i++) {
			char n = str[i];

			if (!seen.Add(n)) {
				while (str[l] != n) {
					seen.Remove(str[l++]);
				}

				l++;
			}

			m = Math.Max(i + 1 - l, m);
		}

		return m;
	}

	double getmedian(int[] x)
	{
		var n = x.Length;

		double med;

		if (n % 2 == 0) {
			med = ((double) x[n / 2] + (double) x[(n / 2) + 1]) / 2d;
		}
		else {
			if (n == 3) {
				med = x[1];
			}
			else med = x[(n + 1) / 2];
		}

		return med;
	}

	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		var u= nums1.Union(nums2).ToArray();
		Array.Sort(u);
		return getmedian(u);
	}	
}