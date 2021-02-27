using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriasController : ControllerBase
	{
		private readonly ICategoriaServico _servico;

		public CategoriasController(ICategoriaServico servico)
		{
			_servico = servico;
		}

		[HttpGet]
		public ActionResult<IEnumerable<CategoriaViewModel>> Get()
		{
			var viewModel = _servico.GetCategorias();
			return Ok(viewModel);
		}

		[HttpGet("{id}")]
		public ActionResult<CategoriaViewModel> Get(int id)
		{
			var categoria = _servico.GetCategoriaById(id);
			if (categoria == null)
			{
				return NotFound();
			}
			return Ok(categoria);
		}

		[HttpPost]
		public ActionResult<CategoriaViewModel> Create([FromForm]CategoriaViewModel categoria)
		{
			try
			{
				if (categoria.ArquivoImagem != null && categoria.ArquivoImagem.Length > 0)
				{
					categoria.UrlImagem = "/imagens/"+categoria.ArquivoImagem.FileName;

					using (var stream = new FileStream(Path.Combine(categoria.CaminhoFisicoImagens, categoria.ArquivoImagem.FileName), FileMode.Create))
					{
						categoria.ArquivoImagem.CopyTo(stream);
					}
				}
				_servico.Create(categoria);
				return Ok(categoria);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut]
		public ActionResult Update([FromForm]CategoriaViewModel categoria)
		{
			try
			{
				if (categoria.ArquivoImagem != null && categoria.ArquivoImagem.Length > 0)
				{
					categoria.UrlImagem = "/imagens/" + categoria.ArquivoImagem.FileName;

					using (var stream = new FileStream(Path.Combine(categoria.CaminhoFisicoImagens, categoria.ArquivoImagem.FileName), FileMode.Create))
					{
						categoria.ArquivoImagem.CopyTo(stream);
					}
				}
				_servico.Update(categoria);
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
			try
			{
				_servico.Delete(id);
				return NoContent();
			}
			catch (Exception ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}
