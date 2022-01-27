using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    class TelefoneConfig : EntityTypeConfiguration<Telefone>
    {
        public TelefoneConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Descricao).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.Numero).HasMaxLength(10).IsVariableLength().IsRequired();

            HasOptional(db => db.Empresa)
                .WithMany(emp => emp.Telefones)
                .HasForeignKey(db => db.IdEmpresa);

            HasOptional(db => db.Dentista)
                .WithMany(den => den.Telefones)
                .HasForeignKey(db => db.IdDentista);



        }
    }
}
