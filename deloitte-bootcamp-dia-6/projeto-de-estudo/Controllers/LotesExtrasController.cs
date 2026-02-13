using Microsoft.AspNetCore.Mvc;
using MinhaApi.Models;
using MinhaApi.Services;
using MinhaApi.Data; 

namespace MinhaApi.Controllers
{
    [ApiController]
    [Route("api/lote-extra")]
    public class LotesExtrasController : ControllerBase
    {
        private readonly AppDbContext _ctx;
        private readonly LoteService _service;

        public LotesExtrasController(AppDbContext ctx, LoteService service)
        {
            _ctx = ctx;
            _service = service;
        }

        // 1) Classificação
        [HttpGet("{id}/classificar")]
        public async Task<IActionResult> Classificar(int id)
        {
            var lote = await  _ctx.LotesMinerio.FindAsync(id);
            if (lote == null) return NotFound();

            var qualidade = _service.ClassificarQualidade(lote);

            return Ok(new { lote.Id, lote.CodigoLote, qualidade });
        }

        // 2) Preço
        [HttpGet("{id}/preco")]
        public async Task<IActionResult> CalcularPreco(int id)
        {
            var lote = await _ctx.LotesMinerio.FindAsync(id);
            if (lote == null) return NotFound();

            return Ok(new 
            {
                lote.Id,
                lote.CodigoLote,
                qualidade = _service.ClassificarQualidade(lote),
                precoPorTonelada = _service.CalcularPrecoPorTonelada(lote),
                toneladas = lote.Toneladas,
                valorTotal = _service.CalcularValorTotal(lote)
            });
        }

        // 3) Histórico
        [HttpPost("{id}/mover")]
        public async Task<IActionResult> Mover(int id, [FromBody] MovimentoDto dto)
        {
            var lote = await _ctx.LotesMinerio.FindAsync(id);
            if (lote == null) return NotFound();

            _service.RegistrarMovimentacao(lote, dto.Local, dto.Status);

            _ctx.SaveChanges();

            return Ok(lote);
        }

        // 4) Avançar status
        [HttpPost("{id}/avancar-status")]
        public async Task<IActionResult> AvancarStatus(int id)
        {
            var lote = await _ctx.LotesMinerio.FindAsync(id);
            if (lote == null) return NotFound();

            _service.AvancarStatus(lote);
            _ctx.SaveChanges();

            return Ok(lote);
        }

        // 5) Penalidade
        [HttpGet("{id}/penalidade")]
        public async Task<IActionResult> Penalidade(int id)
        {
            var lote = await _ctx.LotesMinerio.FindAsync(id);
            if (lote == null) return NotFound();

            var penalidade = _service.CalcularPenalidadeUmidade(lote);

            return Ok(new
            {
                lote.Id,
                lote.CodigoLote,
                lote.Umidade,
                penalidade
            });
        }
    }

    public class MovimentoDto
    {
        public string Local { get; set; }
        public StatusLote Status { get; set; }
    }
}