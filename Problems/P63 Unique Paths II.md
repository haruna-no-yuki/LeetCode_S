#   63. Unique Paths II
  
  
  
##  [题目地址](https://leetcode.com/problems/unique-paths-ii/ )
  
  
  
##  题目描述
与P62类似，这次我们在一些坐标上做不能通过的标记，所有到达终点的路径不能包含任意做标记的点，求到达终点的最短路径数。
输入数据为int的交错数组，并且保证每一行列数相等
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2020/11/04/robot1.jpg )
>输出: 2
>Example 2:
>![](https://assets.leetcode.com/uploads/2020/11/04/robot1.jpg )
>输出: 1
  
  
##  思路
在这里继续套用排列公式不太方便，转而采用一般动规思路：num[i,j] = num[i-1,j] + num[i,j-1]。
加上判断条件：if 被标记 then num[i,j] = 0

同样的，我们也可以使用一维数组记录路径数。
判断条件变为： if array[i,j]被标记 then dp[j] = 0
  
  
  
##  关键点
动规，筛选条件
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    Dictionary<string, int> dictionary = new Dictionary<string, int>();
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        if (obstacleGrid[0][0] == 1){
            return 0;
        }
        int ans = Factorial(m, n, obstacleGrid);
        return ans;
    }

    private int Factorial(int m, int n, int[][] obstacleGrid){
        if (m - 1< 0 || n - 1 < 0 || obstacleGrid[m - 1][n - 1] == 1){return 0;}
        if (m * n == 2 || m *n == 1){return 1;}
        string s = string.Concat(m.ToString(), "_", n.ToString());
        if (dictionary.ContainsKey(s)){
            return dictionary[s];
        }
        int ans = Factorial(m - 1,  n, obstacleGrid) + Factorial(m, n - 1, obstacleGrid);
        dictionary.Add(s, ans);
        return ans;
    }
}
```
  

* **方法2**
```c
public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        int m = obstacleGrid.Length;
        int n = obstacleGrid[0].Length;
        if (obstacleGrid[0][0] == 1){
            return 0;
        }
        int ans = OmnAnalayse(m,n,obstacleGrid);
        return ans;
    }

    private int OmnAnalayse(int m, int n, int[][] obstacleGrid){
        int[] temp = new int[n];
        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = 0;
        }
        temp[0] = 1;
        for (int i = 0; i < m; i++)
        {
            if (obstacleGrid[i][0] == 1){
                temp[0] = 0;
            }
            for (int j = 1; j < n; j++)
            {
                if (obstacleGrid[i][j] == 1){
                    temp[j] = 0;
                    continue;
                }
                temp[j]+= temp[j - 1];
            }
        }
        return temp[n - 1];
    }
}
``` 