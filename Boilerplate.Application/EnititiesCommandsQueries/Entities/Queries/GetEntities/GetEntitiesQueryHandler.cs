using MediatR;
using AutoMapper;
using Boilerplate.Application.Interfaces;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Common;
using System.Reflection;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetEntities
{
    public class GetEntitiesQueryHandler : IRequestHandler<GetEntitiesQuery, OperationResult<IList<EntityDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEntitiesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<IList<EntityDto>>> Handle(GetEntitiesQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.EntitiesRepository.GetAllAsync();
            return OperationResult.CreateResult<IList<EntityDto>>(
                    entities.Select(entity => _mapper.Map<EntityDto>(entity)).ToList()
                );
        }
    }
}
