#   378. Kth Smallest Element in a Sorted Matrix
  
  
  
##  [题目地址](https://leetcode.com/problems/kth-smallest-element-in-a-sorted-matrix/ )
  
  
  
##  题目描述
给一个n阶矩阵，其中每列，每行的各元素已排为增长序列，求矩阵中第k小元素
  
>
>示例:
>Example 1:
>matrix = [[1,5,9],[10,11,13],[12,13,15]], k = 8
>输出: 13
>Example 2:
>matrix = [[-5]], k = 1
>输出: -5
  
  
##  思路
最初想法是按照对角线统计当前所有对角线上的元素总数，后发现第i条对角线上的元素不一定比第i+1条对角线上元素小
后查阅他人评论采用二分法，取matrix[0][0]与matrix[n - 1][n - 1]作为二分的两个起点，循环内统计当前矩阵中不小于mid的总数并做分类讨论
值得注意的是，最后所得到的结果是二分中low与high逐渐逼近的结果，其由于自然数的完备性一定存在于矩阵之中。且计算平均数时，对和为负数的情况，直接首尾相加除以2可能会得到更逼近high的结果，在这道题中是不能接受的。

  
##  关键点
二分
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int KthSmallest(int[][] matrix, int k) {
        int n = matrix.Length;
        int low,high,mid;
        low = matrix[0][0];
        high = matrix[n-1][n-1];
        int lessCount;
        while (low < high)
        {
            lessCount = 0;
            mid = (low + high) >> 1;
            int temp = n - 1;
            for (int i = 0; i < n; i++)
            {
                while (temp >= 0 && matrix[i][temp] > mid)
                {
                     temp--;
                }
                lessCount += (temp + 1);
            }
            if (lessCount < k){
                low = mid + 1;
            }
            else{
                high = mid;
            }
        }
        return low;
    }
}
```
  
  