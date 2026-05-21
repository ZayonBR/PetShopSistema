using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class ServicoDAL
    {
        private Conexao conexao = new Conexao();

        public List<Servico> ListarTodos()
        {
            List<Servico> lista = new List<Servico>();
            string sql = "SELECT * FROM Servico";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Servico
                    {
                        IdServico = (int)dr["cd_servico"],
                        NomeServico = dr["nm_servico"].ToString(),
                        Valor = (decimal)dr["vl_preco"]
                    });
                }
            }
            return lista;
        }
    }
}