using System.Collections;
using System.Collections.Generic;
using System.Text;
using LinkedListTask;

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

            linkedList.Print(linkedList);

            linkedList.Prepend("Jay-Z");
            linkedList.Print(linkedList);

            Console.WriteLine(linkedList.Contains("Eminem"));
            Console.WriteLine(linkedList.Contains("Notorious B.I.G."));
            Console.WriteLine();

            linkedList.Remove("Eminem");
            linkedList.Print(linkedList);

            linkedList.Insert("50 Cent", 1);
            linkedList.Print(linkedList);

            linkedList.Remove(0);
            linkedList.Print(linkedList);

            linkedList.ChangeNodeValue("Drake", 0);
            linkedList.Print(linkedList);

            linkedList.CountOfNodes(linkedList);
        }
    }
}

