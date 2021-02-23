using DominioCleanArch;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Interfaces
{
	public interface ICategoriaServico
	{
		IEnumerable<Categoria> GetCategorias();
		Categoria GetCategoriaById(int id);
		Categoria Create(Categoria produto);
		void Update(int id, Categoria produto);
		void Delete(int id);
	}
}
