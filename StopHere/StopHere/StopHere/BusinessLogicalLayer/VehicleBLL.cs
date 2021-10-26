using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using BusinessLogicalLayer.Validations;
using DataInfrastructure;
using Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class VehicleBLL : IVehicleService
    {
        public async Task<Response> Create(Vehicle v)
        {
            try
            {
                v.Placa = v.Placa.ClearMask();
                VehicleValidation validation = new VehicleValidation(true);
                ValidationResult result = validation.Validate(v);

                Response response = CommonExtension.ToResponse(result);
                if (!response.Success)
                {
                    return response;
                }
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    Vehicle vehicleCadastrado = await db.Vehicles.FirstOrDefaultAsync(veiculosDoBanco => veiculosDoBanco.Placa == v.Placa);
                    if (vehicleCadastrado != null)
                    {
                        return FactoryResponse.FailureResponse();
                    }

                    db.Vehicles.Add(v);
                    await db.SaveChangesAsync();
                    return FactoryResponse.SuccessResponse("Veículo cadastrado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }
        public async Task<Response> Disable(int id)
        {
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    Vehicle vehicleBanco = await db.Vehicles.FindAsync(id);
                    vehicleBanco.Ativo = false;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);

            }
            return FactoryResponse.SuccessResponse("Veículo desativado com sucesso.");
        }

        public async Task<DataResponse<Vehicle>> UserVehicle(int userID)
        {
            List<Vehicle> vehicleList = new List<Vehicle>();

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    vehicleList = await db.Vehicles.Where(v => v.UserID == userID).Where(v => v.Ativo == true).OrderBy(v => v.ID).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureDataResponse<Vehicle>(ex);
            }
            return FactoryResponse.SuccessDataResponse(vehicleList, "Veículos selecionados com sucesso!");
        }

        public async Task<SingleResponse<Vehicle>> GetByID(int id)
        {
            Vehicle vehicle = new Vehicle();

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    vehicle = await db.Vehicles.FindAsync(id);
                    if (vehicle == null)
                    {
                        return FactoryResponse.NotFoundSingleResponse<Vehicle>("Veículo não encontrado.");
                    }
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<Vehicle>(ex);
            }
            return FactoryResponse.SuccessSingleResponse(vehicle, "Veículo selecionado com sucesso.");
        }

        public async Task<Response> Update(Vehicle v)
        {
            ValidationResult result = new VehicleValidation(false).Validate(v);

            Response r = result.ToResponse();
            if (!r.Success)
            {
                return r;
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    Vehicle vehicleBanco = await db.Vehicles.FindAsync(v.ID);
                    vehicleBanco.Cor = v.Cor;
                    vehicleBanco.Observacao = v.Observacao;
                    await db.SaveChangesAsync();

                    return FactoryResponse.SuccessResponse("Veículo editado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }
    }
}
