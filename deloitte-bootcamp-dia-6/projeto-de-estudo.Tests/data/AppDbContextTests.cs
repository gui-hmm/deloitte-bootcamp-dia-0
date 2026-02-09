using Xunit;
using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using MinhaApi.Models;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace MinhaApi.Tests.Data
{
    public class AppDbContextTests
    {
        private AppDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new AppDbContext(options);
        }

        // ==========================
        // DBSET TEST
        // ==========================

        [Fact]
        public async Task Deve_Salvar_LoteMinerio_No_Banco()
        {
            var db = CreateDbContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "LT001",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "Patio A",
                TeorFe = 60,
                Umidade = 5,
                Toneladas = 100,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            };

            db.LotesMinerio.Add(lote);
            await db.SaveChangesAsync();

            Assert.Single(db.LotesMinerio);
        }

        // ==========================
        // QUERY TEST
        // ==========================

        [Fact]
        public async Task Deve_Buscar_Lote_Por_Codigo()
        {
            var db = CreateDbContext();

            db.LotesMinerio.Add(new LoteMinerio
            {
                CodigoLote = "LT999",
                MinaOrigem = "Carajás",
                LocalizacaoAtual = "A",
                TeorFe = 65,
                Umidade = 7,
                Toneladas = 200,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.EmEstoque
            });

            await db.SaveChangesAsync();

            var lote = await db.LotesMinerio
                .FirstOrDefaultAsync(x => x.CodigoLote == "LT999");

            Assert.NotNull(lote);
        }

        // ==========================
        // ENUM CONVERSION TEST
        // ==========================

        [Fact]
        public async Task Deve_Salvar_Status_Enum_Corretamente()
        {
            var db = CreateDbContext();

            var lote = new LoteMinerio
            {
                CodigoLote = "ENUM01",
                MinaOrigem = "Teste",
                LocalizacaoAtual = "B",
                TeorFe = 55,
                Umidade = 6,
                Toneladas = 150,
                DataProducao = DateTime.UtcNow,
                Status = StatusLote.Embarcado
            };

            db.Add(lote);
            await db.SaveChangesAsync();

            var saved = db.LotesMinerio.First();

            Assert.Equal(StatusLote.Embarcado, saved.Status);
        }

        // ==========================
        // MODEL CONFIG TEST
        // ==========================

        [Fact]
        public void Deve_Conter_Indice_Unico_CodigoLote()
        {
            var db = CreateDbContext();

            var entityType = db.Model.FindEntityType(typeof(LoteMinerio));

            var hasUniqueIndex = entityType
                .GetIndexes()
                .Any(i => i.Properties.Any(p => p.Name == "CodigoLote") && i.IsUnique);

            Assert.True(hasUniqueIndex);
        }
    }
}
