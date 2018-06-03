using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.BusinessLogic.Models
{
    public class ClothesTypeModel
    {
        public int ClothesTypeId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название категории")]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
