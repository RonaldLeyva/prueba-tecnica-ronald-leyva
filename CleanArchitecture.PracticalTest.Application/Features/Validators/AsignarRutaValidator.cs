using CleanArchitecture.PracticalTest.Application.Features.Commands.AsignarRuta;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Validators
{
    public class AsignarRutaValidator: AbstractValidator<AsignarRutaCommand>
    {
        public AsignarRutaValidator()
        {
            RuleFor(x => x.PaqueteId).NotEmpty();
            RuleFor(x => x.Origen).NotEmpty();
            RuleFor(x => x.Destino).NotEmpty();
            RuleFor(x => x.DistanciaEnKm).GreaterThan(0);
            RuleFor(x => x.HorasEstimadas).GreaterThan(0);
        }
    }
}
