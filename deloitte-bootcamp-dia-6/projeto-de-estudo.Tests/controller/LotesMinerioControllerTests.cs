using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MinhaApi.Controllers;
using MinhaApi.Data;
using MinhaApi.Models;
using MinhaApi.Dtos;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MinhaApi.Tests.Controllers
{
    public class LotesMinerioControllerTests
    {
        // Cria DB em memória isolado para cada teste
        private AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        private CreateLoteMinerioDto CreateValidDto()
        {
            return new CreateLoteMinerioDto
            {
                CodigoLote = "LT001",
                MinaOrigem = "Carajás",
                LocalizacaoAtual = "Pátio A",
                TeorFe = 65,
                Umidade = 8,
                SiO2 = 4,
                P = 0.02m,
                Toneladas = 1000,
                DataProducao = DateTime.UtcNow,
                Status = 0
            };
        }

        // ==========================
        // CREATE
        // ==========================

        [Fact]
        public async Task Create_Deve_Retornar_Created_Quando_Dados_Validos()
        {
            var db = CreateDbContext();
            var controller = new LotesMinerioController(db);

            var dto = CreateValidDto();

            var result = await controller.Create(dto);

            Assert.IsType<CreatedAtActionResult>(result);
            Assert.Single(db.LotesMinerio);
        }

        [Fact]
        public async Task Create_Deve_Retornar_BadRequest_Quando_CodigoLote_Vazio()
        {
            var db = CreateDbContext();
            var controller = new LotesMinerioController(db);

            var dto = CreateValidDto();
            dto.CodigoLote = "";

            var result = await controller.Create(dto);

            Assert.IsType<BadRequestObjectResult>(result);
        }

        // ==========================
        // GET BY ID
        // ==========================

        [Fact]
        public async Task GetById_Deve_Retornar_Ok_Quando_Existe()
        {
            var db = CreateDbContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "LT001",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "A",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            };

            db.Add(lote);
            await db.SaveChangesAsync();

            var controller = new LotesMinerioController(db);

            var result = await controller.GetById(lote.Id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_Deve_Retornar_NotFound_Quando_Nao_Existe()
        {
            var db = CreateDbContext();
            var controller = new LotesMinerioController(db);

            var result = await controller.GetById(999);

            Assert.IsType<NotFoundResult>(result);
        }

        // ==========================
        // GET ALL
        // ==========================

        [Fact]
        public async Task GetAll_Deve_Retornar_Lista()
        {
            var db = CreateDbContext();

            db.LotesMinerio.Add(new LoteMinerio
            {
                CodigoLote = "LT001",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "A",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            });

            await db.SaveChangesAsync();

            var controller = new LotesMinerioController(db);

            var result = await controller.GetAll();

            var okResult = Assert.IsType<OkObjectResult>(result);
            var lista = Assert.IsAssignableFrom<System.Collections.IEnumerable>(okResult.Value);

            Assert.NotNull(lista);
        }

        // ==========================
        // UPDATE
        // ==========================

        [Fact]
        public async Task Update_Deve_Atualizar_Lote()
        {
            var db = CreateDbContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "LT001",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "A",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            };

            db.Add(lote);
            await db.SaveChangesAsync();

            var controller = new LotesMinerioController(db);

            var dto = CreateValidDto();
            dto.CodigoLote = "NOVO";

            var result = await controller.Update(lote.Id, dto);

            Assert.IsType<OkObjectResult>(result);
            Assert.Equal("NOVO", db.LotesMinerio.First().CodigoLote);
        }

        // ==========================
        // DELETE
        // ==========================

        [Fact]
        public async Task Delete_Deve_Remover_Lote()
        {
            var db = CreateDbContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "LT001",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "A",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            };

            db.Add(lote);
            await db.SaveChangesAsync();

            var controller = new LotesMinerioController(db);

            var result = await controller.Delete(lote.Id);

            Assert.IsType<NoContentResult>(result);
            Assert.Empty(db.LotesMinerio);
        }
    }
}
