using System.Collections.Generic;
using Transversal.Entities;

namespace ServiceRepository.Repository.Interfaces
{
    public interface IRepositoryUserFlightRegister
    {
        int CreateUserFlightRegister (int idFlight, int userDocumentNumber);
    }
}
