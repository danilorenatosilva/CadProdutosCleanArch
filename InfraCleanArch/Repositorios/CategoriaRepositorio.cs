﻿using DominioCleanArch;
using DominioCleanArch.Interfaces;
using InfraCleanArch.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfraCleanArch.Repositorios
{
	public class CategoriaRepositorio : ICategoriaRepositorio
	{
		public readonly DaniloRenatoCommerceDbContext _contexto;

		public CategoriaRepositorio(DaniloRenatoCommerceDbContext contexto)
		{
			_contexto = contexto;
		}

		public Categoria GetCategoriaById(int id)
		{
			return _contexto.Categorias.FirstOrDefault(p => p.Id == id);
		}

		public IEnumerable<Categoria> GetCategorias()
		{
			return _contexto.Categorias.ToList();
		}

		public Categoria Create(Categoria categoria)
		{
			_contexto.Add(categoria);
			_contexto.SaveChanges();
			return categoria;
		}

		public void Update(int id, Categoria categoria)
		{
			var categoriaToUpdate = GetCategoriaById(id);
			if (categoriaToUpdate == null)
			{
				throw new Exception("Categoria não encontrado no banco de dados");
			}
			_contexto.Entry(categoria).State = EntityState.Modified;
			_contexto.SaveChanges();
		}

		public void Delete(int id)
		{
			var categoria = GetCategoriaById(id);
			if (categoria == null)
			{
				throw new Exception("Categoria não encontrado no banco de dados");
			}
			_contexto.Remove(categoria);
		}
	}
}
