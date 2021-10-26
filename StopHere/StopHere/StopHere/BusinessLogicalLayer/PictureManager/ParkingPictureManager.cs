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
    public class ParkingPictureManager
    {
        public static string CreateFolder(int id, string enviromentPath)
        {
            string path = enviromentPath + "\\Fotos\\Vagas\\" + id;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public async static Task SendFilesToFolderAsync(List<IFormFile> files, string path)
        {
            int count = 0;
            foreach (IFormFile photo in files)
            {
                
                if (photo.Name.Contains("1"))
                {
                    count = 1;
                }
                if (photo.Name.Contains("2"))
                {
                    count = 2;
                }
                if (photo.Name.Contains("3"))
                {
                    count = 3;
                }
                using (FileStream fs = new FileStream(path + "\\" + count + ".jpg", FileMode.Create))
                {
                    await photo.CopyToAsync(fs);
                }
            }
        }

        public static DataResponse<IFormFile> ValidateFiles(List<IFormFile> files)
        {
            DataResponse<IFormFile> response = new DataResponse<IFormFile>();
            CultureInfo cibr = new CultureInfo("pt-br");

            foreach (IFormFile photo in files)
            {
                if (photo == null || photo.Length == 0)
                {
                    response.Message = "Fotos são obrigatórias.";
                    response.Success = false;

                    return response;
                }
                // Verifica tamanho do arquivo 1 lenght = 1 byte.
                // Definido tamanho mínimo 2kb e maximo 1mb (imagem 4k => +- 650kb).
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
                         !photo.FileName.EndsWith(".gif", true, cibr) &&
                         !photo.FileName.EndsWith(".pdf", true, cibr) &&
                         !photo.FileName.EndsWith(".jpeg", true, cibr))
                {
                    response.Message = "Foto em formato inválido (os formatos válidos são: .jpg .jpeg .png .gif .pdf)";
                    response.Success = false;
                    return response;
                }
            }
            response.Success = true;
            response.Message = "Validação da lista de fotos realizada com sucesso.";
            response.Data = files;
            return response;
        }
    }
}
