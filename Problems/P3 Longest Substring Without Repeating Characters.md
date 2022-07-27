#   P3 Longest Substring Without Repeating Characters
  
  
  
##  [题目地址](https://leetcode.com/problems/longest-substring-without-repeating-characters/ )
  
  
  
##  题目描述
  
  
  
>给一个字符串，判断最长子字符串的长度
>示例:
>Example 1:
>s = "abcabcbb"
>输出: 3
>Example 2:
>s = "pwwkew"
>输出: 3
  
  
##  思路
  
  
典型的活动区间问题，判断条件是当前子字符串是否包含下一个字符
可以用字典存储每种出现的字符的最新位置，也可以使用stringBuilder直接进行插入与判断，两者在时间负载度上没有太大优劣之分
  
##  关键点

活动区间
  
递归
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int index,maxL;
        maxL = index = 0;
        StringBuilder checkStr = new StringBuilder("");
        for (int i = 0; i < s.Length; i++)
        {
            int checkInt = Contains(checkStr, s[i]);
            if (checkInt >= 0)
            {
                checkStr.Remove(0,checkInt + 1);
            }
            checkStr.Append(s[i]);
            maxL = Math.Max(maxL, checkStr.Length);
        }
        return maxL;
    }
    
    private int Contains(StringBuilder s, char c){
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == c){
                return i;
            }
        }
        return -1;
    }
}
```

* **方法2**
```c
public class Solution {
    public int LengthOfLongestSubstring(string s) {
        int index,maxL;
        maxL = index = 0;
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dictionary.ContainsKey(s[i])){
                index = Math.Max(index, dictionary[s[i]]);
                dictionary[s[i]] = i;
            }
            else
            {
                dictionary.Add(s[i], i);
            }
            maxL = Math.Max(maxL, i - index);
        }
        return maxL;
    }
}
```
  
  