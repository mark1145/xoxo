using Ballicon.API.Controllers;
using Ballicon.API.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Ballicon.API.Tests
{
    [TestClass]
    public class ValuesControllerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mockRepo = new Mock<IUserRepository>();
            //mockRepo.Setup(x => x.Get()).Returns(1000);

            ValuesController controller = new ValuesController(mockRepo.Object);

            var res = controller.Get();
        }
    }
}
