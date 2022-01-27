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
    public class PagamentoDAO : CrudDAOProjFacul<Pagamento>
    {
        public PagamentoDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<Pagamento> PaginatorAll(Pagamento pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Pagamento> pagamentoList = new List<Pagamento>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (pesquisa.ValorTotal>0)
            {
                query = query.Where(c => c.ValorTotal.Equals(pesquisa.ValorTotal));
            }
            if (pesquisa.ValorPago > 0)
            {
                query = query.Where(c => c.ValorPago.Equals(pesquisa.ValorPago));
            }

            pagamentoList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Pagamento>(pagamentoList, countItens, currentPage, ItensPerpage);



        }
    }
}
