using CleanArchitecture.PracticalTest.Application.Features.Commands.ActualizarPaquete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.PracticalTest.Application.Features.Validators
{
    public class ActualizarEstadoValidator: AbstractValidator<ActualizarPaqueteCommand>
    {
        public ActualizarEstadoValidator()
        {
            RuleFor(x => x.PaqueteId).NotEmpty();
        }
    }
}
