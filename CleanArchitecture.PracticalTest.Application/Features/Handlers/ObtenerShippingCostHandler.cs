using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.Exceptions;
using CleanArchitecture.PracticalTest.Application.Features.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Handlers
{
    public class ObtenerShippingCostHandler : IRequestHandler<ObtenerShippingCostQuery, decimal>
    {
        private readonly IContextDb _context;

        public ObtenerShippingCostHandler(IContextDb context)
        {
            this._context = context;
        }
        public async Task<decimal> Handle(ObtenerShippingCostQuery request, CancellationToken cancellationToken)
        {
            var paquete = await _context.GetByIdAsync(request.PaqueteId);

            if(paquete == null)
                throw new NotFoundException("Paquete no encontrado", request.PaqueteId);

            decimal distancia = request.DistanciaEnKm;

            return paquete.CalcularCostoDeEnvio(distancia);
        }
    }
}
