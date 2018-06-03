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
    public class ReviewRepository : IReviewRepository
    {
        private readonly GoodsStoreDbContext _context;
        public ReviewRepository(GoodsStoreDbContext context)
        {
            this._context = context;
        }

        public async Task<ReviewModel> GetReviewByIdAsync(int Id)
        {
            Review review = await this._context.Reviews.FirstOrDefaultAsync(r => r.Id == Id);
            return Mapper.Map<Review, ReviewModel>(review);
        }
        public async Task<int> GetCountReviewsByGoodsIdAsync(int goodsId)
        {
            int countReviews = await this._context.Reviews.Where(r => r.GoodsId == goodsId).CountAsync();
            return countReviews;
        }
        public async Task<ICollection<ReviewModel>> GetReviewsByGoodsIdForOnePageAsync(int goodsId, int pageSize, int page)
        {
            List<Review> reviews = await this._context.Reviews
                .Where(r => r.GoodsId == goodsId)
                .OrderByDescending(r => r.Date)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return Mapper.Map<List<Review>, List<ReviewModel>>(reviews);
        }
        public async Task<int> GetCountReviewsAsync(SearchReview search)
        {
            int count = await this._context.Reviews.Where(r => (search.goodsId == null || r.GoodsId == search.goodsId)
               && (search.UserName == null || r.UserName == search.UserName)
               && (search.rating == null || r.Rating == search.rating)
               && ((search.searchName == null || search.searchName == "") || r.Comment.ToUpper().Contains(search.searchName.ToUpper()))).CountAsync();
            return count;
        }
        public async Task<ICollection<ReviewModel>> GetReviewsForOnePageAsync(SearchReview search, int pageSize, int page)
        {
            List<Review> reviews = await this._context.Reviews.Where(r => (search.goodsId == null || r.GoodsId == search.goodsId)
               && (search.UserName == null || r.UserName == search.UserName)
               && (search.rating == null || r.Rating == search.rating)
               && ((search.searchName == null || search.searchName == "") || r.Comment.ToUpper().Contains(search.searchName.ToUpper())))
               .OrderByDescending(r => r.Date)
               .Skip((page - 1) * pageSize)
               .Take(pageSize).ToListAsync();

            return Mapper.Map<List<Review>, List<ReviewModel>>(reviews);
        }
        public async Task SaveReviewAsync(ReviewModel review)
        {
            this._context.Reviews.Add(Mapper.Map<ReviewModel, Review>(review));
            await this._context.SaveChangesAsync();
        }
        public async Task<ReviewModel> DeleteReviewAsync(int reviewId)
        {
            Review review = await this._context.Reviews.FindAsync(reviewId);
            if (review != null)
            {
                this._context.Reviews.Remove(review);
                await this._context.SaveChangesAsync();
            }
            return Mapper.Map<Review, ReviewModel>(review);
        }
    }
}
