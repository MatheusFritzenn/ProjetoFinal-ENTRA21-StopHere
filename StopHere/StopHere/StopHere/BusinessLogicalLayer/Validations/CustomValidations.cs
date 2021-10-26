using BusinessLogicalLayer.Responses;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Validations
{
    public static class CustomValidations
    {
		public static SingleResponse<Location> ValidaLocacao(Location location)
		{
			if (location.DataEntrada == location.DataSaida || location.DataEntrada > location.DataSaida)
			{
				return FactoryResponse.FailureSingleResponse<Location>("Horário de saída igual ou superior ao de entrada.");
			}

			TimeSpan diferenca = location.DataSaida - location.DataEntrada;
			double valorFinal = diferenca.TotalHours * location.ValorHora;
			location.ValorTotal = valorFinal;
			return FactoryResponse.SuccessSingleResponse<Location>(location, "Locação validada com sucesso.");
		}

		public static bool IsValidCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
				return false;
            }
			int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
			int soma;
			int resto;
			string digito;
			string tempCnpj;
			cnpj = cnpj.Trim();
			cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
			if (cnpj.Length != 14)
				return false;
			tempCnpj = cnpj.Substring(0, 12);
			soma = 0;
			for (int i = 0; i < 12; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCnpj = tempCnpj + digito;
			soma = 0;
			for (int i = 0; i < 13; i++)
				soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
			resto = (soma % 11);
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cnpj.EndsWith(digito);
		}

		public static bool IsValidCPF(string cpf)
        {
			int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
			string tempCpf;
			string digito;
			int soma;
			int resto;
            if (string.IsNullOrWhiteSpace(cpf))
            {
				return false;
            }
			cpf = cpf.Trim();
			cpf = cpf.Replace(".", "").Replace("-", "");
			if (cpf.Length != 11)
				return false;
			tempCpf = cpf.Substring(0, 9);
			soma = 0;

			for (int i = 0; i < 9; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = resto.ToString();
			tempCpf = tempCpf + digito;
			soma = 0;
			for (int i = 0; i < 10; i++)
				soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
			resto = soma % 11;
			if (resto < 2)
				resto = 0;
			else
				resto = 11 - resto;
			digito = digito + resto.ToString();
			return cpf.EndsWith(digito);
		}

		public static bool IsValidPlaca(string value)
		{
			Regex regex = new Regex(@"^[a-zA-Z]{3}\-\d{4}$");

			if (regex.IsMatch(value))
			{
				return true;
			}

			return false;
		}

		public static bool IsValidCEP(string value)
		{
			Regex regex = new Regex(@"^\d{5}-\d{3}$");

			if (regex.IsMatch(value))
			{
				return true;
			}

			return false;
		}
	}
}
