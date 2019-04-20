using Transversal.Entities;

namespace ServiceRepository.Repository.Interfaces
{
    public interface IRepositoryFlight
    {
        int CreateFlight(Flight flight);
        Flight GetFlight(int idFlight);
    }
}
