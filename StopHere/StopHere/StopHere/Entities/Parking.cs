using Entities.Enums;
using System;

namespace Entities
{
    public class Parking
    {
        public int ID { get; set; }
        public string CEP { get; set; }
        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public TimeSpan Abre { get; set; }
        public TimeSpan Fecha { get; set; }
        public DaysOfWeek DiasDisponiveis { get; set; }

        public double HoraDisponivel
        {
            get
            {
                return this.Fecha.TotalHours - this.Abre.TotalHours;
            }
        }

        public bool IsCoberta { get; set; }
        public bool IsVigiada { get; set; }
        public bool DeixarChave { get; set; }

        public double Valor { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }


        public bool Ativo { get; set; }

    }
}
