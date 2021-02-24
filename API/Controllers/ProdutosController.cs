using AplicacaoCleanArch.Interfaces;
using DominioCleanArch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProdutosController : ControllerBase
	{
		private readonly IProdutoServico _servico;

		public ProdutosController(IProdutoServico servico)
		{
			_servico = servico;
		}

		[HttpGet]
		public ActionResult<IEnumerable<Produto>> Get()
		{
			return Ok(_servico.GetProdutos());
		}

		[HttpGet("{id}")]
		public ActionResult<Produto> Get(int id)
		{
			var produto = _servico.GetProdutoById(id);
			if (produto == null)
			{
				return BadRequest("Produto não encontrado");
			}
			return Ok(produto);
		}

		[HttpGet("categoria/{id}")]
		public ActionResult<IEnumerable<Produto>> GetByIdCategoria(int id)
		{
			var produtos = _servico.GetProdutosByIdCategoria(id).ToList();
			if (produtos == null || produtos.Count <= 0)
			{
				return BadRequest("Produtos não encontrados para esta categoria");
			}
			return Ok(produtos);
		}

		[HttpPost]
		public ActionResult<Produto> Create(Produto produto)
		{
			_servico.Create(produto);
			return Ok(produto);
		}

		[HttpPut("{id}")]
		public ActionResult Update(int id, Produto produto)
		{
			if (id != produto.Id)
			{
				return BadRequest();
			}

			_servico.Update(produto);

			return NoContent();
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_servico.Delete(id);
			return NoContent();
		}
	}
}
