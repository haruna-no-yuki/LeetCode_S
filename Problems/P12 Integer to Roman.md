#   12. Integer to Roman
  
  
  
##  [题目地址](https://leetcode.com/problems/integer-to-roman/ )
  
  
  
##  题目描述
给一个数字（<=3999），返回对应其以罗马数字形式表达的字符串
  
  
>
>示例:
>Example 1:
>58
>输出: LVIII 
>Example 2:
>1994
>输出: MCMXCIV
  
  
##  思路
每一位是余10的产物，取其再对5做余，分类讨论各种情况。
  
  
##  关键点
模拟
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    
    public string IntToRoman(int num) {
        int temp = num;
        int index = 0;
        char[,] charArray = new char[4,3]{
            {'I', 'V', 'X'},
            {'X', 'L','C'},
            {'C', 'D', 'M'},
            {'M','M','M'},
        };
        StringBuilder builder = new StringBuilder("");
        while (temp > 0){
            int bit = temp % 10;
            int numI = bit % 5;
            if (numI == 4){
                builder.Append(bit > 5 ? charArray[index,2] : charArray[index, 1]);
                builder.Append(charArray[index, 0]);
            }
            else{
                for (int i = 0; i < numI; i++)
                {
                    builder.Append(charArray[index,0]);
                }
                builder.Append(bit >= 5 ? charArray[index, 1] : "");
            }
            temp/= 10;
            index++;
        }    
        int left,right;
        left = 0;
        right = builder.Length - 1;
        while (left <= right){
            char tempC = builder[left];
            builder[left] = builder[right];
            builder[right] = tempC;
            left++;
            right--;
        }
        string returnS = builder.ToString();
        return returnS;
    }
}
```
  
  