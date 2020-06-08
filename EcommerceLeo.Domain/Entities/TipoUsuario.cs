using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Entities
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string DescTipoUsuario { get; set; }

        public virtual Usuario Usuario { get; set; }
    }
}
