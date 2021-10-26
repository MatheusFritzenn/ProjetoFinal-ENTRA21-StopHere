using AutoMapper;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Responses;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class VehicleController : Controller
    {
        private readonly IVehicleService _iVehicleService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public IActionResult Index()
        {
            return View();
        }

        public VehicleController(IVehicleService vehicleService, IMapper mapper, IWebHostEnvironment environment)
        {
            this._iVehicleService = vehicleService;
            this._mapper = mapper;
            this._environment = environment;
        }

        [HttpGet]
        public async Task<IActionResult> ShowAll()
        {
            int userID = int.Parse(User.Claims.ToList()[2].Value);
            DataResponse<Vehicle> response = await this._iVehicleService.UserVehicle(userID);

            if (!response.Success)
            {
                ViewBag.Errors = response.Message;
            }
            List<VehicleShowAllViewModel> veiculos =
                _mapper.Map<List<VehicleShowAllViewModel>>(response.Data);

            return View(veiculos);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(VehicleCreateViewModel viewModel)
        {
            Vehicle vehicle = _mapper.Map<Vehicle>(viewModel);
            vehicle.UserID = int.Parse(User.Claims.ToList()[2].Value);

            viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo1);
            viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo2);
            viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo3);
            viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo4);

            DataResponse<IFormFile> dataResponse = VehiclePictureManager.ValidateFiles(viewModel.ListaFotosVeiculos);
            if (!dataResponse.Success)
            {
                ViewBag.Error = dataResponse.Message;
                return View();
            }

            Response response = await _iVehicleService.Create(vehicle);

            if (!response.Success)
            {
                ViewBag.Error = response.Message;
                return View();
            }
            string path = VehiclePictureManager.CreateFolder(vehicle.ID, _environment.WebRootPath);
            await VehiclePictureManager.SendFilesToFolderAsync(viewModel.ListaFotosVeiculos, path);

            return RedirectToAction("ShowAll", "Vehicle");
        }
        public async Task<IActionResult> Disable(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ShowAll", "Vehicle");
            }

            Response responseR = await _iVehicleService.Disable(id.Value);

            if (!responseR.Success)
            {
                ViewBag.Error = responseR.Message;
                return View();
            }
            return RedirectToAction("ShowAll", "Vehicle");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ShowAll", "Vehicle");
            }

            SingleResponse<Vehicle> response = await _iVehicleService.GetByID(id.Value);
            if (!response.Success)
            {
                return RedirectToAction("ShowAll", "Vehicle");
            }
            VehicleUpdateViewModel viewModel = _mapper.Map<VehicleUpdateViewModel>(response.Item);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(VehicleUpdateViewModel viewModel)
        {
            Vehicle v = _mapper.Map<Vehicle>(viewModel);

            if (viewModel.FotoVeiculo1 != null && viewModel.FotoVeiculo1.Length != 0)
            {
                viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo1);
            }
            if (viewModel.FotoVeiculo2 != null && viewModel.FotoVeiculo2.Length != 0)
            {
                viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo2);
            }
            if (viewModel.FotoVeiculo3 != null && viewModel.FotoVeiculo3.Length != 0)
            {
                viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo3);
            }
            if (viewModel.FotoVeiculo4 != null && viewModel.FotoVeiculo4.Length != 0)
            {
                viewModel.ListaFotosVeiculos.Add(viewModel.FotoVeiculo4);
            }
            
            if (viewModel.ListaFotosVeiculos.Count != 0)
            {
                DataResponse<IFormFile> dataResponse = VehiclePictureManager.ValidateFiles(viewModel.ListaFotosVeiculos);
                if (!dataResponse.Success)
                {
                    ViewBag.Error = dataResponse.Message;
                    return View(viewModel);
                }
                else if (dataResponse.Success)
                {
                    string path = VehiclePictureManager.CreateFolder(viewModel.ID, _environment.WebRootPath);
                    await VehiclePictureManager.SendFilesToFolderAsync(viewModel.ListaFotosVeiculos, path);
                }
            }
            
            Response r = await _iVehicleService.Update(v);
            if (r.Success)
            {
                return RedirectToAction("ShowAll", "Vehicle");
            }
            ViewBag.Errors = r.Message;
            return View();
        }
    }
}
