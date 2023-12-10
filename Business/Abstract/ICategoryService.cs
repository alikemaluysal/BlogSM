using Core.Business.Results;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract;

public interface ICategoryService
{
    Task<IDataResult<IList<Category>>> GetAllAsync();
    Task<IDataResult<Category>> GetByIdAsync(int id);

    Task<IResult> CreateAsync(Category category);
    Task<IResult> UpdateAsync(Category category);
    Task<IResult> DeleteAsync(Category category);
}
