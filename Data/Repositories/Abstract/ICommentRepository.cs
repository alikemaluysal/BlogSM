using Core.DataAccess.Repositories;
using Entities;

namespace Data.Repositories.Abstract;

public interface ICommentRepository : IAsyncRepository<Comment>, IRepository<Comment>
{
}