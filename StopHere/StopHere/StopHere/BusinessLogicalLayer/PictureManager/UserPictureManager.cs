using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.PictureManager
{
    public class UserPictureManager
    {
        public static string CreateFolder(int id, string enviromentPath)
        {
            string path = enviromentPath + "\\Fotos\\Pessoas\\" + id;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return path;
        }

        public async static Task SendFilesToFolderAsync(IFormFile photo, string path)
        {
            using (FileStream fs = new FileStream(path + "\\" + 1 + ".jpg", FileMode.Create))
            {
                await photo.CopyToAsync(fs);
            }
        }

        public static SingleResponse<IFormFile> ValidateFile(IFormFile photo)
        {
            SingleResponse<IFormFile> response = new SingleResponse<IFormFile>();
            CultureInfo cibr = new CultureInfo("pt-br");
            

            if (photo == null || photo.Length == 0)
            {
                response.Message = "Foto é obrigatória.";
                response.Success = false;

                return response;
            }
            // Verifica tamanho do arquivo 1 lenght = 1 byte.
            // Definido tamanho mínimo 2kb e máximo 1mb (imagem 4k => +- 650kb).
            if (photo.Length < 2000)
            {
                response.Message = "Foto deve ter tamanho superior a 10kb.";
                response.Success = false;
                return response;
            }
            else if (photo.Length > 1000000)
            {
                response.Message = "Foto deve ter tamanho inferior a 500kb.";
                response.Success = false;
                return response;
            }
            else if (!photo.FileName.EndsWith(".jpg", true, cibr) &&
                     !photo.FileName.EndsWith(".png", true, cibr) &&
                     !photo.FileName.EndsWith(".jpeg", true, cibr))
            {
                response.Message = "Foto em formato inválido (os formatos válidos são: .jpg .jpeg .png )";
                response.Success = false;
                return response;
            }
            response.Success = true;
            response.Message = "Validação da foto realizada com sucesso.";
            response.Item = photo;
            return response;
        }
    }
}
