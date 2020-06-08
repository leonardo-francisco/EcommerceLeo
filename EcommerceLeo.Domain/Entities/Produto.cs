using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EcommerceLeo.Domain.Entities
{
    public class Produto
    {
        public int idProduto { get; set; }
        public string nmProduto { get; set; }
        public int idCateProd { get; set; }
        public DateTime dtCadastro { get; set; }
        public int qtdProduto { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double precoProduto { get; set; }
        public string urlFoto { get; set; }
        public IFormFile Image { get; set; }

        public virtual ICollection<CategoriaProduto> CategoriaProduto { get; set; }
    }
}
