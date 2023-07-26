using System;
using System.Collections.Generic;

namespace appAUGEuropa2.Shared.DTO;
public partial class ScriptDetalleDTO
{
    public int Id { get; set; }

    public int ScriptId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ScriptDTO Script { get; set; } = null!;
}
