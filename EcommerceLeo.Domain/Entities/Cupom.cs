using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceLeo.Domain.Entities
{
    public class Cupom
    {
        public int IdCupom { get; set; }
        public string TipoCupom { get; set; }
        public string CodigoCupom { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ValorDesconto { get; set; }
    }
}
