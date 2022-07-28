#   P4 Median of Two Sorted Arrays
  
  
  
##  [题目地址](https://leetcode.com/problems/median-of-two-sorted-arrays/ )
  
  
  
##  题目描述
  
  
  
>给两个已经顺序排序好的数组，求这两个数组合并之后的中位数（double），其中nums1,nums2都不为空。要求时间复杂度为O(lg(m+n))，m与n分别为nums1，nums2的数组长度
>示例:
>Example 1:
>nums1 = [1,3], nums2 = [2]
>输出: 2.00000
>Example 2:
>nums1 = [1,2], nums2 = [3,4]
>输出: 2.50000
  
  
##  思路
  
最简单的暴力解显然时间复杂度过高，最先联想到的是使用二分法快速找到对应的数。
值得注意的是使用暴力解时，我们使用了一个(m+n+1)/2来判断当前元素是否位于中位数的位置，这一点可以用于二分判断。
我们以数组长度较小的数组为主，以i记录当前判断的位置，同时，j = (m+n+1)/2 - i是另外一个数组与之对应的位置。
由于两个数组已经排序完毕，所以在合并过程中，原本属于统一数组的元素的相对位置不会改变。
那么，最后合并的数组的中位数，其之前一定包含有(m+n+1)/2 - 1个，分别属于nums1与nums2的元素。
我们取  num1_MedianLeft,num1_MedianRight,num2_MedianLeft,num2_MedianRight 分别代表这两个数组对应i，j位置**两边**的元素
>初始条件是index1 = 0, index2 = min(m,n), i = (index1 + index2) / 2 j = (m+n+1) / 2
>循环条件是index1 <= index2
>退出条件是 num1_MedianLeft <= num2_MedianRight && num2_MedianLeft <= num1_MedianRight
>递归内容是： 
num1_MedianLeft >= num2_MedianRight : index1 = i + 1, i = (index1 + index2) >/ 2
>num2_MedianLeft >= num1_MedianRight: index2 = i - 1, i = (index1 + index2) >/ 2
>
>返回结果是: 
>(m+n) % 2 == 1: return max(num1_MedianLeft, num2_MedianLeft)
>(m+n) % 2 == 0 : return (max(num1_MedianLeft, num2_MedianLeft) + min>(num1_MedianRight, num2_MedianRight)) / 2
>需要注意的是，对应i(j) == 0 or m(n),取得元素分别应为int.MinValue / int.MaxValue，对应**两边**

  
##  关键点
二分
递归
双指针
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) {
        int index1,index2,i,j;
        int num1_MedianLeft,num1_MedianRight,num2_MedianLeft,num2_MedianRight;
        bool bflag = nums1.Length > nums2.Length;
        index1 = 0;
        index2 = bflag ? nums2.Length : nums1.Length;
        while (index1 <= index2)
        {
            i = (index1 + index2) / 2;
            j = (nums1.Length + nums2.Length + 1)/2 - i;
            if (bflag){
                num1_MedianLeft = i == 0 ?  int.MinValue : nums2[i - 1];
                num1_MedianRight = i == nums2.Length ? int.MaxValue : nums2[i];
                num2_MedianLeft = j == 0 ? int.MinValue : nums1[j - 1];
                num2_MedianRight = j == nums1.Length ? int.MaxValue : nums1[j];
            }
            else
            {
                num1_MedianLeft = i == 0 ? int.MinValue : nums1[i - 1];
                num1_MedianRight = i == nums1.Length ? int.MaxValue : nums1[i];
                num2_MedianLeft = j == 0 ?  int.MinValue : nums2[j - 1];
                num2_MedianRight = j == nums2.Length ? int.MaxValue : nums2[j];
            }
            
            if (num1_MedianLeft <= num2_MedianRight && num2_MedianLeft <= num1_MedianRight){
                if ((nums1.Length + nums2.Length) % 2 == 1){
                    return (double)(Math.Max(num1_MedianLeft, num2_MedianLeft));
                }
                else
                {
                    return (double)((Math.Max(num1_MedianLeft, num2_MedianLeft) + Math.Min(num1_MedianRight, num2_MedianRight)))/ 2;
                }
                break;
            }
            else if (num1_MedianLeft > num2_MedianRight)
            {
                index2 = i - 1;
            }
            else if (num1_MedianRight < num2_MedianLeft)
            {
                index1 = i + 1;
            }
        }
        return 0;
    }
}
```
  