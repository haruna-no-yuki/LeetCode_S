#   659. Split Array into Consecutive Subsequences
  
  
  
##  [题目地址](https://leetcode.com/problems/split-array-into-consecutive-subsequences/ )
  
  
  
##  题目描述
给你一个按升序排序的整数数组 num（可能包含重复数字），请你将它们分割成一个或多个长度至少为 3 的子序列，其中每个子序列都由连续整数组成。

如果可以完成上述分割，则返回 true ；否则，返回 false 。

  
  
>
>示例:
>Example 1:
>nums = [1,2,3,3,4,5]
>输出: true([1,2,3] [3,4,5])
>Example 2:
>nums = [1,2,3,3,4,4,5,5]
>输出: true([1,2,3,4,5] [3,4,5])
>Example 2:
>nums = [1,2,3,4,4,5]
>输出: false

  
##  思路
注意到所有序列的长度必须大于3，且相邻元素严格增长1，那么必不存在长度大于5的子序列，因为可以把它划分为更小的子序列。
初始的思路是从最小的数开始，判断能否形成长度为3的最小子序列，若不能，则从之前的序列中判断结尾数是否比自己小1，也就是能不能接入其他序列的结尾，这样能Ac 90%左右。
后来发现这样判断并不完备，应该先判断当前列表中最小的数是否能接入到之前的序列中，如果不能，再判断能否形成长度3的最小子序列，两者皆否则返回false，退出条件是列表中仍有没被分配的元素
例：[1,2,3,4,5,5,6,7]，如果用前一种思路则会剩下5和7，最后发现无法接入5，从而返回false
  
  
  
##  关键点
哈希表
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public bool IsPossible(int[] nums) {
        List<int> list = new List<int>();
        Dictionary<int, int> dic = new Dictionary<int, int>();
        List<int> ends = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!dic.ContainsKey(nums[i]))
                dic.Add(nums[i], 0);
            dic[nums[i]]++;
            list.Add(nums[i]);
        }
        while (list.Count > 0)
        {
            int target = list[0];
            bool flag = CheckIsListValid(target, ends, list);
            if (!flag){
                flag = CheckIsThreeValid(target, dic, list, ends);
                if (!flag) return false;
            }
        }
        return true;
    }

    private bool CheckIsThreeValid(int target, Dictionary<int,int> dic, List<int> oriL, List<int> ends){
        if (!dic.ContainsKey(target + 1) || !dic.ContainsKey(target + 2))
            return false;
        
        oriL.RemoveAt(0);
        oriL.RemoveAt(dic[target] - 1);
        oriL.RemoveAt(dic[target] + dic[target + 1] - 2);
        for (int i = 0; i < 3; i++)
        {
            dic[target + i]--;
            if (dic[target + i] <= 0)
                dic.Remove(target + i);
        }
        ends.Add(target+2);
        return true;
    }

    private bool CheckIsListValid(int target, List<int> ends, List<int> oriL, Dictionary<int,int> dic){
        for (int i = 0; i < ends.Count; i++)
        {
            if (target == ends[i] + 1){
                ends[i] = target;
                oriL.RemoveAt(0);
                dic[target]--;
                if (dic[target] <= 0) dic.Remove(target);
                return true;
            }
        }
        return false;
    }
}
```

  
  