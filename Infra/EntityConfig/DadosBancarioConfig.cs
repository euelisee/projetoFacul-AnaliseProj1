using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class DadosBancarioConfig : EntityTypeConfiguration<DadosBancario>
    {
        public DadosBancarioConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Banco).HasMaxLength(3).IsVariableLength().IsRequired();
            Property(db => db.Agencia).HasMaxLength(7).IsVariableLength().IsRequired();
            Property(db => db.Conta).HasMaxLength(7).IsVariableLength().IsRequired();
            Property(db => db.Digito).HasMaxLength(1).IsFixedLength().IsRequired();
            Property(db => db.Documento).HasMaxLength(14).IsVariableLength().IsRequired();
            Property(db => db.Nome).HasMaxLength(200).IsVariableLength().IsRequired();

            Property(db => db.TipoStatus);
            Property(db => db.TipoPessoa);



        }
    }
}
