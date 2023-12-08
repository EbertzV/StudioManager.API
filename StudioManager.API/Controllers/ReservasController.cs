using Microsoft.AspNetCore.Mvc;
using StudioManager.API.Models;
using StudioManager.Application.CancelarReserva;
using StudioManager.Application.ReservarHorario;

namespace StudioManager.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class ReservasController
    {
        [HttpPost]
        public async Task<IActionResult> Reservar(
            [FromBody] ReservarInputModel inputModel,
            [FromServices] IReservarHorarioCommandHandler reservarHorarioCommandHandler)
        {
            if (await reservarHorarioCommandHandler.Executar(inputModel.ConverterParaComando(DateTime.Now)) is var resultado && resultado.EhFalha)
                return new BadRequestObjectResult(resultado.Falha);
            return new OkObjectResult(resultado.Sucesso);
        }

        [HttpDelete("{idReserva}")]
        public async Task<IActionResult> Cancelar(
            [FromRoute] int idReserva,
            [FromQuery] int idCliente,
            [FromServices] ICancelarReservaAplicacao cancelarReservaAplicacao)
        {
            if (await cancelarReservaAplicacao.Executar(idReserva, idCliente, DateTime.Now) is var resultado && resultado.EhFalha)
                return new BadRequestObjectResult(resultado.Falha);
            return new NoContentResult();
        }
    }
}
