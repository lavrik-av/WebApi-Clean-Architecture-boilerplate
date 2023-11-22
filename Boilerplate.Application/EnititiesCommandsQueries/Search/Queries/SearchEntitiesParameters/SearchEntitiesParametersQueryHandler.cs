using AutoMapper;
using Boilerplate.Application.Common;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using Boilerplate.Application.Interfaces.Repositories;

using MediatR;
using System.Linq.Expressions;
using System.Reflection;

namespace Boilerplate.Application.EnititiesCommandsQueries.Search.Queries.SearchEntitiesParameters
{
    public class SearchEntitiesParametersQueryHandler<TEntity, TEntityDto> : IRequestHandler<SearchEntitiesParametersQuery<TEntity, TEntityDto>, PagedList<TEntityDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SearchEntitiesParametersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<TEntityDto>> Handle(SearchEntitiesParametersQuery<TEntity, TEntityDto> request, CancellationToken cancellationToken)
        {
            PagedList<TEntityDto> result = PagedList.ToPagedList(
                new List<TEntityDto>()
                );

            var repo = GetRepository();

            MethodInfo repoMethod = repo.GetType().GetMethod("SearchExt");
            var items = await (Task<IList<TEntity>>)repoMethod.Invoke(repo, new object[] { request.auxParams });

            if (items.Any())
            {
                result = PagedList.ToPagedList(
                    items.Select(item => _mapper.Map<TEntityDto>(item)).ToList(),
                    items.Count()
                    );
            }

            return result;
        }

        private object GetRepository()
        {
            MethodInfo metodGetRepository = typeof(IUnitOfWork).GetMethod("GetRepository");
            MethodInfo genericMethod = metodGetRepository.MakeGenericMethod(typeof(TEntity));

            return genericMethod.Invoke(_unitOfWork, new object[] { });
        }
    }
}
