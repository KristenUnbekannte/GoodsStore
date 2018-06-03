using GoodsStore.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class ReviewsListViewModel
    {
        public IEnumerable<ReviewModel> Reviews { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public GoodsModel Goods { get; set; }
        public SearchReview Search { get; set; }
    }
}