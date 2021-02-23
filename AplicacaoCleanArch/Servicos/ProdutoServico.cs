using AplicacaoCleanArch.Interfaces;
using DominioCleanArch;
using DominioCleanArch.Interfaces;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Servicos
{
	public class ProdutoServico : IProdutoServico
	{
		private readonly IProdutoRepositorio _repositorio;

		public ProdutoServico(IProdutoRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public Produto Create(Produto produto)
		{
			return _repositorio.Create(produto);
		}

		public void Delete(int id)
		{
			_repositorio.Delete(id);
		}

		public Produto GetProdutoById(int id)
		{
			return _repositorio.GetProdutoById(id);
		}

		public IEnumerable<Produto> GetProdutos()
		{
			return _repositorio.GetProdutos();
		}

		public IEnumerable<Produto> GetProdutosByIdCategoria(int idCategoria)
		{
			return _repositorio.GetProdutosByIdCategoria(idCategoria);
		}

		public void Update(Produto produto)
		{
			_repositorio.Update(produto);
		}
	}
}
