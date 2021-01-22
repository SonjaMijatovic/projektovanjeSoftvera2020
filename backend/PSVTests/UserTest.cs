using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using Xunit.Sdk;

namespace PSVTests
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void TestUser()
        {
            User user = new User();

            user.FirstName = "Petar";
            user.LastName = "Petrovic";

            Assert.AreEqual(user.FirstName, "Petar");
            Assert.AreEqual(user.LastName, "Petrovic");
            Assert.AreNotEqual(user.FirstName, "Petar Petrovic");
        }
    }
}
