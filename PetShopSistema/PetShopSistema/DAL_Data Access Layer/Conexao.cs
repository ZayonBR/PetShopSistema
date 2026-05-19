using System.Data.SqlClient;
using System.Configuration;

namespace PetShopSistema.DAL_Data_Access_Layer
{
    internal class Conexao
    {
        // Busca a string de conexão que configuramos no App.config de forma segura
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["PetShopDB"].ConnectionString;

        // Método responsável por entregar uma conexão pronta para uso
        public SqlConnection Conectar()
        {
            return new SqlConnection(connectionString);
        }
    }
}
