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
    public class SizeRepository : ISizeRepository
    {
        private readonly GoodsStoreDbContext _context;
        public SizeRepository(GoodsStoreDbContext context)
        {
            this._context = context;
        }

        public async Task<SizeModel> GetSizeByIdAsync(int sizeId)
        {
            Size size = await this._context.Sizes.FirstOrDefaultAsync(s => s.SizeId == sizeId);
            return Mapper.Map<Size, SizeModel>(size);
        }
        public async Task<ICollection<SizeModel>> GetSizesAsync(string search)
        {
            List<Size> sizes = await this._context.Sizes
                .Where(c => ((search== null||search=="") || c.Name.ToUpper()
                .Contains(search.ToUpper()))).ToListAsync();
            return Mapper.Map<List<Size>,List<SizeModel>>(sizes);
        }
        public ICollection<SizeModel> GetSizes()
        {
            List<Size> sizes = this._context.Sizes.ToList();
            return Mapper.Map<List<Size>, List<SizeModel>>(sizes);
        }
        public async Task SaveSizeAsync(SizeModel size)
        {
            if (size.SizeId == 0)
            {
                this._context.Sizes.Add(Mapper.Map<SizeModel,Size>(size));
            }
            else
            {
                Size newSize = await this._context.Sizes.FindAsync(size.SizeId);
                newSize.Name = size.Name;
            }
            await this._context.SaveChangesAsync();
        }
        public async Task<SizeModel> DeleteSizeAsync(int sizeId)
        {
            Size size = await this._context.Sizes.FindAsync(sizeId);
            if (size != null)
            {
                this._context.Sizes.Remove(size);
                await this._context.SaveChangesAsync();
            }
            return Mapper.Map<Size,SizeModel>(size);
        }
    }
}
