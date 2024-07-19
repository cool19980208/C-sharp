using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace InterfaceExample1.Tests
{
    [TestClass]
    public class DeskFenTests
    {
        [TestMethod]//特征
        public void PowerLowerThanZero_OK()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 0);
            var fan = new DeskFan(mock.Object);
            var expected = "电压过低";
            var actial = fan.Work();
            Assert.AreEqual(expected, actial);//对比fan获取到的结果是否和expected 一致。
        }
        [TestMethod]//特征
        public void PowerLowerThanZero_Fail()
        {
            var mock = new Mock<IPowerSupply>();
            mock.Setup(ps => ps.GetPower()).Returns(() => 200);
            var fan = new DeskFan(mock.Object);
            var expected = "电压过大";
            var actial = fan.Work();
            Assert.AreEqual(expected, actial);//对比fan获取到的结果是否和expected 一致。
        }
    }
   
}
