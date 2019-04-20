using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceBusiness.Business.Interfaces;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceBusiness.Business.Class
{
    public class BusinessUserFlight : IBusinessUserFlight
    {
        private readonly IRepositoryUserFlight repositoryUserFlight;
        public BusinessUserFlight(IRepositoryUserFlight repositoryUserFlight)
        {
            this.repositoryUserFlight = repositoryUserFlight;
        }

        public int CreateUserFlight(UserFlight userFlight)
        {
            return this.repositoryUserFlight.CreateUserFlight(userFlight);
        }

        public UserFlight GetUserFlight(int userDocumentNumber)
        {
            return this.repositoryUserFlight.GetUserFlight(userDocumentNumber);
        }
    }
}
