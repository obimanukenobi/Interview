using System;
using System.Collections.Generic;

namespace Interview
{
    public static class Heap
    {
        public static ListNode MergeKSortedList(ListNode[] lists)
        {
            SortedSet<ListNode> heap = new SortedSet<ListNode>(new ByListNodeValue());

            foreach(ListNode list in lists)
            {
                heap.Add(list);
            }

            ListNode dummy = new ListNode(0);
            ListNode head = heap.Min;
            dummy.next = head;
            heap.Remove(head);
            heap.Add(head.next);

            while(heap.Count != 0)
            {
                ListNode currMinNode = heap.Min;
                head.next = currMinNode;
                heap.Remove(currMinNode);
                if (currMinNode.next != null)
                {
                    heap.Add(currMinNode.next);
                }
                head = head.next;
            }

            head.next = null;
            return dummy.next;
        }
    }

    public class ByListNodeValue : IComparer<ListNode>
    {
        public int Compare(ListNode x, ListNode y)
        {
            return x.val - y.val;
        }
    }
}
