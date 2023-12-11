using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioManager.Infra.SqlServer.Query.Semanas.DTO
{
    public sealed class ReservaDTO
    {
        public int Id { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
    }
}
