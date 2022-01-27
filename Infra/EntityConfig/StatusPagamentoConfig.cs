using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class StatusPagamentoConfig : EntityTypeConfiguration<StatusPagamento>
    {
        public StatusPagamentoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Descricao).HasMaxLength(200).IsVariableLength().IsRequired();

            Property(db => db.TipoStatus);

            HasMany(db => db.Pagamentos)
                .WithRequired(pag => pag.StatusPagamento)
                .HasForeignKey(pag => pag.IdStatusPagamento);



        }
    }
}
