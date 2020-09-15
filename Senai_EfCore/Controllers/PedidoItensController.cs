using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Senai_EfCore.Domains;
using Senai_EfCore.Interfaces;
using Senai_EfCore.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Senai_EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoItensController : ControllerBase
    {
        private readonly IPedidoItemRepository _pedidoItensRepository;

        public PedidoItensController()
        {
            _pedidoItensRepository = new PedidoItensRepository();
  
        }

        [HttpGet]
        public List<PedidoItem> Get()
        {
            return _pedidoItensRepository.Listar();
        }

        [HttpGet("{id}")]
        public PedidoItem Get(Guid id)
        {
            return _pedidoItensRepository.BuscarPorID(id);
        }

        [HttpPost]
        public void Post(PedidoItem item)
        {
            _pedidoItensRepository.Adicionar(item);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, PedidoItem item)
        {
            _pedidoItensRepository.Editar(item);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _pedidoItensRepository.Remover(id);
        }
    }
}
