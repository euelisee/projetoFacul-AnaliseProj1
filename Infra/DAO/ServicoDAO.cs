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
    public class ServicoDAO : CrudDAOProjFacul<Servico>
    {
        public ServicoDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<Servico> PaginatorAll(Servico pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Servico> servicoList = new List<Servico>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Titulo))
            {
                query = query.Where(c => c.Titulo.Contains(pesquisa.Titulo.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Descricao))
            {
                query = query.Where(c => c.Descricao.Contains(pesquisa.Descricao.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Cor))
            {
                query = query.Where(c => c.Cor.Contains(pesquisa.Cor.Trim()));
            }
            if (pesquisa.ValorUnitario>0)
            {
                query = query.Where(c => c.ValorUnitario.Equals(pesquisa.ValorUnitario));
            }
            servicoList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Servico>(servicoList, countItens, currentPage, ItensPerpage);



        }
    }
}
