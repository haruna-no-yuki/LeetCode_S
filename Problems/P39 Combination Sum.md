#   39. Combination Sum

  
##  [题目地址](https://leetcode.com/problems/combination-sum/ )
  
  
  
##  题目描述
给你一个 无重复元素 的整数数组 candidates 和一个目标整数 target ，找出 candidates 中可以使数字和为目标数 target 的 所有 不同组合 ，并以列表形式返回。你可以按 任意顺序 返回这些组合。
  
  
>
>示例:
>Example 1:
>candidates = [2,3,6,7], target = 7
>
>输出: [[2,2,3],[7]]
>
>Example 2:
>candidates = [2,3,5], target = 8
>
>输出: [[2,2,2,2],[2,3,3],[3,5]]
> 
  
##  思路
此题按网上题解为经典的回溯法，但作为初见，我们第一位并不考虑通解。

首先想到的是分治法解决问题，我们考虑F(n)为原问题，取数组某项对其做减后得到子问题F(n - ai)

返回条件为F(0)，此时得到的list表即为一组答案。

显然思考止步于此是不够的，我们要考虑筛选因为路线不同而产生重复的list。

起初，我的对策是对每一个list取一个唯一特征值，由特征值来判断list是否重复。

最开始取得特征值为各项元素之积，这在一定程度上保证了list的唯一性，原因是 xy = k1与x + y = k2在第一象限有且仅有小于等于2个的交点，且两交点对于list而言是等价的。

但后来在跑侧例的过程中发现，对3 * 3 = 9， 2 * 2 = 4，这几种特殊情况欠缺考虑。对于取乘积为特征值的list而言[2, 2] 与 [4]是等价的，而这显然与答案条件不符。

于是我们考虑在深度搜索的过程中改变搜索的起点，如下图所示。

>[![Dingtalk-20230706001731.jpg](https://i.postimg.cc/pVc4kKj8/Dingtalk-20230706001731.jpg)](https://postimg.cc/kD8Tg6fX)

  
  
  
##  关键点
每一次遍历中，我们想穷尽以当前节点为起点的所有可能达成target的路径，进而在下一次同级遍历中排除之前所有节点的影响。
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    IList<IList<int>> ansList = new List<IList<int>>();
    public IList<IList<int>> CombinationSum(int[] candidates, int target)
    {
        IList<int> ints = new List<int>();
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
            IList<int> ints = new List<int>(list);
            ints.Add(candiated[i]);
            CheckComboExist(candiated, ints, target - candiated[i], i);
        }
    }
}
```
  
  