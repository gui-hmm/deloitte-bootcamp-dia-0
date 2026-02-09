using MinhaApi.Models;
using Xunit;

// Seguinto padrão AAA - Arrange, Act e Assert

namespace MinhaApi.Tests.Models
{
    public class LoteMinerioTests
    {
        [Fact]
        public void Deve_Criar_LoteMinerio_Com_Valores_Validos()
        {
            var lote = new LoteMinerio
            {
                Id = 1,
                CodigoLote = "LT001",
                MinaOrigem = "Carajas",
                LocalizacaoAtual = "Patio A",
                TeorFe = 65.5m,
                Umidade = 8.2m,
                SiO2 = 3.1m,
                P = 0.05m,
                Toneladas = 1000m,
                DataProducao = new DateTime(2025, 01, 01),
                Status = StatusLote.EmEstoque
            };

            Assert.NotNull(lote);
            Assert.Equal("LT001", lote.CodigoLote);
            Assert.Equal(StatusLote.EmEstoque, lote.Status);
            Assert.True(lote.TeorFe > 0);
        }

        [Fact]
        public void Deve_Atribuir_Status_Enum_Corretamente()
        {
            var lote = new LoteMinerio();

            lote.Status = StatusLote.Embarcado;

            Assert.Equal(StatusLote.Embarcado, lote.Status);
        }

        [Fact]
        public void Deve_Permitir_Campos_Nulos_Para_SiO2_E_P()
        {
            var lote = new LoteMinerio
            {
                CodigoLote = "LT002",
                MinaOrigem = "Minas Gerais",
                LocalizacaoAtual = "Patio B",
                TeorFe = 60m,
                Umidade = 7m,
                Toneladas = 500m,
                DataProducao = DateTime.Now,
                Status = StatusLote.EmTransporte,
                SiO2 = null,
                P = null
            };

            Assert.Null(lote.SiO2);
            Assert.Null(lote.P);
        }
    }
}
