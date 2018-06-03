using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class SearchReview
    {
        public string UserName { get; set; }
        public int? goodsId { get; set; }
        public int? rating { get; set; }
        public string searchName { get; set; }
    }
}
