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
    public class StatusTrabalhoBusiness
    {
        private StatusTrabalhoDAO StatusTrabalhoDAO { get; set; }

        public StatusTrabalhoBusiness(ContextProjFacul context = null)
        {
            StatusTrabalhoDAO = new StatusTrabalhoDAO(context);
        }
        public void Dispose()
        {
            StatusTrabalhoDAO.Dispose();
        }
        public StatusTrabalho BuscaPorId(long id)
        {
            try
            {
                return StatusTrabalhoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<StatusTrabalho> BuscaStatusTrabalhoPaginator(StatusTrabalho statusTrabalhoPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = StatusTrabalhoDAO.PaginatorAll(statusTrabalhoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public StatusTrabalho Save(StatusTrabalho statusTrabalho)
        {
            try
            {
                StatusTrabalho retorno = null;
                if (statusTrabalho.Id > 0)
                {
                    retorno = StatusTrabalhoDAO.Update(statusTrabalho);

                }
                else
                {
                    retorno = StatusTrabalhoDAO.Save(statusTrabalho);
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
