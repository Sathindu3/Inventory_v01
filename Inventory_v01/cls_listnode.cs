using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_v01
{
    class cls_listnode
    {
        public class ListNode
        {
            public string Data { get; set; }
            public ListNode Next { get; set; }

            public ListNode(string data)
            {
                Data = data;
                Next = null;
            }
        }
    }
}
