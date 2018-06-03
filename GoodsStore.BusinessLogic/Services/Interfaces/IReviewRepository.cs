using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface IReviewRepository
    {
        Task<ReviewModel> GetReviewByIdAsync(int Id);
        Task<int> GetCountReviewsByGoodsIdAsync(int goodsId);
        Task<ICollection<ReviewModel>> GetReviewsByGoodsIdForOnePageAsync(int goodsId,int pageSize,int page);
        Task<int> GetCountReviewsAsync(SearchReview search);
        Task<ICollection<ReviewModel>> GetReviewsForOnePageAsync(SearchReview search, int pageSize, int page);
        Task SaveReviewAsync(ReviewModel review);
        Task<ReviewModel> DeleteReviewAsync(int reviewId);
    }
}
