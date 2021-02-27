using API.Controllers;
using AplicacaoCleanArch.Interfaces;
using AplicacaoCleanArch.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Testes
{
	public class UnitTestProdutos
    {
        private List<ProdutoViewModel>  GetProdutosTeste()
        {
            return new List<ProdutoViewModel>()
            {
                new ProdutoViewModel
                {
                    Id = 1,
                    IdCategoria = 1,
                    Nome = "Produto 1",
                    Descricao = "Este é o Produto 1",
                    PrecoUnitario = 20.10m
                },
                new ProdutoViewModel
                {
                    Id = 2,
                    IdCategoria = 1,
                    Nome = "Produto 2",
                    Descricao = "Este é o Produto 2",
                    PrecoUnitario = 45.15m
                }
            };
        }

        [Fact]
        public async Task Get_PrecisaHaverNoMinimoUmProduto()
        {
            //Arrange
            var mockServico = new Mock<IProdutoServico>();
            mockServico.Setup(mockServico => mockServico.GetProdutos())
                        .Returns(GetProdutosTeste());
            var controller = new ProdutosController(mockServico.Object);

            //Act
            var result = controller.Get();
            var okResult = result.Result as OkObjectResult;

            // Assert  
            Assert.IsAssignableFrom<ActionResult<IEnumerable<ProdutoViewModel>>>(result);
            Assert.True((okResult.Value as IEnumerable<ProdutoViewModel>).Count() > 0);

        }
    }
}
