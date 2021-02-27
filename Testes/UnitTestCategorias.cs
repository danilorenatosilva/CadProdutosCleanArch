using API.Controllers;
using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
    public class UnitTestCategorias
    {
        private List<CategoriaViewModel> GetCategoriasTeste()
        {
            return new List<CategoriaViewModel>()
            {
                new CategoriaViewModel
                {
                    Id = 1,
                    Nome = "Categoria 1",
                    Descricao = "Este é o Categoria 1",
                },
                new CategoriaViewModel
                {
                    Id = 2,
                    Nome = "Categoria 2",
                    Descricao = "Este é o Categoria 2",
                }
            };
        }

        [Fact]
        public async Task Get_PrecisaHaverNoMinimoUmaCategoria()
        {
            //Arrange
            var mockServico = new Mock<ICategoriaServico>();
            mockServico.Setup(mockServico => mockServico.GetCategorias())
                        .Returns(GetCategoriasTeste());
            var controller = new CategoriasController(mockServico.Object);

            //Act
            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            // Assert  
            Assert.IsAssignableFrom<ActionResult<IEnumerable<CategoriaViewModel>>>(result);
            Assert.True((okResult.Value as IEnumerable<CategoriaViewModel>).Count() > 0);
        }

        [Fact]
        public async Task Create_CategoriaFoiAdicionada()
        {
            //Arrange
            var mockServico = new Mock<ICategoriaServico>();
            mockServico.Setup(mockServico => mockServico.Create(GetCategoriasTeste()[0]))
                        .Returns(GetCategoriasTeste()[0]);
            var controller = new CategoriasController(mockServico.Object);

            //Act
            var result = controller.Create(GetCategoriasTeste()[0]);
            var okResult = result.Result as OkObjectResult;

            // Assert  
            Assert.IsAssignableFrom<ActionResult<CategoriaViewModel>>(result);
            Assert.NotNull((okResult.Value as CategoriaViewModel));
        }

        [Fact]
        public async Task Update_CategoriaFoiAlterada()
        {
            //Arrange
            var mockServico = new Mock<ICategoriaServico>();
            var categoria = GetCategoriasTeste()[0];
            mockServico.Setup(mockServico => mockServico.Create(categoria))
                        .Returns(categoria);
            var controller = new CategoriasController(mockServico.Object);

            //Act
            categoria.Nome = "Categoria 1 alterada";
            var result = controller.Update(categoria);
            var noContentResult = result as NoContentResult;

            // Assert  
            Assert.IsAssignableFrom<ActionResult>(result);
            Assert.Equal(noContentResult.StatusCode, StatusCodes.Status204NoContent);
        }

        [Fact]
        public async Task Delete_CategoriaFoiDeletado()
        {
            //Arrange
            var mockServico = new Mock<ICategoriaServico>();
            mockServico.Setup(mockServico => mockServico.Delete(2));
            var controller = new CategoriasController(mockServico.Object);

            //Act
            var result = controller.Delete(2);

            // Assert  
            Assert.IsType<NoContentResult>(result);
        }

    }
}
