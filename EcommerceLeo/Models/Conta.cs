using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceLeo.Web.Models
{
    public class Conta
    {
        [Required(ErrorMessage = "Informe o seu login")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Informe a senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
