using Domain.Entidades.Base;
using Domain.Enum;

namespace Domain.Entidades
{
    public class Endereco : Entity
    {        
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string CEP { get; set; }
        public TipoEstado TipoEstado { get; set; }
        public Empresa Empresa { get; set; }

        public Dentista Dentista { get; set; }

    }
}
