using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class StatusTrabalhoConfig : EntityTypeConfiguration<StatusTrabalho>
    {
        public StatusTrabalhoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Descricao).HasMaxLength(200).IsVariableLength().IsRequired();

            Property(db => db.TipoStatus);

            HasMany(db => db.Trabalhos)
               .WithRequired(serv => serv.Status)
               .HasForeignKey(db => db.IdStatus);

        }
    }
    
   
}
