using System.Linq;
using System.Numerics;

namespace LeetCode;

public class Program
{
	public static void Main(string[] args)
	{
		Console.WriteLine("Hello, World!");

		var s  = new Solution();
		var l1 = new Solution.ListNode(2, new Solution.ListNode(4, new Solution.ListNode(3)));
		var l2 = new Solution.ListNode(5, new Solution.ListNode(6, new Solution.ListNode(4)));
		var l3 = s.AddTwoNumbers(l1, l2);
		var lp = l3;
		Console.WriteLine(string.Join(',', (Solution.ToArray(l1))));
		Console.WriteLine(string.Join(',', (Solution.ToArray(l3))));
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

	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		ListNode          l3 = null, p   = null;

		IEnumerable<int> r1  = ToArray(l1).Reverse().ToArray(), r2  = ToArray(l2).Reverse().ToArray();
		BigInteger              rr1 = BigInteger.Parse(string.Concat(r1)),    rr2 = BigInteger.Parse(string.Concat(r2));
		var              ns  = rr1 + rr2;
		var              nss= new string(ns.ToString().Reverse().ToArray());

		for (int i = 0; i < nss.Length; i++) {
			var s = int.Parse(nss[i].ToString());
			l3    = Add(l3, s);

		}

		return l3;
	}
}