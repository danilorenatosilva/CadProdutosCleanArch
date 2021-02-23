using DominioCleanArch;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Interfaces
{
	public interface IProdutoServico
	{
		IEnumerable<Produto> GetProdutos();
		Produto GetProdutoById(int id);
		IEnumerable<Produto> GetProdutosByIdCategoria(int idCategoria);
		Produto Create(Produto produto);
		void Update(int id, Produto produto);
		void Delete(int id);
	}
}
