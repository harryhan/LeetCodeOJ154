/******************************************************************
* Copyright (C): http://www.EmersonNetwork.com
* CLR版本: 4.0.30319.17929
* 命名空间名称: LeetCodeOJ154
* 文件名: Number
* CLR版本: 4.0.30319.17929
* 创建者: H92774
* 创建时间: 2015/7/3 9:43:14
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace LeetCodeOJ154
{
    partial class Solution
    {
        /*
        Given an array of integers, find two numbers such that they add up to a specific target number.

        The function twoSum should return indices of the two numbers such that they add up to the target, 
        where index1 must be less than index2. Please note that your returned answers (both index1 and index2) are not zero-based.

        You may assume that each input would have exactly one solution.

        Input: numbers={2, 7, 11, 15}, target=9
        Output: index1=1, index2=2
        */
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result=new int[2];

            int[] nums2 = new int[nums.Length - 1];
            Array.Copy(nums, 1, nums2, 0, nums.Length - 1);
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums2.Length; j++)
                {
                    if (target == nums[i] + nums2[j])
                    {
                        result[0] = i+1;
                        result[1] = j+2;
                        return result;
                    }
                }
            }

            return result;
        }

        public int[] TwoSum2(int[] nums, int target)
        {
            int[] result = new int[2];

            Hashtable ht = new Hashtable(nums.Length - 1);
            
            for (int i = 0; i < nums.Length; i++)
            {
                if (ht.Contains(target-nums[i]))
                {
                    result[0] = Convert.ToInt32(ht[target - nums[i]]);
                    result[1] = i + 1;
                    break;
                }
                else
                {
                    if (ht.Contains(nums[i]))
                    {
                        ht[nums[i]] = i + 1;
                    }
                    else
                    {
                        ht.Add(nums[i], i + 1);
                    }
                }
            }
            return result;
        }

        public int[] TwoSum3(int[] nums, int target)
        {
            int[] result = new int[2];

            var dict = new Dictionary<int,int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    result[0] = dict[target - nums[i]];
                    result[1] = i + 1;
                    break;
                }
                else
                {
                    if (dict.ContainsKey(nums[i]))
                    {
                        dict[nums[i]] = i + 1;
                    }
                    else
                    {
                        dict.Add(nums[i], i + 1);
                    }
                }
            }
            return result;
        }


        /*
         * Given an integer, write a function to determine if it is a power of two.
        */
        public bool IsPowerOfTwo(int n)
        {
            bool result = false;

            if (n!=1 && n%2!=0)
            {
                return result;
            }
            else
            {
                for (int i = 0; i < int.MaxValue; i++)
                {
                    var temp=Math.Pow(2,i);
                    if (temp==n)
                    {
                        result = true;
                        break;
                    }
                    if (temp>n || temp>int.MaxValue/2 )
                    {
                        break;
                    }
                }
            }

            return result;
        }


        /*
         * Given a sorted integer array without duplicates, return the summary of its ranges.
         * For example, given [0,1,2,4,5,7], return ["0->2","4->5","7"].
        */
        public IList<string> SummaryRanges(int[] nums)
        {
            List<string> result = new List<string>();
            if (nums==null || nums.Length==0)
            {
                return result;
            }

            long lenth = nums.LongLength;
            int lastNum = nums[0];
            int num = nums[0];
            string str=lastNum.ToString();

            for (long i = 1; i < lenth; i++)
            {
                lastNum = num;
                num = nums[i];
                if (num != lastNum + 1)
                {
                    if (lastNum.ToString()!=str)
                    {
                        str = str + "->" + lastNum;
                    }
                    result.Add(str);

                    str = num.ToString();
                }
            }

            if (num.ToString() != str)
            {
                result.Add(str + "->" + num);
            }
            else
            {
                result.Add(num.ToString());
            }
            
            return result;
        }


        /*
         * You are given two linked lists representing two non-negative numbers. 
         * The digits are stored in reverse order and each of their nodes contain a single digit. 
         * Add the two numbers and return it as a linked list.
         * Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
         * Output: 7 -> 0 -> 8
        */
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            if (l1==null || l2 == null)
            {
                return l1 == null ? l2 : l1;
            }

            ListNode tempResult = new ListNode((l1.val + l2.val) % 10);
            ListNode result = tempResult;
            int isCarry = 0;
            if (l1.val + l2.val >= 10)
            {
                isCarry = 1;
            }

            while (l1.next!=null && l2.next!=null)
            {
                ListNode temp = new ListNode((l1.next.val + l2.next.val + isCarry) % 10);
                tempResult.next = temp;

                if (l1.next.val + l2.next.val + isCarry >= 10)
                {
                    isCarry = 1;
                }
                else
                {
                    isCarry = 0;
                }
                
                l1 = l1.next;
                l2 = l2.next;
                tempResult = tempResult.next;
            }

            if (isCarry==1)
            {
                ListNode carry = new ListNode(1);
                tempResult.next = AddTwoNumbers(l1.next == null ? l2.next : l1.next, carry);
            }
            else
            {
                tempResult.next = AddTwoNumbers(l1.next == null ? l2.next : l1.next, null);
            }
            
            return result;
        }


        /*
         * Reverse Integer  
         * Reverse digits of an integer.
         * Example1: x = 123, return 321
         * Example2: x = -123, return -321
         * 
         * Have you thought about this?
Here are some good questions to ask before coding. Bonus points for you if you have already thought through this!
If the integer's last digit is 0, what should the output be? ie, cases such as 10, 100.
Did you notice that the reversed integer might overflow? 
         * Assume the input is a 32-bit integer, then the reverse of 1000000003 overflows. How should you handle such cases?
For the purpose of this problem, assume that your function returns 0 when the reversed integer overflows.
         */
        //Reverse Integer
        public int Reverse(int x)
        {
            int result = 0;
            string s;

            if (x<0)
            {
                if (x==int.MinValue)
                {
                    s = "0";
                }
                else
                {
                    s = "-" + new string(Math.Abs(x).ToString().Reverse().ToArray());
                }
            }
            else
            {
                s = new string(x.ToString().Reverse().ToArray());
            }

            int.TryParse(s, out result);

            return result;
        }

        public int Reverse2(int x)
        {
            int flag = 1;
            if (x < 0)
            {
                flag = -1;
            }

            if (x==int.MinValue)
            {
                return 0;
            }
            else
            {
                x = Math.Abs(x);
            }

            long result = 0;

            while (x > 0)
            {
                result = result * 10 + x % 10;
                x = x / 10;
            }

            if (result > int.MaxValue)
            {
                return 0;
            }
            else
            {
                return (int)result * flag;
            }
        }


        /*
         * Implement atoi to convert a string to an integer.
         * 
         * Hint: Carefully consider all possible input cases. 
         * Notes: It is intended for this problem to be specified vaguely (ie, no given input specs). 
         * You are responsible to gather all the input requirements up front.
         * 
         * Requirements for atoi:
         * The function first discards as many whitespace characters as necessary until the first non-whitespace character is found. 
         * Then, starting from this character, takes an optional initial plus or minus sign followed by as many numerical digits as possible, 
         * and interprets them as a numerical value.
         * The string can contain additional characters after those that form the integral number, 
         * which are ignored and have no effect on the behavior of this function.
         * If the first sequence of non-whitespace characters in str is not a valid integral number, 
         * or if no such sequence exists because either str is empty or it contains only whitespace characters, no conversion is performed.
         * If no valid conversion could be performed, a zero value is returned. 
         * If the correct value is out of the range of representable values, INT_MAX (2147483647) or INT_MIN (-2147483648) is returned.
         */
        //String to Integer (atoi) 
        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
	        {
                return 0;
	        }

            int result = 0;
            str=str.Trim();

            int flag=0;
            if (str[0]=='-'||str[0]=='+')
	        {
                flag=1;
	        }
            for (int i = flag; i < str.Length && str[i]>='0' && str[i]<='9' ; i++)
            {
                //7+flag 的原因，int.MaxValue最后一位是7，int.MinValue最后一位是8
                if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && int.Parse(str[i].ToString()) > (7 + str[0] == '-' ? 1 : 0)))
                {
                    result = str[0] == '-' ? int.MinValue : int.MaxValue;
                    return result;
                }
                result = int.Parse(str[i].ToString()) + result * 10;
            }
            if (str[0] == '-')
            {
                result = result * -1;
            }

            return result;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
