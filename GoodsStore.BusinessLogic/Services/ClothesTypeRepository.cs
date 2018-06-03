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
    public class ClothesTypeRepository : IClothesTypeRepository
    {
        private readonly GoodsStoreDbContext _context;
        public ClothesTypeRepository(GoodsStoreDbContext db)
        {
            this._context = db;
        }
        public async Task<ClothesTypeModel> GetClothesTypeByIdAsync(int clothesTypeId)
        {
            ClothesType types = await this._context.ClothesTypes.FirstOrDefaultAsync(c => c.ClothesTypeId == clothesTypeId);
            return Mapper.Map<ClothesType, ClothesTypeModel>(types);
        }
        public async Task<ICollection<ClothesTypeModel>> GetClothesTypesAsync(string search)
        {
            List<ClothesType> clothesType = await this._context.ClothesTypes
                .Where(c => ((search == null || search == "") || c.Name.ToUpper().Contains(search.ToUpper()))).ToListAsync();
            return Mapper.Map<List<ClothesType>, List<ClothesTypeModel>>(clothesType);
        }
        public ICollection<ClothesTypeModel> GetClothesTypes()
        {
            List<ClothesType> clothesType = this._context.ClothesTypes.ToList();
            return Mapper.Map<List<ClothesType>, List<ClothesTypeModel>>(clothesType);
        }
        public async Task SaveClothesTypeAsync(ClothesTypeModel clothesType)
        {
            if (clothesType.ClothesTypeId == 0)
            {
                this._context.ClothesTypes.Add(Mapper.Map<ClothesTypeModel, ClothesType>(clothesType));
            }
            else
            {
                ClothesType newClothesType = await this._context.ClothesTypes.FindAsync(clothesType.ClothesTypeId);
                newClothesType.Name = clothesType.Name;
            }
            await this._context.SaveChangesAsync();
        }
        public async Task<ClothesTypeModel> DeleteClothesTypeAsync(int clothesTypeId)
        {
            ClothesType clothesType = await this._context.ClothesTypes.FindAsync(clothesTypeId);
            if (clothesType != null)
            {
                this._context.ClothesTypes.Remove(clothesType);
                await this._context.SaveChangesAsync();
            }
            return Mapper.Map<ClothesType, ClothesTypeModel>(clothesType);
        }

    }
}
