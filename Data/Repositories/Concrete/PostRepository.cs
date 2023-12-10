using Core.DataAccess.Repositories;
using Data.Contexts;
using Data.Repositories.Abstract;
using Entities;

namespace Data.Repositories.Concrete;

public class PostRepository : EfRepositoryBase<Post, AppDbContext>, IPostRepository
{
    public PostRepository(AppDbContext context) : base(context)
    {
    }
}