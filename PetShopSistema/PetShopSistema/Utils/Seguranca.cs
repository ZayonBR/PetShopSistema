using System;
using System.Text;
using System.Security.Cryptography;

namespace PetShopSystem.Utils
{
    // Usamos 'public static' para não precisarmos instanciar a classe toda vez que formos usar.
    // É como um martelo na caixa de ferramentas: é só pegar e usar.
    public static class Seguranca
    {
        public static string CriptografarSenha(string senha)
        {
            // Cria o objeto que faz a criptografia
            using (SHA256 sha256 = SHA256.Create())
            {
                // Transforma a senha digitada (ex: "123") em um array de bytes
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

                // Constrói a nova string embaralhada (o Hash)
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Converte para hexadecimal
                }
                return builder.ToString();
            }
        }
    }
}