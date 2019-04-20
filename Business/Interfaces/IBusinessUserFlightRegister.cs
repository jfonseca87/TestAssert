using System.Collections.Generic;
using Transversal.Entities;

namespace ServiceRepository.Business.Interfaces
{
    public interface IBusinessUserFlightRegister
    {
        int CreateUserFlightRegister(int idFlight, int userDocumentNumber);
        IEnumerable<int> CreateUserFlightRegisterMassive(IEnumerable<UserFlightRegister> lstRegisters);
    }
}
