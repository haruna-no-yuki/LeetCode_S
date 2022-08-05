#   377. Combination Sum IV
  
  
  
##  [题目地址](https://leetcode.com/problems/combination-sum-iv/ )
  
  
  
##  题目描述
给一组正整数nums和一个正整数target，求用nums中元素相加获得target的不同组合方式总数
  
  
>
>示例:
>Example 1:
>nums = [1,2,3], target = 4
>输出: 7
>Example 2:
>nums = [9], target = 3
>输出: 0
  
  
##  思路
最初的思路就是常见的递归解决，F(target)可以分解为F(target - nums[i])之和，同时用记忆递归减少时间消耗。
同时另一种解法是由0向target靠拢
F(0) = 1,F(i) = F(i - nums[i])之和，但是这样只用套一遍由1到target的循环，内部判断 nums[i] > i则跳过
  
##  关键点
  
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    Dictionary<int, int> dic = new Dictionary<int, int>();
    public int CombinationSum4(int[] nums, int target) {
        if (target < 0) {
            return 0;
        }
        else if (target == 0){
            return 1;
        }
        if (dic.ContainsKey(target)) return dic[target];
        int sum = 0;
        for (int i = 0; i < nums.Length; i++)
        {   
            sum += CombinationSum4(nums, target- nums[i]);
        }
        if (!dic.ContainsKey(target)) dic.Add(target, sum);
        return sum;
    }
}
```

* **方法2**
```c
public class Solution {
    public int CombinationSum4(int[] nums, int target) {
        int[] dp = new int[target+1];
        dp[0] = 1;
        for (int i = 0; i < dp.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] > i)
                    continue;
                dp[i] += dp[i - nums[j]];
            }
        }
        return dp[target];
    }
}
```
  
  