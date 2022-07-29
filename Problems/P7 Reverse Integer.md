#   7. Reverse Integer

  
  
  
##  [题目地址](https://leetcode.com/problems/reverse-integer/ )
  
  
  
##  题目描述
给一个int数，反向输出它
  
  
>
>示例:
>Example 1:
>123
>输出: 321
>Example 2:
>10
>输出: 1
  
  
##  思路
第一时间联想到二进制与位运算，但是整体是十进制所以把除数换位10，同时用list存储。
也可以使用栈
  
  
  
##  关键点
x进制，先进后出，判断int的极限
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int Reverse(int x) {
        int maxInt = int.MaxValue;
        List<int> list = new List<int>();
        List<int> maxIntL = new List<int>();
        if (x == int.MinValue){
            return 0;
        }
        int absValue = Math.Abs(x);
        while (absValue > 0)
        {
            int temp = absValue % 10;
            absValue = absValue/10;
            list.Add(temp);
        }
        while (maxInt > 0)
        {
             int temp = maxInt % 10;
             maxInt = maxInt / 10;
             maxIntL.Add(temp);
        }
        if (list.Count > maxIntL.Count){
            return 0;
        }
        absValue = 0;
        bool bOverLimit = true;
        for (int i = 0; i < list.Count; i++)
        {
            if (list.Count == maxIntL.Count && (list[i] < maxIntL[list.Count - 1 - i]))
                bOverLimit = false;
            if (list.Count == maxIntL.Count && list[i] > maxIntL[list.Count - i - 1] && bOverLimit){
                return 0;
            }
            int powInt = (int)Math.Pow(10, list.Count - 1 - i);
            absValue += (list[i] * powInt);
        }
        return x < 0? absValue : -absValue;
    }
}
```
  
  