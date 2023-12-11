using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudioManager.Crosscutting;
using StudioManager.DataAccess.Agenda.VisualizacaoSemana;
using StudioManager.Infra.SqlServer.Query.Semanas.DTO;

namespace StudioManager.Infra.SqlServer.Query.Semanas
{
    public sealed class SemanasDataAccess : ISemanasDataAccess
    {
		private readonly string _stringConexao;

        public SemanasDataAccess(IConfiguration configuration)
        {
			_stringConexao = configuration.GetSection("ConnectionStrings:Default").Value;
        }
        public async Task<Resultado<SemanaViewModel>> RecuperarReservasDaSemanaAPartirDe(DateTime quando)
        {
            const string sql = @"DECLARE @inicio DATETIME = @quando;
								DECLARE @fim DATETIME = DATEADD(DAY, 7, @inicio);

								WITH ReservasDoDia AS (
									SELECT	Reservas.Id,
											Reservas.Inicio,
											Reservas.Fim,
											Reservas.ClienteId
									FROM reservas.Reservas
									WHERE Inicio >= @inicio
										AND Fim < @fim
								)

								SELECT	ReservasDoDia.*,
										Clientes.Nome
								FROM ReservasDoDia
								INNER JOIN reservas.Clientes (NOLOCK)
									ON Clientes.Id = ReservasDoDia.ClienteId";

			using var conexao = new SqlConnection(_stringConexao);

			try
			{
				await conexao.OpenAsync();
				var resultado = await conexao.QueryAsync<ReservaDTO>(sql, new { quando });
				
				

			} catch (Exception ex)
			{
				throw;
			}
			finally
			{
				await conexao.CloseAsync();
			}
        }
    }
}
