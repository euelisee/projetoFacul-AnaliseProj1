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
    public class EnderecoDAO : CrudDAOProjFacul<Endereco>
    {
        public EnderecoDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<Endereco> PaginatorAll(Endereco pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Endereco> enderecoList = new List<Endereco>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Logradouro))
            {
                query = query.Where(c => c.Logradouro.Contains(pesquisa.Logradouro.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Numero))
            {
                query = query.Where(c => c.Numero.Contains(pesquisa.Numero.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Complemento))
            {
                query = query.Where(c => c.Complemento.Contains(pesquisa.Complemento.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Bairro))
            {
                query = query.Where(c => c.Bairro.Contains(pesquisa.Bairro.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Cidade))
            {
                query = query.Where(c => c.Cidade.Contains(pesquisa.Cidade.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.CEP))
            {
                query = query.Where(c => c.CEP.Contains(pesquisa.CEP.Trim()));
            }

            enderecoList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Endereco>(enderecoList, countItens, currentPage, ItensPerpage);



        }

    }
}
