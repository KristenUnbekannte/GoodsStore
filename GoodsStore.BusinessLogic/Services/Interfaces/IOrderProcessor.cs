using GoodsStore.BusinessLogic.Models;
using GoodsStore.BusinessLogic.Services;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderProcessor
    {
        Task ProcessOrder(Cart cart, OrderModel shippingDetails);
    }
}
