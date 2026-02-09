using MinhaApi.Dtos;
using MinhaApi.Models;
using Xunit;

namespace MinhaApi.Tests.Dtos
{
    public class LoteMinerioResponseDtoTests
    {
        [Fact]
        public void Deve_Criar_ResponseDto_Corretamente()
        {
            var dto = new LoteMinerioResponseDto(
                1,
                "LT001",
                "Carajás",
                65.5m,
                8.2m,
                null,
                null,
                1000,
                DateTime.Now,
                StatusLote.EmEstoque,
                "Pátio A"
            );

            Assert.Equal(1, dto.Id);
            Assert.Equal("LT001", dto.CodigoLote);
            Assert.Equal(StatusLote.EmEstoque, dto.Status);
        }
    }
}
