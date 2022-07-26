# Max Consecutive Ones III
  
## [题目地址](https://leetcode.com/problems/max-consecutive-ones-iii/ )


## 题目描述
  
>给定一个由若干 0 和 1 组成的数组 A，我们最多可以将 K 个值从 0 变成 1 。
>
>返回仅包含 1 的最长（连续）子数组的长度。
>
> 
>示例 1：
>
>输入：A = [1,1,1,0,0,0,1,1,1,1,0], K = 2
>输出：6
>解释：
>[1,1,1,0,0,1,1,1,1,1,1]
>粗体数字从 0 翻转到 1，最长的子数组长度为 6。
>
>示例 2：
>
>输入：A = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], K = 3
>输出：10
>解释：
>[0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
>粗体数字从 0 翻转到 1，最长的子数组长度为 10。
>
>提示：
>
>1 <= A.length <= 20000
>0 <= K <= A.length
>A[i] 为 0 或 1 
  
  
## 思路
  
最初的想法是通过求和与k比较直接找到对应的序列最大长度。每次对固定长度的子数组求和只需对首尾值进行改变，内部值保持不变，同时遍历待选的最大长度也由最大值递减优化为二分。时间复杂度由O(n^2)变为O(nlgn)
  
可实际上，一遍遍历数组即可完成区间与区间长度的筛选。我们采取双指针方法，每次遍历右指针向右移一位，如果发现条件不满足，则左指针向右移，并得到当前的最大区间长度。对每次的长度进行最大值比较，在遍历结束后即可获得整个序列满足条件的最大长度。

值得一提的是，每一次遍历右指针只会向右移动一次，所以当出现不满足条件的情况时，左指针向右移动一位即可：即最新加入序列的数是导致不满足条件的原因，在只用判断序列长度的情况下，左指针也只需移动一次即可。但这样会损失有关最常序列出现位置等信息。所以作为此类活动区间的通解，使用while当即判断出最大长度更为稳妥。
  
## 关键点
  
活动区间，双指针
  
## 代码
  
  
* **方法1**
```c
public class Solution {
    public int LongestOnes(int[] nums, int k) { 
        int consencutiveL = nums.Length;
        int start,end;
        start = 1;
        end = nums.Length;
        int maxL = -1;
        while (consencutiveL >= 1 && start <= end)
        {
            maxL = Get(nums, k, consencutiveL);
            start = maxL < 0?start : consencutiveL + 1;
            end = maxL < 0?consencutiveL - 1 : end;
            consencutiveL = (start + end)/2;
        }
        return consencutiveL;
    }

    private int Get(int[] nums, int k, int consencutiveL){
        int tempSum = 0;
        int maxL = -1;
        for (int i = 0; i < consencutiveL; i++)
        {
            tempSum += nums[i];
        }
        for (int i = 0; i <= nums.Length - consencutiveL; i++)
        {
            int minusNum,addNum;
            minusNum = i == 0 ? 0 : nums[i - 1];
            addNum = i == 0 ? 0 : nums[i + consencutiveL - 1];
            tempSum = tempSum - minusNum + addNum;
            if (tempSum >= consencutiveL - k){
                maxL = maxL > consencutiveL ? maxL : consencutiveL;
            }
        }
        return maxL;
    }
}
```
  
* **方法2**
```c
public int LongestOnes(int[] nums, int k) { 
    int start,end,sum;
    start = 0;
    end = 0;
    sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        while (sum + k < i + 1)
        {
             sum += 1 - nums[start];
             start++;
        }
        end = Math.Max(end, i - start + 1);
    }
    return end;
}
```

* **方法3**
```c
private int SimpleSolution(int[] nums, int k){
    int start,sum;
    start = 0;
    sum = 0;
    for (int i = 0; i < nums.Length; i++)
    {
        sum += nums[i];
        if (sum + k < i + 1)
        {
             sum += 1 - nums[start];
             start++;
        }
    }
    return nums.Length - start + 1;
}
```
  
  
  