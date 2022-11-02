using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers
{
    public abstract class ImageHelper
    {
        public static string UploadedFile(IFormFile Foto, string hostEnvironment)
        {
            string nomeUnicoArquivo = null;
            if (Foto != null)
            {
                string pastaFotos = Path.Combine(hostEnvironment, "Imagens");
                nomeUnicoArquivo = Guid.NewGuid().ToString() + "_" + Foto.FileName;
                string caminhoArquivo = Path.Combine(pastaFotos, nomeUnicoArquivo);
                using (var fileStream = new FileStream(caminhoArquivo, FileMode.Create))
                {
                    Foto.CopyTo(fileStream);
                }
            }

            return nomeUnicoArquivo;
        }
        public static void DestroyFile(string name, string hostEnvironment)
        {
            if (name != null)
            {
                string pastaFotos = Path.Combine(hostEnvironment, "Imagens");

                string caminhoArquivo = Path.Combine(pastaFotos, name);
                File.Delete(caminhoArquivo);
            }
        }
    }
}
