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
    public class StatusPagementoBusiness
    {
        private StatusPagamentoDAO StatusPagamentoDAO { get; set; }

        public StatusPagementoBusiness(ContextProjFacul context = null)
        {
            StatusPagamentoDAO = new StatusPagamentoDAO(context);
        }
        public void Dispose()
        {
            StatusPagamentoDAO.Dispose();
        }
        public StatusPagamento BuscaPorId(long id)
        {
            try
            {
                return StatusPagamentoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<StatusPagamento> BuscaStatusPagamentoPaginator(StatusPagamento statusPagamentoPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = StatusPagamentoDAO.PaginatorAll(statusPagamentoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public StatusPagamento Save(StatusPagamento statusPagamento)
        {
            try
            {
                StatusPagamento retorno = null;
                if (statusPagamento.Id > 0)
                {
                    retorno = StatusPagamentoDAO.Update(statusPagamento);

                }
                else
                {
                    retorno = StatusPagamentoDAO.Save(statusPagamento);
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
