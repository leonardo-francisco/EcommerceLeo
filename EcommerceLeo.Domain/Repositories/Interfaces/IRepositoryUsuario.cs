using System;
using System.Collections.Generic;
using System.Text;

namespace EcommerceLeo.Domain.Repositories.Interfaces
{
    public interface IRepositoryUsuario<T> where T : class
    {
        T InsereUsuario(string nmUsu, string emailUsu, string telUsu, string celUsu, string cpfUsu, string endUsu, string complUsu,
                        string cepUsu, string cidadeUsu, string ufUsu, string loginUsu, string senhaUsu);

        T Login(string login, string senha);
    }
}