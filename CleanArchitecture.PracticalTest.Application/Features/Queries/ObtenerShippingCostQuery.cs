using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Queries
{
    public class ObtenerShippingCostQuery: IRequest<decimal>
    {
        public Guid PaqueteId { get; set; }
        public decimal DistanciaEnKm { get; set; }
    }
}
