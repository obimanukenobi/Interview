using System;
namespace Interview
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            this.val = x;
        }

        public static ListNode GenerateLinkedList(int min, int max, bool sorted, int count)
        {
            ListNode dummy = new ListNode(0);
            ListNode prev = dummy;

            Random rand = new Random();

            if (!sorted)
            {
                for (int i = 0; i < count; i++)
                {
                    int valToAdd = rand.Next(min, max);
                    ListNode node = new ListNode(valToAdd);
                    prev.next = node;
                    prev = prev.next;
                }
            }
            else
            {
                int[] array = new int[count];
                for (int i = 0; i < count; i++)
                {
                    int valToAdd = rand.Next(min, max);
                    array[i] = valToAdd;
                }

                Array.Sort(array);

                for (int i = 0; i < count; i++)
                {
                    ListNode node = new ListNode(array[i]);
                    prev.next = node;
                    prev = prev.next;
                }
            }

            return dummy.next;
        }
    }
}
