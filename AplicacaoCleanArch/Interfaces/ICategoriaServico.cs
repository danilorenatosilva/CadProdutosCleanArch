using DominioCleanArch;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Interfaces
{
	public interface ICategoriaServico
	{
		IEnumerable<Categoria> GetCategorias();
		Categoria GetCategoriaById(int id);
		Categoria Create(Categoria categoria);
		void Update(Categoria categoria);
		void Delete(int id);
	}
}
