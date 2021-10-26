using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using DataInfrastructure;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class LocationBLL : ILocationService
    {
        public async Task<Response> Create(Location location)
        {
            SingleResponse<Location> validate = Validations.CustomValidations.ValidaLocacao(location);
            if (!validate.Success)
            {
                return validate;
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    db.Locations.Add(location);
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Locação realizada com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }

        public async Task<DataResponse<Location>> LocationParking(int id)
        {
            DataResponse<Location> dataResponse = new DataResponse<Location>();
            List<Location> locationList = new List<Location>();
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    locationList = await db.Locations.Where(p => p.ParkingID == id).OrderBy(p => p.ID).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureDataResponse<Location>(ex);
            }
            return FactoryResponse.SuccessDataResponse(locationList, "Locações selecionadas com sucesso!");
        }



    }
}
