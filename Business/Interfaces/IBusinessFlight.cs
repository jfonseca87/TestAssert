using Transversal.Entities;

namespace ServiceBusiness.Business.Interfaces
{
    public interface IBusinessFlight
    {
        int CreateFlight(Flight userFlight);
        Flight GetFlight(int idFlight);
    }
}
