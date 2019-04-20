using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServiceBusiness.Business.Class;
using ServiceBusiness.Business.Interfaces;
using ServiceRepository.Repository.Class;
using Transversal.Entities;

namespace ServiceAPI.WebAPI.Controllers
{
    public class FlightController : ApiController
    {
        private readonly IBusinessFlight businessFlight;
        public FlightController()
        {
            this.businessFlight = new BusinessFlight(new RepositoryFlight());
        }

        [HttpGet()]
        [Route("api/Flight/{idFlight}")]
        public IHttpActionResult GetFlightById(int idFlight)
        {
            try
            {
                Flight flight = this.businessFlight.GetFlight(idFlight);
                return Ok(flight);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost()]
        [Route("api/Flight")]
        public IHttpActionResult CreateFlight(Flight flight)
        {
            if (flight == null)
            {
                throw new ArgumentNullException("It´s mandatory provide the data");
            }

            try
            {
                int idFlight = this.businessFlight.CreateFlight(flight);
                return Ok(idFlight);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
