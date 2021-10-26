using AutoMapper;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Parking;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class MapController : Controller
    {
        IMaps _map;
        IParkingService _parkingService;
        IMapper _mapper;
        public MapController(IMaps maps, IParkingService _parkingSvc, IMapper mapper)
        {
            _parkingService = _parkingSvc;
            _map = maps;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SearchMap(string compromisso)
        {
            string address = "";
            if (string.IsNullOrWhiteSpace(compromisso))
            {
                address = "7 de setembro 1600, Blumenau SC";
            }
            else
            {
                address = compromisso;
            }
            try
            {
                DataResponse<string> result = await _map.SearchGeolocationAsync(address);
                if (!result.Success)
                {
                    return View();
                }
                DataResponse<Parking> parkings = await _parkingService.GetNearParks(double.Parse(result.Data[0], new CultureInfo("en-us")), double.Parse(result.Data[1], new CultureInfo("en-us")));
                List<ParkJsonViewModel> data = _mapper.Map<List<ParkJsonViewModel>>(parkings.Data);
                ViewBag.Parkings = JsonSerializer.Serialize<List<ParkJsonViewModel>>(data);
                ViewBag.Latitude = result.Data[0];
                ViewBag.Longitude = result.Data[1];
            }
            catch (Exception ex)
            {
                ViewBag.GeoError = "Este endereço não foi encontrado!";
                RedirectToAction("Create");
            }
            return View();
        }

        public class AddressComponent
        {
            public string long_name { get; set; }
            public string short_name { get; set; }
            public List<string> types { get; set; }
        }

        public class Location
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Northeast
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Southwest
        {
            public double lat { get; set; }
            public double lng { get; set; }
        }

        public class Viewport
        {
            public Northeast northeast { get; set; }
            public Southwest southwest { get; set; }
        }

        public class Geometry
        {
            public Location location { get; set; }
            public string location_type { get; set; }
            public Viewport viewport { get; set; }
        }

        public class Result
        {
            public List<AddressComponent> address_components { get; set; }
            public string formatted_address { get; set; }
            public Geometry geometry { get; set; }
            public string place_id { get; set; }
            public List<string> types { get; set; }
        }

        public class Root
        {
            public List<Result> results { get; set; }
            public string status { get; set; }
        }
    }
}
