using AutoMapper;
using Boilerplate.Application.Common;
using Boilerplate.Application.Common.Filters;
using Boilerplate.Application.Common.Filters.AuxParams;
using Boilerplate.Application.Common.Filters.Products;
using Boilerplate.Application.Dto.Entity;
using Boilerplate.Application.Interfaces;
using Boilerplate.Domain.Enitities.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Boilerplate.Application.EnititiesCommandsQueries.Enteties.Queries.GetProductsPaged
{
    public class GetEntitesPagedQueryHandler :
        IRequestHandler<GetEntitiesPagedQuery, OperationResultList<IList<EntityDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetEntitesPagedQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OperationResultList<IList<EntityDto>>> Handle(GetEntitiesPagedQuery request, CancellationToken cancellationToken)
        {

            Func<IQueryable<Entity>, IIncludableQueryable<Entity, object>>? include = null;

            var auxParams = new AuxParams() { IncludeParam = new string[] { "ProductMedia" } };
            _unitOfWork.EntitiesRepository.SearchExt(auxParams);

            var products = await _unitOfWork.EntitiesRepository.
                GetAllPagedAsync(
                    request.Model.PageIndex, 
                    request.Model.PageSize,
                    GetSortingDictionary(request.Model.Direction)[request.Model.OrderBy.ToUpper()],
                    Include: request.Model.IncludeJoined ? p => p.Include(m => m.EntityMedia) : include
                );

            return OperationResult.CreateResultList<IList<EntityDto>>(
                    products.Select(product => _mapper.Map<EntityDto>(product)).ToList(),
                    OperationResult.GetPageInfoObject(request.Model.PageIndex, request.Model.PageSize, 1, 20)
                );

        }

        private Dictionary<string, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>> GetSortingDictionary(string direction)
        {
            Dictionary<string, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>> sortingDictionary;

            if (direction.ToUpper() == SortingConstants.ASC) 
            {
                sortingDictionary = new Dictionary<string, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>
                {
                    { ProductFieldsConstants.NAME, x => x.OrderBy(p => p.Name) },
                    { ProductFieldsConstants.CREATED, x => x.OrderBy(p => p.Created) },
                    { ProductFieldsConstants.PRICE, x => x.OrderBy(p => p.Price) }
                };
            }
            else 
            {
                sortingDictionary = new Dictionary<string, Func<IQueryable<Entity>, IOrderedQueryable<Entity>>>
                {
                    { ProductFieldsConstants.NAME, x => x.OrderByDescending(p => p.Name) },
                    { ProductFieldsConstants.CREATED, x => x.OrderByDescending(p => p.Created) },
                    { ProductFieldsConstants.PRICE, x => x.OrderByDescending(p => p.Price) }
                };
            }

            return sortingDictionary;
        }
    }
}
