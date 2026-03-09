using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.DTO.Common
{
    public class Paginacion<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int TotalRegistros { get; set; }
        public int NumeroPaginas { get; set; }
        public int RegistrosPorPagina { get; set; }
    }
}
