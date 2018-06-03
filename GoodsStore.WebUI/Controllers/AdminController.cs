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
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        #region Fields
        private readonly IGoodsRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IClothesTypeRepository _typeRepository;
        private readonly ISizeRepository _sizeRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IReviewRepository _reviewRepository;
        private int pageSize = 9;
        #endregion

        #region Constructor
        public AdminController(IGoodsRepository repository, ICategoryRepository categoryRepository,
            IClothesTypeRepository typeRepository, ISizeRepository sizeRepository,
            IOrderRepository orderRepository, IReviewRepository reviewRepository)
        {
            this._repository = repository;
            this._categoryRepository = categoryRepository;
            this._typeRepository = typeRepository;
            this._sizeRepository = sizeRepository;
            this._orderRepository = orderRepository;
            this._reviewRepository = reviewRepository;
        }
        #endregion

        #region Methods

        #region GoodsMethods
        public async Task<ActionResult> ListGoods(SearchGoods searchGoods, int page = 1)
        {
            ICollection<GoodsModel> goods = await this._repository.GetGoodsForOnePageAsync(searchGoods, pageSize, page);
            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await _repository.GetCountGoodsAsync(searchGoods)
            };
            GoodsListViewModel model = new GoodsListViewModel()
            {
                Goods = goods,
                PagingInfo = pageInfo,
                Search = searchGoods
            };

            return View(model);
        }
        public async Task<ActionResult> Goods(SearchGoods searchGoods, int page = 1)
        {
            ICollection<GoodsModel> goods = await this._repository.GetGoodsForOnePageAsync(searchGoods, pageSize, page);
            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await _repository.GetCountGoodsAsync(searchGoods)
            };
            GoodsListViewModel model = new GoodsListViewModel()
            {
                Goods = goods,
                PagingInfo = pageInfo,
                Search = searchGoods
            };

            return PartialView("_PartialAdmin_Goods",model);
        }

        [HttpGet]
        public async Task<ActionResult> EditGoods(int? goodsId)
        {
            if (goodsId != null)
            {
                GoodsModel goods = await this._repository.GetGoodsByIdAsync((int)goodsId);
                if (goods != null)
                {
                    ViewBag.Categories = new SelectList(await this._categoryRepository.GetCategoriesAsync(), "CategoryId", "Name");
                    ViewBag.ClothesTypes = new SelectList(await this._typeRepository.GetClothesTypesAsync(), "ClothesTypeId", "Name");
                    ViewBag.Sizes = await this._sizeRepository.GetSizesAsync();

                    return View(goods);
                }
                return RedirectToAction("ListGoods");
            }
            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditGoods(GoodsModel goods, int[] selectedSizes, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    goods.ImageData = new byte[image.ContentLength];
                    goods.ImageMimeType = image.ContentType;
                    image.InputStream.Read(goods.ImageData, 0, image.ContentLength);
                }
                if (goods.GoodsId == 0)
                {
                    await _repository.AddGoodsAsync(goods, selectedSizes);
                }
                else
                {
                    await _repository.SaveGoodsAsync(goods, selectedSizes);
                }
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", goods.Name);
                return RedirectToAction("ListGoods");
            }
            else
            {
                ViewBag.Categories = new SelectList(await this._categoryRepository.GetCategoriesAsync(), "CategoryId", "Name");
                ViewBag.ClothesTypes = new SelectList(await this._typeRepository.GetClothesTypesAsync(), "ClothesTypeId", "Name");
                ViewBag.Sizes = await this._sizeRepository.GetSizesAsync();
                return View(goods);
            }
        }
        public async Task<ActionResult> AddGoods()
        {
            ViewBag.Categories = new SelectList(await this._categoryRepository.GetCategoriesAsync(), "CategoryId", "Name");
            ViewBag.ClothesTypes = new SelectList(await this._typeRepository.GetClothesTypesAsync(), "ClothesTypeId", "Name");
            ViewBag.Sizes = await this._sizeRepository.GetSizesAsync();

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteGoods(int goodsId)
        {
            GoodsModel deletedGoods = await this._repository.DeleteGoodsAsync(goodsId);
            if (deletedGoods != null)
            {
                TempData["message"] = string.Format("Товар \"{0}\" был удален!", deletedGoods.Name);
            }
            return RedirectToAction("ListGoods");
        }
        #endregion

        #region CategoryMethods
        public async Task<ActionResult> ListCategories(string searchName)
        {
            ICollection<CategoryModel> categories = await this._categoryRepository.GetCategoriesAsync(searchName);

            return View(categories);
        }

        [HttpGet]
        public async Task<ActionResult> EditCategory(int? categoryId)
        {
            if (categoryId != null)
            {
                CategoryModel category = await this._categoryRepository.GetCategoryByIdAsync((int)categoryId);
                if (category != null)
                {
                    return View(category);
                }
                return RedirectToAction("ListCategories");
            }

            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditCategory(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                await _categoryRepository.SaveCategoryAsync(category);

                TempData["message"] = string.Format("Изменения в категории \"{0}\" были сохранены", category.Name);
                return RedirectToAction("ListCategories");
            }
            else
            {
                return View(category);
            }
        }
        public ActionResult AddCategory(CategoryModel category)
        {
            return View("EditCategory", new CategoryModel());
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            CategoryModel deletedCategory = await _categoryRepository.DeleteCategoryAsync(categoryId);
            if (deletedCategory != null)
            {
                TempData["message"] = string.Format("Категория \"{0}\" была удалена!", deletedCategory.Name);
            }
            return RedirectToAction("ListCategories");
        }
        #endregion

        #region ClothesTypeMethods
        public async Task<ActionResult> ListClothesTypes(string searchName)
        {
            ICollection<ClothesTypeModel> clothesTypes = await this._typeRepository.GetClothesTypesAsync(searchName);
            return View(clothesTypes);
        }

        [HttpGet]
        public async Task<ActionResult> EditClothesType(int? clothesTypeId)
        {
            if (clothesTypeId != null)
            {
                ClothesTypeModel clothesType = await this._typeRepository.GetClothesTypeByIdAsync((int)clothesTypeId);
                if (clothesType != null)
                {
                    return View(clothesType);
                }
                return RedirectToAction("ListClothesTypes");
            }
            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditClothesType(ClothesTypeModel clothesType)
        {
            if (ModelState.IsValid)
            {
                await this._typeRepository.SaveClothesTypeAsync(clothesType);

                TempData["message"] = string.Format("Изменения в типе одежды \"{0}\" были сохранены", clothesType.Name);
                return RedirectToAction("ListClothesTypes");
            }
            else
            {
                return View(clothesType);
            }
        }
        public ActionResult AddClothesType(ClothesTypeModel clothesType)
        {
            return View("EditClothesType", new ClothesTypeModel());
        }

        [HttpPost]
        public async Task<ActionResult> DeleteClothesType(int clothesTypeId)
        {
            ClothesTypeModel deletedClothesType = await this._typeRepository.DeleteClothesTypeAsync(clothesTypeId);
            if (deletedClothesType != null)
            {
                TempData["message"] = string.Format("Тип одежды \"{0}\" была удалена!", deletedClothesType.Name);
            }
            return RedirectToAction("ListClothesTypes");
        }
        #endregion

        #region SizeMethods
        public async Task<ActionResult> ListSizes(string searchName)
        {
            ICollection<SizeModel> size = await this._sizeRepository.GetSizesAsync(searchName);
            return View(size);
        }

        [HttpGet]
        public async Task<ActionResult> EditSize(int? sizeId)
        {
            if (sizeId != null)
            {
                SizeModel size = await this._sizeRepository.GetSizeByIdAsync((int)sizeId);
                if (size != null)
                {
                    return View(size);
                }
                return RedirectToAction("ListSizes");
            }
            return HttpNotFound();
        }

        [HttpPost]
        public async Task<ActionResult> EditSize(SizeModel size)
        {
            if (ModelState.IsValid)
            {
                await this._sizeRepository.SaveSizeAsync(size);
                TempData["message"] = string.Format("Изменения в размере \"{0}\" были сохранены", size.Name);
                return RedirectToAction("ListSizes");
            }
            else
            {
                return View(size);
            }
        }
        public ActionResult AddSize(SizeModel size)
        {
            return View("EditSize", new SizeModel());
        }
        [HttpPost]
        public async Task<ActionResult> DeleteSize(int sizeId)
        {
            SizeModel size = await this._sizeRepository.DeleteSizeAsync(sizeId);
            if (size != null)
            {
                TempData["message"] = string.Format("Размер \"{0}\" был удален!", size.Name);
            }
            return RedirectToAction("ListSizes");
        }
        #endregion

        #region OrderMethods
        public async Task<ActionResult> ListOrders(string searchName, int page = 1)
        {
            ICollection<OrderModel> orders = await this._orderRepository.GetOrdersForOnePageAsync(searchName, pageSize, page);

            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await this._orderRepository.GetCountOrdersAsync(searchName)
            };
            OrdersListViewModel model = new OrdersListViewModel()
            {
                Orders = orders,
                PagingInfo = pageInfo,
                searchName = searchName
            };
            return View(model);
        }
        public async Task<ActionResult> OrderDetails(int? orderId)
        {
            if (orderId != null)
            {
                OrderModel order = await this._orderRepository.GetOrderByIdAsync((int)orderId);
                if (order != null)
                {
                    return View(order);
                }
                return RedirectToAction("ListOrders");
            }
            return HttpNotFound();
        }
        #endregion

        #region ReviewsMethods

        public async Task<ActionResult> ListReviews(SearchReview search, int page = 1)
        {
            ICollection<ReviewModel> reviews = await this._reviewRepository.GetReviewsForOnePageAsync(search, pageSize, page);

            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await this._reviewRepository.GetCountReviewsAsync(search)
            };
            ReviewsListViewModel model = new ReviewsListViewModel()
            {
                Reviews = reviews,
                PagingInfo = pageInfo,
                Search = search
            };

            return View(model);
        }
        public async Task<ActionResult> Reviews(SearchReview search, int page = 1)
        {
            ICollection<ReviewModel> reviews = await this._reviewRepository.GetReviewsForOnePageAsync(search, pageSize, page);

            PagingInfo pageInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = await this._reviewRepository.GetCountReviewsAsync(search)
            };
            ReviewsListViewModel model = new ReviewsListViewModel()
            {
                Reviews = reviews,
                PagingInfo = pageInfo,
                Search = search
            };

            return PartialView("_PartialAdmin_Reviews",model);
        }
        public async Task<ActionResult> ViewReview(int? Id)
        {
            if (Id != null)
            {
                ReviewModel review = await this._reviewRepository.GetReviewByIdAsync((int)Id);
                if (review != null)
                {
                    return View(review);
                }
            }
            return RedirectToAction("ListReviews");
        }
        public async Task<ActionResult> DeleteReview(int? reviewId)
        {
            if (reviewId != null)
            {
                ReviewModel deletedReview = await this._reviewRepository.DeleteReviewAsync((int)reviewId);
                if (deletedReview != null)
                {
                    TempData["message"] = string.Format("Отзывы был удален!");
                }
            }
            return RedirectToAction("ListReviews");
        }

        #endregion

        #endregion
    }
}