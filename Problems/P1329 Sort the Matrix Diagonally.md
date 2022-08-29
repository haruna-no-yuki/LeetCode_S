#   1329. Sort the Matrix Diagonally
  
  
  
##  [题目地址](https://leetcode.com/problems/sort-the-matrix-diagonally/ )
  
  
  
##  题目描述
矩阵对角线 是一条从矩阵最上面行或者最左侧列中的某个元素开始的对角线，沿右下方向一直到矩阵末尾的元素。例如，矩阵 mat 有 6 行 3 列，从 mat[2][0] 开始的 矩阵对角线 将会经过 mat[2][0]、mat[3][1] 和 mat[4][2] 。

给你一个 m * n 的整数矩阵 mat ，请你将同一条 矩阵对角线 上的元素按升序排序后，返回排好序的矩阵。
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2020/01/21/1482_example_1_2.png )
>输出: 如上
>
>Example 2:
>mat = [ [11,25,66,1,69,7],[23,55,17,45,15,52],[75,31,36,44,58,8],[22,27,33,25,68,4],[84,28,14,11,5,50] ]
>输出: [ [5,17,4,1,52,7],[11,11,25,45,8,69],[14,23,25,44,58,15],[22,27,31,36,50,66],[84,28,75,33,55,68] ]
  
  
##  思路
对每条对角线录入数据，排序后按顺序放置
  
  
  
##  关键点
无
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    int m,n;
    public int[][] DiagonalSort(int[][] mat) {
        m = mat.Length;
        n = mat[0].Length;
        for (int i = 0; i < m; i++)
        {
            SortByDiagonal(i, true, mat);
        }
        for (int i = 1; i < n; i++)
        {
            SortByDiagonal(i, false, mat);
        }
        return mat;
    }

    private void SortByDiagonal(int begin, bool bUp, int[][] mat){
        int[] indexs = new int[2];
        int sortedIndex = 0;
        List<int> list = GetPresentDiagonalList(begin, bUp, mat);
        if (bUp){
            indexs[0] = begin;
            indexs[1] = 0;
        }
        else
        {
            indexs[0] = 0;
            indexs[1] = begin;
        }
        while (indexs[0] < m &&  indexs[1] < n)
        {
            mat[indexs[0]][indexs[1]] = list[sortedIndex];
            sortedIndex++;
            for (int i = 0; i < indexs.Length; i++)
            {
                indexs[i]++;
            }
        }
    }

    private List<int> GetPresentDiagonalList(int begin, bool bUp, int[][] mat){
        List<int> list = new List<int>();
        int[] indexs = new int[2];
        if (bUp){
            indexs[0] = begin;
            indexs[1] = 0;
        }
        else
        {
            indexs[0] = 0;
            indexs[1] = begin;
        }
        while (indexs[0] < m && indexs[1] < n)
        {
            list.Add(mat[indexs[0]][indexs[1]]);
            for (int i = 0; i < indexs.Length; i++)
            {
                indexs[i]++;
            }
        }
        list.Sort();
        return list;
    }
}
```
  
  
