using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Queries;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Handlers
{
    public class ObtenerPaquetesHandler : IRequestHandler<ObtenerPaginadoQuery, Paginacion<Paquete>>
    {
        private readonly IContextDb _context;

        public ObtenerPaquetesHandler(IContextDb context)
        {
            this._context = context;
        }
        public Task<Paginacion<Paquete>> Handle(ObtenerPaginadoQuery request, CancellationToken cancellationToken)
        {
            var query = _context.PaquetesQuery();

            if(request.Estado != null)
            {
                query = query.Where(x => x.Estatus == request.Estado);
            }

            if(request.FechaInicio.HasValue)
            {
                var inicioDia = DateTime.SpecifyKind(request.FechaInicio.Value.Date, DateTimeKind.Utc);

                query = query.Where(x => x.CreatedAt >= inicioDia);
            }

            if(request.FechaFin.HasValue)
            {
                var fechaFin = DateTime.SpecifyKind(request.FechaFin.Value.Date, DateTimeKind.Utc);

                query = query.Where(x => x.CreatedAt <= fechaFin);
            }
            var data = query.ToList();

            var totalPaginas = query.Count();
            var items = data
                .OrderBy(x => x.CreatedAt)
                .Skip((request.NumeroPagina - 1) * request.RegistrosPorPagina)
                .Take(request.RegistrosPorPagina)
                .ToList();

            var result = new Paginacion<Paquete>
            {
                Items = items,
                TotalRegistros = totalPaginas,
                NumeroPaginas = request.NumeroPagina,
                RegistrosPorPagina = request.RegistrosPorPagina
            };
            return Task.FromResult(result);
        }
    }
}
