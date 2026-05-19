using PetShopSistema.DAL_Data_Access_Layer;
using PetShopSistema.Models;
using PetShopSistema.Utils; // Faz o C# enxergar os Validadores e a Criptografia
using PetShopSystem.DAL;
using PetShopSystem.Models;
using PetShopSystem.Utils;
using System;

namespace PetShopSistema.BLL_Business_Logic_Layer
{
    public class UsuarioBLL
    {
        // Instanciamos a DAL para conseguir salvar no banco de dados depois que tudo for validado
        private UsuarioDAL usuarioDAL = new UsuarioDAL();

        public bool CadastrarUsuario(Usuario modelUsuario)
        {
            // 1. VALIDAÇÃO DE CAMPOS OBRIGATÓRIOS
            if (string.IsNullOrWhiteSpace(modelUsuario.Nome) ||
                string.IsNullOrWhiteSpace(modelUsuario.Email) ||
                string.IsNullOrWhiteSpace(modelUsuario.Senha))
            {
                throw new Exception("Nome, E-mail e Senha são campos obrigatórios!");
            }

            // 2. VALIDAÇÃO COM REGEX (As ferramentas que fizemos na Utils)
            if (!Validadores.ValidarEmail(modelUsuario.Email))
            {
                throw new Exception("O formato do E-mail digitado é inválido!");
            }

            if (!Validadores.ValidarTelefone(modelUsuario.Telefone))
            {
                throw new Exception("O formato do Telefone é inválido! Use um padrão com DDD (ex: 13999999999).");
            }

            if (!Validadores.ValidarCEP(modelUsuario.Cep))
            {
                throw new Exception("O CEP digitado é inválido! Deve conter 8 dígitos.");
            }

            // 3. SEGURANÇA: CRIPTOGRAFIA DA SENHA (SHA-256)
            // A senha original "texto puro" é substituída pelo Hash seguro antes de ir pro banco
            modelUsuario.Senha = Seguranca.CriptografarSenha(modelUsuario.Senha);

            // 4. ENVIO PARA O BANCO DE DADOS
            return usuarioDAL.Cadastrar(modelUsuario);
        }
    }
}