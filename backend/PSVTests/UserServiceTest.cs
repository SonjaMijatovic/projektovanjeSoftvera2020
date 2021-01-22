using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using PSV.Service;
using Xunit.Sdk;

namespace PSVTests
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void TestUserService()
        {
            
            UserService service = new UserService();

            Assert.IsNotNull(service);
        }
    }
}
