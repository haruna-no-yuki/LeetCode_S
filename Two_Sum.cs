using System;

namespace TwoSum{
    public class Solution{
        public int[] TwoSum(int[] nums, int target){
            int[] ans = new int[2];
            Dictionary <int,int> dictionary = new Dictionary<int, int>();
            for (int i = 0; i < nums.length; i++)
            {
                int diff = target - nums[i];
                if (dictionary.ContainsKey(nums[i]))
                {
                    int refKey = dictionary[nums[i]];
                    ans[0] = i;
                    ans[1] = refKey;
                    return ans;
                }
                if (!dictionary.ContainsKey(diff))
                {
                    dictionary.Add(diff, i);
                }   
            }
            return ans;
        }
    }
}