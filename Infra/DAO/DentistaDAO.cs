using Domain.Entidades;
using Domain.Helpers;
using Infra.Context;
using Infra.DAO.Base;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace Infra.DAO
{
    public class DentistaDAO : CrudDAOProjFacul <Dentista>
    {
        public DentistaDAO(ContextProjFacul context = null) : base(context)
        {

        }

        public Dentista BuscaDentistaEdicao(long id)
        {
            return DbSet.Include(x => x.Telefones).Include(x => x.Empresas).FirstOrDefault(x => x.Id == id);
                 
        }

        public Paginator<Dentista> PaginatorAll(Dentista pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Dentista> dentistaList = new List<Dentista>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Nome))
            {
                query = query.Where(c => c.Nome.Contains(pesquisa.Nome.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.CRO))
            {
                query = query.Where(c => c.CRO.Contains(pesquisa.CRO.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Documento))
            {
                query = query.Where(c => c.Documento.Contains(pesquisa.Documento.Trim()));
            }

            dentistaList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Dentista>(dentistaList, countItens, currentPage, ItensPerpage);



        }
    }
}
