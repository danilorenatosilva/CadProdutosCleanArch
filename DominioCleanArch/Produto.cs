﻿using System.ComponentModel.DataAnnotations.Schema;

namespace DominioCleanArch
{
	public class Produto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string UrlImagem { get; set; }
		public decimal PrecoUnitario { get; set; }
		public int IdCategoria { get; set; }
		[NotMapped]
		public Categoria Categoria { get; set; }
	}
}
