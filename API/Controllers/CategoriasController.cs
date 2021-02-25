using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using Microsoft.AspNetCore.Hosting;
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
		private readonly IWebHostEnvironment _webHostEnvironment;

		public CategoriasController(ICategoriaServico servico, IWebHostEnvironment webHostEnvironment)
		{
			_servico = servico;
			_webHostEnvironment = webHostEnvironment;
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
				return BadRequest("CategoriaViewModel não encontrada");
			}
			return Ok(categoria);
		}

		[HttpPost]
		public ActionResult<CategoriaViewModel> Create([FromForm]CategoriaViewModel categoria)
		{
			try
			{
				if (categoria.ArquivoImagem.Length > 0)
				{
					categoria.UrlImagem = "/imagens/"+categoria.ArquivoImagem.FileName;

					using (var stream = new FileStream(Path.Combine(categoria.CaminhoFisicoImagens, categoria.ArquivoImagem.FileName), FileMode.Create))
					{
						categoria.ArquivoImagem.CopyTo(stream);
					}
				}
				var created = _servico.Create(categoria);
				categoria.Id = created.Id;
				return Ok(categoria);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut("{id}")]
		public ActionResult Update(int id, CategoriaViewModel categoria)
		{
			if (id != categoria.Id)
			{
				return BadRequest();
			}

			_servico.Update(categoria);

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
