using Core.DataAccess.Repositories;
using Data.Contexts;
using Data.Repositories.Abstract;
using Entities;

namespace Data.Repositories.Concrete;

public class CategoryRepository : EfRepositoryBase<Category, AppDbContext>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}
