namespace DominioCleanArch
{
	public class Produto
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public string UrlImagem { get; set; }
		public int IdCategoria { get; set; }
		public Categoria Categoria { get; set; }
	}
}
