using Business.Abstract;
using Core.Business.Results;
using Data.Repositories.Abstract;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class PostService : IPostService
{

    private readonly IPostRepository _repository;

    public PostService(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> CreateAsync(Post category)
    {
        await _repository.AddAsync(category);
        return new SuccessResult();
    }

    public async Task<IResult> DeleteAsync(Post category)
    {
        await _repository.DeleteAsync(category);
        return new SuccessResult();
    }

    public async Task<IDataResult<IList<Post>>> GetAllAsync()
    {
        var posts = await _repository.GetListAsync(
            include: p => p
            .Include(p => p.User)
            .Include(p => p.Category)
            .Include(p => p.Comments).ThenInclude(u => u.User)
            );

        return new SuccessDataResult<IList<Post>>(posts);
    }

    public async Task<IDataResult<Post>> GetByIdAsync(int id)
    {
        var post = await _repository.GetAsync(
            predicate: p => p.Id == id,
            include: p => p
            .Include(p => p.User)
            .Include(p => p.Category)
            .Include(p => p.Comments).ThenInclude(u => u.User)
            );

        return new SuccessDataResult<Post>(post);

    }

    public async Task<IDataResult<List<Post>>> GetByRoleAsync(string role, int userId)
    {
        List<Post> posts;
        if (role == "Admin")
        {
            var result = await GetAllAsync();
            posts = result.Data.ToList();

        }
        else
        {
            posts = (List<Post>)await _repository.GetListAsync(
                predicate: p => p.UserId == userId,
               include: p => p
               .Include(p => p.User)
               .Include(p => p.Category)
               .Include(p => p.Comments).ThenInclude(u => u.User)
               );
        }

        return new SuccessDataResult<List<Post>>(posts);
    }

    public async Task<IResult> UpdateAsync(Post category)
    {
        await _repository.UpdateAsync(category);
        return new SuccessResult();
    }
}
