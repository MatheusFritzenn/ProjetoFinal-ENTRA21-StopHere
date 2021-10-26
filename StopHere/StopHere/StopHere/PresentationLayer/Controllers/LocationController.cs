using AutoMapper;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Location;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{

    public class LocationController : Controller
    {
        private readonly IParkingService _parkingService;
        private readonly IMapper _mapper;
        private readonly IVehicleService _vehicleService;
        private readonly ILocationService _locationService;

        public LocationController(IParkingService pS, IMapper mapper, IVehicleService vehicle, ILocationService Ilocation)
        {
            this._parkingService = pS;
            this._mapper = mapper;
            this._vehicleService = vehicle;
            this._locationService = Ilocation;
        }


        [HttpGet]
        public async Task<IActionResult> Add(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("SearchMap", "Map");
            }

            // VAGA
            SingleResponse<Parking> parkingResponse = await this._parkingService.GetByID(id.Value);
            LocationInsertViewModel view = _mapper.Map<LocationInsertViewModel>(parkingResponse.Item);
            view.ParkingID = parkingResponse.Item.ID;
            view.ValorHora = parkingResponse.Item.Valor;
            // adicionar fotos na view


            //VEICULO
            int userID = int.Parse(User.Claims.ToList()[2].Value);
            DataResponse<Vehicle> veiculoResponse = await _vehicleService.UserVehicle(userID);
            view.Vehicles = veiculoResponse.Data;



            // HORARIOS DISPONIVEIS
            List<DateTime> datasDisponiveisParaLocacao = new List<DateTime>();
            TimeSpan horaAbertura = parkingResponse.Item.Abre;
            TimeSpan horaFechamento = parkingResponse.Item.Fecha;
            DaysOfWeek days = parkingResponse.Item.DiasDisponiveis;

            for (int i = 0; i < 7; i++)
            {
                DateTime dia = DateTime.Now.Date.AddDays(i);
                DayOfWeek diaDaSemana = dia.DayOfWeek;
                DaysOfWeek nossoDiaDaSemana = (DaysOfWeek)Math.Pow(2, (int)diaDaSemana);

                if (days.HasFlag(nossoDiaDaSemana))
                {
                    TimeSpan ts = horaFechamento - horaAbertura;
                    for (int j = 0; j <= ts.TotalHours; j++)
                    {
                        DateTime dt = dia.AddHours(horaAbertura.TotalHours + j);
                        datasDisponiveisParaLocacao.Add(dt);
                    }
                }
            }

            //DataResponse<Location> dataResponse = await _locationService.LocationParking(id.Value);
            //List<Location> parkingList = dataResponse.Data;

            //for (int i = 0; i < parkingList.Count; i++)
            //{
            //    // se a hora reservada for mais cedo a hora de busca e a hora de saida for mais tarde q a hora de busca
            //    if (parkingList[i].DataEntrada < DateTime.Now && parkingList[i].DataSaida > DateTime.Now )
            //    {
            //        // está buscando durante uma reserva
            //        datasDisponiveisParaLocacao.Remove(parkingList[i].DataEntrada);

            //    }
            //}
            ViewBag.Horarios = datasDisponiveisParaLocacao;
            ViewBag.HorariosDistinct = datasDisponiveisParaLocacao.GroupBy(C => C.Date).ToList();
            return View(view);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LocationInsertViewModel viewModel)
        {
            Location location = _mapper.Map<Location>(viewModel);
            Response response = await _locationService.Create(location);
            if (!response.Success)
            {
                ViewBag.Erros = response.Message;
                return View(viewModel);

            }

            return RedirectToAction("SearchMap", "Map");
        }

        public async Task<IActionResult> ShowAll()
        {
            int userID = int.Parse(User.Claims.ToList()[2].Value);
            DataResponse<Parking> parkingDataResponse = await this._parkingService.UserParking(userID);

            if (!parkingDataResponse.Success)
            {
                ViewBag.Errors = parkingDataResponse.Message;
            }

            List<Location> locations = new List<Location>();

            for (int i = 0; i < parkingDataResponse.Data.Count; i++)
            {
                DataResponse<Location> listLocation = await _locationService.LocationParking(parkingDataResponse.Data[i].ID);
                if (listLocation.Data.Count > 0)
                {
                    listLocation.Data.ForEach(l => locations.Add(l));
                }
            }
            List<LocationShowAllViewModel> view = _mapper.Map<List<LocationShowAllViewModel>>(locations);
            return View(view);
        }

    }
}
