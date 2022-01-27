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
    public class StatusPagamentoDAO : CrudDAOProjFacul<StatusPagamento>
    {
        public StatusPagamentoDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<StatusPagamento> PaginatorAll(StatusPagamento pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<StatusPagamento> statusPagamentoList = new List<StatusPagamento>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Descricao))
            {
                query = query.Where(c => c.Descricao.Contains(pesquisa.Descricao.Trim()));
            }

            statusPagamentoList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<StatusPagamento>(statusPagamentoList, countItens, currentPage, ItensPerpage);



        }
    }
}
