using MinhaApi.Models;
using MinhaApi.Services;
using Xunit;

// Seguinto padrão AAA - Arrange, Act e Assert

namespace MinhaApi.Tests.Models
{
    public class LoteServiceTests
    {
        // Classificação
        [Fact]
        public void ClassificarQualidade_DeveRetornarPremium()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 61,
                Umidade = 5,
                SiO2 = 3
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Premium", result);
        }

        [Fact]
        public void ClassificarQualidade_LimitePremium()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 60,
                Umidade = 8,
                SiO2 = 4
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Premium", result);
        }

        [Fact]
        public void ClassificarQualidade_NaoPremiumPorSiO2()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 5 // quebra premium
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Padrão", result);
        }

        [Fact]
        public void ClassificarQualidade_NaoPremiumPorUmidade()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 9,
                SiO2 = 3
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Baixa", result);
        }

        [Fact]
        public void ClassificarQualidade_DeveRetornarPadrao()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 60,
                Umidade = 5,
                SiO2 = 10
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Padrão", result);
        }

        [Fact]
        public void ClassificarQualidade_LimitePadrao()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 55,
                Umidade = 7,
                SiO2 = 10
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Padrão", result);
        }

        [Fact]
        public void ClassificarQualidade_DeveRetornarBaixa()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 50,
                Umidade = 12,
                SiO2 = 10
            };

            var result = service.ClassificarQualidade(lote);

            Assert.Equal("Baixa", result);
        }


        // Preço
        [Fact]
        public void CalcularPrecoPorTonelada_Premium()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3
            };

            var preco = service.CalcularPrecoPorTonelada(lote);

            Assert.Equal(230.40m, preco);
        }

        [Fact]
        public void CalcularPrecoPorTonelada_Premium_DeveRetornarErrado()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3
            };

            var preco = service.CalcularPrecoPorTonelada(lote);

            Assert.NotEqual(30.40m, preco);
        }

        [Fact]
        public void CalcularPreco_NuncaDeveSerNegativo()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 0,
                Umidade = 100,
                SiO2 = 100
            };

            var preco = service.CalcularPrecoPorTonelada(lote);

            Assert.True(preco >= 0);
        }

        [Fact]
        public void CalcularPrecoPorTonelada_Padrao()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 56,
                Umidade = 7,
                SiO2 = 10
            };

            var preco = service.CalcularPrecoPorTonelada(lote);

            Assert.Equal(120.30m, preco);
        }

        [Fact]
        public void CalcularPrecoPorTonelada_Baixa()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 40,
                Umidade = 15,
                SiO2 = 10
            };

            var preco = service.CalcularPrecoPorTonelada(lote);

            Assert.Equal(75.00m, preco);
        }

        // Valor total
        [Fact]
        public void CalcularValorTotal_DeveMultiplicarCorretamente()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3,
                Toneladas = 10
            };

            var total = service.CalcularValorTotal(lote);

            Assert.Equal(2304.0m, total);
        }

        [Fact]
        public void CalcularValorTotal_DeveMultiplicarErrado()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3,
                Toneladas = 10
            };

            var total = service.CalcularValorTotal(lote);

            Assert.NotEqual(304.0m, total);
        }

        [Fact]
        public void CalcularValorTotal_ToneladasZero()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                TeorFe = 65,
                Umidade = 5,
                SiO2 = 3,
                Toneladas = 0
            };

            var total = service.CalcularValorTotal(lote);

            Assert.Equal(0, total);
        }

        // Registrar movimentação
        [Fact]
        public void RegistrarMovimentacao_DeveAdicionarHistorico()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                LocalizacaoAtual = "A",
                Status = StatusLote.EmEstoque
            };

            service.RegistrarMovimentacao(lote, "B", StatusLote.EmTransporte);

            Assert.Single(lote.Historico);
            Assert.Equal("B", lote.LocalizacaoAtual);
            Assert.Equal(StatusLote.EmTransporte, lote.Status);
        }

        [Fact]
        public void RegistrarMovimentacao_DeveAcrescentarHistorico()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                LocalizacaoAtual = "A",
                Status = StatusLote.EmEstoque
            };

            service.RegistrarMovimentacao(lote, "B", StatusLote.EmTransporte);
            service.RegistrarMovimentacao(lote, "C", StatusLote.Embarcado);

            Assert.Equal(2, lote.Historico.Count);
        }

        // Avançar Status
        [Fact]
        public void AvancarStatus_EstoqueParaTransporte()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Status = StatusLote.EmEstoque,
                LocalizacaoAtual = "X"
            };

            service.AvancarStatus(lote);

            Assert.Equal(StatusLote.EmTransporte, lote.Status);
        }

        [Fact]
        public void AvancarStatus_TransporteParaEmbarcado()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Status = StatusLote.EmTransporte,
                LocalizacaoAtual = "X"
            };

            service.AvancarStatus(lote);

            Assert.Equal(StatusLote.Embarcado, lote.Status);
        }

        [Fact]
        public void AvancarStatus_Embarcado_DeveLancarErro()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Status = StatusLote.Embarcado
            };

            Assert.Throws<InvalidOperationException>(() =>
                service.AvancarStatus(lote));
        }

        [Fact]
        public void AvancarStatus_StatusInvalido_DeveLancarErro()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Status = (StatusLote)999 // valor inválido
            };

            Assert.Throws<ArgumentOutOfRangeException>(() =>
                service.AvancarStatus(lote));
        }

        // Penalidade
        [Fact]
        public void Penalidade_SemExcesso()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Umidade = 7,
                Toneladas = 10
            };

            var result = service.CalcularPenalidadeUmidade(lote);

            Assert.Equal(0, result);
        }

        [Fact]
        public void Penalidade_ComExcesso()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Umidade = 10,
                Toneladas = 10
            };

            var result = service.CalcularPenalidadeUmidade(lote);

            Assert.Equal(42m, result); // (10-8)*2.10*10
        }

        [Fact]
        public void Penalidade_NoLimiteNaoDeveAplicar()
        {
            var service = new LoteService();

            var lote = new LoteMinerio
            {
                Umidade = 8,
                Toneladas = 10
            };

            var result = service.CalcularPenalidadeUmidade(lote);

            Assert.Equal(0, result);
        }

        // Histórico
        [Fact]
        public void Historico_DeveIniciarListaVazia()
        {
            var lote = new LoteMinerio();

            Assert.NotNull(lote.Historico);
            Assert.Empty(lote.Historico);
        }



    }
}
