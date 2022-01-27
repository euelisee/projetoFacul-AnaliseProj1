using Domain.Entidades;
using Infra.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class ContextProjFacul : DbContext
    {
        public ContextProjFacul() : base("ConexaoPrimaria")           
        {
             
        }
        public DbSet<DadosBancario> DadosBancarios { get; set; }
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<StatusPagamento> StatusPagamentos { get; set; }
        public DbSet<StatusTrabalho> StatusTrabalhos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Trabalho> Trabalhos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //remocao da pluralizacao para eu mesma customizar pois a pluralizacao e ingles 
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //remocao em cascata para evitar o bd ficar sem nada 1 pra muitos
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();// remocao em cascata para evitar o bd ficar sem nada muitos pra muitos

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new DadosBancarioConfig());
            modelBuilder.Configurations.Add(new DentistaConfig());
            modelBuilder.Configurations.Add(new EmpresaConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new PacienteConfig());
            modelBuilder.Configurations.Add(new PagamentoConfig());
            modelBuilder.Configurations.Add(new ServicoConfig());
            modelBuilder.Configurations.Add(new StatusPagamentoConfig());
            modelBuilder.Configurations.Add(new StatusTrabalhoConfig());
            modelBuilder.Configurations.Add(new TelefoneConfig());
            modelBuilder.Configurations.Add(new TrabalhoConfig());
            modelBuilder.Configurations.Add(new UsuarioConfig());


            base.OnModelCreating(modelBuilder);


        }
    }
}
