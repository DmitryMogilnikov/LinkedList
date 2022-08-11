using NUnit.Framework;
using LinkedListTask;

namespace LinkedList.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void AppendTest()
        {
            var checkList = Initialization();
            checkList.Append("z");
            string check = checkList.toString();
            var testAppend = new string("a, b, c, d, z");
            Assert.AreEqual(2, 1 + 1);
            Assert.AreEqual(testAppend, check);
        }

        public NewLinkedList<string> Initialization()
        {
            var list = new NewLinkedList<string>();
            list.Append("a");
            list.Append("b");
            list.Append("c");
            list.Append("d");
            return list;
        }
    }
}