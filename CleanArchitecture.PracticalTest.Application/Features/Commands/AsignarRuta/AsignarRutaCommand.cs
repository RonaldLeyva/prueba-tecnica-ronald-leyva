using CleanArchitecture.PracticalTest.Application.DTO.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Commands.AsignarRuta
{
    public class AsignarRutaCommand: IRequest<OperationResult<Guid>>
    {
        public Guid PaqueteId { get; set; }
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public decimal DistanciaEnKm { get; set; }
        public decimal HorasEstimadas { get; set; }
    }
}
