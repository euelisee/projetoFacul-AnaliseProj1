using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Servico : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public TipoStatus TipoStatus { get; set; }
        public string Cor { get; set; }
        public float ValorUnitario { get; set; }
        public List<Trabalho> Trabalhos { get; set; }

    }
}
