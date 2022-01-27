using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    public class PacienteConfig : EntityTypeConfiguration<Paciente>
    {
        public PacienteConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.Nome).HasMaxLength(200).IsVariableLength().IsRequired();

            HasRequired(db => db.Dentista)
                .WithMany(den => den.Pacientes)
                .HasForeignKey(db => db.IdDentista);//estou mapeando o lado de 1 dentista para muitos pacientes.

            HasMany(db => db.Trabalhos)
                .WithRequired(trab => trab.Paciente)
                .HasForeignKey(trab => trab.IdPaciente);


        }
    }
}
