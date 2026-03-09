using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Queries
{
    public class ObtenerPaqueteQuery: IRequest<OperationResult<Paquete>>
    {
        public Guid PaqueteId { get; set; }
    }
}
