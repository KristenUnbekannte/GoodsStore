using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services
{
    public class CartLine
    {
        public GoodsModel Goods { get; set; }
        public SizeModel Size { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();
        public void AddItem(GoodsModel goods, SizeModel size, int quantity)
        {
            CartLine line = _lineCollection
                .Where(g => g.Goods.GoodsId == goods.GoodsId&&g.Size.SizeId==size.SizeId)
                .FirstOrDefault();

            if (line == null)
            {
                _lineCollection.Add(new CartLine
                {
                    Goods = goods,
                    Quantity = quantity,
                    Size = size
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(GoodsModel goods,SizeModel size)
        {
            _lineCollection.RemoveAll(l => l.Goods.GoodsId == goods.GoodsId&&l.Size.SizeId==size.SizeId);
        }

        public decimal ComputeTotalValue()
        {
            return _lineCollection.Sum(e => e.Goods.Price * e.Quantity);

        }
        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
        }
    }
}
