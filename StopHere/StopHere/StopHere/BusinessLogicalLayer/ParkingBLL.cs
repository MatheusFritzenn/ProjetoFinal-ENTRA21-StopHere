using BusinessLogicalLayer.Extensions;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using BusinessLogicalLayer.Validations;
using DataInfrastructure;
using Entities;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer
{
    public class ParkingBLL : IParkingService
    {
        private readonly IMaps _maps;
        public ParkingBLL(IMaps mapsService)
        {
            this._maps = mapsService;
        }

        public async Task<DataResponse<Parking>> GetNearParks(double latitude, double longitude)
        {

            DataResponse<Parking> responseParking = await this.GetAll();
            if (!responseParking.Success)
            {
                return FactoryResponse.FailureDataResponse<Parking>();
            }

            List<Parking> parkings = responseParking.Data;
            Dictionary<int, double> distancia = new Dictionary<int, double>();
            foreach (Parking item in parkings)
            {
                double distance = this._maps.GetDistance(latitude, longitude, double.Parse(item.Latitude, new CultureInfo("en-us")), double.Parse(item.Longitude, new CultureInfo("en-us"))).Item;
                distancia.Add(item.ID, distance);
            }

            var sortedDict = from entry in distancia orderby entry.Value ascending select entry;

            DataResponse<Parking> response = new DataResponse<Parking>();
            List<Parking> estacionamentosProximos = new List<Parking>();
            int count = 0;

            var enumerator = sortedDict.GetEnumerator();
            foreach (var item in sortedDict)
            {
                if (count == 5)
                {
                    break;
                }
                estacionamentosProximos.Add(parkings.Find(c => c.ID == item.Key));
                count++;
            }
            response.Data = estacionamentosProximos;
            response.Message = "Estacionamentos selecionados com sucesso.";
            return response;
        }


        public async Task<Response> Create(List<Parking> p)
        {
            if (p.Count <= 0)
            {
                return FactoryResponse.FailureResponse("Ao menos uma vaga deve ser criada.");
            }

            
            for (int i = p.Count - 1; i < p.Count; i++)
            {
                p[i].CEP = p[i].CEP.ClearMask();
                ValidationResult result = new ParkingValidation().Validate(p[i]);
                Response response = CommonExtension.ToResponse(result);
                if (!response.Success)
                {
                    return response;
                }
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    for (int i = 0; i < p.Count; i++)
                    {
                        p[i].Ativo = true;
                        db.Parkings.Add(p[i]);
                        await db.SaveChangesAsync();
                        Response results = await _maps.SetGeolocationAsync(p[i]);
                        if (!results.Success)
                        {
                            return results;
                        }
                    }
                    return FactoryResponse.SuccessResponse("Vaga cadastrada com sucesso.");
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
                    Parking parkingBanco = await db.Parkings.FindAsync(id);
                    parkingBanco.Ativo = false;
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);

            }
            return FactoryResponse.SuccessResponse("Vaga desativada com sucesso.");
        }

        public async Task<DataResponse<Parking>> GetAll()
        {
            List<Parking> parkingList = new List<Parking>();
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    parkingList = await db.Parkings.OrderBy(p => p.ID).Where(p => p.Ativo == true).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureDataResponse<Parking>(ex);
            }
            return FactoryResponse.SuccessDataResponse(parkingList, "Vagas selecionadas com sucesso!");
        }

        public async Task<DataResponse<Parking>> UserParking(int id)
        {
            DataResponse<Parking> dataResponse = new DataResponse<Parking>();
            List<Parking> parkingList = new List<Parking>();
            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    parkingList = await db.Parkings.Where(p => p.UserID == id).Where(p => p.Ativo == true).OrderBy(p => p.ID).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureDataResponse<Parking>(ex);
            }
            return FactoryResponse.SuccessDataResponse(parkingList, "Vagas selecionadas com sucesso!");
        }

        public async Task<SingleResponse<Parking>> GetByID(int id)
        {
            //falta testar esse metodo
            Parking parking = new Parking();

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    parking = await db.Parkings.FindAsync(id);
                    if (parking == null)
                    {
                        return FactoryResponse.NotFoundSingleResponse<Parking>();
                    }
                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureSingleResponse<Parking>(ex);
            }
            return FactoryResponse.SuccessSingleResponse(parking, "Vaga selecionada com sucesso.");
        }

        public async Task<Response> Update(Parking p)
        {

            ValidationResult result = new ParkingValidation().Validate(p);

            Response r = result.ToResponse();
            if (!r.Success)
            {
                return r;
            }

            try
            {
                using (StopHereDBContext db = new StopHereDBContext())
                {
                    Parking parkingBanco = await db.Parkings.FindAsync(p.ID);
                    parkingBanco.Complemento = p.Complemento;
                    parkingBanco.Abre = p.Abre;
                    parkingBanco.Fecha = p.Fecha;
                    parkingBanco.IsCoberta = p.IsCoberta;
                    parkingBanco.IsVigiada = p.IsVigiada;
                    parkingBanco.DeixarChave = p.DeixarChave;
                    parkingBanco.Valor = p.Valor;
                    parkingBanco.Bairro = p.Bairro;
                    parkingBanco.CEP = p.CEP;
                    parkingBanco.Cidade = p.Cidade;
                    parkingBanco.Rua = p.Rua;
                    parkingBanco.Numero = p.Numero;
                    parkingBanco.UF = p.UF;
                    parkingBanco.DiasDisponiveis = p.DiasDisponiveis;
                    await db.SaveChangesAsync();

                    Response results = await _maps.SetGeolocationAsync(parkingBanco);
                    if (!results.Success)
                    {
                        return FactoryResponse.FailureResponse();
                    }

                    return FactoryResponse.SuccessResponse("Vaga editada com sucesso.");

                }
            }
            catch (Exception ex)
            {
                return FactoryResponse.FailureResponse(ex);
            }
        }

        public DataResponse<Parking> ParkingFactory(Parking obj, int qtd)
        {

            List<Parking> parking = new List<Parking>();
            for (int i = 0; i < qtd; i++)
            {
                Parking temp = new Parking();
                temp.Abre = obj.Abre;
                temp.Fecha = obj.Fecha;
                temp.Ativo = obj.Ativo;
                temp.Bairro = obj.Bairro;
                temp.CEP = obj.CEP;
                temp.Cidade = obj.Cidade;
                temp.Complemento = obj.Complemento;
                temp.DeixarChave = obj.DeixarChave;
                temp.IsCoberta = obj.IsCoberta;
                temp.IsVigiada = obj.IsVigiada;
                temp.Latitude = obj.Latitude;
                temp.Longitude = obj.Longitude;
                temp.Numero = obj.Numero;
                temp.Rua = obj.Rua;
                temp.UF = obj.UF;
                temp.User = obj.User;
                temp.UserID = obj.UserID;
                temp.Valor = obj.Valor;
                temp.DiasDisponiveis = obj.DiasDisponiveis;
                parking.Add(temp);
            }
            return new DataResponse<Parking>()
            {
                Message = "Vagas criadas com sucesso",
                Success = true,
                Data = parking,
            };
        }
    }

}

