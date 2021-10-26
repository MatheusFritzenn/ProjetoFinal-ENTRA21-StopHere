using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public bool IsUserNaturalPerson { get; set; }
        public bool IsUserLegalPerson { get; set; }
        public bool IsAdministrator{ get; set; }
    }
}
