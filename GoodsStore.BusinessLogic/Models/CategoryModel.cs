using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [MaxLength(20)]
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название категории")]
        public string Name { get; set; }
    }
}
