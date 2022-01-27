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
    public class UsuarioDAO : CrudDAOProjFacul<Usuario>
    {
        public UsuarioDAO(ContextProjFacul context = null) : base(context)
        {

        }
        public Paginator<Usuario> PaginatorAll(Usuario pesquisa, int currentPage = 1, int ItensPerpage = 30)
        {
            if (ItensPerpage <= 0)
            {
                return null;
            }
            List<Usuario> usuarioList = new List<Usuario>();
            int countItens = 0;

            var query = DbSet.Select(c => c);
            if (!string.IsNullOrEmpty(pesquisa.Nome))
            {
                query = query.Where(c => c.Nome.Contains(pesquisa.Nome.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Email))
            {
                query = query.Where(c => c.Email.Contains(pesquisa.Email.Trim()));
            }
            if (!string.IsNullOrEmpty(pesquisa.Senha))
            {
                query = query.Where(c => c.Senha.Contains(pesquisa.Senha.Trim()));
            }
            usuarioList = query
                .OrderByDescending(c => c.Id)
                .Skip((currentPage - 1) * ItensPerpage)
                .Take(ItensPerpage)
                .ToList();

            countItens = query.Count();

            return new Paginator<Usuario>(usuarioList, countItens, currentPage, ItensPerpage);



        }
    }
}
