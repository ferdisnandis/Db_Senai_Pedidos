using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Domains
{
    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto : BaseDomain
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        [NotMapped] //Não mapeia a propriedade no banco de dados
        public IFormFile Imagem { get; set; }
        //Url da imagem do produto salva no servidor
        public string UrlImagem { get; set; }
        public List<PedidoItem> PedidoItens { get; set; }



    }
}
