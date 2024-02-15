using AutoMapper;
using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Constants.Common;
using Boilerplate.Application.Common.Constants.Entity;
using Boilerplate.Application.Common.Exceptions;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using Boilerplate.Domain.Enitities.Entity;
using MediatR;
using System;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Commands.CreateEntity
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

            var entity = await _unitOfWork.EntitiesRepository.AddAsync(_mapper.Map<Entity>(request.Model), cancellationToken);
            var error = CommonConstans.SOMETHING_WENT_WRONG;

            if (entity != null)
            {
                try
                {
                    await _unitOfWork.SaveChangesAsync(cancellationToken);
                }
                catch (Exception exception)
                {
                    throw new DbException(exception);
                }

                return OperationResult.CreateResult(_mapper.Map<EntityDto>(entity));
            }
            else
            {
                return OperationResult.CreateErrorResult<EntityDto>(new Dictionary<string, string[]>() { [EntityConstants.UNKNOWN_ERROR] = new string[] { error } });
            }
        }
    }
}
