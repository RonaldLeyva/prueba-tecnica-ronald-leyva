using CleanArchitecture.PracticalTest.Application.Contracts.ContextApplication;
using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Commands.CrearPaquete;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using CleanArchitecture.PracticalTest.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Handlers
{
    public class CrearPaqueteHandler : IRequestHandler<CrearPaqueteCommand, OperationResult<Guid>>
    {
        private readonly IContextDb context;

        public CrearPaqueteHandler(IContextDb context)
        {
            this.context = context;
        }
        public async Task<OperationResult<Guid>> Handle(CrearPaqueteCommand request, CancellationToken cancellationToken)
        {
            var paquete = new Paquete(
                peso: request.Peso,
                longitud: request.Longitud,
                ancho: request.Ancho,
                altura: request.Altura
            );

            await context.AddAsync(paquete);
            var metaData = new Dictionary<string, object> { { "PaqueteId", paquete.Id } };
            return OperationResult.With(paquete.Id, metadata: metaData);
        }
    }
}
