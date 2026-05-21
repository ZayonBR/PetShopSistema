using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System.Data;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class AgendamentoDAL
    {
        private Conexao conexao = new Conexao();

        public void Agendar(Agendamento agendamento)
        {
            string sql = @"INSERT INTO Agendamento (dt_agendamento, cd_pet, cd_servico) 
                           VALUES (@data, @idPet, @idServico)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@data", agendamento.DataAgendamento);
                cmd.Parameters.AddWithValue("@idPet", agendamento.IdPet);
                cmd.Parameters.AddWithValue("@idServico", agendamento.IdServico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ListarAgendamentosGerais()
        {
            DataTable dt = new DataTable();
            string sql = @"SELECT A.cd_agendamento AS [Código], A.dt_agendamento AS [Data], P.nm_pet AS [Pet], 
                                  S.nm_servico AS [Serviço], A.cd_statusAgendamento AS [Status]
                           FROM Agendamento A
                           INNER JOIN Pet P ON A.cd_pet = P.cd_pet
                           INNER JOIN Servico S ON A.cd_servico = S.cd_servico";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                con.Open();
                da.Fill(dt);
            }
            return dt;
        }
    }
}