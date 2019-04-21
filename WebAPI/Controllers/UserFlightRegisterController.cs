using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ServiceBusiness.Business.Class;
using ServiceRepository.Business.Interfaces;
using ServiceRepository.Repository.Class;
using Transversal.Entities;
using Utilities.GlobalResources;

namespace ServiceAPI.WebAPI.Controllers
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
                throw new ArgumentNullException(GlobalMessages.NullArgumentMessage, nameof(userFlightRegistry));
            }

            try
            {
                int idRegistry = this.businessUserFlightRegister.CreateUserFlightRegister(
                                                                    userFlightRegistry.IdFlight,
                                                                    userFlightRegistry.UserDocumentNumber);
                return Ok(idRegistry);
            }
            catch (Exception)
            {
                return BadRequest(GlobalMessages.ExceptionErrorMessage);
            }
        }

        [HttpPost()]
        [Route("api/Registry/UserFlightRegistryMassive")]
        public IHttpActionResult CreateUserFlightRegistryMassive(IEnumerable<UserFlightRegister> userFlightRecords)
        {
            if (userFlightRecords.Any())
            {
                throw new ArgumentNullException(GlobalMessages.NullArgumentMessage, nameof(userFlightRecords));
            }

            try
            {
                IEnumerable<int> lstRecords = this.businessUserFlightRegister.CreateUserFlightRegisterMassive(userFlightRecords);
                return Ok(lstRecords);
            }
            catch (Exception)
            {
                return BadRequest(GlobalMessages.ExceptionErrorMessage);
            }
        }
    }
}
