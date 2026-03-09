using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Exceptions;
using CleanArchitecture.PracticalTest.Application.Features.Commands.ActualizarPaquete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Handlers
{
    public class ActualizarEstadoHandler : IRequestHandler<ActualizarPaqueteCommand, OperationResult<Guid>>
    {
        private readonly IContextDb _context;

        public ActualizarEstadoHandler(IContextDb context)
        {
            this._context = context;
        }
        public async Task<OperationResult<Guid>> Handle(ActualizarPaqueteCommand request, CancellationToken cancellationToken)
        {
            var paquete = await _context.GetByIdAsync(request.PaqueteId)
                ?? throw new NotFoundException("Paquete no encontrado", request.PaqueteId);

            paquete.ActualizarEstatus(request.NuevoEstatus, request.Motivo!);

            await _context.UpdateAsync(paquete);
            var metaData = new Dictionary<string, object> { { "PaqueteId", paquete.Id } };
            return OperationResult.With(paquete.Id, metadata: metaData);
        }
    }
}
