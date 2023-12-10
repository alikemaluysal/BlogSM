using Core.Business.Results;
using Entities;

namespace Business.Abstract;

public interface IPostService
{
    Task<IDataResult<IList<Post>>> GetAllAsync();
    Task<IDataResult<Post>> GetByIdAsync(int id);
    Task<IDataResult<List<Post>>> GetByRoleAsync(string role, int userId);
    Task<IResult> CreateAsync(Post category);
    Task<IResult> UpdateAsync(Post category);
    Task<IResult> DeleteAsync(Post category);
}
