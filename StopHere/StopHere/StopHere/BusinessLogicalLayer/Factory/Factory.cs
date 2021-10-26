using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Factory
{
    static class Factory
    {
        public static DataResponse<Parking> Parkingfactory(Parking obj, int qtd)
        {
            List<Parking> parking = new List<Parking>();
            for (int i = 0; i < qtd; i++)
            {
                Parking temp = new Parking();
                temp.Abre = obj.Abre;
                temp.Ativo = obj.Ativo;
                temp.Bairro= obj.Bairro;
                temp.CEP = obj.Cidade;
                temp.Complemento= obj.Complemento;
                temp.DeixarChave = obj.DeixarChave;
                temp.IsCoberta = obj.IsCoberta;
                temp.IsVigiada = obj.IsVigiada;
                temp.Latitude = obj.Latitude;
                temp.Longitude= obj.Longitude;
                temp.Numero= obj.Numero;
                temp.Rua= obj.Rua;
                temp.UF= obj.UF;
                temp.User= obj.User;
                temp.UserID= obj.UserID;
                temp.Valor= obj.Valor;
                parking.Add(temp);
            }
            return new DataResponse<Parking>()
            {
                Message = "Vagas criadas com sucesso",
                Success = true,
                Data = parking,
            };
        }




    }
}
