using Domain.Entidades.Base;
using System;

namespace Domain.Entidades
{
    public class Trabalho:Entity
    {        
        public DateTime DataEntrada { get; set; }
        public DateTime DataSaida { get; set; }
        public long IdDentista { get; set; }
        public Dentista Dentista { get; set; }
        public long IdServico { get; set; }
        public Servico Servico { get; set; }
        public long IdPaciente { get; set; }
        public Paciente Paciente { get; set; }
        public long IdStatus { get; set; }
        public StatusTrabalho Status { get; set; }
        public Pagamento Pagamento { get; set; }
    }
}
