#  P34 Find First and Last Position of Element in Sorted Array
  
  
## [题目地址](https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/ )
  
  
## 题目描述
  
  
>给一个由整型数组成的数组与目标target，数组已经由低到高排序。找到数组中与target相等的的最小index与最大index组成的int数组
>示例:
>Example 1:
>输入:[5,7,7,8,8,10], target = 8
>输出:[3,4]
>Example 2:
>输入:[5,7,7,8,8,10], target = 6
>输出:[-1,-1]
  
## 思路
  
  
最初的想法是二分法找到与target相等的index，然后前后搜索直到边界为止
后来发现这样做的风险是，当整个数组有较大数量的值与target相等时，在前后搜索处可能会花费较多时间
于是采用两遍二分法，分别找到与target相等的最小index与最大index
  
## 关键点
  
二分法的运用，边界/退出条件
  
## 代码
  
* **方法1**
```c
public int[] SearchRange(int[] nums, int target) {
    int[] lastAns = {-1, -1};
    int length = nums.Length;
    if (length <= 0){
        return lastAns;
    }
    int a_Mid,beginIndex,endIndex,midIndex,tempIndex;
    beginIndex = 0;
    endIndex = length - 1;
    tempIndex = (endIndex + beginIndex) / 2;
    midIndex = -1;
    while (tempIndex != midIndex)
    {
        midIndex = tempIndex;
        a_Mid = nums[midIndex];
        if (a_Mid == target)
        {
            int r_Begin,r_End;
            r_Begin = r_End = midIndex;
            while (r_End <= length - 1 || r_Begin >= 0)
            {
                int tempB,tempE;
                tempB = r_Begin;
                tempE = r_End;
                r_Begin = (r_Begin >= 0 && nums[r_Begin] == target) ? r_Begin - 1: r_Begin;
                r_End = (r_End <= length - 1 && nums[r_End] == target) ? r_End + 1 : r_End;
                if (r_Begin == tempB && r_End == tempE){
                    break;
                }
            }
            int[] r_Array = new int[2];
            r_Array[0] = r_Begin + 1;
            r_Array[1] = r_End - 1;
            return r_Array;
        }
        else
        {
            if (a_Mid < target){
                beginIndex = midIndex + 1;
            }
            else
            {
                endIndex = midIndex - 1;
            }
        }
        tempIndex = (endIndex + beginIndex) / 2;
    }
    return lastAns;
}
```
  
* **方法2**
```c
public class Solution {
    public int[] SearchRange(int[] nums, int target) {
        int firstIndex = GetFirst(nums, target);
        int lastIndex = GetLast(nums, target);
        return new int[] {firstIndex, lastIndex};
    }
    private int GetFirst(int[] nums, int target){
        int beginIndex = 0;
        int endIndex = nums.Length - 1;
        int pos = -1;
        while (beginIndex <= endIndex)
        {
             int midIndex = (beginIndex + endIndex)/2;
             if (nums[midIndex] == target)
             {
                 pos = midIndex;
                 endIndex = midIndex - 1;
             }
             else if(nums[midIndex] < target)
             {
                beginIndex = midIndex + 1;
             }
             else
             {
                 endIndex = midIndex - 1;
             }
        }
        return pos;
    }
  
    private int GetLast(int[] nums, int target){
        int beginIndex = 0;
        int endIndex = nums.Length - 1;
        int pos = -1;
        while (beginIndex <= endIndex)
        {
             int midIndex = (beginIndex + endIndex) / 2;
             if (nums[midIndex] == target)
             {
                 pos = midIndex;
                 beginIndex = midIndex + 1;
             }
             else if(nums[midIndex] < target)
             {
                 beginIndex = midIndex + 1;
             }
             else
             {
                 endIndex = midIndex - 1;
             }
        }
        return pos;
    }
}
```
  