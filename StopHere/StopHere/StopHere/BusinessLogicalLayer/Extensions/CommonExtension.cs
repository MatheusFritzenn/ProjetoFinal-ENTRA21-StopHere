using BusinessLogicalLayer.Responses;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Extensions
{
    static class CommonExtension
    {
        public static Response ToResponse(this ValidationResult result)
        {

            if (result.IsValid)
            {
                return new Response()
                {
                    Success = true,
                    Message = "Validação bem sucedida."
                };
            }

            StringBuilder sb = new StringBuilder();
            foreach (ValidationFailure item in result.Errors)
            {
                sb.AppendLine(item.ErrorMessage);
            }

            return new Response()
            {
                Success = false,
                Message = sb.ToString()
            };

        }

        public static string ClearMask(this string item)
        {
            return item.Replace(".", "")
                       .Replace(",", "")
                       .Replace("/", "")
                       .Replace("-", "")
                       .Replace("(", "")
                       .Replace(")", "");
        }

        public static string HashPassword(this string authenticate)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] _passwordBytes = Encoding.ASCII.GetBytes(authenticate);
            byte[] md5Data = md5.ComputeHash(_passwordBytes);
            string senha = Convert.ToBase64String(md5Data);
            return authenticate = senha;
        }

    }
}
