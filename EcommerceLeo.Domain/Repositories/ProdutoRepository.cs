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
    public class ProdutoRepository : DataContext, IProdutoRepository
    {
        public ProdutoRepository(IConfiguration config) : base(config)
        {

        }

        public void DeleteProduto(int idProduto)
        {
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_PRODUTO", idProduto);
                int itensAtingidos = con.Execute("PR_DEL_PRODUTO_ID", parameter, commandType: CommandType.StoredProcedure);

            }
        }

        public IEnumerable<Produto> GetAllProduto()
        {
            List<Produto> produto = new List<Produto>();

            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                
                produto = con.Query<Produto>("PR_SEL_PRODUTO", parameter, commandType: CommandType.StoredProcedure).ToList();
            }

            return produto;
        }

        public Produto GetProdutoById(int idProduto)
        {
            Produto produto = new Produto();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_PRODUTO", idProduto);
                produto = con.Query<Produto>("PR_SEL_PRODUTO_ID", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return produto;
        }

        public Produto InsertProduto(string nomeProduto, int idCategoria, double precoProduto, string urlPhoto)
        {
            Produto produto = new Produto();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@NM_PRODUTO", nomeProduto);
                parameter.Add("@ID_CATEGORIA", idCategoria);
                parameter.Add("@PRECO_PRODUTO", precoProduto);
                parameter.Add("@URL_PHOTO", urlPhoto);
                produto = con.Query<Produto>("PR_INS_PRODUTO", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return produto;
        }

        public Produto UpdateProduto(int idProduto, string nomeProduto, int idCategoria, double precoProduto)
        {
            Produto produto = new Produto();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_PRODUTO", idProduto);
                parameter.Add("@NM_PRODUTO", nomeProduto);
                parameter.Add("@ID_CATEGORIA", idCategoria);
                parameter.Add("@PRECO_PRODUTO", precoProduto);               
                produto = con.Query<Produto>("PR_UPD_PRODUTO", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return produto;
        }
    }
}
