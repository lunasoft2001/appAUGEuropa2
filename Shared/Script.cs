using System;
using System.Collections.Generic;

namespace appAUGEuropa2.Shared;

public partial class Script
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioId { get; set; }

    public virtual ICollection<ScriptDetalle> ScriptDetalles { get; set; } = new List<ScriptDetalle>();

    public virtual Usuario? Usuario { get; set; }
}
