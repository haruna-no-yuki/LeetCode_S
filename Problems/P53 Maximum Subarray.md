#   53. Maximum Subarray
  
  
  
##  [题目地址](https://leetcode.com/problems/maximum-subarray/)
  
  
  
##  题目描述
给一个int类型的数组，求其中最大子序列和的值
  
  
>
>示例:
>Example 1:
>[-2,1,-3,4,-1,2,1,-5,4]
>输出: 6
>Example 2:
>[5,4,-1,7,8]
>输出: 23
  
  
##  思路
初始想法为动态规划，建立状态方程。
易知当下一个数为正数时，其可以直接添加到当前和中，重点是讨论负数或0的情况
动态规划的时间复杂度为O(n)，相比其他解法要快
  
  
##  关键点
动态规划（dp）
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int MaxSubArray(int[] nums) {
        int begin = -1;
        int end = -1;
        List<int> ansList = new List<int>();
        ansList.Add(int.MinValue);
        for (int i = 0; i < nums.Length; i++)
        {
            if(nums[i] > 0)
            {
                begin = i;
                break;
            }
        }
        if (begin < 0){
            int min = int.MinValue;
            for (int i = 0; i < nums.Length; i++)
            {
                min = Math.Max(nums[i], min);
            }
            return min;
        }
        int sum = 0;
        for (int i = begin; i < nums.Length; i++)
        {
            if (nums[i] >= 0){
                sum += nums[i];
            }
            else{
                if (sum + nums[i] > 0)
                {
                    if (ansList[ansList.Count - 1] < sum)
                        ansList.Add(sum);
                    sum += nums[i];
                }
                else
                {
                    if (ansList[ansList.Count - 1] < sum)
                        ansList.Add(sum);
                    sum = 0;
                }
            }
        }
        int ans = Math.Max(ansList[ansList.Count - 1], sum);
        return ans;
    }
}
```
  
  