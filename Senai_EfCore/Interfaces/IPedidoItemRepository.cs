using Senai_EfCore.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Interfaces
{
    interface IPedidoItemRepository
    {
        List<PedidoItem> BuscarPorNome(string nome);
        PedidoItem BuscarPorID(Guid id);
        void Adicionar(PedidoItem item);
        void Editar(PedidoItem item);
        void Remover(Guid id);
        List<PedidoItem> Listar();
    }
}
