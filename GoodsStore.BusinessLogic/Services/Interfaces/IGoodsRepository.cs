using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface IGoodsRepository
    {
        Task<GoodsModel> GetGoodsByIdAsync(int goodsId);
        ICollection<GoodsModel> GetGoods();
        Task<int> GetCountGoodsAsync(SearchGoods search);
        Task<ICollection<GoodsModel>> GetGoodsForOnePageAsync(SearchGoods search, int pageSize, int page);
        Task UpdateRatingGoodsAsync(GoodsModel goodsModel);
        Task SaveGoodsAsync(GoodsModel goods,int[] sizes);
        Task AddGoodsAsync(GoodsModel goods, int[] sizes);
        Task<GoodsModel> DeleteGoodsAsync(int goodsId);
    }
}
