using System;
using System.Text.RegularExpressions;

namespace PetShopSistema.Utils
{
    public static class Validadores
    {
        // 1. REGEX PARA E-MAIL (Padrão de mercado)
        public static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            string modeloEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, modeloEmail);
        }

        // 2. REGEX PARA TELEFONE (Celular ou Fixo com DDD)
        public static bool ValidarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone)) return false;

            // Aceita: (11) 99999-9999, 11999999999, 11 99999-9999, etc.
            string modeloTelefone = @"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$";
            return Regex.IsMatch(telefone, modeloTelefone);
        }

        // 3. REGEX PARA CEP
        public static bool ValidarCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep)) return false;

            // Aceita: 11111-111 ou apenas 11111111
            string modeloCEP = @"^\d{5}-?\d{3}$";
            return Regex.IsMatch(cep, modeloCEP);
        }
    }
}