using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface ILocationService
    {
        Task<Response> Create(Location location);
        Task<DataResponse<Location>> LocationParking(int id);
    }
}
