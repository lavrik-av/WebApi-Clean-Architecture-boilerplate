using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;
using Boilerplate.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Boilerplate.Application.EnititiesCommandsQueries.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, OperationResult<EmptyResult>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<EmptyResult>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.EntitiesRepository.DeleteAsync(request.Model.Id, cancellationToken);

            if (result)
            {
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception exception)
                {

                    throw new NotImplementedException(exception.Message);
                }

            }
            else
            {
                // not found
                throw new NotFoundException(CommonConstans.OPERATION_DELETE, CommonConstans.ENTITY_TYPE_PRODUCT);
            }

            return OperationResult.CreateResult<EmptyResult>(null);
        }
    }
}
