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
    public class PagamentoBusiness
    {
        private PagamentoDAO PagamentoDAO { get; set; }

        public PagamentoBusiness(ContextProjFacul context = null)
        {
            PagamentoDAO = new PagamentoDAO(context);
        }
        public void Dispose()
        {
            PagamentoDAO.Dispose();
        }
        public Pagamento BuscaPorId(long id)
        {
            try
            {
                return PagamentoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Pagamento> BuscaPagamentoPaginator(Pagamento pagamentoPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = PagamentoDAO.PaginatorAll(pagamentoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Pagamento Save(Pagamento pagamento)
        {
            try
            {
                Pagamento retorno = null;
                if (pagamento.Id > 0)
                {
                    retorno = PagamentoDAO.Update(pagamento);

                }
                else
                {
                    retorno = PagamentoDAO.Save(pagamento);
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

