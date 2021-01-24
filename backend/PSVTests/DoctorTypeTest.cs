using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using Xunit.Sdk;

namespace PSVTests
{
    [TestClass]
    public class DoctorTypeTest
    {
        [TestMethod]
        public void TestDoctorType()
        {
            DoctorType doctorType = new DoctorType();

            doctorType.Name = "Kardiolog";

            Assert.AreEqual(doctorType.Name, "Kardiolog");
            Assert.AreNotEqual(doctorType.Name, "Pedijatar");
        }
    }
}
