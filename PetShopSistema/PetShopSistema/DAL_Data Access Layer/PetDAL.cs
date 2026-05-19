using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace PetShopSystem.DAL
{
    public class PetDAL
    {
        private Conexao conexao = new Conexao();

        // Cadastrar um Pet vinculado a um cliente
        public void Cadastrar(Pet pet)
        {
            string sql = @"INSERT INTO Pet (nome, especie, raca, idade, id_usuario) 
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

        // Listar todos os Pets de um cliente específico (útil para a visão do Cliente)
        public List<Pet> ListarPorCliente(int idUsuario)
        {
            List<Pet> lista = new List<Pet>();
            string sql = "SELECT * FROM Pet WHERE id_usuario = @idUsuario";

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
                        IdPet = (int)dr["id_pet"],
                        Nome = dr["nome"].ToString(),
                        Especie = dr["especie"].ToString(),
                        Raca = dr["raca"].ToString(),
                        Idade = (int)dr["idade"],
                        IdUsuario = (int)dr["id_usuario"]
                    });
                }
            }
            return lista;
        }
    }
}