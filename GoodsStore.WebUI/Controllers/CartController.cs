using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services;
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
    public class CartController : Controller
    {
        #region Fields
        private IGoodsRepository repository;
        private ISizeRepository sizeRepository;
        private IOrderProcessor orderProcessor;
        private IOrderRepository orderRepository;
        #endregion

        #region Constructor
        public CartController(IGoodsRepository repository, IOrderProcessor orderProcessor,
            IOrderRepository orderRepository,ISizeRepository sizeRepository)
        {
            this.repository = repository;
            this.sizeRepository = sizeRepository;
            this.orderProcessor = orderProcessor;
            this.orderRepository = orderRepository;
        }
        #endregion

        #region Methods
        public ViewResult Index(Cart cart,string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public async Task<RedirectToRouteResult> AddToCart(Cart cart,CartLineViewModel model)
        {
            if (model.sizeId != null)
            {
                GoodsModel goods = await this.repository.GetGoodsByIdAsync(model.goodsId);
                SizeModel size = await this.sizeRepository.GetSizeByIdAsync((int)model.sizeId);
                if (goods != null)
                {
                    cart.AddItem(goods,size, Convert.ToInt32(model.quantity));
                }
                return RedirectToAction("Index", new { model.returnUrl });
            }
            TempData["message"] = "Выберите размер";
            return RedirectToAction("GetGoodsDescription", "Goods", new { goodsId = model.goodsId });
        }

        public async Task<RedirectToRouteResult> RemoveFromCart(Cart cart,CartLineViewModel model)
        {
            GoodsModel goods = await this.repository.GetGoodsByIdAsync(model.goodsId);
            SizeModel size = await this.sizeRepository.GetSizeByIdAsync((int)model.sizeId);
            if (goods != null)
            {
                cart.RemoveLine(goods,size);
            }
            return RedirectToAction("Index", new { model.returnUrl });
        }
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        [HttpGet]
        public ActionResult Checkout(Cart cart,string returnUrl)
        {
            if (cart.Lines.Count() == 0)
            {
                return RedirectToAction("Index", new { returnUrl });
            }
            return View(new OrderModel());
        }

        [HttpPost]
        public async Task<ViewResult> Checkout(Cart cart, OrderModel shippingDetails)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                await orderProcessor.ProcessOrder(cart, shippingDetails);
                await orderRepository.SaveOrderAsync(shippingDetails, cart.Lines);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }
        #endregion
    }
}