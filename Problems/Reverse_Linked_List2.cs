using System;

namespace Reversr_Linked_List2{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    public class Solution {
        public ListNode ReverseBetween(ListNode head, int left, int right) {
            int index = 1;
            ListNode travelNode = head;
            ListNode leftReverse, rightReverse,temp,tempTail;
            leftReverse = rightReverse = temp = tempTail = null;
            while (travelNode != null)
            {
                if (index >= left && index <= right){
                    if (temp == null){
                        temp = new ListNode(travelNode.val);
                        temp.next = null;
                        tempTail = temp;
                    }
                    else
                    {
                        ListNode insertHead = new ListNode(travelNode.val);
                        insertHead.next = temp;
                        temp = insertHead;
                    }
                }
                if (index == left - 1){
                    leftReverse = travelNode;
                }
                if (index == right + 1){
                    rightReverse = travelNode;
                }
                index++;
                travelNode = travelNode.next;
            }
            if (leftReverse != null){
                leftReverse.next = temp;
            }
            else
            {
                head = temp;
            }
            if (rightReverse != null){
                tempTail.next = rightReverse;
            }
            return head;
        }
    }



}