using System;

namespace PetShopSystem.Models
{
    public class Agendamento
    {
        public int IdAgendamento { get; set; }     // No SQL: INT PRIMARY KEY
        public DateTime DataAgendamento { get; set; } // No SQL: DATE

        // Diferencial de projeto: O tipo TIME do SQL Server se traduz 
        // perfeitamente para TimeSpan no C#, facilitando cálculos de horas.
        public TimeSpan Horario { get; set; }      // No SQL: TIME

        public string StatusAgendamento { get; set; } // No SQL: VARCHAR(20) - Ex: 'Pendente', 'Concluído'

        // Chaves Estrangeiras: ligam o Agendamento ao Pet e ao Serviço
        public int IdPet { get; set; }             // No SQL: INT FOREIGN KEY
        public int IdServico { get; set; }         // No SQL: INT FOREIGN KEY
    }
}