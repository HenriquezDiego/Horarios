using System;

namespace HorariosConsoleApp.Entities
{
    public class Hora
    {
        public int HoraId { get; set; }
        public String Descripcion { get; set; }
        public String Abreviatura { get; set; }

        public Decimal PorcetajeExtra { get; set; }



    }
}