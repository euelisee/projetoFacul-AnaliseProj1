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
    public class EnderecoBusiness
    {
        private EnderecoDAO EnderecoDAO { get; set; }

        public EnderecoBusiness(ContextProjFacul context = null)
        {
            EnderecoDAO = new EnderecoDAO(context);
        }
        public void Dispose()
        {
            EnderecoDAO.Dispose();
        }
        public Endereco BuscaPorId(long id)
        {
            try
            {
                return EnderecoDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Endereco> BuscaEnderecoPaginator(Endereco enderecoPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = EnderecoDAO.PaginatorAll(enderecoPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Endereco Save(Endereco endereco)
        {
            try
            {
                Endereco retorno = null;
                if (endereco.Id > 0)
                {
                    retorno = EnderecoDAO.Update(endereco);

                }
                else
                {
                    retorno = EnderecoDAO.Save(endereco);
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
