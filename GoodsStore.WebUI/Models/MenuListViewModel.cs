using GoodsStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodsStore.WebUI.Models
{
    public class MenuListViewModel
    {
        public SelectList Categories { get; set; }
        public ICollection<ClothesTypeModel> ClothesTypes { get; set; }
        public ICollection<SizeModel> Sizes { get; set; }
        public SearchGoods Search { get; set; }
    }
}