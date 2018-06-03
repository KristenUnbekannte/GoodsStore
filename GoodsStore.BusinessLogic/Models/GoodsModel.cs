using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace GoodsStore.BusinessLogic.Models
{
    public class GoodsModel
    {
        public GoodsModel()
        {
            Sizes = new List<SizeModel>();
        }
        
        [HiddenInput(DisplayValue = false)]
        public int GoodsId { get; set; }

        [Display(Name = "Название")]
        [Required(ErrorMessage = "Пожалуйста, введите название товара")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Пожалуйста, введите описание товара")]
        public string Description { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Пожалуйста, введите категорию товара")]
        public int CategoryId { get; set; }

        [Display(Name = "Тип")]
        [Required(ErrorMessage = "Пожалуйста, введите тип товара")]
        public int ClothesTypeId { get; set; }

        [Display(Name = "Цена (руб.)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Пожалуйста, введите положительное значение для цены")]
        public decimal Price { get; set; }

        [Display(Name = "Картинка")]
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

        [Display(Name = "Количество отзывов")]
        public int NumberOfReviews { get; set; }

        [Display(Name = "Рейтинг")]
        public double Rating { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string CategoryName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ClothesTypeName { get; set; }
        public List<SizeModel> Sizes { get; set; }

    }
}
