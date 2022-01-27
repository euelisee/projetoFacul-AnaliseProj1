using Domain.Entidades.Base;
using Domain.Enum;
using System.Collections.Generic;

namespace Domain.Entidades
{
    public class Empresa : Entity
    {        
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string RazaoSocial { get; set; }
        public string Inscricao { get; set; }

        public TipoPessoa TipoPessoa { get; set; }
        public List<Dentista> Dentistas { get; set; }
        public Endereco Endereco { get; set; }
        public List<Telefone> Telefones { get; set; }


    }
}
