using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class DentistaConfig : EntityTypeConfiguration<Dentista>
    {
        public DentistaConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Nome).HasMaxLength(200).IsVariableLength().IsRequired();
            Property(db => db.CRO).HasMaxLength(10).IsVariableLength().IsRequired();
            Property(db => db.Documento).HasMaxLength(20).IsVariableLength().IsRequired();
            // Property(db => db.RelacaoEmpresa)
            Property(db => db.TipoStatus);

            HasMany(db => db.Pacientes)
                .WithRequired(pac => pac.Dentista)
                .HasForeignKey(pac => pac.IdDentista);


            HasMany(db => db.Telefones)
                .WithOptional(tel=>tel.Dentista)
                .HasForeignKey(tel=>tel.IdDentista);

            HasMany(db => db.Trabalhos)
                .WithRequired(trab => trab.Dentista)
                .HasForeignKey(trab => trab.IdDentista);

            HasMany(db => db.Empresas)
                .WithMany(emp => emp.Dentistas)
                .Map(x =>
                {
                    x.MapLeftKey("IdDentista");
                    x.MapRightKey("IdEmpresa");
                    x.ToTable("Dentista_Empresa");
                });

            HasOptional(db => db.Endereco).WithOptionalDependent(end => end.Dentista);

        }
    }
}
