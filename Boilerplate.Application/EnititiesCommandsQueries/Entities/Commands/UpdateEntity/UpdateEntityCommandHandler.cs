using AutoMapper;
using ValidaionException = Boilerplate.Application.Common.Exceptions.ValidationException;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using MediatR;
using Boilerplate.Application.Common;
using Boilerplate.Domain.Enitities.Entity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Boilerplate.Application.Common.Constants.Entity;
using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Exceptions;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.UpdateEntity
{
    public class UpdateEntityCommandHandler : IRequestHandler<UpdateEntityCommand, OperationResult<EntityDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEntityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResult<EntityDto>> Handle(UpdateEntityCommand request, CancellationToken cancellationToken)
        {
            var entityId = await _unitOfWork.EntitiesRepository.UpdateAsync(_mapper.Map<Entity>(request.Model), cancellationToken);
            var error = CommonConstans.SOMETHING_WENT_WRONG;

            if (entityId != Guid.Empty)
            {
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    throw new DbException(exception);
                }

                return OperationResult.CreateResult(_mapper.Map<EntityDto>(request.Model));

            }
            else
            {

            }

            return OperationResult.CreateResult(_mapper.Map<EntityDto>(request.Model));            
        }
    }
}
