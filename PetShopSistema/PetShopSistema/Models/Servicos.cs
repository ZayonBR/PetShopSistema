namespace PetShopSystem.Models
{
    public class Servico
    {
        public int IdServico { get; set; }       // No SQL: INT PRIMARY KEY
        public string NomeServico { get; set; }  // No SQL: VARCHAR(100)

        // Diferencial de projeto: Sempre use 'decimal' no C# para dinheiro. 
        // Nunca use 'float' ou 'double', pois eles causam erros de arredondamento em centavos.
        public decimal Valor { get; set; }       // No SQL: DECIMAL(10,2)
    }

}