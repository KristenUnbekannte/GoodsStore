using GoodsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using GoodsStore.BusinessLogic.Services.Interfaces;
using GoodsStore.BusinessLogic.Models;
using AutoMapper;

namespace GoodsStore.WebUI.Controllers
{
    public class GoodsController : Controller
    {
        #region Fields
        private readonly IGoodsRepository _repository;
        private readonly IReviewRepository _reviewRepository;
        private readonly ISizeRepository _sizeRepository;
        public int pageSize = 6;
        private int pageSizeForReviews = 2;
        #endregion

        #region Constructor
        public GoodsController(IGoodsRepository repository, IReviewRepository reviewRepository, ISizeRepository sizeRepository)
        {
            this._repository = repository;
            this._reviewRepository = reviewRepository;
            this._sizeRepository = sizeRepository;
        }
        #endregion

        #region Methods
        public async Task<ActionResult> Cards(SearchGoods search, int page = 1)
        {
            ICollection<GoodsModel> goods = await this._repository.GetGoodsForOnePageAsync(search, pageSize, page);

            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await _repository.GetCountGoodsAsync(search)
            };
            GoodsListViewModel model = new GoodsListViewModel()
            {
                Goods = goods,
                PagingInfo = pageInfo,
                Search = search
            };
            return PartialView("_PartialCards", model);
        }
        public async Task<ViewResult> GoodsCards(SearchGoods search, int page = 1)
        {
            ICollection<GoodsModel> goods = await this._repository.GetGoodsForOnePageAsync(search, pageSize, page);

            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await _repository.GetCountGoodsAsync(search)
            };
            GoodsListViewModel model = new GoodsListViewModel()
            {
                Goods = goods,
                PagingInfo = pageInfo,
                Search = search
            };
            return View(model);
        }
        public async Task<FileContentResult> GetImage(int? goodsId)
        {
            GoodsModel goods = await _repository.GetGoodsByIdAsync((int)goodsId);
            if (goods != null)
            {
                return File(goods.ImageData, goods.ImageMimeType);
            }
            else
            {
                return null;
            }
        }
        public async Task<ActionResult> GetGoodsDescription(int? goodsId, int page = 1)
        {
            if (goodsId != null)
            {
                GoodsModel goods = await _repository.GetGoodsByIdAsync((int)goodsId);
                if (goods != null)
                {
                    ICollection<ReviewModel> reviews = await this._reviewRepository.GetReviewsByGoodsIdForOnePageAsync((int)goodsId, pageSizeForReviews, page);

                    PagingInfo pageInfo = new PagingInfo
                    {
                        CurrentPage = page,
                        ItemsPerPage = pageSizeForReviews,
                        TotalItems = await this._reviewRepository.GetCountReviewsByGoodsIdAsync((int)goodsId)
                    };

                    ReviewsListViewModel model = new ReviewsListViewModel
                    {
                        Reviews = reviews,
                        PagingInfo = pageInfo,
                        Goods = goods,
                    };
                    return View(model);
                }
                else
                {
                    return new HttpNotFoundResult();
                }
            }
            else
            {
                return RedirectToAction("GoodsCards");
            }
        }
        [HttpGet]
        public async Task<ActionResult> ListReviews(int? goodsId, int page = 1)
        {
            if (goodsId != null)
            {
                ICollection<ReviewModel> reviews = await this._reviewRepository.GetReviewsByGoodsIdForOnePageAsync((int)goodsId, pageSizeForReviews, page);
                PagingInfo pageInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSizeForReviews,
                    TotalItems = await this._reviewRepository.GetCountReviewsByGoodsIdAsync((int)goodsId)
                };
                GoodsModel goods = await this._repository.GetGoodsByIdAsync((int)goodsId);
                ReviewsListViewModel model = new ReviewsListViewModel { Reviews = reviews, PagingInfo = pageInfo,Goods =goods };
                return PartialView("_PartialReviews", model);
            }
            return new HttpNotFoundResult();
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<ActionResult> AddReview(string comment, int goodsId, int rate)
        {
            if (comment!="" && rate > 0)
            {
                GoodsModel goods = await _repository.GetGoodsByIdAsync(goodsId);
                goods.Rating = Math.Round((goods.Rating * goods.NumberOfReviews + rate) / (goods.NumberOfReviews + 1), 1);
                goods.NumberOfReviews += 1;
                await _repository.UpdateRatingGoodsAsync(goods);

                if (goods != null)
                {
                    ReviewModel review = new ReviewModel();
                    review.GoodsId = goods.GoodsId;
                    review.Comment = comment;
                    review.UserName = User.Identity.GetUserName();
                    review.Rating = rate;
                    review.Date = DateTime.Now;
                    await _reviewRepository.SaveReviewAsync(review);
                }
            }
            return RedirectToAction("GetGoodsDescription", new { goodsId = goodsId });
        }
        #endregion
    }
}