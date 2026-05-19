using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class ServicoDAL
    {
        private Conexao conexao = new Conexao();

        // Listar todos os serviços disponíveis (para preencher um ComboBox na tela de agendamento)
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
                        IdServico = (int)dr["id_servico"],
                        NomeServico = dr["nome_servico"].ToString(),
                        Valor = (decimal)dr["valor"]
                    });
                }
            }
            return lista;
        }
    }
}