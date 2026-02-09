using MinhaApi.Dtos;
using Xunit;

namespace MinhaApi.Tests.Dtos
{
    public class CreateLoteMinerioDtoTests
    {
        [Fact]
        public void Deve_Criar_CreateDto_Com_Valores_Validos()
        {
            var dto = new CreateLoteMinerioDto
            {
                CodigoLote = "LT001",
                MinaOrigem = "Carajás",
                TeorFe = 65.5m,
                Umidade = 8.2m,
                Toneladas = 1000,
                Status = 0,
                LocalizacaoAtual = "Pátio A"
            };

            Assert.Equal("LT001", dto.CodigoLote);
            Assert.True(dto.TeorFe > 0);
            Assert.Equal(0, dto.Status);
        }

        [Fact]
        public void Deve_Permitir_DataProducao_Nula()
        {
            var dto = new CreateLoteMinerioDto
            {
                DataProducao = null
            };

            Assert.Null(dto.DataProducao);
        }
    }
}
