using Domain.Entidades;
using Domain.Helpers;
using Infra.Context;
using Infra.DAO.Base;
using System.Collections.Generic;
using System.Linq;

namespace Infra.DAO
{
    public class EmpresaDAO : CrudDAOProjFacul<Empresa>
    {
        public EmpresaDAO(ContextProjFacul context = null) : base(context)
        {

        }
        
        public Paginator<Empresa> PaginatorAll(Empresa pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Empresa> empresaList = new List<Empresa>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.CPF))
            {
                query = query.Where(c => c.CPF.Contains(pesquisa.CPF.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.CNPJ))
            {
                query = query.Where(c => c.CNPJ.Contains(pesquisa.CNPJ.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.RazaoSocial))
            {
                query = query.Where(c => c.RazaoSocial.Contains(pesquisa.RazaoSocial.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Inscricao))
            {
                query = query.Where(c => c.Inscricao.Contains(pesquisa.Inscricao.Trim()));
            }

            empresaList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Empresa>(empresaList, countItens, currentPage, ItensPerpage);



        }
    }
}
