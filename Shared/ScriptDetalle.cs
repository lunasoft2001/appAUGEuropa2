using System;
using System.Collections.Generic;

namespace appAUGEuropa2.Shared;
public partial class ScriptDetalle
{
    public int Id { get; set; }

    public int ScriptId { get; set; }

    public string Titulo { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual Script Script { get; set; } = null!;
}
