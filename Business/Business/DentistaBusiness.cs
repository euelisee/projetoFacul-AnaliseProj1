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
   public  class DentistaBusiness
    {
        private DentistaDAO DentistaDAO { get; set; }

        public DentistaBusiness(ContextProjFacul context = null)
        {
            DentistaDAO = new DentistaDAO(context);
        }

        

        public void Dispose()
        {
            DentistaDAO.Dispose();
        }
        public Dentista BuscaPorId(long id)
        {
            try
            {
                return DentistaDAO.BuscaDentistaEdicao(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Dentista> BuscaDentistaPaginator(Dentista dentistaPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = DentistaDAO.PaginatorAll(dentistaPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
                
            }
        }
        public Dentista Save(Dentista dentista)
        {
            try
            {
                Dentista retorno = null;
                if (dentista.Id > 0)
                {
                    retorno = DentistaDAO.Update(dentista);

                }
                else
                {
                    retorno = DentistaDAO.Save(dentista);
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
