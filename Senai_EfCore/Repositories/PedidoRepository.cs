using Microsoft.EntityFrameworkCore;
using Senai_EfCore.Context;
using Senai_EfCore.Domains;
using Senai_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }

        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="pedidosItens">Lista de pedidos itens</param>
        /// <returns>Objeto Pedido</returns>
        public Pedido Adicionar(List<PedidoItem> pedidosItens)
        {
            try
            {
                //Crio um objeto do tipo pedido
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now,
                    PedidosItens = new List<PedidoItem>()
                };

                //Adiciono itens ao meu pedidoItens
                foreach (var item in pedidosItens)
                {
                    pedido.PedidosItens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do pedido criado acima
                        IdProduto = item.IdProduto, //Item da lista recebida como parametro
                        Quantidade = item.Quantidade //Item da lista recebida como parametro
                    });
                }

                //Adiciona ao contexto
                _ctx.Pedido.Add(pedido);
                //Salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (System.Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try 
            {
                return _ctx.Pedido.Include(c => c.PedidosItens).Include("Produto").FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
