using AutoMapper;
using ValidaionException = Boilerplate.Application.Common.Exceptions.ValidationException;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using MediatR;
using Boilerplate.Application.Common;
using Boilerplate.Domain.Enitities.Entity;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, OperationResult<EntityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<EntityDto>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productId = await _unitOfWork.EntitiesRepository.UpdateAsync(CreateProductObject(request), cancellationToken);

            if (productId != Guid.Empty)
            {
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    // new DbExceptions(exception);
                }
            }
            else
            {

            }

            return OperationResult.CreateResult(_mapper.Map<EntityDto>(CreateProductObject(request)));
            
        }

        private Entity CreateProductObject(UpdateProductCommand request)
        {
            return new Entity
            {
                Id = request.Model.Id,
                Name = request.Model.Name,
                Description = request.Model.Description,
                Sku = request.Model.Sku,
                Price = request.Model.Price,
                Published = true
            };
        }

    }
}
