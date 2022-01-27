using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class StatusTrabalho : Entity
    {
        public string Descricao { get; set; }        
        public TipoStatus TipoStatus { get; set; }
        public List<Trabalho> Trabalhos { get; set; }


    }
}