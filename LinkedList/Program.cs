using System.Collections;
using System.Collections.Generic;
using System.Text;
using LinkedListTask;

namespace LinkedListTask
{
    public class NewLinkedList<T>: IEnumerable<T>
    {
        LinkedListNode<T> head = null; 
        LinkedListNode<T> tail = null; 
        int countOfNodes;

        public void Append(T data)
        {
            var newNode = new LinkedListNode<T>(data);
            countOfNodes++;

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                return;
            }
            
            tail.Next = newNode;
            tail = newNode;
        }

        public void Prepend(T data)
        {
            var newNode = new LinkedListNode<T>(data);
            newNode.Next = head;
            head = newNode;
            if (countOfNodes == 0)
                tail = head;
            countOfNodes++;
        }

        public T[] toArray()
        {
            var nodes = new T[countOfNodes];
            var currentNode = head;
            int i = 0; 
            while (currentNode != null)
            {
                nodes[i] = (currentNode.Data);
                currentNode = currentNode.Next;
                i++;
            }
            return nodes;
        }

        public string toString()
        {
            var nodes = toArray();
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var elem in nodes) 
                stringBuilder.Append(elem + ", ");
            return stringBuilder.ToString().TrimEnd(' ', ',');
            
        }

        public void Remove(T data)
        {

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            LinkedListNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
}

namespace Program
{
    public class Test
    {
        public static void Main(string[] args)
        {
            var linkedList = new NewLinkedList<string>();
            linkedList.Append("Eminem");
            linkedList.Append("Dr. Dre");
            linkedList.Append("A$AP Rocky");

            var linkedList2 = linkedList.toString();

            Console.WriteLine(linkedList2);
            Console.WriteLine();


            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}

