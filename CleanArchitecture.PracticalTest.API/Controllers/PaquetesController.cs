using CleanArchitecture.PracticalTest.Application.DTO.Common;
using CleanArchitecture.PracticalTest.Application.Features.Commands.ActualizarPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Commands.AsignarRuta;
using CleanArchitecture.PracticalTest.Application.Features.Commands.CrearPaquete;
using CleanArchitecture.PracticalTest.Application.Features.Queries;
using CleanArchitecture.PracticalTest.Domain.Entidades;
using CleanArchitecture.PracticalTest.Domain.Enums;
using Microsoft.Extensions.Localization;
using System.Linq.Dynamic.Core;

namespace CleanArchitecture.PracticalTest.API.Controllers
{
    [ApiController]
    [Route("api/v1/packages")]
    public class PaquetesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILocalizer _localizer;

        public PaquetesController(IMediator mediator, ILocalizer localizer)
        {
            this._mediator = mediator;
            this._localizer = localizer;
        }
        [HttpPost]
        public async Task<ActionResult<APIResponse<Guid>>> Post([FromBody] CrearPaqueteCommand crearPaqueteCommand)
        {
            var result = await _mediator.Send(crearPaqueteCommand);
            var message = _localizer.GetResponseMessage("Entity.Created");
            return Ok(APIResponse.From(result, message));
        }
        [HttpPatch("{id}/status")]
        public async Task<ActionResult<APIResponse<Guid>>> Patch(Guid id,
            [FromBody] ActualizarPaqueteCommand actualizarPaqueteCommand)
        {
            actualizarPaqueteCommand.PaqueteId = id;
            var result = await _mediator.Send(actualizarPaqueteCommand);
            var message = _localizer.GetResponseMessage("Entity.Updated");
            return Ok(APIResponse.From(result, message));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<APIResponse<Paquete>>> Get(Guid id)
        {
            var query = new ObtenerPaqueteQuery() { PaqueteId = id };
            var result = await _mediator.Send(query);
            var message = _localizer.GetResponseMessage("Entity.Found");
            return Ok(APIResponse.From(result, message));
        }
        [HttpPost("{id}/assign-route")]
        public async Task<ActionResult<APIResponse<Guid>>> AsignarRuta(Guid id, [FromBody] AsignarRutaCommand asignarRutaCommand)
        {
            asignarRutaCommand.PaqueteId = id;
            var result = await _mediator.Send(asignarRutaCommand);
            var message = _localizer.GetResponseMessage("Package.Assigned");
            return Ok(APIResponse.From(result, message));
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse<Paquete>>> GetPaginado([FromQuery] EstatusPaquete? estado,
            [FromQuery] DateTime? fechaInicio,
            [FromQuery] DateTime? fechaFin,
            [FromQuery] int numeroPagina = 1, 
            [FromQuery] int registrosPorPagina = 10)
        {
            var query = new ObtenerPaginadoQuery
            {
                Estado = estado,
                FechaInicio = fechaInicio,
                FechaFin = fechaFin,
                NumeroPagina = numeroPagina,
                RegistrosPorPagina = registrosPorPagina
            };

            var result = await _mediator.Send(query);

            var operationResult = OperationResult.With(result);
            var message = _localizer.GetResponseMessage("Packages.Found");

            return Ok(APIResponse.From(operationResult, message));
        }
        [HttpGet("{id}/shipping-cost")]
        public async Task<ActionResult> GetShippingCost(Guid id, [FromQuery] decimal distanciaEnKm)
        {
            var query = new ObtenerShippingCostQuery
            {
                PaqueteId = id,
                DistanciaEnKm = distanciaEnKm
            };

            var result = await _mediator.Send(query);

            var operationResult = OperationResult.With(result);
            var message = _localizer.GetResponseMessage("Cost.Calculated");

            return Ok(APIResponse.From(operationResult, message));
        }
    }
}
