#   823. Binary Trees With Factors
  
  
  
##  [题目地址](https://leetcode.com/problems/binary-trees-with-factors/ )
  
  
  
##  题目描述
给一个int数组，其中每个数与其他数均不相同。求可以构造的二叉树的数量。
其中二叉树满足这样的条件：树中非叶节点的节点上的值是子节点之积
由于求出的数量可能过大，要求对结果取 10^9 + 7的模再输出
  
  
>
>示例:
>Example 1:
>arr = [2,4]
>输出: 3    ([2], [4], [4, 2, 2])
>Example 2:
>arr = [2,4,5,10]
>输出: 7    ([2], [4], [5], [10], [4, 2, 2], [10, 2, 5], [10, 5, 2])
  
  
##  思路
对原数组进行排序，并创建字典dic对应数组中每个值以及以他们为父节点时所能构造的二叉树数量。
我们发现每加入一个新的值(比之前所有的都大，这也是排序的原因),其能创建的二叉树数量是1 + 数组中满足乘积等于arr[i]的arr[j1] , arr[j2]之积
关系方程为:
if (arr[i] % arr[j] == 0) and (dic.ContainsKey(arr[i]/arr[j]))
    
    $dic[arr[i]] += dic[arr[j]] * dic[arr[i]/arr[j]]$

  
  
##  关键点
(a + b) mod n = (a mod n + b mod n) mod n
(a * b) mod n = (a mod n * b mod n) mod n
注意结果相加时不要超过数据范围
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public int NumFactoredBinaryTrees(int[] arr) {
        Array.Sort(arr);
        Dictionary<int, ulong> dic = new Dictionary<int, ulong>();
        ulong sum = 0;
        ulong modNum = 1000000007;
        for (int i = 0; i < arr.Length; i++)
        {
            if (!dic.ContainsKey(arr[i]))
                dic.Add(arr[i], 1);
            for (int j = 0; j < i; j++)
            {
                if ((arr[i] % arr[j] == 0) && dic.ContainsKey(arr[i]/ arr[j])){
                    dic[arr[i]]= dic[arr[i]] + dic[arr[j]] * dic[arr[i]/ arr[j]];
                }
            }
            sum = (sum % modNum + dic[arr[i]] % modNum) % modNum;
        }
        return (int)sum;
    }
}
```

* **方法2**
```c

```
  
  
