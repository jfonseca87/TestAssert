using Transversal.Entities;

namespace ServiceRepository.Repository.Interfaces
{
    public interface IRepositoryUserFlight
    {
        int CreateUserFlight (UserFlight userFlight);
        UserFlight GetUserFlight (int userDocumentNumber);
    }
}
