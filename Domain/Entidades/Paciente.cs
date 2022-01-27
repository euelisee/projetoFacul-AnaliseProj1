using Domain.Entidades.Base;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Paciente : Entity
    {
        public long IdPaciente { get; set; }
        public string Nome { get; set; }
        public long IdDentista { get; set; }
        public Dentista Dentista { get; set; }
        public List<Trabalho> Trabalhos { get; set; }


    }
}
