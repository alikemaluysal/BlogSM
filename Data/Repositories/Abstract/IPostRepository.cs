using Core.DataAccess.Repositories;
using Entities;

namespace Data.Repositories.Abstract;

public interface IPostRepository : IAsyncRepository<Post>, IRepository<Post>
{
}
