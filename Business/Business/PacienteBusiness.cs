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
    public class PacienteBusiness
    {
        private PacienteDAO PacienteDAO { get; set; }

        public PacienteBusiness(ContextProjFacul context = null)
        {
            PacienteDAO = new PacienteDAO(context);
        }
        public void Dispose()
        {
            PacienteDAO.Dispose();
        }
        public Paciente BuscaPorId(long id)
        {
            try
            {
                return PacienteDAO.FindById(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paginator<Paciente> BuscaPacientePaginator(Paciente pacientePesquisa, int paginaAtual = 1, int itensPagina = 30)
        {
            try
            {
                var retorno = PacienteDAO.PaginatorAll(pacientePesquisa, paginaAtual, itensPagina);
                return retorno;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public Paciente Save(Paciente paciente)
        {
            try
            {
                Paciente retorno = null;
                if (paciente.Id > 0)
                {
                    retorno = PacienteDAO.Update(paciente);

                }
                else
                {
                    retorno = PacienteDAO.Save(paciente);
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
