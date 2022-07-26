# P92 Reverse Linked List 2
  
## [题目地址](https://leetcode.com/problems/reverse-linked-list-ii/ )
  
## 题目描述
  
>反转从位置 m 到 n 的链表。请使用一趟扫描完成反转。
>
>说明：
>1 ≤ m ≤ n ≤ 链表长度。
>
>示例:
>输入: 1->2->3->4->5->NULL, m = 2, n = 4
>输出: 1->4->3->2->5->NULL
  
  
## 思路
  
最初的想法是在[m,n]的闭区间上直接创造一截反向链表，同时记录m-1与n+1的节点，最后将这段链表重新接入原链表中。
  
后来发现整体空间占用较大，猜想可能与while循环中调用了new方法有关，于是参考他人解法直接在原有链表上进行操作。
  
如示例中需要反转的[2,4]，我们将节点3的next指向2，4的next指向3，最后退出循环时通过记录的1，2，4，5进行首尾衔接操作，即可得到反转链表。
  
需要注意的是，第二种方法需要更加谨慎地对待边界条件：即[m,n]包含链表头部或者尾部的情况
  
## 关键点
  
对边界条件的处理是否得当
  
## 代码
  
  
* **方法1**
```c
public ListNode ReverseBetween(ListNode head, int left, int right) {
    int index = 1;
    ListNode travelNode = head;
    ListNode leftReverse, rightReverse,temp,tempTail;
    leftReverse = rightReverse = temp = tempTail = null;
    while (travelNode != null)
    {
        if (index == left - 1){
            leftReverse = travelNode;
        }
        if (index == right + 1){
            rightReverse = travelNode;
        }
        if (index >= left && index <= right){
            ListNode insertNode = new ListNode(travelNode.val);
            insertNode.next = tempTail;
            tempTail = insertNode;
            if (temp == null){
                temp = insertNode;
            }
        }
        index++;
        travelNode = travelNode.next;
    
    if (leftReverse != null){
        leftReverse.next = tempTail;
    }
    else
    {
        head = tempTail;
    }
    temp.next = rightReverse;
    return head;
}
```
  
* **方法2**
```c
public ListNode ReverseBetween(ListNode head, int left, int right) {
    int index = 1;
    ListNode travelNode = head;
    ListNode leftReverse, rightReverse,temp,tempTail,pre;
    leftReverse = rightReverse = temp = tempTail = null;
    while (travelNode != null)
    {
        ListNode tempNext = travelNode.next;
        if (index > left && index <= right){
            travelNode.next = pre;
        }
        if (index == left - 1){
            leftReverse = travelNode;
        }
        if (index == right + 1){
            rightReverse = travelNode;
        }
        if (index == left){
            tempTail = travelNode;
        }
        if (index == right){
            temp = travelNode;
        }
        index++;
        pre = travelNode;
        travelNode = tempNext;
  
    if (leftReverse != null){
        leftReverse.next = temp;
    }
    else
    {
        head = temp;
    }
    tempTail.next = rightReverse;
    return head;
}
```
  
  
  
