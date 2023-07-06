#   40. Combination Sum II

  
##  [题目地址](https://leetcode.com/problems/combination-sum-ii/ )
  
  
  
##  题目描述
给你一个 整数数组 candidates 和一个目标整数 target ，找出 candidates 中可以使数字和为目标数 target 的 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。
  
  
>
>示例:
>Example 1:
>candidates = [10,1,2,7,6,1,5], target = 8,
>
>输出: [
[1,1,6],
[1,2,5],
[1,7],
[2,6]
]
>
>Example 2:
>candidates = [2,5,2,1,2], target = 5,
>
>输出: [
[1,2,2],
[5]
]
> 
  
##  思路
此题相比P39变化不大，区别在于所给的数组中每一个元素最多只能用一次。

同时我们注意到，测例里list中是存在重复元素的，所以需要考虑存在重复元素时的特殊状况。

解决思路依然是分治法，但是在挑选起点的同时我们要把自身筛去。

  
  
  
##  关键点
每一次遍历中，我们想穷尽以当前节点为起点的所有可能达成target的路径，进而在下一次同级遍历中排除之前所有节点的影响。

同时我们需要注意到，若存在重复元素，那么分别以他们为起点会创造出重复的list，我们需要对这些结果进行剪枝。

方法为将原数组进行排序，那么重复元素必然相邻，我们只需挑出非重复元素构成的起点进行分治即可。
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    IList<IList<int>> ansList = new List<IList<int>>();
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<int> ints = new List<int>();
        Array.Sort(candidates);
        CheckComboExist(candidates, ints, target, 0);
        return ansList;
    }
    
    public void CheckComboExist(int[] candiated, IList<int> list, int target, int totalProduct)
    {
        if (target < 0)
        {
            list.Clear();
            return;
        }

        if (target == 0)
        {
            ansList.Add(list);
            return;
        }
        for (int i = totalProduct; i < candiated.Length; i++)
        {
            if (i > totalProduct && candiated[i - 1] == candiated[i])
                continue;
            IList<int> ints = new List<int>(list);
            ints.Add(candiated[i]);
            CheckComboExist(candiated, ints, target - candiated[i], i + 1);
        }
    }
}
```
  
  