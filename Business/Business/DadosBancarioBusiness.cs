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
    public class DadosBancarioBusiness
    {
        private DadosBancarioDAO DadosBancarioDAO { get; set; }

        public DadosBancarioBusiness(ContextProjFacul context = null)
        {
            DadosBancarioDAO = new DadosBancarioDAO(context);
        }
        public void Dispose()
        {
            DadosBancarioDAO.Dispose();
        }
        public DadosBancario BuscaPorId(long id)
        {
            try
            {
                return DadosBancarioDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<DadosBancario> BuscaDadosBancarioPaginator(DadosBancario dadosBancarioPesquisa,
            int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = DadosBancarioDAO.PaginatorAll(dadosBancarioPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public DadosBancario Save(DadosBancario dadosBancario)
        {
            try
            {
                DadosBancario retorno = null;
                if (dadosBancario.Id > 0)
                {
                    retorno = DadosBancarioDAO.Update(dadosBancario);

                }
                else
                {
                    retorno = DadosBancarioDAO.Save(dadosBancario);
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
