using Senai_EfCore.Context;
using Senai_EfCore.Domains;
using Senai_EfCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_EfCore.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly PedidoContext _ctx;
        public ProdutoRepository()
        {
            _ctx = new PedidoContext();
        }

        #region Leitura
        /// <summary>
        /// Buscar produto por Id
        /// </summary>
        /// <param name="id">Id do produto</param>
        /// <returns>Lista de produtos</returns>
        public Produto BuscarPorId(Guid id)
        {
            try
            {
                //Produto produto = _ctx.Produtos.FirstOrDefault(c => c.Id == id);
                Produto produto = _ctx.Produtos.Find(id);
                return produto;
            }
            catch(Exception ex)
            {
                //Gravar no log do banco de dados
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Buscar produtos pelo nome
        /// </summary>
        /// <param name="nome">Nome do produto</param>
        /// <returns>Retorna um produto</returns>
        public List<Produto> BuscarPorNome(string nome)
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.Where(c => c.Nome.Contains(nome)).ToList();
                return produtos;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Lista todos os produtos cadastrados
        /// </summary>
        /// <returns>Retorna uma lista de produtos</returns>
        public List<Produto> Listar()
        {
            try
            {
                List<Produto> produtos = _ctx.Produtos.ToList();
                return produtos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Gravação

        /// <summary>
        /// Adiciona um novo produto
        /// </summary>
        /// <param name="produto">Objeto Produto</param>
        public void Adicionar(Produto produto)
        {
            try
            {
                //Adicionar produto ao 
                _ctx.Produtos.Add(produto);

                //Salvar alterações
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Editar(Produto produto)
        {
            try
            {
                //Buscar produto pelo Id
                Produto produtoTemp = BuscarPorId(produto.Id);

                //Verificar se o produto existe
                //Caso não exista gera uma exception
                //if (produtoTemp == null)
                //  throw new Exception("Produto não encontrado");

                //Caso exista altera sua propriedade
                produtoTemp.Nome = produto.Nome;
                produtoTemp.Preco = produto.Preco;

                //Altera Produto no contexto
                _ctx.Produtos.Update(produtoTemp);
                //Salva contexto
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                //TODO : Cadastrar Tabela LogErro  mensagem erro com Tag Geral
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Remove um produto
        /// </summary>
        /// <param name="id">Id do produto</param>
        public void Remover(Guid id)
        {
            try
            {
                //Buscar produto por Id
                Produto produtoTemp = BuscarPorId(id);

                //Verifica se o produto existe
                //Caso não exista gera uma exeception
                if (produtoTemp == null)
                    throw new Exception("Produto não encontrado");

                //Remove produto
                _ctx.Produtos.Remove(produtoTemp);
                //Salva alterações
                _ctx.SaveChanges();
            }
            catch(Exception ex)
            {
                //TODO : Incluir erro no log do banco de dados
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
