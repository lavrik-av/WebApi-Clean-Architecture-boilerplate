using AutoMapper;
using Eshop.Application.Dto.Posts;
using Eshop.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Eshop.Application.EnititiesCommandsQueries.Posts.Queries.GetPosts;
using Eshop.Domain.Enitities.PostEntities;
using Eshop.Application.Common;

namespace Eshop.WebApi.Controllers.Posts
{
    [ApiController]
    [Route("api/posts")]
    public class PostController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public PostController(ISender sender, IMapper mapper)
        {
            _sender = sender;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<OperationResult<IList<PostDto>>> GetAllAsync() 
        {
            return await _sender.Send(new GetPostsQuery());
        }
    }
}
