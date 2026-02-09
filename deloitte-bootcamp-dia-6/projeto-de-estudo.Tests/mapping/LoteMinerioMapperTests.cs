using MinhaApi.Models;
using MinhaApi.Mappings;
using Xunit;

public class LoteMinerioMapperTests
{
    [Fact]
    public void Deve_Mapear_Model_Para_ResponseDto()
    {
        var model = new LoteMinerio
        {
            Id = 1,
            CodigoLote = "LT001",
            MinaOrigem = "Carajás",
            TeorFe = 65,
            Umidade = 8,
            SiO2 = 4,
            P = 0.02m,
            Toneladas = 1000,
            DataProducao = DateTime.UtcNow,
            Status = StatusLote.EmEstoque,
            LocalizacaoAtual = "Pátio A"
        };

        var dto = model.ToResponseDto();

        Assert.Equal(model.Id, dto.Id);
        Assert.Equal(model.CodigoLote, dto.CodigoLote);
        Assert.Equal(model.Status, dto.Status);
    }
}
