using Domain.Entidades.Base;
using Domain.Enum;
using System;

namespace Domain.Entidades
{
    public class Pagamento : Entity
    {
        public DateTime DataPrevistaPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public float ValorTotal { get; set; }
        public float ValorPago { get; set; }
        public TipoPagamento TipoPagamento { get; set; }
        public long IdStatusPagamento { get; set; }
        public StatusPagamento StatusPagamento { get; set; }
        public Trabalho Trabalho { get; set; }
        public long IdDadosBancario { get; set; }
        public DadosBancario DadosBancario { get; set; }



    }
}
