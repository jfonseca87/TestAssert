using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceBusiness.Business.Class;
using ServiceRepository.Business.Interfaces;
using ServiceRepository.Repository.Class;
using Transversal.Entities;

namespace WebAPI.Controllers
{
    public class UserFlightRegisterController : ApiController
    {
        private readonly IBusinessUserFlightRegister businessUserFlightRegister;
        public UserFlightRegisterController()
        {
            this.businessUserFlightRegister = new BusinessUserFlightRegister(new RepositoryUserFlightRegister());
        }

        [HttpPost()]
        [Route("api/Registry/UserFlightRegistry")]
        public IHttpActionResult CreateUserFlightRegistry(UserFlightRegister userFlightRegistry)
        {
            if (userFlightRegistry == null)
            {
                throw new ArgumentNullException("It´s mandatory provide the data");
            }

            try
            {
                int idRegistry = this.businessUserFlightRegister.CreateUserFlightRegister(
                                                                    userFlightRegistry.IdFlight,
                                                                    userFlightRegistry.UserDocumentNumber);
                return Ok(idRegistry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        [Route("api/Registry/UserFlightRegistryMassive")]
        public IHttpActionResult CreateUserFlightRegistryMassive(IEnumerable<UserFlightRegister> userFlightRecords)
        {
            if (userFlightRecords.Count() == 0)
            {
                throw new ArgumentNullException("It´s mandatory provide the list of data");
            }

            try
            {
                IEnumerable<int> lstRecords = this.businessUserFlightRegister.CreateUserFlightRegisterMassive(userFlightRecords);
                return Ok(lstRecords);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
