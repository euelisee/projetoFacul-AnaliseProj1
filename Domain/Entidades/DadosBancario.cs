using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

/// <summary>
/// Na pasta entidades tudo o que está dentro dela é referente as entidades de 
/// cada classe que eu irei trabalhar nesse software,onde basicamente ele irá se vincular a 
/// um BD para gerar as entidades se são abertas ou fechadas.
/// </summary>
namespace Domain.Entidades
{
    public class DadosBancario:Entity
    {       
        public string Banco { get; set; }
        public string Agencia { get; set; }
        public string Conta { get; set; }
        public string Digito { get; set; }
        public string Documento { get; set; }
        public string Nome { get; set; }
        public TipoStatus TipoStatus { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        public List <Pagamento> Pagamentos { get; set; }
        


    }
}