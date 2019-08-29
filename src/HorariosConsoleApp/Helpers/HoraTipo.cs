namespace HorariosConsoleApp.Helpers
{
    /// <summary>
    /// Provee de la información de las horas de una jornada laboral  (hora diurna, hora nocturna) 
    /// </summary>
    public enum HoraTipo
    {
        /// <summary>
        /// Hora Ordinaria Diura
        /// </summary>
        Hod = 1,
        /// <summary>
        /// Hora Ordinaria Nocturna
        /// </summary>
        Hon = 2,
        /// <summary>
        /// Hora Extra Diura
        /// </summary>
        Hed = 3,
        /// <summary>
        /// Hora Extra Nocturna
        /// </summary>
        Hen = 4,
        /// <summary>
        /// Hora Ordinaria Diurna Sabado
        /// </summary>
        Hds = 5,
        /// <summary>
        /// Hora Ordinaria Nocturna Sabado
        /// </summary>
        Hns = 6,
        /// <summary>
        /// Hora Ordinaria Diurna Domingo
        /// </summary>
        Hdd = 7,
        /// <summary>
        /// Hora Ordinaria Nocturna Domingo
        /// </summary>
        Hnd = 8,
        /// <summary>
        /// Hora Extra Diurna Domingo
        /// </summary>
        Hedd = 9,
        /// <summary>
        /// Hora Extra Nocturna Domingo
        /// </summary>
        Hend = 10
    }
}
