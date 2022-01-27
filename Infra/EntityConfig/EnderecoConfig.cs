using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    class EnderecoConfig : EntityTypeConfiguration<Endereco>

    {
        public EnderecoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Logradouro).HasMaxLength(100).IsVariableLength().IsRequired();
            Property(db => db.Numero).HasMaxLength(5).IsVariableLength().IsOptional();
            Property(db => db.Complemento).HasMaxLength(50).IsVariableLength().IsOptional();
            Property(db => db.Bairro).HasMaxLength(50).IsVariableLength().IsRequired();
            Property(db => db.Cidade).HasMaxLength(255).IsVariableLength().IsRequired();
            Property(db => db.CEP).HasMaxLength(8).IsFixedLength().IsRequired();

            Property(db => db.TipoEstado);

            HasOptional(db => db.Empresa)
                .WithRequired(emp => emp.Endereco);

            HasOptional(db => db.Dentista)
                .WithOptionalPrincipal(dt => dt.Endereco);


        }
    }
}
