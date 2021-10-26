using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public abstract class User
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public UF UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }

        public ICollection<Parking> Vagas { get; set; }
        public ICollection<Vehicle> Veiculos { get; set; }
        public bool Ativo { get; set; }

    }
}
