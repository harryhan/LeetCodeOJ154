using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeOJ154
{
    partial class Solution
    {
        /*
         * Given n non-negative integers a1, a2, ..., an, where each represents a point at coordinate (i, ai). 
         * n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). 
         * Find two lines, which together with x-axis forms a container, such that the container contains the most water.
         */
        //Container With Most Water
        public int MaxArea(int[] height)
        {
            int maxArea = 0, tempArea = 0;
            int left = 0, right = height.Length - 1;

            while (left < right)
            {
                tempArea = (right - left) * Math.Min(height[left], height[right]);
                maxArea = Math.Max(maxArea, tempArea);
                if (height[left] < height[right])
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }

            return maxArea;
        }

        public int MaxArea2(int[] height)
        {
            int maxArea = 0, tempArea = 0;
            int arrayLength = height.Length;
            for (int i = 0; i < arrayLength; i++)
            {
                for (int j = i + 1; j < arrayLength; j++)
                {
                    tempArea = Math.Min(height[i], height[j]) * (j - i);
                    maxArea = Math.Max(maxArea, tempArea);
                }
            }

            return maxArea;
        }
    }
}
