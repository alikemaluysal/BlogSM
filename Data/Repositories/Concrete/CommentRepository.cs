using Core.DataAccess.Repositories;
using Data.Contexts;
using Data.Repositories.Abstract;
using Entities;

namespace Data.Repositories.Concrete;

public class CommentRepository : EfRepositoryBase<Comment, AppDbContext>, ICommentRepository
{
    public CommentRepository(AppDbContext context) : base(context)
    {
    }
}
