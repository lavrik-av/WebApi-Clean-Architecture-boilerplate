using Boilerplate.Application.Common;
using Boilerplate.Application.EnititiesCommandsQueries.ComplexQuery.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.WebApi.Controllers.ComplexQueries
{
    [ApiController]
    [Route("api/complex-queries")]
    public class ComplexQueriesController : ControllerBase
    {
        private readonly IMediator _sender;

        public ComplexQueriesController(IMediator sender)
        {
            _sender = sender;
        }

        [HttpGet("/entitites")]
        public async Task<OperationResultList<IList<ComplexQueryModel>>> MakeComplexQuery()
        {
            return await _sender.Send(new GetComplexQuery(new ComplexQueryModel()));
        }
    }
}
