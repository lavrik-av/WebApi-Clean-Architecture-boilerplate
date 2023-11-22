using Boilerplate.Application.Common;
using Boilerplate.Application.Interfaces;
using Boilerplate.Domain.Enitities.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Application.EnititiesCommandsQueries.ComplexQuery.Queries
{
    public class GetComplexQueryHandler : IRequestHandler<GetComplexQuery, OperationResultList<IList<ComplexQueryModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetComplexQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<OperationResultList<IList<ComplexQueryModel>>> Handle(GetComplexQuery request, CancellationToken cancellationToken)
        {

            var context = _unitOfWork.DbContext;

            IQueryable<ComplexQueryModel> entities = context.Entities
                .FromSqlRaw("SELECT * FROM Entities");

            var entitiesResultList = entities.ToList();


            return Task.FromResult(OperationResult.CreateResultList<IList<ComplexQueryModel>>(entitiesResultList, new PageInfo() {Count = entitiesResultList.Count() }));
        }
    }
}
