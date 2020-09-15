using Senai_EfCore.Context;
using Senai_EfCore.Domains;
using Senai_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Repositories
{
    public class PedidoItensRepository : IPedidoItemRepository
    {
        private readonly PedidoContext _ctx;

        public PedidoItensRepository()
        {
            _ctx = new PedidoContext();
        }

        public void Adicionar(PedidoItem item)
        {
            try
            {
                _ctx.PedidoItens.Add(item);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public PedidoItem BuscarPorID(Guid id)
        {
            try
            {
                PedidoItem item = _ctx.PedidoItens.Find(id);

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PedidoItem> BuscarPorNome(string nome)
        {
            try
            {
                List<PedidoItem> item = _ctx.PedidoItens.Where(c => c.Produto.Nome.Contains(nome)).ToList();

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(PedidoItem item)
        {
            try
            {
                PedidoItem itemTemp = BuscarPorID(item.Id);

                if (item == null)
                    throw new Exception("Produto não encontrado.");

                itemTemp.Quantidade = item.Quantidade;

                _ctx.PedidoItens.Update(itemTemp);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PedidoItem> Listar()
        {
            try
            {
                List<PedidoItem> itens = _ctx.PedidoItens.ToList();
                return itens;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remover(Guid id)
        {
            try
            {
                PedidoItem item = BuscarPorID(id);

                if (item == null)
                    throw new Exception("Produto não encontrado");
                _ctx.PedidoItens.Remove(item);

                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
