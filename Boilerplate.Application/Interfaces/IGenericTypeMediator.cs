using AutoMapper;
using MediatR;

namespace Boilerplate.Application.Interfaces
{
    public abstract class IGenericTypeMediator
    {
        protected IMediator? _sender;
        protected IUnitOfWork? _unitOfWork;
        protected IMapper? _mapper;
        public IMediator Sender => _sender;
    }
}
