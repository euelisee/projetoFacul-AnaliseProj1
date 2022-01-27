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
   public class EmpresaBusiness
    {
        private EmpresaDAO EmpresaDAO { get; set; }

        public EmpresaBusiness(ContextProjFacul context = null)
        {
            EmpresaDAO = new EmpresaDAO(context);
        }
        public void Dispose()
        {
            EmpresaDAO.Dispose();
        }

        public object BuscaEmpresaPaginator(Empresa empresa, object page)
        {
            throw new NotImplementedException();
        }

        public Empresa BuscaPorId(long id)
        {
            try
            {
                return EmpresaDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Empresa> BuscaEmpresaPaginator(Empresa empresaPesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = EmpresaDAO.PaginatorAll(empresaPesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Empresa Save(Empresa empresa)
        {
            try
            {
                Empresa retorno = null;
                if (empresa.Id > 0)
                {
                    retorno = EmpresaDAO.Update(empresa);

                }
                else
                {
                    retorno = EmpresaDAO.Save(empresa);
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
