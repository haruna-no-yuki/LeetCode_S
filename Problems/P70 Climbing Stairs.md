#   70. Climbing Stairs

  
##  [题目地址](https://leetcode.com/problems/climbing-stairs/ )
  
  
  
##  题目描述
给一个整数n，起点为0,。你可以每次选择加1或加2，问有多少种排列方式能够使所有加数之和为n

  
  
>
>示例:
>Example 1:
>n = 2
>
>输出: 2
>
>Example 2:
>n = 3
>
>输出: 3
  
  
##  思路
此题是一道标准的动态规划题，可以把问题分治为d[n] = d[n-1] + d[n-2]，但这类简单且没有附加条件的题再用dp的方式反而落了下风。
这里我们考虑使用数学的方式去思考。

由于是求排列总数，容易联想到C<sub>n</sub><sup>m</sup>， 取(1 + 2)<sup>n</sup> 的二项式展开，我们发现，对于其中每一项 C<sub>n</sub><sup>i</sup>，其乘数2与1构成的组合对应了一个可以达成的条件。

例：C<sub>n</sub><sup>i</sup> * 2<sup>i</sup> * 1<sup>(n - i)</sup>， 对应 2i + n - i = n + i.
即我们取所有满足 n + i = n`的n i组合，取所有C<sub>n</sub><sup>i</sup>之和即可得到结果

  
  
##  关键点
二项式展开

  
##  代码
  
  
* **方法1**
```c
public class Solution
{
    public int ClimbStairs(int n)
    {
        int beginValue = (int)Math.Ceiling((double)n / 2);
        int returnANs = 0;
        for (int i = beginValue; i <= n; i++)
        {
            returnANs += CombinationDynamic(i, n - i);
        }
        return returnANs;
    }

    private int CombinationDynamic(int n, int m)
    {
        int[,] Combination = new int[n + 1, m + 1];
        int i, j;
        for (i = 0; i <= n; i++)
        {
            for (j = 0; j <= Math.Min(i, m); j++)
            {
                if (j == 0 || j == i)
                    Combination[i, j] = 1;
                else
                    Combination[i, j] = Combination[i - 1, j - 1] + Combination[i - 1, j];
            }
        }

        return Combination[n, m];
    }
}
```
  
  
