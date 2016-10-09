using System;
using AlarmClock.Localization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var x = Resources.ResourceManager.GetString("test");
        }
    }
}
