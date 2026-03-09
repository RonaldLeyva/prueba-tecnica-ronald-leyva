using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Commands.ActualizarPaquete
{
    public class ActualizarPaqueteCommand: IRequest<OperationResult<Guid>>
    {
        public Guid PaqueteId { get; set; }
        public EstatusPaquete NuevoEstatus { get; set; }
        public string? Motivo { get; set; }
    }
}
