using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class PetDAL
    {
        private Conexao conexao = new Conexao();

        public void Cadastrar(Pet pet)
        {
            string sql = @"INSERT INTO Pet (nm_pet, ds_especie, ds_raca, qt_idade, cd_usuario)
                           VALUES (@nome, @especie, @raca, @idade, @idUsuario)";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@nome", pet.Nome);
                cmd.Parameters.AddWithValue("@especie", pet.Especie);
                cmd.Parameters.AddWithValue("@raca", pet.Raca);
                cmd.Parameters.AddWithValue("@idade", pet.Idade);
                cmd.Parameters.AddWithValue("@idUsuario", pet.IdUsuario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<Pet> ListarPorCliente(int idUsuario)
        {
            List<Pet> lista = new List<Pet>();
            string sql = "SELECT * FROM Pet WHERE cd_usuario = @idUsuario";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Pet
                    {
                        IdPet = (int)dr["cd_pet"],
                        Nome = dr["nm_pet"].ToString(),
                        Especie = dr["ds_especie"].ToString(),
                        Raca = dr["ds_raca"].ToString(),
                        Idade = (int)dr["qt_idade"],
                        IdUsuario = (int)dr["cd_usuario"]
                    });
                }
            }
            return lista;
        }

        public List<Pet> ListarTodos()
        {
            List<Pet> lista = new List<Pet>();
            string sql = "SELECT * FROM Pet";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    lista.Add(new Pet
                    {
                        IdPet = (int)dr["cd_pet"],
                        Nome = dr["nm_pet"].ToString(),
                        Especie = dr["ds_especie"].ToString(),
                        Raca = dr["ds_raca"].ToString(),
                        Idade = (int)dr["qt_idade"],
                        IdUsuario = (int)dr["cd_usuario"]
                    });
                }
            }
            return lista;
        }

        public void Atualizar(Pet pet)
        {
            string sql = @"UPDATE Pet SET nm_pet = @nome, ds_especie = @especie, 
                           ds_raca = @raca, qt_idade = @idade, cd_usuario = @idUsuario 
                           WHERE cd_pet = @idPet";

            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idPet", pet.IdPet);
                cmd.Parameters.AddWithValue("@nome", pet.Nome);
                cmd.Parameters.AddWithValue("@especie", pet.Especie);
                cmd.Parameters.AddWithValue("@raca", pet.Raca);
                cmd.Parameters.AddWithValue("@idade", pet.Idade);
                cmd.Parameters.AddWithValue("@idUsuario", pet.IdUsuario);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Excluir(int idPet)
        {
            string sql = "DELETE FROM Pet WHERE cd_pet = @idPet";
            using (SqlConnection con = conexao.Conectar())
            {
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@idPet", idPet);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}