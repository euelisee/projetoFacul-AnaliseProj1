using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Titulo).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.Descricao).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.Cor).HasMaxLength(50).IsVariableLength().IsRequired();
            Property(db => db.ValorUnitario);


            Property(db => db.TipoStatus);

            HasMany(db => db.Trabalhos)
               .WithRequired(sev => sev.Servico)
               .HasForeignKey(db => db.IdServico);



        }

    }
}
