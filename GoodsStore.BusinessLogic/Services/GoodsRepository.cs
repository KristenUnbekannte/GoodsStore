using AutoMapper;
using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services.Interfaces;
using GoodsStore.Domain.EF;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services
{
    public class GoodsRepository : IGoodsRepository
    {
        private readonly GoodsStoreDbContext _context;
        public GoodsRepository(GoodsStoreDbContext context)
        {
            this._context = context;
        }

        #region Methods


        public async Task<GoodsModel> GetGoodsByIdAsync(int goodsId)
        {
            Goods goods = await this._context.Goods.FirstOrDefaultAsync(g => g.GoodsId == goodsId);
            return Mapper.Map<Goods, GoodsModel>(goods);
        }
        public ICollection<GoodsModel> GetGoods()
        {
            List<Goods> goods = this._context.Goods.ToList();
            return Mapper.Map<List<Goods>, List<GoodsModel>>(goods);
        }
        public async Task<int> GetCountGoodsAsync(SearchGoods search)
        {
            int count = await this._context.Goods.Where(c => (search.CurrentCategory == null || c.CategoryId == search.CurrentCategory)
                  && (search.CurrentClothesType == null || c.ClothesTypeId == search.CurrentClothesType)
                  && (c.Price >= search.MinPrice)
                  && (search.MaxPrice == null || (c.Price >= search.MinPrice && c.Price <= search.MaxPrice))
                  && (search.CurrentSize == null || c.Sizes.Any(s => s.SizeId == search.CurrentSize))
                  && ((search.searchName == null || search.searchName == "") || c.Name.ToUpper().Contains(search.searchName.ToUpper()))).CountAsync();

            return count;
        }
        public async Task<ICollection<GoodsModel>> GetGoodsForOnePageAsync(SearchGoods search,int pageSize, int page)
        {
            List<Goods> goods = await this._context.Goods.Where(c => (search.CurrentCategory == null || c.CategoryId == search.CurrentCategory)
                  && (search.CurrentClothesType == null || c.ClothesTypeId == search.CurrentClothesType)
                  && (c.Price >= search.MinPrice)
                  && (search.MaxPrice == null || (c.Price >= search.MinPrice && c.Price <= search.MaxPrice))
                  && (search.CurrentSize == null || c.Sizes.Any(s => s.SizeId == search.CurrentSize))
                  && ((search.searchName == null || search.searchName == "") || c.Name.ToUpper().Contains(search.searchName.ToUpper())))
              .OrderBy(g => g.Price)
              .Skip((page - 1) * pageSize)
              .Take(pageSize).ToListAsync();

            return Mapper.Map<List<Goods>, List<GoodsModel>>(goods);
        }
        public async Task AddGoodsAsync(GoodsModel goodsModel, int[] sizes)
        {
            Goods goods = Mapper.Map<GoodsModel, Goods>(goodsModel);
            this._context.Goods.Add(goods);

            var newSizes = await this._context.Sizes.Where(s => sizes.Contains(s.SizeId)).ToListAsync();
            foreach (var size in newSizes)
            {
                goods.Sizes.Add(size);
            }

            await this._context.SaveChangesAsync();
        }
        public async Task UpdateRatingGoodsAsync(GoodsModel goodsModel)
        {
            Goods editGoods = await this._context.Goods.FindAsync(goodsModel.GoodsId);
            if (editGoods != null)
            {
                editGoods.Rating = goodsModel.Rating;
                editGoods.NumberOfReviews = goodsModel.NumberOfReviews;
            }
            await this._context.SaveChangesAsync();
        }

        public async Task SaveGoodsAsync(GoodsModel goods, int[] sizes)
        {
            Goods editGoods = await this._context.Goods.FindAsync(goods.GoodsId);
            if (editGoods != null)
            {
                editGoods.Name = goods.Name;
                editGoods.Description = goods.Description;
                editGoods.CategoryId = goods.CategoryId;
                editGoods.ClothesTypeId = goods.ClothesTypeId;
                editGoods.Price = goods.Price;
                if (goods.ImageData != null)
                {
                    editGoods.ImageData = goods.ImageData;
                    editGoods.ImageMimeType = goods.ImageMimeType;
                }
                if (sizes != null)
                {
                    editGoods.Sizes.Clear();
                    foreach (var size in await this._context.Sizes.Where(s => sizes.Contains(s.SizeId)).ToListAsync())
                    {
                        editGoods.Sizes.Add(size);
                    }
                }
                this._context.Entry(editGoods).State = EntityState.Modified;
                await this._context.SaveChangesAsync();
            }
        }
        public async Task<GoodsModel> DeleteGoodsAsync(int goodsId)
        {
            Goods deletedGoods = await this._context.Goods.FindAsync(goodsId);
            if (deletedGoods != null)
            {
                this._context.Goods.Remove(deletedGoods);
                await this._context.SaveChangesAsync();
            }
            return Mapper.Map<Goods, GoodsModel>(deletedGoods);
        }
        #endregion
    }
}
