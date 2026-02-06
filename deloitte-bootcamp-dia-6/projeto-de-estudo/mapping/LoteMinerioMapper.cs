using MinhaApi.Models;
using MinhaApi.Dtos;

namespace MinhaApi.Mappings;

public static class LoteMinerioMapper
{
    public static LoteMinerioResponseDto ToResponseDto(this LoteMinerio l)
    {
        return new LoteMinerioResponseDto(
            l.Id,
            l.CodigoLote,
            l.MinaOrigem,
            l.TeorFe,
            l.Umidade,
            l.SiO2,
            l.P,
            l.Toneladas,
            l.DataProducao,
            l.Status,
            l.LocalizacaoAtual
        );
    }
}
