using System;
using System.Collections.Generic;

namespace appAUGEuropa2.Shared.DTO;

public partial class UsuarioDTO
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Email { get; set; } = null!;

    public virtual ICollection<ScriptDTO> Scripts { get; set; } = new List<ScriptDTO>();
}
