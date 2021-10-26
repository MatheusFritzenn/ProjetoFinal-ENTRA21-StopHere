using Entities.Enums;
using System;
namespace Entities
{
    public class Location
    {
        public int ID { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public DaysOfWeek DiasDisponiveis { get; set; }
        public int VehicleID { get; set; }
        public Vehicle Vehicle { get; set; }
        public int ParkingID { get; set; }
        public Parking Parking { get; set; }
        public double ValorHora { get; set; }
        public double ValorTotal { get; set; }

    }
}
