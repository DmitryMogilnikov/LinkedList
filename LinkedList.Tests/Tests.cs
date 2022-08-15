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
            Assert.AreEqual("a, b, c, d, z", checkList.toString());
        }

        [Test]
        public void PrependTest()
        {
            var checkList = Initialization();
            checkList.Prepend("z");
            Assert.AreEqual("z, a, b, c, d", checkList.toString());
        }

        [Test]
        public void RemoveTest()
        {
            var checkList = Initialization();
            checkList.Remove("b");
            Assert.AreEqual("a, c, d", checkList.toString());
            checkList.Remove("d");
            Assert.AreEqual("a, c", checkList.toString());
        }

        [Test]
        public void RemoveMultiplyTest()
        {
            var checkList = Initialization();
            checkList.Append("a");
            checkList.Remove("a");
            Assert.AreEqual("b, c, d", checkList.toString());

            checkList = Initialization();
            checkList.Prepend("a");
            checkList.Remove("a");
            Assert.AreEqual("b, c, d", checkList.toString());

            checkList = Initialization();
            checkList.Prepend("a");
            checkList.Insert("a", 2);
            checkList.Insert("a", 2);
            checkList.Insert("a", 2);
            checkList.Insert("a", 100);
            checkList.Remove("a");
            Assert.AreEqual("b, c, d", checkList.toString());

        }

        [Test]
        public void RemoveWithIndexTest()
        {
            var checkList = Initialization();
            checkList.Append("y");
            checkList.Append("z");
            checkList.Remove(0);
            Assert.AreEqual("b, c, d, y, z", checkList.toString());
            checkList.Remove(4);
            Assert.AreEqual("b, c, d, y", checkList.toString());
            checkList.Remove(2);
            Assert.AreEqual("b, c, y", checkList.toString());
            checkList.Remove(100);
            Assert.AreEqual("b, c, y", checkList.toString());
        }

        [Test]
        public void ContainsTest()
        {
            var checkList = Initialization();
            Assert.AreEqual(true, checkList.Contains("a"));
            Assert.AreEqual(false, checkList.Contains("z"));
        }

        [Test]
        public void InsertTest()
        {
            var checkList = Initialization();
            checkList.Insert("x", 1);
            Assert.AreEqual("a, x, b, c, d", checkList.toString());
            checkList.Insert("y", 0);
            Assert.AreEqual("y, a, x, b, c, d", checkList.toString());
            checkList.Insert("z", 100);
            Assert.AreEqual("y, a, x, b, c, d, z", checkList.toString());
        }

        [Test]
        public void ChangeNodeValueTest()
        {
            var checkList = Initialization();
            checkList.ChangeNodeValue("alpha", 0);
            Assert.AreEqual("alpha, b, c, d", checkList.toString());
            checkList.ChangeNodeValue("beta", 1);
            Assert.AreEqual("alpha, beta, c, d", checkList.toString());
            checkList.ChangeNodeValue("gamma", 2);
            Assert.AreEqual("alpha, beta, gamma, d", checkList.toString());
            checkList.ChangeNodeValue("delta", 3);
            Assert.AreEqual("alpha, beta, gamma, delta", checkList.toString());
        }
        
        [Test]
        public void GetValueTest()
        {
            var checkList = Initialization();
            Assert.AreEqual("a", checkList.GetValue(0));
            Assert.AreEqual("d", checkList.GetValue(3));
        }

        [Test]
        public void ReverseTest()
        {
            var checkList = Initialization();
            checkList.Reverse();
            Assert.AreEqual("d, c, b, a", checkList.toString());
            checkList.Reverse();
            Assert.AreEqual("a, b, c, d", checkList.toString());
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