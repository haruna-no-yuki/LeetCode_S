#   P242 Valid Anagram
  
  
  
##  [题目地址](https://leetcode.com/problems/valid-anagram/ )
  
  
  
##  题目描述
给两个字符串s,t，判断t是否为s的变位词
  
  
>
>示例:
>Example 1:
>s = "anagram", t = "nagaram"
>输出: true
>Example 2:
>s = "rat", t = "car"
>输出: false
  
  
##  思路
用字典分别记录两个字符串中字符出现的次数进行比对
也可以利用字符对应的asc码对数字进行对比
  
  
##  关键点
字典
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public bool IsAnagram(string s, string t) {
        if (s.Length != t.Length){
            return false;
        }
        Dictionary<char, int> dictionary = new Dictionary<char, int>();
        for (int i = 0; i < s.Length; i++)
        {
            if (dictionary.ContainsKey(s[i])){
                dictionary[s[i]] = dictionary[s[i]] + 1;
            }
            else
            {
                dictionary.Add(s[i],1);
            }
        }

        for (int i = 0; i < t.Length; i++)
        {
            if (!dictionary.ContainsKey(t[i]) || dictionary[t[i]] <= 0){
                return false;
            }
            else
            {
                dictionary[t[i]] = dictionary[t[i]] - 1;
            }
        }
        return true;
    }
}
```
  
  