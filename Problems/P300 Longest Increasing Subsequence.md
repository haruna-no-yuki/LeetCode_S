#   300. Longest Increasing Subsequence
  
  
  
##  [题目地址](https://leetcode.com/problems/longest-increasing-subsequence/ )
  
  
  
##  题目描述
给一个int数组，求其中最常递增序列长度
  
  
>
>示例:
>Example 1:
>[10,9,2,5,3,7,101,18]
>输出: 4
>Example 2:
>[7,7,7,7,7,7,7]
>输出: 1
  
  
##  思路
初始解法用动规去解，int数组dp记录以第i号元素结尾的最长长度。向前遍历，若小于nums[i]则dp[i] = max(dp[i], dp[j] + 1)
这样做的解法时间复杂度是O(n^2),在遍历寻找最大长度时花费时间较多。
要减少遍历的时间消耗，第一时间想到二分法，但对记录最长长度的dp，二分法无法起效，于是我们换一个记录状态的数组tails

tails[k]记录长度为k+1的序列尾部元素，每次遍历中尽可能保证最小
在遍历时，如果存在元素使tails[i] > nums[j],则右指针一定会向内缩放，最后逼近得到的index直接以nums[j]赋值；
如果不存在，则右指针保持不变，遍历完后ans++，同时逼近的index即为新的尾部；
以上两种结果都保证了tails[k]尽可能小的特点
这里我对二分法的循环与退出条件有了进一步的认识。什么时候是小于等于，什么时候左右指针向内缩放。
  
  
  
##  关键点
  
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] dp = new int[nums.Length];
        dp[0] = 1;
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            ans = Math.Max(ans, GetMaxLength(i,nums, dp));
        }
        return ans;
    }

    private int GetMaxLength(int index, int[] nums, int[] dp){
        for (int i = 0; i < index; i++)
        {
            if (nums[i] < nums[index]){
                dp[index] = Math.Max(dp[i]+1, dp[index]);
            }
        }
        if (dp[index] == 1) dp[index] = 1;
        return dp[index];
    }
}
```

* **方法1**
```c
public class Solution {
    public int LengthOfLIS(int[] nums) {
        int[] tails = new int[nums.Length];
        int ans = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            int comPare = nums[i];
            int left = 0;
            int right = ans;
            while (left < right)
            {
                int mid = (left + right) / 2;
                if (tails[mid] < comPare) left = mid + 1;
                else right = mid;
            }
            tails[left] = comPare;      //无论是哪种都能保证tails[left] >= comPare
            if (ans == right) ans++;
        }
        return ans;
    }
}
```
  
  