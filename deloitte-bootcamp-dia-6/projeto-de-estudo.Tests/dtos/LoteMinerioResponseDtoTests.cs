using MinhaApi.Dtos;
using MinhaApi.Models;
using Xunit;

namespace MinhaApi.Tests.Dtos
{
    public class LoteMinerioResponseDtoTests
    {
        [Fact]
        public void Deve_Preencher_Todos_Campos_Corretamente()
        {
            var data = DateTime.UtcNow;

            var dto = new LoteMinerioResponseDto(
                10,
                "LT999",
                "Serra Norte",
                67.3m,
                7.1m,
                3.5m,
                0.01m,
                2500,
                data,
                StatusLote.Embarcado,
                "Navio X"
            );

            Assert.Equal(10, dto.Id);
            Assert.Equal("LT999", dto.CodigoLote);
            Assert.Equal("Serra Norte", dto.MinaOrigem);
            Assert.Equal(67.3m, dto.TeorFe);
            Assert.Equal(7.1m, dto.Umidade);
            Assert.Equal(3.5m, dto.SiO2);
            Assert.Equal(0.01m, dto.P);
            Assert.Equal(2500, dto.Toneladas);
            Assert.Equal(data, dto.DataProducao);
            Assert.Equal(StatusLote.Embarcado, dto.Status);
            Assert.Equal("Navio X", dto.LocalizacaoAtual);
        }

        [Fact]
        public void Deve_Aceitar_Campos_Nullable()
        {
            var dto = new LoteMinerioResponseDto(
                1,
                "LT001",
                "Carajás",
                65,
                8,
                null,
                null,
                1000,
                DateTime.UtcNow,
                StatusLote.EmEstoque,
                "Pátio A"
            );

            Assert.Null(dto.SiO2);
            Assert.Null(dto.P);
        }

        [Fact]
        public void Records_Com_Mesmos_Valores_Devem_Ser_Iguais()
        {
            var data = DateTime.UtcNow;

            var dto1 = new LoteMinerioResponseDto(
                1,"LT001","Carajás",65,8,null,null,1000,data,
                StatusLote.EmEstoque,"Pátio A"
            );

            var dto2 = new LoteMinerioResponseDto(
                1,"LT001","Carajás",65,8,null,null,1000,data,
                StatusLote.EmEstoque,"Pátio A"
            );

            Assert.Equal(dto1, dto2);
        }

    }
}
