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
    public class ServicoBusiness
    {
        private ServicoDAO ServicoDAO { get; set; }

        public ServicoBusiness(ContextProjFacul context = null)
        {
            ServicoDAO = new ServicoDAO(context);
        }
        public void Dispose()
        {
            ServicoDAO.Dispose();
        }
        public Servico BuscaPorId(long id)
        {
            try
            {
                return ServicoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Servico> BuscaServicoPaginator(Servico servicoPesquisa,
            int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = ServicoDAO.PaginatorAll(servicoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Servico Save(Servico servico)
        {
            try
            {
                Servico retorno = null;
                if (servico.Id > 0)
                {
                    retorno = ServicoDAO.Update(servico);

                }
                else
                {
                    retorno = ServicoDAO.Save(servico);
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

