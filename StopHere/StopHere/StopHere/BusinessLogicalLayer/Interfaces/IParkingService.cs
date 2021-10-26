using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IParkingService
    {
        Task<Response> Create(List<Parking> p);
        Task<Response> Disable(int id);
        Task<DataResponse<Parking>> GetAll();
        Task<DataResponse<Parking>> UserParking(int id);
        Task<Response> Update(Parking p);
        Task<SingleResponse<Parking>> GetByID(int id);
        DataResponse<Parking> ParkingFactory(Parking obj, int qtd);
        Task<DataResponse<Parking>> GetNearParks(double latitude, double longitude);

    }
}
