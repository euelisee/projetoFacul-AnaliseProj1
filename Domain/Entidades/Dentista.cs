using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Dentista : Entity
    {        
        public string Nome { get; set; }
       
        public string CRO { get; set; }
        public string Documento { get; set; }

        public Endereco Endereco { get; set; }
        public List<Empresa> Empresas { get; set; }
        public TipoStatus TipoStatus { get; set; }        
        public List<Telefone> Telefones { get; set; }
        public List<Paciente> Pacientes { get; set; }
        public List<Trabalho> Trabalhos { get; set; }

    }
}
