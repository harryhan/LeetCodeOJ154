/******************************************************************
* Copyright (C): http://www.EmersonNetwork.com
* CLR版本: 4.0.30319.17929
* 命名空间名称: LeetCodeOJ154
* 文件名: String
* 创建者: H92774
* 创建时间: 2015/7/7 16:28:38
******************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Collections;

namespace LeetCodeOJ154
{
    partial class Solution
    {
        /*
         * Given a string, find the length of the longest substring without repeating characters. 
         * For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
         * which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
        */
        //Longest Substring Without Repeating Characters
        public int LengthOfLongestSubstring(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return 0;
            }

            int result = 0;
            int startIndex = 0;
            Dictionary<char, int> dic = new Dictionary<char, int>();
            
            for (int i = 0; i < s.Length; i++)
            {
                if (dic.ContainsKey(s[i]))
                {
                    result = Math.Max(result, i - startIndex);
                    startIndex = Math.Max(startIndex, dic[s[i]] + 1);
                    dic[s[i]] = i;
                }
                else
                {
                    dic.Add(s[i], i);
                }
            }

            result = Math.Max(result, s.Length - startIndex);

            return result;
        }


        /*
         * Given a string S, find the longest palindromic substring in S. 
         * You may assume that the maximum length of S is 1000, 
         * and there exists one unique longest palindromic substring.
        */
        //Longest Palindromic Substring
        public string LongestPalindrome(string s)
        {
            int length = s.Length;
            if (length == 1) return s;

            int maxSubString = 0;
            int startIndex = 0;
            
            for (int i = 0; i < length; i++)
            {
                //LongestPalindromeEven like abccba
                int tempStart = i;
                int tempEnd = i + 1;
                int tempMax = 0;
                while (tempStart >= 0 && tempEnd <= length - 1 && s[tempStart] == s[tempEnd])
                {
                    tempMax = tempMax + 2;
                    if (tempMax>maxSubString)
                    {
                        maxSubString = tempMax;
                        startIndex = tempStart;
                    }
                    tempStart--;
                    tempEnd++;
                }

                //LongestPalindromeOdd like abcDcba
                tempStart = i - 1;
                tempEnd = i + 1;
                tempMax = 1;
                while (tempStart >= 0 && tempEnd <= length - 1 && s[tempStart] == s[tempEnd])
                {
                    tempMax = tempMax + 2;
                    if (tempMax>maxSubString)
                    {
                        maxSubString = tempMax;
                        startIndex = tempStart;
                    }
                    tempStart--;
                    tempEnd++;
                }
            }

            return s.Substring(startIndex, maxSubString);
        }

        public string LongestPalindromeDefective(string s)
        {
            //if (string.IsNullOrEmpty(s))
            //{
            //    return s;
            //}
            
            string result = s[0].ToString();
            if (s.Length>=2 && (s[0]==s[1]))
            {
                result=s.Substring(0,2);
            }

            var evenResult = LongestPalindromeEven(s);
            var oddResult = LongestPalindromeOdd(s);

            result = evenResult.Length > oddResult.Length ? evenResult : oddResult;

            return result;
        }
        private string LongestPalindromeEven(string s)
        {
            string result = s[0].ToString(); ;
            int startIndex = 0;

            for (int i = 1; i < s.Length; i++)
            {
                if (startIndex>=0 && s[i] == s[startIndex])
                {
                    if (s.Substring(startIndex, i - startIndex + 1).Length > result.Length)
                    {
                        result = s.Substring(startIndex, i - startIndex + 1);
                    }
                    startIndex--;
                }
                else
                {
                    startIndex = i;
                }
            }

            return result;
        }
        private string LongestPalindromeOdd(string s)
        {
            string result = s[0].ToString(); ;
            int startIndex = 0;

            for (int i = 2; i < s.Length; i++)
            {
                if (startIndex >= 0 && s[i] == s[startIndex])
                {
                    if (s.Substring(startIndex, i - startIndex + 1).Length > result.Length)
                    {
                        result = s.Substring(startIndex, i - startIndex + 1);
                    }
                    startIndex = startIndex - 1;
                }
                else
                {
                    startIndex = i - 2;
                    if (startIndex >= 0 && s[i] == s[startIndex])
                    {
                        if (s.Substring(startIndex, i - startIndex + 1).Length > result.Length)
                        {
                            result = s.Substring(startIndex, i - startIndex + 1);
                        }
                        startIndex = startIndex - 1;
                    }
                    else
                    {
                        startIndex = i - 1;
                    }
                }
            }

            return result;
        }

        public string LongestPalindromeOther(string s)
        {
            if (s == null || s.Length == 1)
            {
                return s;
            }

            int left = 0;
            int maxLen = 0;
            for (int k = 0; k < s.Length; k++)
            {
                // even mode
                int i = k;
                int j = k + 1;
                int possibleMaxLen1 = 2 * Math.Min(i + 1, s.Length - j);
                if (possibleMaxLen1 > maxLen)
                {
                    int len = 0;
                    while (i >= 0 && j < s.Length && s[i] == s[j])
                    {
                        len++;
                        i--;
                        j++;
                    }

                    len = 2 * len;
                    if (len > maxLen)
                    {
                        left = i + 1;
                        maxLen = len;
                    }
                }

                // odd mode
                i = k;
                j = k + 2;
                int possibleMaxLen2 = 2 * Math.Min(i + 1, s.Length - j) + 1;
                if (possibleMaxLen2 > maxLen)
                {
                    int len = 0;
                    while (i >= 0 && j < s.Length && s[i] == s[j])
                    {
                        len++;
                        i--;
                        j++;
                    }

                    len = 2 * len + 1;

                    if (len > maxLen)
                    {
                        left = i + 1;
                        maxLen = len;
                    }
                }
            }

            return s.Substring(left, maxLen);
        }

        public string LongestPalindromeOther2(string s)
        {
            int max = 0;
            int start = 0;

            if (s.Length == 1)
            {
                return s;
            }

            for (int i = 0; i < s.Length; i++)
            {
                // cover the case like: abccba
                int tempMax = 0;
                int tempStart = i;
                int tempEnd = i + 1;

                while (tempStart >= 0 && tempEnd <= s.Length - 1 && s[tempStart] == s[tempEnd])
                {
                    tempMax += 2;

                    if (tempMax > max)
                    {
                        max = tempMax;
                        start = tempStart;
                    }

                    tempStart--;
                    tempEnd++;
                }

                // cover the case like : abcdcba
                tempStart = i - 1;
                tempEnd = i + 1;
                tempMax = 1;

                while (tempStart >= 0 && tempEnd <= s.Length - 1 && s[tempStart] == s[tempEnd])
                {
                    tempMax += 2;

                    if (tempMax > max)
                    {
                        max = tempMax;
                        start = tempStart;
                    }

                    tempStart--;
                    tempEnd++;
                }
            }

            return s.Substring(start, max);
        }


        /*
         * The string "PAYPALISHIRING" is written in a zigzag pattern on a given number of rows like this: 
         * (you may want to display this pattern in a fixed font for better legibility)
            P   A   H   N
            A P L S I I G
            Y   I   R
            And then read line by line: "PAHNAPLSIIGYIR"
            Write the code that will take a string and make this conversion given a number of rows:

            string convert(string text, int nRows);
            convert("PAYPALISHIRING", 3) should return "PAHNAPLSIIGYIR".
        */
        //ZigZag Conversion
        public string ConvertZigZag(string s, int numRows)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }
            
            StringBuilder[] result = new StringBuilder[numRows];
            int index = 0, flag = -1;

            for (int i = 0; i < numRows; i++)
            {
                result[i] = new StringBuilder();
            }

            for (int i = 0; i <= s.Length-1; i++)
            {
                result[index].Append(s[i]);

                if (numRows>1)
                {
                    if (index == 0 || index == numRows - 1)
                    {
                        flag = -flag;
                    }
                    index = index + flag;
                }
            }

            for (int i = 1; i < numRows; i++)
            {
                result[0].Append(result[i]);
            }
            return result[0].ToString();
        }
    }
}
