using Entities.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.Parking
{
    public class ParkingInsertViewModel
    {
        public ParkingInsertViewModel()
        {
            this.FotosVaga = new List<IFormFile>();
        }
        public string CEP { get; set; }
        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }

        [Display(Name = "Horário de abertura da vaga")]
        public TimeSpan Abre { get; set; }

        [Display(Name = "Horário de encerramento da vaga")]
        public TimeSpan Fecha { get; set; }

        public DaysOfWeek DiasDisponiveis { get; set; }

        [Display(Name = "Coberta")]
        public bool IsCoberta { get; set; }
        [Display(Name = "Vigiada")]
        public bool IsVigiada { get; set; }
        [Display(Name = "Deixa Chave")]
        public bool DeixarChave { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public List<IFormFile> FotosVaga { get; set; }
        public IFormFile FotoVaga1 { get; set; }
        public IFormFile FotoVaga2 { get; set; }
        public IFormFile FotoVaga3 { get; set; }
    }
}
