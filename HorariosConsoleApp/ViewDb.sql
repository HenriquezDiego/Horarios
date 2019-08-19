USE [HorarioDbV1.2.1]
GO

/****** Object:  View [dbo].[ConsultaDetalleHoras] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[ConsultaDetalleHoras]
AS
SELECT        COUNT(*) AS NumeroHoras, th.TipoHoraId, th.Nombre AS TipoHora, h.Alias AS Horario, d.DiaId, d.Nombre AS Dia
FROM            dbo.HoraDetalles AS hd INNER JOIN
                         dbo.TipoHoras AS th ON hd.TipoHoraId = th.TipoHoraId INNER JOIN
                         dbo.HorariosFragmentos AS hf ON hd.HorarioFragmentoId = hf.HorarioFragmentoId INNER JOIN
                         dbo.Horarios AS h ON hf.HorarioId = h.HorarioId INNER JOIN
                         dbo.Dias AS d ON hf.DiaId = d.DiaId
GROUP BY th.Nombre, hd.HorarioFragmentoId, h.Alias, d.Nombre, d.DiaId, th.TipoHoraId
GO