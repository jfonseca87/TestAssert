using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceRepository.Business.Interfaces;
using ServiceRepository.Repository.Interfaces;
using Transversal.Entities;

namespace ServiceBusiness.Business.Class
{
    public class BusinessUserFlightRegister : IBusinessUserFlightRegister
    {
        private readonly IRepositoryUserFlightRegister repositoryUserFlightRegister;
        public BusinessUserFlightRegister(IRepositoryUserFlightRegister repositoryUserFlightRegister)
        {
            this.repositoryUserFlightRegister = repositoryUserFlightRegister;
        }

        public int CreateUserFlightRegister(int idFlight, int userDocumentNumber)
        {
            return this.repositoryUserFlightRegister.CreateUserFlightRegister(idFlight, userDocumentNumber);
        }

        public IEnumerable<int> CreateUserFlightRegisterMassive(IEnumerable<UserFlightRegister> lstRegisters)
        {
            List<int> response = new List<int>();

            foreach (var userFlight in lstRegisters)
            {
                response.Add(this.repositoryUserFlightRegister.CreateUserFlightRegister(userFlight.IdFlight, 
                                                                                        userFlight.UserDocumentNumber));
            }

            return response;
        }
    }
}
