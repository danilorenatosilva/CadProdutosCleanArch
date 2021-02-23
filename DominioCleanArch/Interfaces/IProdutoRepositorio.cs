using System.Collections.Generic;

namespace DominioCleanArch.Interfaces
{
	public interface IProdutoRepositorio
	{
		IEnumerable<Produto> GetProdutos();
		Produto GetProdutoById(int id);
		Produto Create(Produto produto);
		void Update(int id, Produto produto);
		void Delete(int id);
	}
}
