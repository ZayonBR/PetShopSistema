using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class UsuarioDAL
    {
        private Conexao conexao = new Conexao();

        // Cadastro completo alinhado com o banco do teu amigo
        public bool Cadastrar(Usuario usuario)
        {
            // Nota: Os nomes aqui batem exatamente com as colunas do CREATE TABLE Usuario
            string sql = @"INSERT INTO Usuario (nm_usuario, ds_email, ds_senha, cd_telefone, cd_CEP, nm_rua, nm_bairro, nm_cidade, sg_estado, cd_tipoUsuario) 
               VALUES (@nome, @email, @senha, @telefone, @cep, @rua, @bairro, @cidade, @estado, @tipo)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                cmd.Parameters.AddWithValue("@nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@email", usuario.Email);
                cmd.Parameters.AddWithValue("@senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@telefone", usuario.Telefone);
                cmd.Parameters.AddWithValue("@cep", usuario.Cep);
                cmd.Parameters.AddWithValue("@rua", usuario.Rua);
                cmd.Parameters.AddWithValue("@bairro", usuario.Bairro);
                cmd.Parameters.AddWithValue("@cidade", usuario.Cidade);
                cmd.Parameters.AddWithValue("@estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@tipo", usuario.TipoUsuario);

                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Validação de Login também atualizada para os novos nomes de colunas
        public Usuario ValidarLogin(string email, string senhaHash)
        {
            // Ajustado para ds_email e ds_senha
            string sql = "SELECT * FROM Usuario WHERE ds_email = @email AND ds_senha = @senha";

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
                        IdUsuario = (int)dr["cd_usuario"],
                        Nome = dr["nm_usuario"].ToString(),
                        TipoUsuario = dr["cd_tipoUsuario"].ToString()
                    };
                }
                return null;
            }
        }
    }
}