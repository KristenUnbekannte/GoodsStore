using GoodsStore.BusinessLogic.Models;
using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Services.Interfaces
{
    public interface ISizeRepository
    {
        Task<SizeModel> GetSizeByIdAsync(int sizeId);
        Task<ICollection<SizeModel>> GetSizesAsync(string search=null);
        ICollection<SizeModel> GetSizes();
        Task SaveSizeAsync(SizeModel size);
        Task<SizeModel> DeleteSizeAsync(int sizeId);
    }
}
