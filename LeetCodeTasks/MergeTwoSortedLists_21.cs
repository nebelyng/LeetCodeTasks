using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class MergeTwoSortedLists
    {
        public ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {
            if (list1 == null && list2 == null)
            {
                return null;
            }
            else if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }

            ListNode currentNode = null;

            if (list1.val < list2.val)
            {
                currentNode = list1;
                list1 = list1.next;
            }
            else
            {
                currentNode = list2;
                list2 = list2.next;
            }

            ListNode startNode = currentNode;

            while (list1 != null || list2 != null)
            {
                if (list1 == null)
                {
                    WriteNextNode(ref currentNode, ref list2);
                    continue;
                }

                if (list2 == null)
                {
                    WriteNextNode(ref currentNode, ref list1);
                    continue;
                }

                if (list1.val < list2.val)
                {
                    WriteNextNode(ref currentNode, ref list1);
                }
                else
                {
                    WriteNextNode(ref currentNode, ref list2);
                }
            }

            return startNode;
        }

        private void WriteNextNode(ref ListNode current, ref ListNode next)
        {
            current.next = next;
            current = current.next;
            next = next.next;
        }
    }
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}
