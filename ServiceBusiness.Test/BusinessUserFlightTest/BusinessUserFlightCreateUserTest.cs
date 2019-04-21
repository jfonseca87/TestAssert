using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceBusiness.Business.Class;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceBusinessTest.ServiceBusiness.Test.BusinessUserFlightTest
{
    [TestClass]
    public class BusinessUserFlightCreateUserTest
    {
        [TestMethod]
        public void CreateUserSuccessfull()
        {
            var mockUserFlightRepository = new Mock<IRepositoryUserFlight>();
            mockUserFlightRepository.Setup(x => x.CreateUserFlight(It.IsAny<UserFlight>())).Returns(1);

            var businessUserFlight = new BusinessUserFlight(mockUserFlightRepository.Object);
            var response = businessUserFlight.CreateUserFlight(GetData());

            Assert.IsNotNull(response);
            Assert.AreEqual(1, response);
        }

        [TestMethod]
        public void CreateUserFailed()
        {
            var mockUserFlightRepository = new Mock<IRepositoryUserFlight>();
            mockUserFlightRepository.Setup(x => x.CreateUserFlight(It.IsAny<UserFlight>())).Returns(0);

            var businessUserFlight = new BusinessUserFlight(mockUserFlightRepository.Object);
            var response = businessUserFlight.CreateUserFlight(GetData());

            Assert.IsNotNull(response);
            Assert.AreEqual(0, response);
        }

        private UserFlight GetData()
        {
            return new UserFlight
            {
                DocumentType = "CC",
                DocumentNumber = 1111,
                UserName = "Pepito Perez",
                Email = "pperez@domain.com",
                PhoneNumber = "3101234567"
            };
        }
    }
}
