#   62. Unique Paths
  
  
  
##  [题目地址](https://leetcode.com/problems/unique-paths/ )
  
  
  
##  题目描述
起始点(0, 0),终点(m, n)，每次只能在x或y轴上平移一格，问最短路径数
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2018/10/22/robot_maze.png )
>输出: 28
>输出: 
  
  
##  思路
答案是C(m+n-2, m - 1)，问题是如何求得较大数的阶乘
为了优化时间，我们使用字典存储已经计算过的中间节点。
也可以采用一维数组简化空间。其中一维数组的每次循环含义是：x = i时，不同y取值对应的路径（空间复杂度变为O(mn))
  
  
##  关键点
排列组合，记忆化递归
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public int UniquePaths(int m, int n) {
        int ans = Factorial(m + n - 2, m - 1);
        return ans;
    }

    private int Factorial(int m, int n){
        if (m == 1){return 1;}
        if (n == 0 || n == m) {return 1;}
        string s = string.Concat(m.ToString(), "_", n.ToString());
        string s1 = string.Concat(m.ToString(), "_", (m-n).ToString());
        if (dictionary.ContainsKey(s)){
            return dictionary[s];
        }
        if (dictionary.ContainsKey(s1)){
            return dictionary[s1];
        }
        int ans = Factorial(m - 1,  n - 1) + Factorial(m - 1, n);
        dictionary.Add(s, ans);
        if (!s.Equals(s1)){
            dictionary.Add(s1,ans);
        }
        return ans;
    }
}
```

* **方法1**
```c
public class Solution {
    public int UniquePaths(int m, int n) {
        int ans = OmnAnalyse(m, n);
        return ans;
    }

    private int OmnAnalyse(int m, int n){
        int[] dp = new int[n];
        for (int i = 0; i < n; i++)
        {
            dp[i] = 0;
        }
        dp[0] = 1;
        for (int i = 0; i < m; i++)
        {
            for (int j = 1; j < n; j++)
            {
                dp[j] += dp[j - 1];
            }
        }
        return dp[n - 1];
    }
}
```
  
  
