#   869. Reordered Power of 2
  
  
##  [题目地址](https://leetcode.com/problems/reordered-power-of-2/ )
  
  
  
##  题目描述
给一个整数n，判断由各位上的数字能否组成一个2的指数幂
  
  
>
>示例:
>Example 1:
>1
>输出: true
>Example 2:
>10
>输出: false
>Example 3:
>23
>输出: true 
  
##  思路
初始想法为由所有组成n的数遍历构成一个可以最终形成的表，最后一个个判断是不是2的整数幂
9的阶乘仍属于可以接受的数据范围内，所以这样能过
但是有更简单的方式
我们注意到10^9范围内的2的整数幂其实非常有限，同时有位运算这类专门为2服务的简便计算
那么，我们将所有范围内的2的整数幂依次整理成字符数组，最后用n的字符数组形成的字符串与其比较，即可用相比遍历小很多的时间，空间复杂度来解决问题（方法2）
  
  
  
##  关键点
位运算 or 递归
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public bool ReorderedPowerOf2(int n) {
        List<int> listNum = new List<int>();
        List<int> result = new List<int>();
        CreateList(listNum, n);
        CreateNum(listNum, result, 0, 0);
        for (int i = 0; i < result.Count; i++)
        {
            if (IsPowerOfX(result[i], 2))
                return true;
        }
        return false;
    }


    private void CreateList(List<int> l1, int n){
        while (n >= 1)
        {
            int temp = n % 10;
            n /= 10;
            l1.Add(temp);
        }
    }

    private void CreateNum(List<int> listBit, List<int> allSum, int sum, int layer){
        int totalBit = listBit.Count;
        if (layer == totalBit){
            allSum.Add(sum);
            return;
        }
        for (int i = 0; i < totalBit; i++)
        {
            if (listBit[i] < 10 && (layer != 0 || listBit[i] != 0)){
                sum += listBit[i] * Convert.ToInt32(Math.Pow(10, totalBit - layer - 1));
                listBit[i] += 10;
                CreateNum(listBit, allSum, sum, layer + 1);
                listBit[i] -= 10;
                sum -= listBit[i] * Convert.ToInt32(Math.Pow(10, totalBit - layer - 1));
            }   
        }
    }

    private bool IsPowerOfX(int n, int x){
        double testOne = (double) n;
        while (n > 1)
        {
            testOne /= x;
            n /= x;
            if (Convert.ToDouble(n) != testOne)
                return false;
        }
        return true;
    }
}
```

* **方法2**
```c
public class Solution {
    public bool ReorderedPowerOf2(int n) {
        char[] charArr = CreateList(n);
        string s = new string(charArr);
        for (int i = 0; i < 30; i++)
        {
            int test = 1 << i;
            char[] testArr = CreateList(test);
            string temp = new string(testArr);
            if (temp == s) return true;
        }
        return false;
    }


    private char[] CreateList(int n){
        string temp = Convert.ToString(n);
        char[] charArr = temp.ToCharArray();
        Array.Sort(charArr);
        return charArr;
    }
}
```
  
  