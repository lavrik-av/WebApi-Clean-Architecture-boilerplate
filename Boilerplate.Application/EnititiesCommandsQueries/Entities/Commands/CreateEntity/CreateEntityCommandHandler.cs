using AutoMapper;
using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Constants.Entity;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using Boilerplate.Domain.Enitities.Entity;
using MediatR;
using System;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.CreateProduct
{
    public class CreateEntityCommandHandler
        : IRequestHandler<CreateEntityCommand, OperationResult<EntityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEntityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<EntityDto>> Handle(CreateEntityCommand request, CancellationToken cancellationToken)
        {

            var product = await _unitOfWork.EntitiesRepository.AddAsync(CreateProductObject(request), cancellationToken);
            var error = "Something went wrong...";

            if (product != null)
            {
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    error = exception.Message;
                    return OperationResult.CreateErrorResult<EntityDto>(new Dictionary<string, string[]>() { [EntityConstants.ENTITY_CREATION_ERROR] = new string[] { error } });
                }

                return OperationResult.CreateResult(_mapper.Map<EntityDto>(product));
            }
            else
            {
                return OperationResult.CreateErrorResult<EntityDto>(new Dictionary<string, string[]>() { [EntityConstants.UNKNOWN_ERROR] = new string[] { error } });
            }
        }

        private Entity CreateProductObject(CreateEntityCommand request)
        {
            return new Entity
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                Sku = request.Model.Sku,
                Price = request.Model.Price,
                Published = true
            };
        }

    }
}
