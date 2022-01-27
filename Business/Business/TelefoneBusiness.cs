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
    public class TelefoneBusiness
    {
        private TelefoneDAO TelefoneDAO { get; set; }

        public TelefoneBusiness(ContextProjFacul context = null)
        {
            TelefoneDAO = new TelefoneDAO(context);
        }
        public void Dispose()
        {
            TelefoneDAO.Dispose();
        }
        public Telefone BuscaPorId(long id)
        {
            try
            {
                return TelefoneDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Telefone> BuscaTelefonePaginator(Telefone telefonePesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = TelefoneDAO.PaginatorAll(telefonePesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Telefone Save(Telefone telefone)
        {
            try
            {
                Telefone retorno = null;
                if (telefone.Id > 0)
                {
                    retorno = TelefoneDAO.Update(telefone);

                }
                else
                {
                    retorno = TelefoneDAO.Save(telefone);
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

