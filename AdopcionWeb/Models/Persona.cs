using System;
using System.Collections.Generic;

namespace AdopcionWeb.Models
{
    public partial class Persona
    {
        public Persona()
        {
            MascotaPersonas = new HashSet<MascotaPersona>();
        }

        public int IdPersona { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        public int? IdMascota { get; set; }

        public virtual Mascotum? IdMascotaAdoptada { get; set; }
        public virtual ICollection<MascotaPersona> MascotaPersonas { get; set; }
    }
}
