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

        
        public double precoProduto { get; set; }
        public string urlFoto { get; set; }
    }
}
