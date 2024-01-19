using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        void Dispose();
    }
}
