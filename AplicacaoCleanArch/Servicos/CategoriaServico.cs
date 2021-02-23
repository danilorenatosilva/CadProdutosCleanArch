using AplicacaoCleanArch.Interfaces;
using DominioCleanArch;
using DominioCleanArch.Interfaces;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Servicos
{
	public class CategoriaServico : ICategoriaServico
	{
		private readonly ICategoriaRepositorio _repositorio;

		public CategoriaServico(ICategoriaRepositorio repositorio)
		{
			_repositorio = repositorio;
		}

		public Categoria Create(Categoria categoria)
		{
			return _repositorio.Create(categoria);
		}

		public void Delete(int id)
		{
			_repositorio.Delete(id);
		}

		public Categoria GetCategoriaById(int id)
		{
			return _repositorio.GetCategoriaById(id);
		}

		public IEnumerable<Categoria> GetCategorias()
		{
			return _repositorio.GetCategorias();
		}

		public void Update(Categoria categoria)
		{
			_repositorio.Update(categoria);
		}
	}
}
