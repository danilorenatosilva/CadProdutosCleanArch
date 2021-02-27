using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using DominioCleanArch;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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
		public ActionResult<IEnumerable<ProdutoViewModel>> Get()
		{
			return Ok(_servico.GetProdutos());
		}

		[HttpGet("{id}")]
		public ActionResult<ProdutoViewModel> Get(int id)
		{
			var produto = _servico.GetProdutoById(id);
			if (produto == null)
			{
				return NotFound();
			}
			return Ok(produto);
		}

		[HttpGet("produto/{id}")]
		public ActionResult<IEnumerable<ProdutoViewModel>> GetByIdCategoria(int id)
		{
			var produtos = _servico.GetProdutosByIdCategoria(id).ToList();
			if (produtos == null || produtos.Count <= 0)
			{
				return NotFound();
			}
			return Ok(produtos);
		}

		[HttpPost]
		public ActionResult<ProdutoViewModel> Create([FromForm]ProdutoViewModel produto)
		{
			try
			{
				if (produto.ArquivoImagem.Length > 0)
				{
					produto.UrlImagem = "/imagens/" + produto.ArquivoImagem.FileName;

					using (var stream = new FileStream(Path.Combine(produto.CaminhoFisicoImagens, produto.ArquivoImagem.FileName), FileMode.Create))
					{
						produto.ArquivoImagem.CopyTo(stream);
					}
				}
				_servico.Create(produto);
				return Ok(produto);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut]
		public ActionResult Update([FromForm]ProdutoViewModel produto)
		{
			try
			{
				if (produto.ArquivoImagem != null && produto.ArquivoImagem.Length > 0)
				{
					produto.UrlImagem = "/imagens/" + produto.ArquivoImagem.FileName;

					using (var stream = new FileStream(Path.Combine(produto.CaminhoFisicoImagens, produto.ArquivoImagem.FileName), FileMode.Create))
					{
						produto.ArquivoImagem.CopyTo(stream);
					}
				}
				_servico.Update(produto);
				return NoContent();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpDelete("{id}")]
		public ActionResult Delete(int id)
		{
			_servico.Delete(id);
			return NoContent();
		}
	}
}
