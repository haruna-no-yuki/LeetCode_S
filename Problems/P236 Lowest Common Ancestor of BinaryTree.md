#   P236 Lowest Common Ancestor of BinaryTree
  
  
  
##  [题目地址](https://leetcode.com/problems/lowest-common-ancestor-of-a-binary-tree/ )
  
  
  
##  题目描述
  
  
  
>给一个binary Trees的根结点root，判断两个树内节点p,q的最近公共祖先节点
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2018/12/14/binarytree.png )
>5,  1
>输出: 3
>Example 2:
>![](https://assets.leetcode.com/uploads/2018/12/14/binarytree.png )
>5, 4
>输出: 5
  
  
##  思路
  
  
初次解法：递归寻找p，q节点，并将路径上的节点插入列表当中，最后比较两个列表中最近的公共祖先 
参考解法：递归判断p或q是否在自身的左子树或右子树,并根据结果返回对应的节点
  
##  关键点
  
  
递归
  
##  代码
  
  
* **方法1**
```c
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    var l1 = new List<TreeNode>();
    var l2 = new List<TreeNode>();
    InsertList(root, p, l1);
    InsertList(root, q, l2);
    for (int i = 0; i < l1.Count; i++)
    {
        if (l2.Contains(l1[i])){
            return l1[i];
        }
    }
    return root;
}
private bool InsertList(TreeNode root, TreeNode p, List<TreeNode> list){
    if (root == null){
        return false;
    }
    if (root.left == null && root.right == null && root.val != p.val){
        return false;
    }
    if (root.val == p.val){
        list.Add(p);
        return true;
    }
    if (InsertList(root.left, p, list) || InsertList(root.right, p, list)){
        list.Add(root);
        return true;
    }
    return false;
}
```

* **方法2**
```c
public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
    if (root == null || root == p || root == q){
        return root;
    }
    TreeNode leftExist = LowestCommonAncestor(root.left, p, q);
    TreeNode rightExist = LowestCommonAncestor(root.right, p, q);
    if (leftExist != null && rightExist != null){
        return root;
    }
    else if (leftExist != null){
        return leftExist;
    }
    else if (rightExist != null)
    {
        return rightExist;
    }
    return null;
}
```
  
  