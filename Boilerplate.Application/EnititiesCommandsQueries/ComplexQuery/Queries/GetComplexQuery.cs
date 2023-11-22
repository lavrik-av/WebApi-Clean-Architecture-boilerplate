using Boilerplate.Application.Common;
using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.ComplexQuery.Queries
{
    public record GetComplexQuery(ComplexQueryModel Model) : IRequest<OperationResultList<IList<ComplexQueryModel>>>
    {
    }
}
