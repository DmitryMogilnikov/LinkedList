using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListTask
{
    public class NewLinkedList<T> : IEnumerable<T>
    {
        LinkedListNode<T> head = null;
        LinkedListNode<T> tail = null;
        int countOfNodes;

        public void Append(T data) //Метод, для добавления элемента в конец списка
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

        public void Prepend(T data) //Метод, для добавления элемента в начало списка
        {
            var newNode = new LinkedListNode<T>(data);
            newNode.Next = head;
            head = newNode;
            if (countOfNodes == 0)
                tail = head;
            countOfNodes++;
        }

        public void Insert(T data, int index) //Метод, для добавления элемента по индексу
        {
            var newNode = new LinkedListNode<T>(data);

            if (!IsExistNode(index)) Append(data); // Если ноды не существует, добавляем элемент в конец списка
            else if (index == 0) Prepend(data);
            else
            {
                var insertNode = GetNode(index - 1);
                newNode.Next = insertNode.Next;
                insertNode.Next = newNode;
            }
            countOfNodes++;
        }

        public bool IsExistNode(int nodeNumber) //Метод, для проверки существования ноды
        {
            if (nodeNumber >= countOfNodes || nodeNumber < 0)
            {
                return false;
            }
            return true;
        }

        public LinkedListNode<T> GetNode(int nodeNumber) //Метод возвращающий ноду с требуемым индексом
        {
            var indexOfNode = head;
            for (int i = 0; i < nodeNumber; i++)
            {
                indexOfNode = indexOfNode.Next;
            }
            return indexOfNode;
        }

        public bool Contains(T data) //Метод, для проверки существования элемента в списке
        {
            if (head == null) return false;

            LinkedListNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void Remove(T data) //Метод, для удаления всех элементов с определенным значением
        {
            if (head == null) return;
            
            while (head != null && head.Data.Equals(data)) //удаление элементов из начала
            {
                head = head.Next;
                countOfNodes--;
            }

            LinkedListNode<T> currentNode = head;
            LinkedListNode<T> previousNode = null;


            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    if (previousNode != null)
                    {
                        previousNode.Next = currentNode.Next;
                        currentNode = head; //
                        if (currentNode.Next == null)
                            tail = previousNode;
                    }
                    else
                    {
                        head = head.Next;

                        if (head == null)
                            tail = null;
                    }
                    countOfNodes--;
                }
                previousNode = currentNode;
                currentNode = currentNode.Next;
            }
        }

        public void Remove(int index) //Метод, для удаления объекта с определенным индексом
        {
            if (!IsExistNode(index)) return;

            if (index == 0)
            {
                head = head.Next;
                countOfNodes--;
            }
            else
            {
                var removeNode = GetNode(index - 1);
                removeNode.Next = removeNode.Next.Next;
                countOfNodes--;
            }
        }

        public void ChangeNodeValue(T newData, int index) //Метод, для изменения значения СУЩЕСТВУЮЩЕЙ ноды
        {
            if (index == 0)
            {
                head.Data = newData;
            }
            else if (IsExistNode(index))
            {
                GetNode(index - 1).Next.Data = newData;
            }
        }

        public void CountOfNodes(NewLinkedList<T> linkedList)
        {
            bool isEmpty = linkedList.countOfNodes > 0;
            int count = linkedList.countOfNodes;
            if (!isEmpty)
                Console.WriteLine("Linked list is empty");
            else Console.WriteLine("Count of nodes in linked list is: {0}", count);
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
            foreach (var elem in nodes)
                stringBuilder.Append(elem + ", ");
            return stringBuilder.ToString().TrimEnd(' ', ',');
        }

        public void Print(NewLinkedList<T> linkedList)
        {
            foreach(var item in linkedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
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
