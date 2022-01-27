using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Nome).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.Email).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.Senha).HasMaxLength(50).IsVariableLength().IsRequired();
        }
    }
}
