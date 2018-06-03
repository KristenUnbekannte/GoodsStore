using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface ICategoryRepository
    {
        Task<CategoryModel> GetCategoryByIdAsync(int categoryId);
        Task<ICollection<CategoryModel>> GetCategoriesAsync(string search=null);
        ICollection<CategoryModel> GetCategories();
        Task SaveCategoryAsync(CategoryModel category);
        Task<CategoryModel> DeleteCategoryAsync(int categoryId);
    }
}
