#   200. Number of Islands
  
  
  
##  [题目地址](https://leetcode.com/problems/number-of-islands/ )
  
  
  
##  题目描述
给一个m * n的二维方阵matrix，其由'1' 与 '0'组成，求由'1'构成的连续区域个数
  
  
>
>示例:
>Example 1:
>grid = 
[
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
>输出: 1
>Example 2:
>[
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
>输出: 3
  
  
##  思路
简单粗暴的dfs，每一步检测当前位置是否为1，否直接返回，是则dfs相邻四格并把自身设为0
  
  
  
##  关键点
DFS
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int NumIslands(char[][] grid) {
        HashSet<int> hash = new HashSet<int>();
        int m = grid.Length;
        int n = grid[0].Length;
        int count = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                count += DFS(grid, i, j);
            }
        }
        return count;
    }
    
    private int DFS(char[][] grid, int i, int j){
        if(i >= grid.Length || j >= grid[0].Length || j < 0 || i < 0 || grid[i][j] != '1')
            return 0;
        grid[i][j] = '0';
        DFS(grid, i, j + 1);
        DFS(grid, i + 1, j);
        DFS(grid, i, j - 1);
        DFS(grid, i - 1, j);
        return 1;
    }
}
```
  
  