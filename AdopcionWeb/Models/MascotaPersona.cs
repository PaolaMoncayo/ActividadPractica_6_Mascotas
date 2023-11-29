using System;
using System.Collections.Generic;

namespace AdopcionWeb.Models
{
    public partial class MascotaPersona
    {
        public int IdRelacion { get; set; }
        public int? IdMascota { get; set; }
        public int? IdPersona { get; set; }

        public virtual Mascotum? IdMascotaAdoptada { get; set; }
        public virtual Persona? IdPersonaNavigation { get; set; }
    }
}
