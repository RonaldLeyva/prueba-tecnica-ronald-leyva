using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Exceptions;
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
    public class ObtenerPaqueteHandler : IRequestHandler<ObtenerPaqueteQuery, OperationResult<Paquete>>
    {
        private readonly IContextDb _context;

        public ObtenerPaqueteHandler(IContextDb context)
        {
            this._context = context;
        }
        public async Task<OperationResult<Paquete>> Handle(ObtenerPaqueteQuery request, CancellationToken cancellationToken)
        {
            var paquete = await _context.GetByIdAsync(request.PaqueteId);
            if (paquete == null)
                throw new NotFoundException("Paquete no encontrado", request.PaqueteId);

            var metaData = new Dictionary<string, object> { { "PaqueteId", paquete.Id } };
            return OperationResult.With(paquete, metadata: metaData);
        }
    }
}
