using AutoMapper;
using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services.Interfaces;
using GoodsStore.Domain.EF;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GoodsStore.BusinessLogic.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly GoodsStoreDbContext _context;
        public CategoryRepository(GoodsStoreDbContext context)
        {
            this._context = context;
        }
        public async Task<CategoryModel> GetCategoryByIdAsync(int categoryId)
        {
            Category category = await this._context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            return Mapper.Map<Category, CategoryModel>(category);
        }
        public async Task<ICollection<CategoryModel>> GetCategoriesAsync(string search)
        {
            List<Category> category = await this._context.Categories.Where(c => ((search == null || search == "") || c.Name.ToUpper().Contains(search.ToUpper()))).ToListAsync();
            return Mapper.Map<List<Category>, List<CategoryModel>>(category);
        }
        public ICollection<CategoryModel> GetCategories()
        {
            List<Category> category = this._context.Categories.ToList();
            return Mapper.Map<List<Category>, List<CategoryModel>>(category);
        }
        public async Task SaveCategoryAsync(CategoryModel category)
        {
            if (category.CategoryId == 0)
            {
                this._context.Categories.Add(Mapper.Map<CategoryModel, Category>(category));
            }
            else
            {
                Category newCategory = await this._context.Categories.FindAsync(category.CategoryId);
                newCategory.Name = category.Name;
            }
            await this._context.SaveChangesAsync();
        }
        public async Task<CategoryModel> DeleteCategoryAsync(int categoryId)
        {
            Category category = await this._context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                this._context.Categories.Remove(category);
                await this._context.SaveChangesAsync();
            }
            return Mapper.Map<Category, CategoryModel>(category);
        }
    }
}
