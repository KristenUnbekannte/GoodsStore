using AutoMapper;
using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic
{
    public class BLLMappingProfile : Profile
    {
        public BLLMappingProfile()
        {
            this.CreateMap<Size, SizeModel>();
            this.CreateMap<SizeModel, Size>();
            this.CreateMap<ClothesType, ClothesTypeModel>();
            this.CreateMap<ClothesTypeModel, ClothesType>();
            this.CreateMap<Category, CategoryModel>();
            this.CreateMap<CategoryModel, Category>();

            this.CreateMap<Review, ReviewModel>()
                .ForMember(r => r.GoodsName, opt => opt.MapFrom(g => g.Goods.Name));
            this.CreateMap<ReviewModel, Review>();

            this.CreateMap<Order, OrderModel>();
            this.CreateMap<OrderModel, Order>();

            this.CreateMap<Goods, GoodsModel>()
                .ForMember(g => g.Sizes, opt => opt.MapFrom(s => s.Sizes.ToList()))
                .ForMember(g => g.CategoryName, opt => opt.MapFrom(c => c.Category.Name))
                .ForMember(g => g.ClothesTypeName, opt => opt.MapFrom(c => c.ClothesType.Name));

            this.CreateMap<GoodsModel, Goods>()
                .ForMember(g => g.Sizes, opt => opt.MapFrom(s => s.Sizes));

            this.CreateMap<OrderDetails, OrderDetailsModel>()
                .ForMember(o => o.SizeName, opt => opt.MapFrom(s => s.Size.Name))
                .ForMember(o => o.GoodsName, opt => opt.MapFrom(g => g.Goods.Name));
        }
    }
}
