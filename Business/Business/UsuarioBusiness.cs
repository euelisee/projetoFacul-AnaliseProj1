using Domain.Entidades;
using Domain.Helpers;
using Infra.Context;
using Infra.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Business
{
    public class UsuarioBusiness
    {
        private UsuarioDAO UsuarioDAO { get; set; }

        public UsuarioBusiness(ContextProjFacul context = null)
        {
            UsuarioDAO = new UsuarioDAO(context);
        }
        public void Dispose()
        {
            UsuarioDAO.Dispose();
        }
        public Usuario BuscaPorId(long id)
        {
            try
            {
                return UsuarioDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Usuario> BuscaUsuarioPaginator(Usuario usuarioPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = UsuarioDAO.PaginatorAll(usuarioPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Usuario Save(Usuario usuario)
        {
            try
            {
                Usuario retorno = null;
                if (usuario.Id > 0)
                {
                    retorno = UsuarioDAO.Update(usuario);

                }
                else
                {
                    retorno = UsuarioDAO.Save(usuario);
                }
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
