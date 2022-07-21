using System;

namespace AddTwoNumbers{
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    public class Solution {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
            ListNode l1Next = l1;
            ListNode l2Next = l2;
            ListNode finalAns = null;
            ListNode tempAns = null;
            int bitAdd = 0;
            while (l1Next != null || l2Next != null)
            {
                int L1Value = l1Next == null ? 0 :l1Next.val;
                int L2Value = l2Next == null ? 0 :l2Next.val;
                int sum = L1Value + L2Value + bitAdd;
                bitAdd = (int)(sum / 10);
                ListNode insertNode = new ListNode(sum % 10);
                if (finalAns == null){
                    finalAns = insertNode;
                    tempAns = finalAns;
                }
                else
                {
                    tempAns.next = insertNode;
                    tempAns = insertNode;
                }
                l1Next = l1Next == null ? null: l1Next.next;
                l2Next = l2Next == null ? null: l2Next.next;
            }       
            if (bitAdd > 0){
                ListNode insertNode = new ListNode();
                tempAns.next = insertNode;
                tempAns = insertNode;
                tempAns.val = bitAdd;
            }
            return finalAns;
        }
    }
}
