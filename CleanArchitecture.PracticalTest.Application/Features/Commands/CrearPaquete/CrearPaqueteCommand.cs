using CleanArchitecture.PracticalTest.Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Commands.CrearPaquete
{
    public class CrearPaqueteCommand : IRequest<OperationResult<Guid>>
    {
        public decimal Peso { get; set; }
        public decimal Longitud { get; set; }
        public decimal Ancho { get; set; }
        public decimal Altura { get; set; }
    }
}
