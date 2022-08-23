#   234. Palindrome Linked List
  
  
  
##  [题目地址](https://leetcode.com/problems/palindrome-linked-list/ )
  
  
  
##  题目描述
给一个int链表的头节点，判断这个链表是否满足回文条件
  
  
>
>示例:
>Example 1:
>![](https://assets.leetcode.com/uploads/2021/03/03/pal1linked-list.jpg )
>输出: true
>Example 2:
>![](https://assets.leetcode.com/uploads/2021/03/03/pal2linked-list.jpg )
>输出: false
  
  
##  思路
此题本身十分简单，但是如果加上限制条件值得一看

如果要求时间为O(n), 空间为O(1)，那么直接遍历链表后反转比较就行不通了

这时我们考虑直接在链表上做反转，且反转区间恰好为链表的后半段。

这里运用的思想与P92 reverse_Linked_List很相像

  
  
  
##  关键点
对于一个只给出头节点的链表，找到其中间节点的位置

我们用fast和slow标记两个节点，其中slow每次前进一步，fast前进两步

如果判断fast或fast.next为null，那么此时的slow刚好行走到链表的中间位置

本质上类似于将链表长度对折，找到对应位置
  
##  代码
  
  
* **方法1**
```c
public class Solution {
    public bool IsPalindrome(ListNode head) {
        ListNode fast = head;
        ListNode slow = head;
        while(fast != null && fast.next != null){
            fast = fast.next.next;
            slow = slow.next;
        }
        slow = reverse(slow);
        fast = head;
        
        while(slow != null){
            if(slow.val != fast.val){
                return false;
            }
            slow = slow.next;
            fast = fast.next;
        }
        return true;
    }
    
    public ListNode reverse(ListNode head){
        ListNode prev = null;
        while(head != null){
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }
}
```
  
  