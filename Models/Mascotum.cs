using System;
using System.Collections.Generic;

namespace AdopcionWeb.Models
{
    public partial class Mascotum
    {
        public Mascotum()
        {
            MascotaPersonas = new HashSet<MascotaPersona>();
            Personas = new HashSet<Persona>();
        }

        public int IdMascota { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string? TiempoRescatada { get; set; }

        public virtual ICollection<MascotaPersona> MascotaPersonas { get; set; }
        public virtual ICollection<Persona> Personas { get; set; }
    }
}
