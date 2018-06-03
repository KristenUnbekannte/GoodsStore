using GoodsStore.Domain.Entities;
using GoodsStore.BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoodsStore.BusinessLogic.Models;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderModel> GetOrderByIdAsync(int orderId);
        Task<int> GetCountOrdersAsync(string search);
        Task<ICollection<OrderModel>> GetOrdersForOnePageAsync(string search, int pageSize, int page);
        Task SaveOrderAsync(OrderModel details, IEnumerable<CartLine> lines);
    }
}
