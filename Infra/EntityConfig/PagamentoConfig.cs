using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class PagamentoConfig : EntityTypeConfiguration<Pagamento>
    {
        public PagamentoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.DataPrevistaPagamento);
            Property(db => db.DataPagamento);
            Property(db => db.ValorTotal);
            Property(db => db.ValorPago);

            Property(db => db.TipoPagamento);

            HasRequired(db => db.StatusPagamento)
                .WithMany(pag => pag.Pagamentos)
                .HasForeignKey(db => db.IdStatusPagamento);


            HasRequired(db => db.Trabalho)
                .WithRequiredDependent(pag=>pag.Pagamento);

            HasRequired(db => db.DadosBancario)
               .WithMany(pag => pag.Pagamentos)
               .HasForeignKey(db => db.IdDadosBancario);


        }



    }
}
