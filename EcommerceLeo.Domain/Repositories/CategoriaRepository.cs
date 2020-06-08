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
    public class CategoriaRepository : DataContext, ICategoriaRepository
    {
        public CategoriaRepository(IConfiguration config) : base(config)
        {

        }

        public void DeleteCategoria(int idCategoria)
        {
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CATEGORIA", idCategoria);
                int itensAtingidos = con.Execute("PR_DEL_CATEGORIA_ID", parameter, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<CategoriaProduto> GetAllCategoria()
        {
            List<CategoriaProduto> cg = new List<CategoriaProduto>();

            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();

                cg = con.Query<CategoriaProduto>("PR_SEL_CATEGORIA", parameter, commandType: CommandType.StoredProcedure).ToList();
            }

            return cg;
        }

        public CategoriaProduto GetCategoriaId(int idCategoria)
        {
            CategoriaProduto cg = new CategoriaProduto();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CATEGORIA", idCategoria);
                cg = con.Query<CategoriaProduto>("PR_SEL_CATEGORIA_ID", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cg;
        }

        public CategoriaProduto InsertCategoria(string nmCategoria)
        {
            CategoriaProduto cg = new CategoriaProduto();
            try
            {
                using (IDbConnection con = new SqlConnection(base.GetConection()))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@NM_CATEGORIA", nmCategoria);
           
                    cg = con.Query<CategoriaProduto>("PR_INS_CATEGORIA", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                return cg;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public CategoriaProduto UpdateCategoria(int idCategoria, string nmCategoria)
        {
            CategoriaProduto cg = new CategoriaProduto();

            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CATEGORIA", idCategoria);
                parameter.Add("@NM_CATEGORIA", nmCategoria);

                cg = con.Query<CategoriaProduto>("PR_UPD_CUPOM", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cg;
        }
    }
}
