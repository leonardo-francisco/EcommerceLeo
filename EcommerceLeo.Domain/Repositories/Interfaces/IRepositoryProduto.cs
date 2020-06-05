using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Repositories.Interfaces
{
    public interface IRepositoryProduto<T> where T : class
    {
        IEnumerable<T> GetAllProduto();
        T GetProdutoById(int idProduto);
    }
}
