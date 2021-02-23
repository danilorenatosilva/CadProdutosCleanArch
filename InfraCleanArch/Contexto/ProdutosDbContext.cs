﻿using DominioCleanArch;
using Microsoft.EntityFrameworkCore;

namespace InfraCleanArch.Contexto
{
	public class ProdutosDbContext : DbContext
	{
		public ProdutosDbContext(DbContextOptions options) : base(options) { }

		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
	}
}
