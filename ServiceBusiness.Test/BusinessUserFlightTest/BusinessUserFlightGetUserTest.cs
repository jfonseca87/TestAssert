using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ServiceBusiness.Business.Class;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceBusinessTest.ServiceBusiness.Test.BusinessUserFlightTest
{
    [TestClass]
    public class BusinessUserFlightGetUserTest
    {
        [TestMethod]
        public void GetUserSuccessfull()
        {
            var mockUserFlightRepository = new Mock<IRepositoryUserFlight>();
            mockUserFlightRepository.Setup(x => x.GetUserFlight(It.IsAny<int>())).Returns(GetData());

            var businessUserFlight = new BusinessUserFlight(mockUserFlightRepository.Object);
            var response = businessUserFlight.GetUserFlight(1111);

            Assert.IsNotNull(response);
            Assert.AreEqual(1111, response.DocumentNumber);
        }

        [TestMethod]
        public void GetUserFailedReturnEmptyUser()
        {
            var mockUserFlightRepository = new Mock<IRepositoryUserFlight>();
            mockUserFlightRepository.Setup(x => x.GetUserFlight(It.IsAny<int>())).Returns(new UserFlight());

            var businessUserFlight = new BusinessUserFlight(mockUserFlightRepository.Object);
            var response = businessUserFlight.GetUserFlight(1111);

            Assert.IsNotNull(response);
            Assert.AreEqual(0, response.DocumentNumber);
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
