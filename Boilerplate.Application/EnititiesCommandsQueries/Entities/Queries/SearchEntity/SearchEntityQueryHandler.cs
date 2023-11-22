using AutoMapper;
using Boilerplate.Application.Interfaces;
using MediatR;
using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.SearchProduct
{

    public class SearchEntityQueryHandler : IRequestHandler<SearchEntityQuery, OperationResult<IList<EntityDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SearchEntityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<IList<EntityDto>>> Handle(SearchEntityQuery request, CancellationToken cancellationToken)
        {
            var products = await _unitOfWork.EntitiesRepository.Search(request.Model.Filters);
            return OperationResult.CreateResult<IList<EntityDto>>(
                    products.Select(p => _mapper.Map<EntityDto>(p)).ToList()
                );
        }
    }
}
