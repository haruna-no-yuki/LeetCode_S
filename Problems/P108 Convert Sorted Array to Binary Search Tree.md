#   108. Convert Sorted Array to Binary Search Tree
  
  
  
##  [题目地址](https://leetcode.com/problems/convert-sorted-array-to-binary-search-tree/ )
  
  
  
##  题目描述
给一个严格递增的int数组，用其组成一个高度平衡的二叉树
高度平衡的定义是：所有节点的左右子树的高度之差的绝对值小于等于1
  
  
>
>示例:
>Example 1:
>nums = [-10,-3,0,5,9]
>输出: ![](https://assets.leetcode.com/uploads/2021/02/18/btree1.jpg )
>Example 2:
>nums = [1,3]
>输出: ![](https://assets.leetcode.com/uploads/2021/02/18/btree.jpg )
  
  
##  思路
每次加入二叉树的节点是左右起点的中点，亦即是递归插入不同区间的中点作为左节点或右节点
  
##  关键点
求中点，退出条件
  
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public TreeNode SortedArrayToBST(int[] nums) {
        int index = (nums.Length - 1) >> 1;
        TreeNode head = InsertNode(0, nums.Length - 1, nums);
        return head;
    }

    private TreeNode InsertNode(int l,int r, int[] nums){
        if (l > r) return null;
        int mid = (l + r) >> 1;
        TreeNode t = new TreeNode(nums[mid]);
        t.left = InsertNode(l, mid - 1, nums);
        t.right = InsertNode(mid + 1, r, nums);
        return t;
    }
}
```
  
  