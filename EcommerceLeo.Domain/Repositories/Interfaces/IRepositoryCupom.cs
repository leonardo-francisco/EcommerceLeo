using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Repositories.Interfaces
{
    public interface IRepositoryCupom<T> where T : class
    {
        IEnumerable<T> GetAllCupom();
        T CreateCupom(string tipoCupom, string codigoCupom, double valorDesconto);
        void DeleteCupom(int idCupom);
        T SearchCupomId(int idCupom);
        T EditCupom(int idCupom, string tipoCupom, string codigoCupom, double valorDesconto);
    }
}
