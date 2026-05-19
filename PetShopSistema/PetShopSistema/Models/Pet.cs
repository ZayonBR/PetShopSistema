namespace PetShopSystem.Models
{
    public class Pet
    {
        public int IdPet { get; set; }           // No SQL: INT PRIMARY KEY
        public string Nome { get; set; }         // No SQL: VARCHAR(100)
        public string Especie { get; set; }      // No SQL: VARCHAR(50)
        public string Raca { get; set; }         // No SQL: VARCHAR(50)
        public int Idade { get; set; }           // No SQL: INT

        // Chave Estrangeira: liga o Pet ao Dono
        public int IdUsuario { get; set; }       // No SQL: INT FOREIGN KEY
    }
}