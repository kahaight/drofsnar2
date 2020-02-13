using System;
using Drofsnar2._0;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrofsnarTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public int TestMethod1()
        {

            Drofsnar drofsnar = new Drofsnar();

            int x = drofsnar.XPosition;
            Console.WriteLine(x);
            return x;


        }
    }
}
