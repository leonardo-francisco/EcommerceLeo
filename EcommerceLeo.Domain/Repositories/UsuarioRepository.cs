using Dapper;
using EcommerceLeo.Domain.Entities;
using EcommerceLeo.Domain.Repositories.Interfaces;
using EcommerceLeo.Infra;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace EcommerceLeo.Domain.Repositories
{
    public class UsuarioRepository: DataContext, IUsuarioRepository
    {
        public UsuarioRepository(IConfiguration config) : base(config)
        {

        }

        public Usuario InsereUsuario(string nmUsu, string emailUsu, string telUsu, string celUsu, string cpfUsu, string endUsu, string complUsu, string cepUsu, string cidadeUsu, string ufUsu, string loginUsu, string senhaUsu)
        {
            Usuario usuario = new Usuario();
            try
            {
                using (IDbConnection con = new SqlConnection(base.GetConection()))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@NM_USUARIO", nmUsu);
                    parameter.Add("@EMAIL_USUARIO", emailUsu);
                    parameter.Add("@TELEFONE_USUARIO", telUsu);
                    parameter.Add("@CELULAR_USUARIO", celUsu);
                    parameter.Add("@CPF_USUARIO", cpfUsu);
                    parameter.Add("@END_USUARIO", endUsu);
                    parameter.Add("@COMPL_USUARIO ", complUsu);
                    parameter.Add("@CEP_USUARIO", cepUsu);
                    parameter.Add("@CIDADE_USUARIO", cidadeUsu);
                    parameter.Add("@UF_USUARIO", ufUsu);
                    parameter.Add("@LOGIN_USUARIO", loginUsu);
                    parameter.Add("@SENHA_USUARIO", senhaUsu);
                    usuario = con.Query<Usuario>("PR_INS_USUARIO", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                return usuario;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Usuario Login(string login, string senha)
        {
            Usuario usuario = new Usuario();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@NM_LOGIN", login);
                parameter.Add("@NM_PASSWORD", senha);
                usuario = con.Query<Usuario>("PR_FORM_LOGIN", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return usuario;
        }
    }
}
