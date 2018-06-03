using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services.Interfaces;
using GoodsStore.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GoodsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        #region Fields
        private readonly IGoodsRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClothesTypeRepository _typesRepository;
        private readonly ISizeRepository _sizeRepository;
        #endregion

        #region Constructor
        public NavController(ICategoryRepository categoryRepository, IClothesTypeRepository typesRepository,
            ISizeRepository sizeRepository, IGoodsRepository repository)
        {
            this._categoryRepository = categoryRepository;
            this._typesRepository = typesRepository;
            this._sizeRepository = sizeRepository;
            this._repository = repository;
        }
        #endregion

        #region Methods
        public PartialViewResult Menu(SearchGoods searchGoods)
        {
            IEnumerable<CategoryModel> categories = this._categoryRepository.GetCategories();
            ICollection<ClothesTypeModel> clothesTypes = this._typesRepository.GetClothesTypes();
            ICollection<SizeModel> sizes = this._sizeRepository.GetSizes();

            MenuListViewModel mlvm = new MenuListViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Name"),
                ClothesTypes = clothesTypes,
                Sizes = sizes,
                Search = searchGoods
            };

            return PartialView(mlvm);
        }
        public PartialViewResult MenuForAdmin(SearchGoods searchGoods)
        {
            IEnumerable<CategoryModel> categories = this._categoryRepository.GetCategories();
            ICollection<ClothesTypeModel> clothesTypes = this._typesRepository.GetClothesTypes();

            MenuListViewModel mlvm = new MenuListViewModel
            {
                Categories = new SelectList(categories, "CategoryId", "Name"),
                ClothesTypes = clothesTypes,
                Search = searchGoods
            };

            return PartialView(mlvm);
        }

        public PartialViewResult MenuAdminForReviews(SearchReview search)
        {
            ICollection<GoodsModel> goods = this._repository.GetGoods();

            MenuForReviewListModel mrlm = new MenuForReviewListModel
            {
                Goods = new SelectList(goods, "GoodsId", "Name"),
                Search=search
            };
            return PartialView(mrlm);
        }
        #endregion
    }
}