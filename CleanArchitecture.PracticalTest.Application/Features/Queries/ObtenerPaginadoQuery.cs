using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using CleanArchitecture.PracticalTest.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Queries
{
    public class ObtenerPaginadoQuery : IRequest<Paginacion<Paquete>>
    {
        public EstatusPaquete? Estado { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int NumeroPagina { get; set; } = 1;
        public int RegistrosPorPagina { get; set; } = 10;
    }
}
