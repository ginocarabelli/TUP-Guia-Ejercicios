using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TurnoApi.Models;

public partial class TTurno
{
    public int Id { get; set; }

    public string? Fecha { get; set; }

    public string? Hora { get; set; }

    public string? Cliente { get; set; }
    //[Column("Fecha_Cancelacion")]
    public DateTime? FechaCancelacion { get; set; }

    public string? MotivoCancelacion { get; set; }

}
