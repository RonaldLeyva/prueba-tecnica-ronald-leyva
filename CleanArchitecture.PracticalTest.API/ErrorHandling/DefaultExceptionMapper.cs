using CleanArchitecture.PracticalTest.Application.Exceptions;
using CleanArchitecture.PracticalTest.Domain.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.PracticalTest.API.ErrorHandling;

public class DefaultExceptionMapper : IExceptionMapper
{
    public bool CanHandle(Exception exception) => true;

    public ProblemDetails MapToProblemDetails(Exception exception, HttpContext context)
    {
        return exception switch
        {
            ValidationException ve => ProblemDetailsFactory.Validation(ve, context),
            DomainException de => ProblemDetailsFactory.Domain(de, context),
            NotFoundException nf => ProblemDetailsFactory.NotFound(nf, context),
            _ => ProblemDetailsFactory.Unexpected(exception, context)
        };
    }
}
