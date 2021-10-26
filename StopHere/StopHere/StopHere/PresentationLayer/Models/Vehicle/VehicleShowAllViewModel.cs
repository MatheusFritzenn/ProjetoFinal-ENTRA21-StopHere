using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.Vehicle
{
    public class VehicleShowAllViewModel
    {
        public int ID { get; set; }
        public string Modelo { get; set; }

        [Display(Name = "Marca")]
        public VehicleBrand Marca { get; set; }

        [Display(Name = "Cor")]
        public VehicleColor Cor { get; set; }

        public string Placa { get; set; }

        [Display(Name = "Tamanho do Veículo")]
        public VehicleSize TamanhoVeiculo { get; set; }

        [Display(Name = "Tipo do Veículo")]
        public VehicleType TipoVeiculo { get; set; }
    }
}
