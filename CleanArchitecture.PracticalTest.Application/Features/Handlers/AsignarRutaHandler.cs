using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Exceptions;
using CleanArchitecture.PracticalTest.Application.Features.Commands.AsignarRuta;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Handlers
{
    public class AsignarRutaHandler : IRequestHandler<AsignarRutaCommand, OperationResult<Guid>>
    {
        private readonly IContextDb _context;

        public AsignarRutaHandler(IContextDb context)
        {
            this._context = context;
        }
        public async Task<OperationResult<Guid>> Handle(AsignarRutaCommand request, CancellationToken cancellationToken)
        {
            var paquete = await _context.GetByIdAsync(request.PaqueteId)
                ?? throw new NotFoundException("Paquete no encontrado", request.PaqueteId);

            var ruta = new Ruta() { Origen = request.Origen, Destino = request.Destino, DistanciaEnKm = request.DistanciaEnKm,
                HorasEstimadas = request.HorasEstimadas };

            paquete.AsignarRuta(ruta);
            await _context.UpdateAsync(paquete);

            decimal distancia = request.DistanciaEnKm;
            var costo = paquete.CalcularCostoDeEnvio(distancia);

            var metaData = new Dictionary<string, object> { { "Costo", costo } };
            return OperationResult.With(paquete.Id, metadata: metaData);
        }
    }
}
