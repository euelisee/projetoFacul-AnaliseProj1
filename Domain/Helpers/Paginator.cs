using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public class Paginator<TEntity>
    {
        public virtual IList<TEntity> Conteudo { get; set; }

        public int CountItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CountPages { get; set; }

        public int PaginaAtual { get; set; }

        public int ProximaPagina { get; set; }

        public int PaginaAnterior { get; set; }

        public int FirstItemOfPage { get; set; }

        public int LastItemOfPage { get; set; }
        public string SearchTerm { get; set; }

        public TEntity PrimeiroItem()
        {
            return Conteudo.FirstOrDefault();

        }
        public Paginator()
        {

        }

        public Paginator(IList<TEntity> conteudo, int countItems, int paginaAtual, int itemsPerpage, string searchTerm = null)
        {
            Conteudo = conteudo;
            CountItems = countItems;
            ItemsPerPage = itemsPerpage;
            SearchTerm = searchTerm;
            PaginaAtual = paginaAtual;
            CountPages = (countItems / itemsPerpage);

            if (countItems % ItemsPerPage > 0)
            {
                CountPages++;
            }
            ProximaPagina = CountPages > paginaAtual ? PaginaAtual + 1 : 0;
            PaginaAnterior = PaginaAtual > 1 ? PaginaAtual - 1 : 0;
            FirstItemOfPage = PaginaAnterior * ItemsPerPage + 1;
            LastItemOfPage = PaginaAtual * ItemsPerPage - (PaginaAtual * ItemsPerPage - CountItems);

            if (CountItems > PaginaAtual * ItemsPerPage)
            {
                LastItemOfPage = PaginaAtual * ItemsPerPage;
            }
            else
            {
                LastItemOfPage = CountItems;
            }

        }
    }

}
