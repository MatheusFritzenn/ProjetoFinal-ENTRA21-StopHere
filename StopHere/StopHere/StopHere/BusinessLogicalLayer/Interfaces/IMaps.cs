using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IMaps
    {
        Task<Response> SetGeolocationAsync(Parking parking);
        Task<DataResponse<string>> SearchGeolocationAsync(string adress);
        SingleResponse<double> GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude);

    }
}
