using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Genetics
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void ExamplesTest(){
            // Example 1
            char[] vector1 = new char[] { 'A', 'B', 'G', 'T', 'A' };
            char[] toFound1 = new char[] { 'G', 'T'};

            //Example 2
            char[] vector2 = new char[] { 'A','B','G','A','B'};
            char[] toFound2 = new char[] { 'A','B'};

            //Example 3
            char[] vector3 = new char[] { 'G','T','A','A','A','A'};
            char[] toFound3 = new char[] { 'A','A','A'};

            int threadLimit = 5;
            for (int i = 1; i <= threadLimit; i++)
            {
                //Example 1
                Master master1 = new Master(vector1, i);
                Assert.AreEqual(master1.ComputeModulus(toFound1), 1);
            }

            threadLimit = 5;
            for (int i = 1; i <= threadLimit; i++)
            {
                //Example 2
                Master master2 = new Master(vector2, i);
                Assert.AreEqual(master2.ComputeModulus(toFound2), 2);
            }

            //threadLimit = 6;
            //for (int i = 1; i <= threadLimit; i++)
            //{
            //    //Example 3
            //    Master master3 = new Master(vector3, i);
            //    Assert.AreEqual(master3.ComputeModulus(toFound3), 3);
            //}
        }
    }
}
