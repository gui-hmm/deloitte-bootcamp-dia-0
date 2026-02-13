using MinhaApi.Models;

namespace MinhaApi.Services
{
    public class LoteService
    {
        // 1) Classificação de qualidade
        public string ClassificarQualidade(LoteMinerio lote)
        {
            var premium = lote.TeorFe >= 60 &&
                        lote.Umidade <= 8 &&
                        lote.SiO2 <= 4;

            if (premium) return "Premium";

            var padrao = lote.TeorFe > 60 &&
                        lote.Umidade <= 8;

            return padrao ? "Padrão" : "Baixa";
        }

        // 2) Cálculo de preço por tonelada
        public decimal CalcularPrecoPorTonelada(LoteMinerio lote)
        {
            var qualidade = ClassificarQualidade(lote);

            return qualidade switch
            {
                "Premium" => 230.40m,
                "Padrão"  => 120.30m,
                "Baixa" => 75.00m
            };
        }

        public decimal CalcularValorTotal(LoteMinerio lote)
        {
            var preco = CalcularPrecoPorTonelada(lote);
            return preco * lote.Toneladas;
        }

        // 3) Histórico de movimentação
        public void RegistrarMovimentacao(LoteMinerio lote, string local, StatusLote novoStatus)
        {
            lote.Historico.Add(new HistoricoMovimentacao
            {
                Local = local,
                Status = novoStatus,
                Data = DateTime.UtcNow
            });

            lote.LocalizacaoAtual = local;
            lote.Status = novoStatus;
        }

        // 4) Avançar status do lote
        public void AvancarStatus(LoteMinerio lote)
        {
            var novoStatus = lote.Status switch
            {
                StatusLote.EmEstoque     => StatusLote.EmTransporte,
                StatusLote.EmTransporte  => StatusLote.Embarcado,
                StatusLote.Embarcado     => throw new InvalidOperationException("Lote já está embarcado."),
                _                        => throw new ArgumentOutOfRangeException(nameof(lote.Status))
            };

            RegistrarMovimentacao(
                lote,
                lote.LocalizacaoAtual,
                novoStatus
            );
        }

        // 5) Penalidade por umidade
        public decimal CalcularPenalidadeUmidade(LoteMinerio lote)
        {
            const decimal limite = 8m;
            const decimal taxa = 2.10m;

            if (lote.Umidade <= limite)
                return 0m;

            var excesso = lote.Umidade - limite;
            return excesso * taxa * lote.Toneladas;
        }
    }
}