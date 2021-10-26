using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.Vehicle
{
    public class VehicleCreateViewModel
    {
        public VehicleCreateViewModel()
        {
            this.ListaFotosVeiculos = new List<IFormFile>();
        }
        public string Placa { get; set; }
        public VehicleBrand Marca { get; set; }
        public string Modelo { get; set; }
        [Display(Name = "Cor")]
        public VehicleColor Cor { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Tamanho do Veículo")]
        public VehicleSize TamanhoVeiculo { get; set; }
        [Display(Name = "Tipo do Veículo")]
        public VehicleType TipoVeiculo { get; set; }
        public List<IFormFile> ListaFotosVeiculos { get; set; }
        public IFormFile FotoVeiculo1 { get; set; }
        public IFormFile FotoVeiculo2 { get; set; }
        public IFormFile FotoVeiculo3 { get; set; }
        public IFormFile FotoVeiculo4 { get; set; }
        public IFormFile FotoVeiculo5 { get; set; }
        public IFormFile FotoVeiculo6 { get; set; }



    }
}
