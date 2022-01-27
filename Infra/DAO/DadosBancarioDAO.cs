
using Domain.Entidades;
using Domain.Helpers;
using Infra.Context;
using Infra.DAO.Base;
using System.Collections.Generic;
using System.Linq;

namespace Infra.DAO
{
    public class DadosBancarioDAO : CrudDAOProjFacul<DadosBancario>
    {
        public DadosBancarioDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<DadosBancario> PaginatorAll(DadosBancario pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<DadosBancario> dadosBancarioList = new List<DadosBancario>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Banco))
            {
                query = query.Where (c => c.Banco.Contains(pesquisa.Banco.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Agencia))
            {
                query = query.Where(c => c.Agencia.Contains(pesquisa.Agencia.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Conta))
            {
                query = query.Where(c => c.Conta.Contains(pesquisa.Conta.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Digito))
            {
                query = query.Where(c => c.Digito.Contains(pesquisa.Digito.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Documento))
            {
                query = query.Where(c => c.Documento.Contains(pesquisa.Documento.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Nome))
            {
                query = query.Where(c => c.Nome.Contains(pesquisa.Nome.Trim()));
            }

            dadosBancarioList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<DadosBancario>(dadosBancarioList, countItens, currentPage, ItensPerpage);

        }
    }
}
