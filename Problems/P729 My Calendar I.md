#   729. My Calendar I
  
  
  
##  [题目地址](https://leetcode.com/problems/my-calendar-i/ )
  
  
  
##  题目描述
给予一组左闭右开的区间，判断每个输入的区间是否与之前的区间没有重叠
  
  
>
>示例:
>Example 1:
>[10, 20], [15, 25], [20, 30]
>输出: true, false, true
  
  
##  思路
这是一道很典型的区间树问题。
区间树，即是把树中的节点换成区间。在此之上我们对每个节点维护一个max值，代表其子树中上界的最大值
剩下的便是完成树的插入与判断重叠操作。
有无从重叠即low1 <= high2 or low2 <= high1，若无，则由max值判断该往左子树还是右子树向下
如果max < low1，那么该子树下没有节点会与判断节点重叠

  
##  关键点
区间树，插入，寻找
  
  
##  代码
  
  
* **方法1**
```c
public class MyCalendar {

    public int begin,end,max;
    public MyCalendar left,right;
    public MyCalendar() {
        begin = 0;
        end = 0;
        max = 0;
        left = right = null;
    }

    public MyCalendar(int b, int e){
        begin = b;
        end = e;
        max = e;
        left = right = null;
    }
    
    public bool Book(int start, int end) {
        bool returnAns = true;
        MyCalendar newone = new MyCalendar(start, end);
        if (!(this.end == 0)){
            returnAns = CheckIsLegal(newone);
        }
        if (returnAns == true){
            Add2Tree(newone);
        }
        return returnAns;
    }

    private void Add2Tree(MyCalendar node){
        if (this.end == 0){
            this.end = node.end;
            this.begin = node.begin;
            return;
        }
        if (node.begin <= this.begin){
            if (this.left == null){
                this.left = node;
            }
            else{
                this.left.Add2Tree(node);
            }
            this.max = Math.Max(this.max, this.left.max);
        }
        else{
            if (this.right == null){
                this.right = node;
            }
            else{
                this.right.Add2Tree(node);
            }
            this.max = Math.Max(this.max, this.right.max);
        }
    }

    private bool CheckIsLegal(MyCalendar node){
        if (node.begin >= this.end || node.end <= this.begin){
            MyCalendar nextOne;
            if (this.left != null && this.left.max >= node.begin){
                nextOne = this.left;
            }
            else
                nextOne = this.right;
            if (nextOne == null){
                return true;
            }
            else
                return nextOne.CheckIsLegal(node);
        }
        else
            return false;
    }
}
```
  
  