using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.Parking
{
    public class ParkingQueryViewModel
    {
        public int ID { get; set; }
        public string Rua { get; set; }


        [Display(Name = "Horário de abertura")]
        public string Abre { get; set; }


        [Display(Name = "Horário de encerramento")]
        public string Fecha { get; set; }

        [Display(Name = "Valor por hora")]
        public string Valor { get; set; }
    }
}
