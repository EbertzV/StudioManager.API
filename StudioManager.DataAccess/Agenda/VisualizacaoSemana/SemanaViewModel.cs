﻿namespace StudioManager.DataAccess.Agenda.VisualizacaoSemana
{
    public struct SemanaViewModel
    {
        public SemanaViewModel(DiaDaSemanaViewModel[] dias)
        {
            Dias = dias;
        }

        public DiaDaSemanaViewModel[] Dias { get; }
    }
}
