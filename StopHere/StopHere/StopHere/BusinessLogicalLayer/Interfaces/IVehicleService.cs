using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IVehicleService
    {
        Task<Response> Create(Vehicle v);
        Task<Response> Disable(int id);
        Task<DataResponse<Vehicle>> UserVehicle(int userID);
        Task<Response> Update(Vehicle v);
        Task<SingleResponse<Vehicle>> GetByID(int id);
    }
}
