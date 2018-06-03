using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }
        public int GoodsId { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string GoodsName { get; set; }
    }
}
