using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StudioManager.Crosscutting;
using StudioManager.DataAccess;
using StudioManager.DataAccess.Agenda;
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
        public async Task<Resultado<SemanaViewModel>> RecuperarReservasDaSemanaAPartirDe(DateTime quando, int diasParaFrente)
        {
            const string sql = @"DECLARE @inicio DATETIME = @quando;
								DECLARE @dias INT = @diasParaFrente;
								DECLARE @fim DATETIME = DATEADD(DAY, @dias, @inicio);

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
				var resultado = await conexao.QueryAsync<ReservaDTO>(sql, new { quando, diasParaFrente });

				var dias = resultado.GroupBy(
					k => k.Inicio.Date,
					v => new ReservaViewModel(
						v.Id, 
						new ClienteViewModel(), 
						v.Inicio.TimeOfDay, 
						v.Fim.TimeOfDay),
					(k, v) => new DiaDaSemanaViewModel(k, v.ToArray())); ;

				return new SemanaViewModel(dias.ToArray());

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
