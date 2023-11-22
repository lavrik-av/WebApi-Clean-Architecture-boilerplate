using AutoMapper;
using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;

using MediatR;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Queries.GetProduct
{
    public class GetEntityQueryHandler : IRequestHandler<GetEntityQuery, OperationResult<EntityDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEntityQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<OperationResult<EntityDto>> Handle(GetEntityQuery request, CancellationToken cancellationToken)
        {
            if (request.Model.Id != Guid.Empty)
            {
                var product = await _unitOfWork.EntitiesRepository.GetByIdAsync(request.Model.Id);

                if (product != null) 
                { 
                    return OperationResult.CreateResult(_mapper.Map<EntityDto>(product));
                }
                else 
                {
                    throw new NotFoundException(CommonConstans.OPERAION_GET_PRODUCT, CommonConstans.ENTITY_TYPE_PRODUCT);
                }
            }
            else
            {
                throw new WrongRequestModelFieldsException(CommonConstans.ENTITY_TYPE_PRODUCT);
            }
        }
    }
}
