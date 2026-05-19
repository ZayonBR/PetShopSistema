using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PetShopSistema.Models;

namespace PetShopSistema.Utils
{
    public static class APIServicos
    {
        // Método assíncrono (Task) para não travar a tela do sistema enquanto busca na internet
        public static async Task<CepModel> BuscarEnderecoPorCEP(string cep)
        {
            // Primeiro limpamos o CEP tirando hífens ou espaços
            cep = cep.Replace("-", "").Trim();

            // Validação rápida: se não tiver 8 números, nem gasta internet
            if (cep.Length != 8) return null;

            string url = $"https://viacep.com.br/ws/{cep}/json/";

            try
            {
                // HttpClient é a ferramenta do C# para acessar links da Web
                using (HttpClient client = new HttpClient())
                {
                    // Faz a chamada e espera a resposta do site
                    HttpResponseMessage response = await client.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        // Lê o texto puro (JSON) que o site do ViaCEP mandou
                        string jsonResult = await response.Content.ReadAsStringAsync();

                        // Se o CEP não existir, o ViaCEP devolve um JSON contendo "erro": true
                        if (jsonResult.Contains("\"erro\":")) return null;

                        // Transforma o texto JSON em um objeto da nossa ViaCepModel
                        CepModel endereco = JsonConvert.DeserializeObject<CepModel>(jsonResult);
                        return endereco;
                    }
                }
            }
            catch (Exception)
            {
                // Se cair a internet ou o site do ViaCEP estiver fora do ar, retorna nulo
                return null;
            }

            return null;
        }
    }
}