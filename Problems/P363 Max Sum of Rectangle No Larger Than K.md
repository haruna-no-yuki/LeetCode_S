#   363. Max Sum of Rectangle No Larger Than K
  
  
  
##  [题目地址](https://leetcode.com/problems/max-sum-of-rectangle-no-larger-than-k/ )
  
  
  
##  题目描述
给你一个 m x n 的矩阵 matrix 和一个整数 k ，找出并返回矩阵内部矩形区域的不超过 k 的最大数值和。

题目数据保证总会存在一个数值和不超过 k 的矩形区域。
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2021/03/18/sum-grid.jpg )
>
>输出: 2
>
>Example 2:
>matrix = [ [2,2,-1] ], k = 3
>
>输出: 3
  
  
##  思路
需要参考P53，求最大子序列和。
对于一个二维的方阵的区域求和，我们可以先将其降维成一维数组，问题转化为在一维数组中求最大的不大于k的和
数组中每个元素的含义指的是当前列（行）所有位于上下边界内的元素之和
```math
    令a_l,a_s为数组a前l，s项的和，我们所求的即为找到数组中满足a_l - a_s \leq k条件的最大差值。更换不等式两端转换为：a_l - k \leq a_s， 我们用hashSet记录数组前s项的和，同时在遍历中找出math.ceil(a_l - k),其最大值即是我们所求的答案
```
  
  
##  关键点
二维方阵降维，最大子序列求和  

  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int MaxSumSubmatrix(int[][] matrix, int k) {
        int m = matrix.Length;
        int n = matrix[0].Length;
        int ans = int.MinValue;
        for (int i = 0; i < m; i++)
        {
            int[] sum = new int[n];
            for (int j = i; j < m; j++)
            {
                for (int x = 0; x < n; x++)
                {
                    sum[x] += matrix[j][x];
                }
                HashSet<int> hash = new HashSet<int>();
                hash.Add(0);
                int temp = 0;
                for (int y = 0; y < sum.Length; y++)
                {
                    temp += sum[y];
                    int ceiling = FindCeilInHash(hash, temp - k);
                    if (ceiling != int.MaxValue){
                        ans = Math.Max(ans, temp - ceiling);
                        
                    }
                    hash.Add(temp);
                }
            }
        }
        return ans;
    }

    private int FindCeilInHash(HashSet<int> h, int target){
        int ceiling = int.MaxValue;
        foreach (var item in h)
        {
            if (item >= target)
                ceiling = Math.Min(ceiling, item);
        }
        return ceiling;
    }
```
  
  
