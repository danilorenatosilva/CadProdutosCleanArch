using AplicacaoCleanArch.Interfaces;
using DominioCleanArch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
		public ActionResult<IEnumerable<Categoria>> Get()
		{
			return Ok(_servico.GetCategorias());
		}

		[HttpGet("{id}")]
		public ActionResult<Categoria> Get(int id)
		{
			var categoria = _servico.GetCategoriaById(id);
			if (categoria == null)
			{
				return BadRequest("Categoria não encontrada");
			}
			return Ok(categoria);
		}

		[HttpPost]
		public ActionResult<Categoria> Create(Categoria categoria)
		{
			_servico.Create(categoria);
			return Ok(categoria);
		}

		[HttpPut("{id}")]
		public ActionResult Update(int id, Categoria categoria)
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
