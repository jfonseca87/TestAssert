using System;
using System.Web.Http;
using ServiceBusiness.Business.Class;
using ServiceBusiness.Business.Interfaces;
using ServiceRepository.Repository.Class;
using Transversal.Entities;
using Utilities.GlobalResources;

namespace ServiceAPI.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private readonly IBusinessUserFlight businessUserFlight;
        public UserController()
        {
            this.businessUserFlight = new BusinessUserFlight(new RepositoryUserFlight()); 
        }

        [HttpGet()]
        [Route("api/User/{userDocumentNumber}")]
        public IHttpActionResult GetUserByDocumentNumber(int userDocumentNumber)
        {
            try
            {
                UserFlight user = this.businessUserFlight.GetUserFlight(userDocumentNumber);
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest(GlobalMessages.ExceptionErrorMessage);
            }
        }

        [HttpPost()]
        [Route("api/User")]
        public IHttpActionResult CreateUser(UserFlight user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(GlobalMessages.NullArgumentMessage, nameof(user));
            }

            try
            {
                int idUser = this.businessUserFlight.CreateUserFlight(user);
                return Ok(idUser);
            }
            catch (Exception)
            {
                return BadRequest(GlobalMessages.ExceptionErrorMessage);
            }
        }
    }
}
