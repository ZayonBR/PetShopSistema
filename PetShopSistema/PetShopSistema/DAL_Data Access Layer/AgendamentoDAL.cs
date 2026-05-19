using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class AgendamentoDAL
    {
        private Conexao conexao = new Conexao();

        // Criar um novo agendamento
        public void Agendar(Agendamento agendamento)
        {
            string sql = @"INSERT INTO Agendamento (data_agendamento, horario, status_agendamento, id_pet, id_servico) 
                           VALUES (@data, @horario, @status, @idPet, @idServico)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@data", agendamento.DataAgendamento);
                cmd.Parameters.AddWithValue("@horario", agendamento.Horario);
                cmd.Parameters.AddWithValue("@status", agendamento.StatusAgendamento);
                cmd.Parameters.AddWithValue("@idPet", agendamento.IdPet);
                cmd.Parameters.AddWithValue("@idServico", agendamento.IdServico);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // DIFERENCIAL EXIGIDO: Retorna uma listagem usando INNER JOIN para jogar direto no DataGrid
        public DataTable ListarAgendamentosGerais()
        {
            DataTable dt = new DataTable();

            // Query idêntica ao teste do JOIN do seu script SQL
            string sql = @"SELECT 
                                a.id_agendamento AS [Código],
                                a.data_agendamento AS [Data],
                                a.horario AS [Horário],
                                p.nome AS [Pet],
                                s.nome_servico AS [Serviço],
                                a.status_agendamento AS [Status]
                           FROM Agendamento a
                           INNER JOIN Pet p ON a.id_pet = p.id_pet
                           INNER JOIN Servico s ON a.id_servico = s.id_servico";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                con.Open();
                da.Fill(dt); // Preenche a tabela em memória com o resultado do JOIN
            }

            return dt; // O pessoal da UI só vai precisar colocar: dataGridView.DataSource = retorno;
        }
    }
}