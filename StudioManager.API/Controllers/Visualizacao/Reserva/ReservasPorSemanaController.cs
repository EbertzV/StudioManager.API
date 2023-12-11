using Microsoft.AspNetCore.Mvc;
using StudioManager.DataAccess.Agenda.VisualizacaoSemana;
using System.Diagnostics;

namespace StudioManager.API.Controllers.Visualizacao.Reserva
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ReservasPorSemanaController
    {
        [HttpGet]
        public async Task<IActionResult> RecuperarReservasPorSemana(
            [FromServices] ISemanasDataAccess semanasDataAccess, 
            [FromQuery] DateTime referencia,
            [FromQuery] int diasParaFrente)
        {
            var inicio = referencia.AddDays(-(int)referencia.DayOfWeek).Date;
            if (await semanasDataAccess.RecuperarReservasDaSemanaAPartirDe(inicio, diasParaFrente) is var resultado && resultado.EhFalha)
                return new BadRequestObjectResult(resultado.Falha);
            return new OkObjectResult(resultado.Sucesso.Dias);
        }
    }
}
