using Eshop.Application;
using Eshop.Application.Dto.Posts;
using Eshop.Application.Interfaces.Repositories;
using Eshop.Domain.Enitities.CusomerEntities;
using Eshop.Domain.Enitities.PostEntities;
using Eshop.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Eshop.Persistence.Repositories
{
    public class PostsRepository : GenericRepository<Post>, IPostsRepository
    {
        public PostsRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IList<Post>> GetAllPostsAsync()
        {
            return await _dBSet
                .Select(post => post)
                .Include(post => post.Tag)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
