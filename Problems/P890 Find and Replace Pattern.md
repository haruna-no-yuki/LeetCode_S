#   890. Find and Replace Pattern
  
  
  
##  [题目地址](https://leetcode.com/problems/find-and-replace-pattern/ )
  
  
  
##  题目描述
给一组字符串构成的数组，返回由满足下列条件的元素构成的表：
存在一种映射，使字符串s与patter按顺序每个字符一一对应（s与pattern长度相等）
  
  
>
>示例:
>Example 1:
>words = ["abc","deq","mee","aqq","dkd","ccc"], pattern = "abb"
>输出: ["mee","aqq"]
>Example 2:
>words = ["a","b","c"], pattern = "a"
>输出: ["a","b","c"]
  
  
##  思路
利用字典的特性，构建映射关系，逐个判断数组中每个字符串与所给patter是否满足条件
  
  
  
##  关键点
判断条件有两个：
* 字典中是否已经存在对应s[i]的键值对，
* 字典中是否已经有其他对应patter[i]的键值对
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public IList<string> FindAndReplacePattern(string[] words, string pattern) {
        List<string> list = new List<string>();
        for (int i = 0; i < words.Length; i++)
        {
            if (CheckValid(words[i], pattern)){
                list.Add(words[i]);
            }
        }
        return list;
    }

    private bool CheckValid(string s, string pattern){
        Dictionary<char, char>dictionary = new Dictionary<char, char>();
        if (pattern.Length != s.Length){
            return false;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (!dictionary.ContainsKey(s[i])){
                if (dictionary.ContainsValue(pattern[i])){
                    return false;
                }
                dictionary.Add(s[i], pattern[i]);
            }
            else{
                if (dictionary[s[i]]!= pattern[i])
                {
                    return false;
                }
            }
        }
        return true;
    }
}
```
  
  