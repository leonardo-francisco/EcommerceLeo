using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Repositories.Interfaces
{
    public interface IRepositoryCategoria<T> where T : class
    {
        IEnumerable<T> GetAllCategoria();
        T InsertCategoria(string nmCategoria);
        T UpdateCategoria(int idCategoria, string nmCategoria);
        T GetCategoriaId(int idCategoria);
        void DeleteCategoria(int idCategoria);
    }
}
