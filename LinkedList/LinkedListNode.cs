using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTask
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public LinkedListNode<T> Next { get; set; }
    }
}
