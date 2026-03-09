using CleanArchitecture.PracticalTest.Application.Features.Commands.CrearPaquete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Validators
{
    public class CrearPaqueteValidator: AbstractValidator<CrearPaqueteCommand>
    {
        public CrearPaqueteValidator()
        {
            RuleFor(x => x.Peso).InclusiveBetween(0.1m, 50m);
            RuleFor(x => x.Longitud).LessThanOrEqualTo(150m);
            RuleFor(x => x.Ancho).LessThanOrEqualTo(150m);
            RuleFor(x => x.Altura).LessThanOrEqualTo(150m);
        }
    }
}
