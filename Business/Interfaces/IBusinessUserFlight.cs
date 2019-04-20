using Transversal.Entities;

namespace ServiceBusiness.Business.Interfaces
{
    public interface IBusinessUserFlight
    {
        int CreateUserFlight(UserFlight userFlight);
        UserFlight GetUserFlight(int userDocumentNumber);
    }
}
