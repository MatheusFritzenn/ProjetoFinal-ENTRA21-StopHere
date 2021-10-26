using AutoMapper;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.PictureManager;
using BusinessLogicalLayer.Responses;
using Entities;
using Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Functions;
using PresentationLayer.Models.Parking;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    //DataAnnotation que informa o controller que todas as suas Actions só podem
    //ser executadas caso exista um cookies (ou seja, o usuário está autenticado)
    [Authorize]
    public class ParkingController : Controller
    {
        private IParkingService _parkingService;
        private IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        public ParkingController(IParkingService parkingService, IMapper mapper, IWebHostEnvironment environment)
        {
            this._parkingService = parkingService;
            this._mapper = mapper;
            this._environment = environment;
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ParkingInsertViewModel viewModel)
        {
            DaysOfWeek days =
                (DaysOfWeek)Request.Form["DiasDisponiveis"].ToString()
                                                           .Split(',')
                                                           .ToList()
                                                           .ConvertAll<int>(c => int.Parse(c))
                                                           .Sum();

            viewModel.DiasDisponiveis = days;
            Parking parking = _mapper.Map<Parking>(viewModel);

            viewModel.FotosVaga.Add(viewModel.FotoVaga1);

            if (viewModel.FotoVaga2 != null && viewModel.FotoVaga2.Length != 0)
            {
                viewModel.FotosVaga.Add(viewModel.FotoVaga2);
            }
            if (viewModel.FotoVaga3 != null && viewModel.FotoVaga3.Length != 0)
            {
                viewModel.FotosVaga.Add(viewModel.FotoVaga3);
            }

            DataResponse<IFormFile> dataResponse = ParkingPictureManager.ValidateFiles(viewModel.FotosVaga);
            if (!dataResponse.Success)
            {
                ViewBag.Error = dataResponse.Message;
                return View(viewModel);
            }

            Response response = new Response();
            parking.DeixarChave = ResolveView.ResolveCheckBoxBinding(Request.Form["DeixarChave"].ToString());
            parking.IsVigiada = ResolveView.ResolveCheckBoxBinding(Request.Form["IsVigiada"].ToString());
            parking.IsCoberta = ResolveView.ResolveCheckBoxBinding(Request.Form["IsCoberta"].ToString());
            parking.UserID = CookiesHelper.GetCookieData(this.User).ID;

            DataResponse<Parking> parkingData = _parkingService.ParkingFactory(parking, viewModel.Quantidade);

            response = await _parkingService.Create(parkingData.Data);

            foreach (Parking vaga in parkingData.Data)
            {
                string path = ParkingPictureManager.CreateFolder(vaga.ID, _environment.WebRootPath);
                await ParkingPictureManager.SendFilesToFolderAsync(viewModel.FotosVaga, path);
            }

            if (response.Success)
            {
                return RedirectToAction("ShowAll", "Parking");
            }

            ViewBag.Error = response.Message;

            return View();
        }
        public async Task<IActionResult> Disable(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ShowAll", "Parking");
            }

            Response responseR = await _parkingService.Disable(id.Value);

            if (!responseR.Success)
            {
                ViewBag.Error = responseR.Message;
                return View();
            }
            return RedirectToAction("ShowAll", "Parking");
        }

        public async Task<IActionResult> ShowAll()
        {
            DataResponse<Parking> response = await this._parkingService.UserParking(int.Parse(User.Claims.ToList()[2].Value));
            if (!response.Success)
            {
                ViewBag.Errors = response.Message;
            }
            List<ParkingQueryViewModel> parkings =
                _mapper.Map<List<ParkingQueryViewModel>>(response.Data);

            return View(parkings);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("ShowAll", "Parking");
            }

            SingleResponse<Parking> response = await _parkingService.GetByID(id.Value);
            if (!response.Success)
            {
                return RedirectToAction("ShowAll", "Parking");
            }
            ParkingUpdateViewModel viewModel = _mapper.Map<ParkingUpdateViewModel>(response.Item);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ParkingUpdateViewModel viewModel)
        {
            DaysOfWeek days =
                (DaysOfWeek)Request.Form["DiasDisponiveis"].ToString()
                                                           .Split(',')
                                                           .ToList()
                                                           .ConvertAll<int>(c => int.Parse(c))
                                                           .Sum();

            viewModel.DiasDisponiveis = days;
            Parking p = _mapper.Map<Parking>(viewModel);
            p.DeixarChave = ResolveView.ResolveCheckBoxBinding(Request.Form["DeixarChave"].ToString());
            p.IsVigiada = ResolveView.ResolveCheckBoxBinding(Request.Form["IsVigiada"].ToString());
            p.IsCoberta = ResolveView.ResolveCheckBoxBinding(Request.Form["IsCoberta"].ToString());

            if (viewModel.FotoVaga1 != null && viewModel.FotoVaga1.Length != 0)
            {
                viewModel.FotosVaga.Add(viewModel.FotoVaga1);
            }
            if (viewModel.FotoVaga2 != null && viewModel.FotoVaga2.Length != 0)
            {
                viewModel.FotosVaga.Add(viewModel.FotoVaga2);
            }
            if (viewModel.FotoVaga3 != null && viewModel.FotoVaga3.Length != 0)
            {
                viewModel.FotosVaga.Add(viewModel.FotoVaga3);
            }
            if (viewModel.FotosVaga.Count != 0)
            {
                DataResponse<IFormFile> dataResponse = ParkingPictureManager.ValidateFiles(viewModel.FotosVaga);
                if (!dataResponse.Success)
                {
                    ViewBag.Error = dataResponse.Message;
                    return View(viewModel);
                }
                else if (dataResponse.Success)
                {
                    string path = ParkingPictureManager.CreateFolder(viewModel.ID, _environment.WebRootPath);
                    await ParkingPictureManager.SendFilesToFolderAsync(viewModel.FotosVaga, path);
                }
            }

            Response r = await _parkingService.Update(p);
            if (r.Success)
            {
                return RedirectToAction("ShowAll", "Parking");
            }
            ViewBag.Errors = r.Message;
            return View();
        }
    }
}
