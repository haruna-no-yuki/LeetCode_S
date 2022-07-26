#   P100 Same Tree
  
  
  
##  [题目地址](https://leetcode.com/problems/same-tree/ )
  
  
  
##  题目描述
  
  
  
>给两个binary Trees的根结点p，q，判断两棵树是否相同
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2020/12/20/ex1.jpg )
>输出: true
>Example 2:
>![](https://assets.leetcode.com/uploads/2020/12/20/ex3.jpg )
>输出: false
  
  
##  思路
  
  
  
递归判断每个节点是否相同
  
##  关键点
  
  
递归
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public bool IsSameTree(TreeNode p, TreeNode q) {
        if (!CheckNullState(p,q)){
            return false;
        }
        else if (p == null && q == null)
        {
            return true;
        }
        if (p.val != q.val){
            return false;
        }
        return IsSameTree(p.left, q.left) && IsSameTree(p.right, q.right);
    }
    private bool CheckNullState(TreeNode p, TreeNode q){
        if ((p == null && q != null) || (p != null && q == null)){
            return false;
        }
        return true;
    }
}
```
  
  