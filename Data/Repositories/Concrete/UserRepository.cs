using Core.DataAccess.Repositories;
using Data.Contexts;
using Data.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Concrete;

public class UserRepository : EfRepositoryBase<User, AppDbContext>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }
}
