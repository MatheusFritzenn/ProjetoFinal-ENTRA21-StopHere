using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.Location
{
    public class LocationShowAllViewModel
    {
        public int ID { get; set; }

        [Display(Name = "Data de entrada")]
        public DateTime DataEntrada { get; set; }
        [Display(Name = "Data de retirada")]
        public DateTime DataSaida { get; set; }

        [Display(Name = "valor final")]
        public string ValorTotal { get; set; }
    }
}
