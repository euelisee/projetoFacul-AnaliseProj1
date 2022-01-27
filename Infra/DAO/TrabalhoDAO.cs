using Domain.Entidades;
using Domain.Helpers;
using Infra.Context;
using Infra.DAO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DAO
{
    public class TrabalhoDAO : CrudDAOProjFacul<Trabalho>
    {
        public TrabalhoDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<Trabalho> PaginatorAll(Trabalho pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Trabalho> trabalhoList = new List<Trabalho>();
            int countItens = 0;

            var query = DbSet.Select(c => c);

            trabalhoList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Trabalho>(trabalhoList, countItens, currentPage, ItensPerpage);



        }
    }
}
