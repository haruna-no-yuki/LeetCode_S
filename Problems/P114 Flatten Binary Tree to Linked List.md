#   P114 Flatten Binary Tree to Linked List
  
  
  
##  [题目地址](https://leetcode.com/problems/flatten-binary-tree-to-linked-list/ )
  
  
  
##  题目描述
  
  
  
>给一个binary Trees的根结点root，将这棵树“拉直”为一个“链表”，这个“链表”具有以下特性：
>拉直后的“链表”上的每个节点，其左节点为null，右节点为下一个节点
>
>整个“链表”顺序遵守二叉树的遍历顺序
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2021/01/14/flaten.jpg )
>Example 2:
>root = []
>输出: []
  
  
##  思路
  
用一个方法使传入的节点满足题目给出的性质，同时递归调用自身去“拉直”原本是自己的左子树与右子树
  
##  关键点
  
  
递归
  
##  代码
  
  
* **方法1**
```c
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
 
public class Solution {
    public void Flatten(TreeNode root) {
        Rotate(root);
    }

    private TreeNode Rotate(TreeNode root){
        if (root == null){
            return null;
        }
        if (root.left == null){
            return root.right == null ? root : Rotate(root.right);
        }
        else
        {
            TreeNode tempR = root.right;
            TreeNode rightTail = Rotate(root.left);
            root.right = root.left;
            root.left = null;
            rightTail.right = tempR;
            rightTail.left = null;
            if (tempR != null){
                TreeNode tempRPlus = Rotate(tempR);
                return tempRPlus;
            }
            else
            {
                return rightTail;
            }
        }
    }
}
```
  
  