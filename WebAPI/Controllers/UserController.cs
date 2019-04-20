using System;
using System.Web.Http;
using ServiceBusiness.Business.Class;
using ServiceBusiness.Business.Interfaces;
using ServiceRepository.Repository.Class;
using Transversal.Entities;

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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        [Route("api/User")]
        public IHttpActionResult CreateUser(UserFlight user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("It´s mandatory provide the data");
            }

            try
            {
                int idUser = this.businessUserFlight.CreateUserFlight(user);
                return Ok(idUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
