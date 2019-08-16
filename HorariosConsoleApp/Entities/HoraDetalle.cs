﻿using System;

namespace HorariosConsoleApp.Entities
{
    public class HoraDetalle
    {
        public int HoraDetalleId { get; set; }
        public int HorarioFraccionId { get; set; }
        public HorarioFragmento HorarioFraccion { get; set; }
        public TimeSpan Hora { get; set; }
        public int TipoHoraId { get; set; }
        public TipoHora TipoHora { get; set; }
    }
}
