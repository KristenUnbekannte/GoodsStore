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
    public class OrderRepository : IOrderRepository
    {
        private readonly GoodsStoreDbContext _context;
        public OrderRepository(GoodsStoreDbContext db)
        {
            this._context = db;
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            Order order = await this._context.Orders.FirstOrDefaultAsync(o=>o.OrderId==orderId);
            return Mapper.Map<Order, OrderModel>(order);
        }
        public async Task<int> GetCountOrdersAsync(string search)
        {
            int count = await this._context.Orders
                .Where(o => ((search == null || search == "") || o.City.ToUpper().Contains(search.ToUpper())
                  || o.Country.ToUpper().Contains(search.ToUpper()))).CountAsync();
            return count;
        }
        public async Task<ICollection<OrderModel>> GetOrdersForOnePageAsync(string search, int pageSize, int page)
        {
            List<Order> orders = await this._context.Orders
                .Where(o=>((search == null||search=="") || o.City.ToUpper().Contains(search.ToUpper())
                  || o.Country.ToUpper().Contains(search.ToUpper())))
                  .OrderByDescending(o=> o.Date)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize).ToListAsync();

            return Mapper.Map<List<Order>, List<OrderModel>>(orders);
        }
        public async Task SaveOrderAsync(OrderModel orderModel, IEnumerable<CartLine> lines)
        {
            Order order = Mapper.Map<OrderModel,Order>(orderModel);
            order.Date=DateTime.Now;
            order.TotalPrice = lines.Sum(l => l.Quantity * l.Goods.Price);
            order.OrderDetails = new List<OrderDetails>();

            foreach (CartLine line in lines)
            {
                OrderDetails details = new OrderDetails
                {
                    GoodsId = line.Goods.GoodsId,
                    SizeId = line.Size.SizeId,
                    Quantity = line.Quantity,
                    Price = line.Goods.Price,
                    TotalPrice = line.Quantity * line.Goods.Price,
                };
                order.OrderDetails.Add(details);
            }
            this._context.Orders.Add(order);
            await this._context.SaveChangesAsync();
        }
    }
}
