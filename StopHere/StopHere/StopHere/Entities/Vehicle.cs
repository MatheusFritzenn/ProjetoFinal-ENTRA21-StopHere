using Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Vehicle
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public VehicleBrand Marca { get; set; }
        public string Modelo { get; set; }
        public VehicleColor Cor { get; set; }
        public string Observacao { get; set; }
        public VehicleSize TamanhoVeiculo { get; set; }
        public VehicleType TipoVeiculo { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public ICollection<Location> Locations { get; set; }

        public bool Ativo { get; set; }

    }
}
