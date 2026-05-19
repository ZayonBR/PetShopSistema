namespace PetShopSistema.Models
{
    public class CepModel
    {
        // Os nomes precisam ser exatamente esses para o C# conseguir mapear o JSON da API
        public string Cep { get; set; }
        public string Logradouro { get; set; } // É a Rua
        public string Bairro { get; set; }
        public string Localidade { get; set; } // É a Cidade
        public string Uf { get; set; }         // É o Estado (ex: SP)
    }
}