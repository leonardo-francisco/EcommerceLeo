using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Entities
{
    public class CategoriaProduto
    {
        public int idCategoria { get; set; }
        public string nmCategoria { get; set; }

        public virtual Produto Produto { get; set; }
    }
}
