using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface IClothesTypeRepository
    {
        Task<ClothesTypeModel> GetClothesTypeByIdAsync(int clothesTypeId);
        Task<ICollection<ClothesTypeModel>> GetClothesTypesAsync(string search=null);
        ICollection<ClothesTypeModel> GetClothesTypes();
        Task SaveClothesTypeAsync(ClothesTypeModel clothesType);
        Task<ClothesTypeModel> DeleteClothesTypeAsync(int clothesTypeId);
    }
}
