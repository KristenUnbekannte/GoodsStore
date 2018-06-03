using GoodsStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoodsStore.WebUI.Models
{
    public class MenuForReviewListModel
    {
        public SelectList Goods{ get; set; }
        public SearchReview Search { get; set; }
    }
}