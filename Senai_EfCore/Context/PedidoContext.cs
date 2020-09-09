using Microsoft.EntityFrameworkCore;
using Senai_EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Context
{
    public class PedidoContext : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<PedidoItem> PedidosItens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(@"Data source=\SQLEXPRESS; Initial Catalog=Db_Senai_Pedidos_Dev; user ID = sa;Password=sa@132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
