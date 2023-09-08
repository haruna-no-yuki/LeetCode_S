#   84. Largest Rectangle in Histogram
  
  
  
##  [题目地址](https://leetcode.com/problems/largest-rectangle-in-histogram/)
  
  
  
##  题目描述
给定 n 个非负整数，用来表示柱状图中各个柱子的高度。每个柱子彼此相邻，且宽度为 1 。

求在该柱状图中，能够勾勒出来的矩形的最大面积。

  
>
>示例:
>Example 1:

>![](https://assets.leetcode.com/uploads/2021/01/04/histogram.jpg )

>输出: 10

  
  
##  思路
此题初步一看以为是动归题，也确实是从动归题目的相似题下跳转而来，实际不是。

类似于泳池积水，我们依据每个元素的高遍历所有矩形，找到其最大能够延伸的宽度，得到该处矩形所能得到的最大面积。

值得一提的是此题在遍历过程中使用的栈结构，很大程度上减少了无效遍历。

易得对 i<sub>1</sub> < i<sub>2</sub>，若height[i<sub>1</sub>] > height[i<sub>2</sub>]，则对height[j]遍历的结果一定不会是 i<sub>1</sub> 。若为i<sub>1</sub> ，则必有 i<sub>2</sub>
相比i<sub>1</sub>更能满足条件。

所以我们维护一个高度严格单调递增的list，其代表的含义是对height[j]时可能返回的结果。又发现对height[j+1]遍历时，height[j]也为可能的答案之一。故在对height[j]遍历的结尾，我们可能会将其插入到list当中，同时移除比height[j]更大的元素（由上面的易得可知）
这完美符合栈结构的特征。

需注意的是，若在pop的过程中发现栈元素个数为0，则记录当前位置左边界为-1，这个特殊情况称为哨兵。由此我们得到了所有元素的左边界，我们再逆向遍历一遍右边界，这时哨兵值设为height.Length。

##  关键点
栈
  
  
##  代码
  
  
* **方法1**
```c
public class Solution
 {
     public int LargestRectangleArea(int[] heights)
     {
         int[] leftBoard = new int[heights.Length];
         int[] rightBoard = new int[heights.Length];
         Stack<int> stack = new Stack<int>();
         stack.Clear();
         for (int i = 0; i < heights.Length; i++)
         {
             StackProcess(stack, leftBoard, heights, i, true);
         }
         stack.Clear();
         for (int i = heights.Length - 1; i >= 0; i--)
         {
             StackProcess(stack, rightBoard, heights, i, false);
         }
         var returnAns = 0;
         for (int i = 0; i < heights.Length; i++)
         {
             returnAns = Math.Max(heights[i] * (rightBoard[i] - leftBoard[i] - 1), returnAns);
         }
         return returnAns;
     }
     public void StackProcess(Stack<int> stack, int[] boards, int[] heights, int index, bool isByOrder)
     {
         int defaultBoard = isByOrder ? -1 : heights.Length;
         if (stack.Count <= 0)
         {
             stack.Push(index);
             boards[index] = defaultBoard;
             return;
         }
         while (stack.Count > 0)
         {
             var target = heights[stack.Peek()];
             if (target >= heights[index])
             {
                 stack.Pop();
             }
             else
             {
                 break;
             }
         }
         boards[index] = stack.Count > 0 ? stack.Peek() : defaultBoard;
         stack.Push(index);
     }
 }
```
  
  