using Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.EntityConfig
{
    class TrabalhoConfig : EntityTypeConfiguration<Trabalho>
    {
        public TrabalhoConfig()
        {
            HasKey(db => db.Id);

            Property(db => db.DataEntrada);
            Property(db => db.DataSaida);

            HasRequired(db => db.Dentista)
                .WithMany(den => den.Trabalhos)
                .HasForeignKey(db => db.IdDentista);

            HasRequired(db => db.Servico)
                .WithMany(serv => serv.Trabalhos)
                .HasForeignKey(db => db.IdServico);

            HasRequired(db => db.Paciente)
                .WithMany(pac => pac.Trabalhos)
                .HasForeignKey(db => db.IdPaciente);

            HasRequired(db => db.Status)
                .WithMany(status => status.Trabalhos)
                .HasForeignKey(db => db.IdStatus);

            HasRequired(db => db.Pagamento)
                .WithRequiredPrincipal(tab => tab.Trabalho);





        }
    }
   
}
