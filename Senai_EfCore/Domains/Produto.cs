using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Domains
{
    /// <summary>
    /// Define a classe produto
    /// </summary>
    public class Produto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public Produto()
        {
            Id = Guid.NewGuid();
        }
    }
}
