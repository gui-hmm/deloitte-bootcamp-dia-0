using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;
using MinhaApi.Services;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MinhaApi.Tests.Controllers
{
    public class LotesExtraControllerTests
    {
        // Cria DB em memória isolado para cada teste
        private AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private LotesExtrasController CriarController()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var ctx = new AppDbContext(options);

            ctx.LotesMinerio.Add(new LoteMinerio
            {
                Id = 1,
                CodigoLote = "ABC",
                MinaOrigem = "Mina Teste",
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3,
                Toneladas = 10,
                LocalizacaoAtual = "A",
                Status = StatusLote.EmEstoque
            });

            ctx.SaveChanges();

            return new LotesExtrasController(ctx, new LoteService());
        }

       
       // Classificar
       [Fact]
        public async Task Classificar_DeveRetornarOk()
        {
            var controller = CriarController();

            var result = await controller.Classificar(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Classificar_DeveRetornarNotFound()
        {
            var controller = CriarController();

            var result = await controller.Classificar(999);

            Assert.IsType<NotFoundResult>(result);
        }


        // Preço
       [Fact]
        public async Task CalcularPreco_DeveRetornarOk()
        {
            var controller = CriarController();

            var result = await controller.CalcularPreco(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task CalcularPreco_DeveRetornarNotFound()
        {
            var controller = CriarController();

            var result = await controller.CalcularPreco(999);

            Assert.IsType<NotFoundResult>(result);
        }


        // Penalidade
       [Fact]
        public async Task Penalidade_DeveRetornarOk()
        {
            var controller = CriarController();

            var result = await controller.Penalidade(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Penalidade_DeveRetornarNotFound()
        {
            var controller = CriarController();

            var result = await controller.Penalidade(999);

            Assert.IsType<NotFoundResult>(result);
        }


        // AvancarStatus
       [Fact]
        public async Task AvancarStatus_DeveRetornarOk()
        {
            var controller = CriarController();

            var result = await controller.AvancarStatus(1);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task AvancarStatus_DeveRetornarNotFound()
        {
            var controller = CriarController();

            var result = await controller.AvancarStatus(999);

            Assert.IsType<NotFoundResult>(result);
        }


        // Mover
       [Fact]
        public async Task Mover_DeveRetornarOk()
        {
            var controller = CriarController();

            var dto = new MovimentoDto
            {
                Local = "NovoLocal",
                Status = StatusLote.EmTransporte
            };

            var result = await controller.Mover(1, dto);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Mover_DeveRetornarNotFound()
        {
            var controller = CriarController();

            var dto = new MovimentoDto
            {
                Local = "NovoLocal",
                Status = StatusLote.EmTransporte
            };

            var result = await controller.Mover(999, dto);

            Assert.IsType<NotFoundResult>(result);
        }



    }
}
