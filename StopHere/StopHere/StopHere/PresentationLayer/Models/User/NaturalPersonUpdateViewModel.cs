using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PresentationLayer.Models.NaturalPerson
{
    public class NaturalPersonUpdateViewModel
    {
        public IFormFile FotoPerfil { get; set; }
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public int UF { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
    }
}
