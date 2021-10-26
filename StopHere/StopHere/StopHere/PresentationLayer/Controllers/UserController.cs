using AutoMapper;
using BusinessLogicalLayer;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.PictureManager;
using BusinessLogicalLayer.Responses;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models.LegalPerson;
using PresentationLayer.Models.NaturalPerson;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PresentationLayer.Controllers
{
    public class UserController : Controller
    {
        private IMapper _mapper;

        private IUserService _userService;
        private IHttpContextAccessor _context;
        private readonly IWebHostEnvironment _environment;


        public UserController(IUserService iUserService, IMapper mapper, IHttpContextAccessor context, IWebHostEnvironment environment)
        {
            this._mapper = mapper;
            this._userService = iUserService;
            this._context = context;
            this._environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChooseTypePerson()
        {
            return View();
        }
        public async Task<IActionResult> Disable(int? id)
        {
            int userID = 0;
            if (!id.HasValue)
            {
                userID = int.Parse(User.Claims.ToList()[2].Value);
            }
            else if (id.HasValue)
            {
                userID = id.Value;
            }

            SingleResponse<User> response = await _userService.Disable(userID);
            if (!response.Success)
            {
                ViewBag.Errors = response.Message;
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AuthenticateRequest request)
        {
            SingleResponse<User> responseUser = await _userService.Authenticate(request);

            if (!responseUser.Success)
            {
                ViewBag.Errors = responseUser.Message;
                return View();
            }

            string nome = "";
            if (responseUser.Item is NaturalPerson)
            {
                nome = ((NaturalPerson)responseUser.Item).Nome;
            }
            else
            {
                nome = ((LegalPerson)responseUser.Item).NomeFantasia;
            }

            string role = "";
            if (responseUser.Item is NaturalPerson)
            {
                role = "NaturalPerson";
            }
            else
            {
                role = "LegalPerson";
            }


            List<Claim> userClaims = new List<Claim>()
                {
                    // Define o cookie.
                    new Claim(ClaimTypes.Name, nome),
                    new Claim(ClaimTypes.Email, responseUser.Item.Email),
                    new Claim(ClaimTypes.NameIdentifier, responseUser.Item.ID.ToString()),
                    new Claim(ClaimTypes.Role, role)
                };
            var minhaIdentity = new ClaimsIdentity(userClaims, "Usuario");
            var userPrincipal = new ClaimsPrincipal(new[] { minhaIdentity });
            // Cria o cookie.


            if (_context != null)
            {
                // Se entrou aqui, é porque chegamos nesse método através da criação da conta.
                await _context.HttpContext.SignInAsync(userPrincipal);
            }
            else
            {
                // Se entrou aqui, é porque foi informado os dados do login normalmente.
                await HttpContext.SignInAsync(userPrincipal);
            }
            
            return RedirectToAction($"SearchMap", "Map");


        }

        #region Legal Person
        [HttpGet]
        public IActionResult CreateLegal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateLegal(LegalPersonCreateViewModel viewModel)
        {
            LegalPerson empresa = _mapper.Map<LegalPerson>(viewModel);

            SingleResponse<IFormFile> singleResponse = UserPictureManager.ValidateFile(viewModel.FotoPerfil);
            if (!singleResponse.Success)
            {
                ViewBag.Error = singleResponse.Message;
                return View();
            }

            Response response = await _userService.CreateLegalPersonAsync(empresa);
            if (!response.Success)
            {
                ViewBag.Error = response.Message;
                return View();
            }
            AuthenticateRequest authenticate = new AuthenticateRequest()
            {
                Email = viewModel.Email,
                Senha = viewModel.Senha
            };

            string path = UserPictureManager.CreateFolder(empresa.ID, _environment.WebRootPath);
            await UserPictureManager.SendFilesToFolderAsync(viewModel.FotoPerfil, path);

            return await this.Login(authenticate);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateLegal(int? id)
        {
            int userID = 0;
            if (!id.HasValue)
            {
                userID = int.Parse(User.Claims.ToList()[2].Value);
            }
            else if (id.HasValue)
            {
                userID = id.Value;
            }

            SingleResponse<LegalPerson> response = await _userService.GetLegalPersonByIdAsync(userID);
            if (!response.Success)
            {
                return RedirectToAction("SearchMap","Map");
            }
            LegalPersonUpdateViewModel viewModel = _mapper.Map<LegalPersonUpdateViewModel>(response.Item);
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateLegal(LegalPersonUpdateViewModel viewModel)
        {
            LegalPerson empresa = _mapper.Map<LegalPerson>(viewModel);

            if (viewModel.FotoPerfil != null)
            {
                SingleResponse<IFormFile> singleResponse = UserPictureManager.ValidateFile(viewModel.FotoPerfil);
                if (!singleResponse.Success)
                {
                    ViewBag.Error = singleResponse.Message;
                    return View(viewModel);
                }
                else if (singleResponse.Success)
                {
                    string path = UserPictureManager.CreateFolder(empresa.ID, _environment.WebRootPath);
                    await UserPictureManager.SendFilesToFolderAsync(viewModel.FotoPerfil, path);
                }
            }

            Response response = await _userService.UpdateLegalPersonAsync(empresa);
            if (response.Success)
            {
                return RedirectToAction("ShowAll", "Vehicle");
            }
            ViewBag.Errors = response.Message;
            return View(viewModel);
        }
        #endregion

        #region Natural Person
        [HttpGet]
        public IActionResult CreateNatural()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNatural(NaturalPersonCreateViewModel viewModel)
        {
            NaturalPerson pessoa = _mapper.Map<NaturalPerson>(viewModel);

            SingleResponse<IFormFile> singleResponse = UserPictureManager.ValidateFile(viewModel.FotoPerfil);
            if (!singleResponse.Success)
            {
                ViewBag.Error = singleResponse.Message;
                return View();
            }

            Response response = await _userService.CreateNaturalPersonAsync(pessoa);
            if (!response.Success)
            {
                ViewBag.Error = response.Message;
                return View();
            }
            AuthenticateRequest authenticate = new AuthenticateRequest()
            {
                Email = viewModel.Email,
                Senha = viewModel.Senha
            };

            string path = UserPictureManager.CreateFolder(pessoa.ID, _environment.WebRootPath);
            await UserPictureManager.SendFilesToFolderAsync(viewModel.FotoPerfil, path);

            return await this.Login(authenticate);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> UpdateNatural(int? id)
        {
            int userID = 0;
            if (!id.HasValue)
            {
                userID = int.Parse(User.Claims.ToList()[2].Value);
            }
            else if (id.HasValue)
            {
                userID = id.Value;
            }

            SingleResponse<NaturalPerson> response = await _userService.GetNaturalPersonByIdAsync(userID);
            if (!response.Success)
            {
                return RedirectToAction("SearchMap", "Map");
            }
            NaturalPersonUpdateViewModel viewModel = _mapper.Map<NaturalPersonUpdateViewModel>(response.Item);
            
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> UpdateNatural(NaturalPersonUpdateViewModel viewModel)
        {
            NaturalPerson pessoa = _mapper.Map<NaturalPerson>(viewModel);

            if (viewModel.FotoPerfil != null)
            {
                SingleResponse<IFormFile> singleResponse = UserPictureManager.ValidateFile(viewModel.FotoPerfil);
                if (!singleResponse.Success)
                {
                    ViewBag.Error = singleResponse.Message;
                    return View(viewModel);
                }
                else if (singleResponse.Success)
                {
                    string path = UserPictureManager.CreateFolder(pessoa.ID, _environment.WebRootPath);
                    await UserPictureManager.SendFilesToFolderAsync(viewModel.FotoPerfil, path);
                }
            }
            
            Response response = await _userService.UpdateNaturalPersonAsync(pessoa);
            if (response.Success)
            {

                return RedirectToAction("SearchMap","Map");
            }
            ViewBag.Errors = response.Message;
            return View(viewModel);
        }
        #endregion

    }
}
