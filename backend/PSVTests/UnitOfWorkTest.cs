using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSV.Model;
using PSV.Repository;
using PSV.Service;
using Xunit.Sdk;

namespace PSVTests
{
    [TestClass]
    public class UnitOfWorkTest
    {
        [TestMethod]
        public void TestUnitOfWork()
        {

            BackendContext context = new BackendContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            Assert.IsNotNull(unitOfWork.Appointments);
            Assert.IsNotNull(unitOfWork.DoctorTypes);
            Assert.IsNotNull(unitOfWork.Feedbacks);
            Assert.IsNotNull(unitOfWork.Users);
            Assert.IsNotNull(unitOfWork.Visits);
        }
    }
}

