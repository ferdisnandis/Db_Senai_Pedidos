using Microsoft.AspNetCore.Http;
using Senai_EfCore.Domains;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera o nome do arquivo / Pego a extensão / Cocateno o nome do arquivo com sua extensão / 
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //GetCurrentDirectory = Pega o caminho do diretório atual, aplicação esta
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\Upload\Imagens", nomeArquivo);
            //Crio um objeto do tipo FileStream passando o caminho do arquivo
            //Passa para criar este arquivo
            using var streamImage = new FileStream(caminhoArquivo, FileMode.Create);

            //Executa o comando da criação do arquivo no local informado
            file.CopyTo(streamImage);

            return "http://localhost:51195/Upload/Imagens/" + nomeArquivo;
        }
    }
}
