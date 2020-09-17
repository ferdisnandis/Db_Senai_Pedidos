using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai_EfCore.Domains;
using Senai_EfCore.Interfaces;
using Senai_EfCore.Repositories;
using Senai_EfCore.Utils;

namespace Senai_EfCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController()
        {
            _produtoRepository = new ProdutoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Listar os produtos no repositório
                var produtos = _produtoRepository.Listar();

                //verifica se existe produtos, caso não tenha retorna
                //NoContent - Sem Conteúdo
                    if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorna OK e produtos
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch(Exception ex)
            {
                //Caso ocorra algum erro retorna BadRequest e a mensagem de erro
                // TODO : Gravar mensagem de erro log e retornar BadRequest
                return BadRequest(ex.Message);
             };
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //Buscar o produto no repositório
                Produto produto = _produtoRepository.BuscarPorId(id);

                //Verifica se o produto existe
                //Caso produto não exista retorna NotFound - Não encontrado
                if (produto == null)
                    return NotFound();

                //Caso o produto exista retorna
                //Ok e os dados do produto
                return Ok(produto);
            }
            catch(Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem de erro
                return BadRequest(ex.Message);
            }
        }

        //From form - Recebe os dados do produto via From-Data
        [HttpPost]
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                //Verifico se foi enviado um arquivo com a imagem
                if(produto.Imagem != null)
                {
                    var urlImagem = Upload.Local(produto.Imagem);
                    produto.UrlImagem = urlImagem;
                }
                //Adiciona produto
                _produtoRepository.Adicionar(produto);

                //Retorna ok com os dados do produto
                return Ok(produto);
            } 
            catch(Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //deu erro
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                var produtoTemp = _produtoRepository.BuscarPorId(id);
                if (produtoTemp == null)
                    return NotFound();

                _produtoRepository.Editar(produto);
                 
                return Ok(produto);
            }
            catch(Exception ex)
            {
                //Caso ocorra um erro retorna BadRequest com a mensagem
                //de erro
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoRepository.BuscarPorId(id);

                if (produto == null)
                    return NotFound();

                _produtoRepository.Remover(id);

                return Ok(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
