using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class SizeModel
    {
        public int SizeId { get; set; }

        [MaxLength(10)]
        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название размера")]
        public string Name { get; set; }
    }
}
