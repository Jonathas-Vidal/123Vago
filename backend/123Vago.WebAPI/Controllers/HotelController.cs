using _123Vago.Servico;
using Microsoft.AspNetCore.Mvc;

namespace _123Vago.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelServico _servico;

        public HotelController(IHotelServico servico)
        {
            _servico = servico;
        }

        [HttpPost]
        public IActionResult Adicionar([FromBody] HotelDto dto)
        {
            _servico.Adicionar(dto);
            return Ok(new { mensagem = "Hotel adicionado com sucesso" });
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_servico.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var hotel = _servico.BuscarPorId(id);
            if (hotel == null) return NotFound(new { mensagem = "Hotel não encontrado" });
            return Ok(hotel);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] HotelDto dto)
        {
            var atualizado = _servico.Atualizar(id, dto);
            if (!atualizado)
                return NotFound(new { mensagem = "Hotel não encontrado para atualizar" });

            return Ok(new { mensagem = "Hotel atualizado com sucesso" });
        }

        [HttpDelete("{id}")]
        public IActionResult Remover(int id)
        {
            var removido = _servico.Remover(id);
            if (!removido)
                return NotFound(new { mensagem = "Hotel não encontrado para remoção" });

            return Ok(new { mensagem = "Hotel removido com sucesso" });
        }
    }
}
