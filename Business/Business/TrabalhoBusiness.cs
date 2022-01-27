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
    public class TrabalhoBusiness
    {
        private TrabalhoDAO TrabalhoDAO { get; set; }

        public TrabalhoBusiness(ContextProjFacul context = null)
        {
            TrabalhoDAO = new TrabalhoDAO(context);
        }
        public void Dispose()
        {
            TrabalhoDAO.Dispose();
        }
        public Trabalho BuscaPorId(long id)
        {
            try
            {
                return TrabalhoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Trabalho> BuscaTrabalhoPaginator(Trabalho trabalhoPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = TrabalhoDAO.PaginatorAll(trabalhoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Trabalho Save(Trabalho trabalho)
        {
            try
            {
                Trabalho retorno = null;
                if (trabalho.Id > 0)
                {
                    retorno = TrabalhoDAO.Update(trabalho);

                }
                else
                {
                    retorno = TrabalhoDAO.Save(trabalho);
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

