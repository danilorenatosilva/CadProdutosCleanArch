using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using AutoMapper;
using DominioCleanArch;
using DominioCleanArch.Interfaces;
using System.Collections.Generic;

namespace AplicacaoCleanArch.Servicos
{
	public class CategoriaServico : ICategoriaServico
	{
		private readonly ICategoriaRepositorio _repositorio;
		private readonly IMapper _mapper;

		public CategoriaServico(ICategoriaRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
		}

		public CategoriaViewModel Create(CategoriaViewModel categoriaViewModel)
		{
			Categoria categoria = _mapper.Map<Categoria>(categoriaViewModel);
			categoria = _repositorio.Create(categoria);
			return _mapper.Map<CategoriaViewModel>(categoria);
		}

		public void Delete(int id)
		{
			_repositorio.Delete(id);
		}

		public CategoriaViewModel GetCategoriaById(int id)
		{
			return _mapper.Map<CategoriaViewModel>(_repositorio.GetCategoriaById(id));
		}

		public IEnumerable<CategoriaViewModel> GetCategorias()
		{
			return _mapper.Map<IEnumerable<CategoriaViewModel>>( _repositorio.GetCategorias());
		}

		public void Update(CategoriaViewModel categoriaViewModel)
		{
			Categoria categoria = _mapper.Map<Categoria>(categoriaViewModel);
			_repositorio.Update(categoria);
		}
	}
}
