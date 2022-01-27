namespace Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DadosBancario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Banco = c.String(nullable: false, maxLength: 3, unicode: false),
                        Agencia = c.String(nullable: false, maxLength: 7, unicode: false),
                        Conta = c.String(nullable: false, maxLength: 7, unicode: false),
                        Digito = c.String(nullable: false, maxLength: 1, unicode: false),
                        Documento = c.String(nullable: false, maxLength: 14, unicode: false),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        TipoStatus = c.Int(nullable: false),
                        TipoPessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pagamento",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        DataPrevistaPagamento = c.DateTime(nullable: false),
                        DataPagamento = c.DateTime(nullable: false),
                        ValorTotal = c.Single(nullable: false),
                        ValorPago = c.Single(nullable: false),
                        TipoPagamento = c.Int(nullable: false),
                        IdStatusPagamento = c.Long(nullable: false),
                        IdDadosBancario = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DadosBancario", t => t.IdDadosBancario)
                .ForeignKey("dbo.StatusPagamento", t => t.IdStatusPagamento)
                .ForeignKey("dbo.Trabalho", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.IdStatusPagamento)
                .Index(t => t.IdDadosBancario);
            
            CreateTable(
                "dbo.StatusPagamento",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        TipoStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trabalho",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        DataEntrada = c.DateTime(nullable: false),
                        DataSaida = c.DateTime(nullable: false),
                        IdDentista = c.Long(nullable: false),
                        IdServico = c.Long(nullable: false),
                        IdPaciente = c.Long(nullable: false),
                        IdStatus = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Paciente", t => t.IdPaciente)
                .ForeignKey("dbo.Dentista", t => t.IdDentista)
                .ForeignKey("dbo.Servico", t => t.IdServico)
                .ForeignKey("dbo.StatusTrabalho", t => t.IdStatus)
                .Index(t => t.IdDentista)
                .Index(t => t.IdServico)
                .Index(t => t.IdPaciente)
                .Index(t => t.IdStatus);
            
            CreateTable(
                "dbo.Dentista",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        CRO = c.String(nullable: false, maxLength: 10, unicode: false),
                        Documento = c.String(nullable: false, maxLength: 20, unicode: false),
                        TipoStatus = c.Int(nullable: false),
                        Endereco_Id = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Endereco_Id)
                .Index(t => t.Endereco_Id);
            
            CreateTable(
                "dbo.Empresa",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CPF = c.String(maxLength: 11, unicode: false),
                        CNPJ = c.String(maxLength: 14, unicode: false),
                        RazaoSocial = c.String(maxLength: 200, unicode: false),
                        Inscricao = c.String(maxLength: 50, unicode: false),
                        TipoPessoa = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Endereco", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Endereco",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Logradouro = c.String(nullable: false, maxLength: 100, unicode: false),
                        Numero = c.String(maxLength: 5, unicode: false),
                        Complemento = c.String(maxLength: 50, unicode: false),
                        Bairro = c.String(nullable: false, maxLength: 50, unicode: false),
                        Cidade = c.String(nullable: false, maxLength: 255, unicode: false),
                        CEP = c.String(nullable: false, maxLength: 8, unicode: false),
                        TipoEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Telefone",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        Numero = c.String(nullable: false, maxLength: 10, unicode: false),
                        IdEmpresa = c.Long(),
                        IdDentista = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Empresa", t => t.IdEmpresa)
                .ForeignKey("dbo.Dentista", t => t.IdDentista)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdDentista);
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        IdDentista = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dentista", t => t.IdDentista)
                .Index(t => t.IdDentista);
            
            CreateTable(
                "dbo.Servico",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 200, unicode: false),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        TipoStatus = c.Int(nullable: false),
                        Cor = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValorUnitario = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StatusTrabalho",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descricao = c.String(nullable: false, maxLength: 200, unicode: false),
                        TipoStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 200, unicode: false),
                        Email = c.String(nullable: false, maxLength: 200, unicode: false),
                        Senha = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dentista_Empresa",
                c => new
                    {
                        IdEmpresa = c.Long(nullable: false),
                        IdDentista = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEmpresa, t.IdDentista })
                .ForeignKey("dbo.Dentista", t => t.IdEmpresa)
                .ForeignKey("dbo.Empresa", t => t.IdDentista)
                .Index(t => t.IdEmpresa)
                .Index(t => t.IdDentista);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagamento", "Id", "dbo.Trabalho");
            DropForeignKey("dbo.Trabalho", "IdStatus", "dbo.StatusTrabalho");
            DropForeignKey("dbo.Trabalho", "IdServico", "dbo.Servico");
            DropForeignKey("dbo.Trabalho", "IdDentista", "dbo.Dentista");
            DropForeignKey("dbo.Telefone", "IdDentista", "dbo.Dentista");
            DropForeignKey("dbo.Paciente", "IdDentista", "dbo.Dentista");
            DropForeignKey("dbo.Trabalho", "IdPaciente", "dbo.Paciente");
            DropForeignKey("dbo.Dentista", "Endereco_Id", "dbo.Endereco");
            DropForeignKey("dbo.Dentista_Empresa", "IdDentista", "dbo.Empresa");
            DropForeignKey("dbo.Dentista_Empresa", "IdEmpresa", "dbo.Dentista");
            DropForeignKey("dbo.Telefone", "IdEmpresa", "dbo.Empresa");
            DropForeignKey("dbo.Empresa", "Id", "dbo.Endereco");
            DropForeignKey("dbo.Pagamento", "IdStatusPagamento", "dbo.StatusPagamento");
            DropForeignKey("dbo.Pagamento", "IdDadosBancario", "dbo.DadosBancario");
            DropIndex("dbo.Dentista_Empresa", new[] { "IdDentista" });
            DropIndex("dbo.Dentista_Empresa", new[] { "IdEmpresa" });
            DropIndex("dbo.Paciente", new[] { "IdDentista" });
            DropIndex("dbo.Telefone", new[] { "IdDentista" });
            DropIndex("dbo.Telefone", new[] { "IdEmpresa" });
            DropIndex("dbo.Empresa", new[] { "Id" });
            DropIndex("dbo.Dentista", new[] { "Endereco_Id" });
            DropIndex("dbo.Trabalho", new[] { "IdStatus" });
            DropIndex("dbo.Trabalho", new[] { "IdPaciente" });
            DropIndex("dbo.Trabalho", new[] { "IdServico" });
            DropIndex("dbo.Trabalho", new[] { "IdDentista" });
            DropIndex("dbo.Pagamento", new[] { "IdDadosBancario" });
            DropIndex("dbo.Pagamento", new[] { "IdStatusPagamento" });
            DropIndex("dbo.Pagamento", new[] { "Id" });
            DropTable("dbo.Dentista_Empresa");
            DropTable("dbo.Usuario");
            DropTable("dbo.StatusTrabalho");
            DropTable("dbo.Servico");
            DropTable("dbo.Paciente");
            DropTable("dbo.Telefone");
            DropTable("dbo.Endereco");
            DropTable("dbo.Empresa");
            DropTable("dbo.Dentista");
            DropTable("dbo.Trabalho");
            DropTable("dbo.StatusPagamento");
            DropTable("dbo.Pagamento");
            DropTable("dbo.DadosBancario");
        }
    }
}
