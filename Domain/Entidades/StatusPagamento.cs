using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class StatusPagamento : Entity
    {        
        public string Descricao { get; set; }
        public TipoStatus TipoStatus { get; set; }
        public List<Pagamento> Pagamentos { get; set; }

    }
}