#   P424 Longest Repeating Character Replacement
  
  
  
##  [题目地址](https://leetcode.com/problems/longest-repeating-character-replacement/ )
  
  
  
##  题目描述
给一个字符串s与int值 k，我们可以将任意k个字符换成任意其他字符，判断该条件下的最长子字符串的长度
  
  
>
>示例:
>Example 1:
>s = "ABAB", k = 2
>输出:  4
>Example 2:
>s = "AABABBA", k = 1
>输出: 4
  
  
##  思路
滑动区间问题
  
  
  
##  关键点
判断每一次右指针右移时是否满足条件
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int CharacterReplacement(string s, int k) {
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        int index = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (dictionary.ContainsKey(s[i])){
                dictionary[s[i]] = dictionary[s[i]] + 1;
            }
            else
            {
                dictionary.Add(s[i], 1);
            }
            if (!CheckDic(dictionary, k)){
                dictionary[s[index]]--;
                index++;
            }
        }
        return s.Length - index;
    }

    private bool CheckDic(Dictionary<char, int> dictionary, int k){
        int maxCount = -1;
        int totalSum = 0;
        foreach (var key in dictionary.keys)
        {
            totalSum += dictionary[key];
            maxCount = Math.Max(dictionary[key], maxCount);
        }
        if (totalSum - maxCount <= k){
            return true;
        }
        else
        {
            return false;
        }
    }
}
```
  
  