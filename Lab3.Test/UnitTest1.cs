using Lab3;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;


namespace Tests
{
    public class Tests
    {
        

        [Test]
        public void TestSelect1_2_3_odd()
        {
            int[] arr = { 1, 2, 3 };
            int[] expected  = { 1,  3 };
            Helper<int> helper = new Helper<int>();
            IEnumerable<int> selected = helper.Select(arr, x => x % 2 == 1);
            Assert.AreEqual(selected, expected);
        }

        [Test]
        public void TestSelect1_2_3_even()
        {
            int[] arr = { 1, 2, 3 };
            int[] expected = { 2 };
            Helper<int> helper = new Helper<int>();
            IEnumerable<int> selected = helper.Select(arr, x => x % 2 == 0);
            CollectionAssert.AreEqual(selected, expected);
        }

        [Test]
        public void TestSelect1_3_even()
        {
            int[] arr = { 1,  3 };
            int[] expected = { };
            Helper<int> helper = new Helper<int>();
            IEnumerable<int> selected = helper.Select(arr, x => x % 2 == 0);
            CollectionAssert.AreEqual(selected, expected);
        }

        [Test]
        public void TestSelect_null_odd()
        {
            int[] arr = {  };
            int[] expected = { };
            Helper<int> helper = new Helper<int>();
            IEnumerable<int> selected = helper.Select(arr, x => x % 2 == 1);
            CollectionAssert.AreEqual(selected, expected);
        }
        [Test]
        public void TestSelect1_2_3_4even()
        {
            IEnumerable<int> list  = new List<int>{ 1, 2, 3, 4};            
            IEnumerable<int> expected = new List<int>{ 2, 4 };
            Helper<int> helper = new Helper<int>();
            IEnumerable<int> selected = helper.Select(list, x => x % 2 == 0);
            CollectionAssert.AreEqual(selected, expected);
        }

    }
}
