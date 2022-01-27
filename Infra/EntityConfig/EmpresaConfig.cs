using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    class EmpresaConfig : EntityTypeConfiguration<Empresa>
    {
        public EmpresaConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.CPF).HasMaxLength(11).IsFixedLength().IsOptional();
            Property(db => db.CNPJ).HasMaxLength(14).IsFixedLength().IsOptional();
            Property(db => db.RazaoSocial).HasMaxLength(200).IsVariableLength().IsOptional();
            Property(db => db.Inscricao).HasMaxLength(50).IsVariableLength().IsOptional();

            Property(db => db.TipoPessoa);

           HasMany(db=>db.Dentistas)
                .WithMany(den=>den.Empresas)
                .Map(x =>
                {
                    x.MapLeftKey("IdDentista");
                    x.MapRightKey("IdEmpresa");
                    x.ToTable("Dentista_Empresa");
                });

            HasRequired(db => db.Endereco)
                .WithOptional(end => end.Empresa);

            HasMany(db => db.Telefones)
                .WithOptional(tel => tel.Empresa)
                .HasForeignKey(tel => tel.IdEmpresa);


        }
    }
}
