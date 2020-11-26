using System;
using System.Linq;

namespace Jonny.LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Reverse(-123));
            Console.WriteLine(Reverse(0));
            Console.WriteLine(Reverse(1534236469));
            Console.WriteLine(Reverse(-2147483412));
            Console.ReadLine();
        }

        /// <summary>
        /// 题目:https://leetcode-cn.com/problems/two-sum/
        /// 题解:https://leetcode-cn.com/problems/two-sum/solution/leetcode-1-two-sum-liang-shu-zhi-he-c-ha-xi-biao-d/
        /// </summary>
        static int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i; j < nums.Length; j++)
                {
                    if (i != j && nums[i] + nums[j] == target)
                    {
                        return new int[] { i, j };
                    }
                }
            }
            return new int[] { 0, 0 };
        }

        static int Reverse(int x)
        {
            try
            {
                if (x < 10 && x > -10)
                {
                    return x;
                }
                var result = string.Join("", Math.Abs(x).ToString().Reverse()).TrimStart('0');
                return x < 0 ? int.Parse(result) * -1 : int.Parse(result);
            }
            catch (OverflowException ex)
            {
                return 0;
            }
        }

        static bool IsPalindrome(int x)
        {
            string str = x.ToString();
            return str == string.Join("", str.Reverse());
        }
    }
}
