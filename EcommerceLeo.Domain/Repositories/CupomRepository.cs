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
    public class CupomRepository : DataContext, ICupomRepository
    {
        public CupomRepository(IConfiguration config) : base(config)
        {

        }

        public Cupom CreateCupom(string tipoCupom, string codigoCupom, double valorDesconto)
        {
            Cupom cupom = new Cupom();
            try
            {
                using (IDbConnection con = new SqlConnection(base.GetConection()))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@TIPO_CUPOM", tipoCupom);
                    parameter.Add("@CODIGO_CUPOM", codigoCupom);
                    parameter.Add("@VALOR_DESCONTO", valorDesconto);
                    cupom = con.Query<Cupom>("PR_INS_CUPOM", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }

                return cupom;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteCupom(int idCupom)
        {
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CUPOM", idCupom);
                int itensAtingidos = con.Execute("PR_DEL_CUPOM_ID", parameter, commandType: CommandType.StoredProcedure);

            }
        }

        public Cupom EditCupom(int idCupom, string tipoCupom, string codigoCupom, double valorDesconto)
        {
            Cupom cupom = new Cupom();

            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CUPOM", idCupom);
                parameter.Add("@TIPO_CUPOM", tipoCupom);
                parameter.Add("@CODIGO_CUPOM", codigoCupom);
                parameter.Add("@VALOR_DESCONTO", valorDesconto);
                cupom = con.Query<Cupom>("PR_UPD_CUPOM", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cupom;

        }

        public IEnumerable<Cupom> GetAllCupom()
        {
            List<Cupom> cupom = new List<Cupom>();

            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();

                cupom = con.Query<Cupom>("PR_SEL_CUPOM", parameter, commandType: CommandType.StoredProcedure).ToList();
            }

            return cupom;
        }

        public Cupom SearchCupomId(int idCupom)
        {
            Cupom cupom = new Cupom();
            using (IDbConnection con = new SqlConnection(base.GetConection()))
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@ID_CUPOM", idCupom);
                cupom = con.Query<Cupom>("PR_SEL_CUPOM_ID", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }

            return cupom;
        }
    }
}
