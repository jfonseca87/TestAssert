using System;
using ServiceBusiness.Business.Interfaces;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceBusiness.Business.Class
{
    public class BusinessFlight : IBusinessFlight
    {
        private readonly IRepositoryFlight repositoryFlight;
        public BusinessFlight(IRepositoryFlight repositoryFlight)
        {
            this.repositoryFlight = repositoryFlight;
        }

        public int CreateFlight(Flight userFlight)
        {
            return this.repositoryFlight.CreateFlight(userFlight);
        }

        public Flight GetFlight(int idFlight)
        {
            return this.repositoryFlight.GetFlight(idFlight);
        }
    }
}
