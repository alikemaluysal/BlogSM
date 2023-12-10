using Business.Abstract;
using Core.Business.Results;
using Data.Repositories.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repository;

    public CategoryService(ICategoryRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> CreateAsync(Category category)
    {
        bool exists = await _repository.AnyAsync(c => c.Name == category.Name);

        if(exists)
            return new ErrorResult("Aynı isimde iki kategori olamaz");

        await _repository.AddAsync(category);

        return new SuccessResult("Ürün başarıyla eklendi.");
    }

    public async Task<IResult> DeleteAsync(Category category)
    {
        await _repository.DeleteAsync(category);
        return new SuccessResult("Ürün başarıyla silindi.");
    }

    public async Task<IDataResult<IList<Category>>> GetAllAsync()
    {
        var categories = await _repository.GetListAsync();
        return new SuccessDataResult<IList<Category>>(categories);
    }

    public async Task<IDataResult<Category>> GetByIdAsync(int id)
    {
        var category = await _repository.GetAsync(c => c.Id == id);
        return new SuccessDataResult<Category>(category);

    }

    public async Task<IResult> UpdateAsync(Category category)
    {
        bool exists = await _repository.AnyAsync(c => c.Name == category.Name);

        if (exists)
            return new ErrorResult("Aynı isimde iki kategori olamaz");

        await _repository.UpdateAsync(category);
        return new SuccessResult("Ürün başarıyla eklendi.");
    }
}
