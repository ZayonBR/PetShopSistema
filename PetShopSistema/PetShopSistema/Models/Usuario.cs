using System;

namespace PetShopSystem.Models
{
    public class Usuario
    {
        // O "get; set;" significa que podemos ler e gravar dados nessas propriedades

        public int IdUsuario { get; set; }       // No SQL será: INT PRIMARY KEY IDENTITY
        public string Nome { get; set; }         // No SQL será: VARCHAR(100)
        public string Telefone { get; set; }     // No SQL será: VARCHAR(20)
        public string Email { get; set; }        // No SQL será: VARCHAR(100)
        public string Senha { get; set; }        // No SQL será: VARCHAR(255) (Para caber o Hash SHA-256)
        public string Cep { get; set; }          // No SQL será: VARCHAR(10)
        public string Rua { get; set; }          // No SQL será: VARCHAR(100)
        public string Bairro { get; set; }       // No SQL será: VARCHAR(100)
        public string Cidade { get; set; }       // No SQL será: VARCHAR(100)
        public string Estado { get; set; }       // No SQL será: VARCHAR(50)

        // Vamos usar 'cliente' ou 'admin' para separar as duas vistas exigidas pelo professor
        public string TipoUsuario { get; set; }  // No SQL será: VARCHAR(20)
    }
}