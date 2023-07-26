using System;
using System.Collections.Generic;

namespace appAUGEuropa2.Shared.DTO;

public partial class ScriptDTO
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime Fecha { get; set; }

    public int? UsuarioId { get; set; }

    public string nombreUsuario { get; set; }

}
