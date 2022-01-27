using Domain.Entidades.Base;

namespace Domain.Entidades
{
    public class Telefone:Entity
    {
        
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public long? IdEmpresa { get; set; }
        public Empresa Empresa {get; set;}
        public long? IdDentista { get; set; }
        public Dentista Dentista { get; set; }
    }
}
