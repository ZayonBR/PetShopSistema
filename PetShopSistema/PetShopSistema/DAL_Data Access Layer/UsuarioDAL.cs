using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class UsuarioDAL
    {
        private Conexao conexao = new Conexao();

        // Método para Cadastrar Usuário
        public void Cadastrar(Usuario usuario)
        {
            string sql = @"INSERT INTO Usuario (nome, telefone, email, senha, cep, rua, bairro, cidade, estado, tipo_usuario) 
                           VALUES (@nome, @telefone, @email, @senha, @cep, @rua, @bairro, @cidade, @estado, @tipo)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha); // Aqui já deve vir o Hash vindo da BLL
                cmd.Parameters.AddWithValue("@cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@rua", usuario.Rua);
                cmd.Parameters.AddWithValue("@bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@cidade", usuario.Cidade);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@tipo", usuario.TipoUsuario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para Validar Login (Retorna o objeto usuário se encontrar, null se não)
        public Usuario ValidarLogin(string email, string senhaHash)
        {
            string sql = "SELECT * FROM Usuario WHERE email = @email AND senha = @senha";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senhaHash);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    return new Usuario
                    {
                        IdUsuario = (int)dr["id_usuario"],
                        Nome = dr["nome"].ToString(),
                        TipoUsuario = dr["tipo_usuario"].ToString()
                    };
                }
                return null;
            }
        }
    }
}