#   48. Rotate Image
  
  
  
##  [题目地址](https://leetcode.com/problems/rotate-image/ )
  
  
  
##  题目描述
给一个n阶矩阵，输出其顺时针旋转 Math.Pi / 2后的矩阵
要求空间复杂度小于O(n^2)
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2020/08/28/mat1.jpg )
>输出: {[7,4,1],[8,5,2],[9,6,3]}
>Example 2:
>![](https://assets.leetcode.com/uploads/2020/08/28/mat2.jpg )
>输出: {[15,13,2,5],[14,3,4,1],[12,6,8,9],[16,7,10,11]}
  
  
##  思路
初始思路是对最外层的元素进行替换，每层循环矩阵阶层 n 减 2
同时因为要尽可能减少空间复杂度，所以在做交换时，也得到了通用的，不是用额外空间的交换方法

查阅他人评论后发现也可以进行对角线做对称变换，然后再做水平对称变换：

![](https://camo.githubusercontent.com/93f39844d3b358004f7eec48d4298b2adf91e66350fde1fc655709515dda0489/68747470733a2f2f747661312e73696e61696d672e636e2f6c617267652f30303753385a496c6c793167686c7479616a3666316a33306d79306165676d612e6a7067)
  
  
##  关键点

  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public void Rotate(int[][] matrix) {
        for (int i = 0; i < matrix.Length / 2; i++)
        {
            RotateCertainRow(matrix, i);
        }   
    }

    private void RotateCertainRow(int[][] matrix, int row){
        int endLength = matrix.Length - row - 1;
        int beginLength = row;
        if (endLength - beginLength < 1){return ;}
        for (int i = beginLength; i < endLength; i++)
        {
            /*int temp1 = matrix[beginLength][i];
            int temp2 = matrix[i][endLength];
            int temp3 = matrix[endLength][endLength + beginLength - i];
            int temp4 = matrix[endLength + beginLength - i][beginLength];
            matrix[i][endLength] = temp1;
            matrix[endLength][endLength + beginLength - i] = temp2;
            matrix[endLength + beginLength - i][beginLength] = temp3;
            matrix[beginLength][i] = temp4;*/
            SwapBetweenFour(ref matrix[beginLength][i], 
                            ref matrix[endLength + beginLength - i][beginLength], 
                            ref matrix[endLength][endLength + beginLength - i],
                            ref matrix[i][endLength]);
        }
    }

    private void SwapBetweenFour(ref int a, ref int b, ref int c, ref int d){
        d = a + b + c - d;
        c = a + b + c - d;
        b = d - a - b + c;
        a = d - a - b + c;
        d = d + c - a - b;
    }
}
```


  
  