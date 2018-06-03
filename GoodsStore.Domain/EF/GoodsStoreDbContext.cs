using GoodsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodsStore.Domain.EF
{
    public class GoodsStoreDbContext : DbContext
    {
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ClothesType> ClothesTypes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
    public class GoodsDbInitializer : DropCreateDatabaseAlways<GoodsStoreDbContext>
    {
        protected override void Seed(GoodsStoreDbContext db)
        {
            #region Sizes
            Size xs = new Size { Name = "XS" };
            db.Sizes.Add(xs);

            Size s = new Size { Name = "S" };
            db.Sizes.Add(s);

            Size m = new Size { Name = "M" };
            db.Sizes.Add(m);

            Size l = new Size { Name = "L" };
            db.Sizes.Add(l);

            Size xl = new Size { Name = "XL" };
            db.Sizes.Add(xl);


            #endregion

            #region Categories
            db.Categories.Add(new Category { Name = "Джинсы" });
            db.Categories.Add(new Category { Name = "Платья" });
            db.Categories.Add(new Category { Name = "Футболки" });
            db.Categories.Add(new Category { Name = "Шорты" });
            db.Categories.Add(new Category { Name = "Джемперы" });
            db.Categories.Add(new Category { Name = "Юбки" });
            db.Categories.Add(new Category { Name = "Брюки" });
            #endregion

            #region Clothes types
            db.ClothesTypes.Add(new ClothesType { Name = "Женская" });
            db.ClothesTypes.Add(new ClothesType { Name = "Мужская" });
            #endregion

            //21 шт.
            #region Female
            //женские джинсы
            db.Goods.Add(new Goods { Name = "Джинсы роза", Price = 38.50m, Description = "Женские джинсы на тонкой байке. Цветной рисунок располагается по всей длине.Original rise – это джинсы из разряда «нормальных». Сидят они чуть-чуть ниже, чем  high wasted. Пояс изделия находится на линии талии.Slim fit – модель в точности повторяющая формы тела. ", CategoryId = 1, ClothesTypeId = 1, NumberOfReviews = 2, Rating = 4.5, Sizes = new List<Size> { xs, s, l } });
            db.Reviews.Add(new Review { GoodsId = 1, UserName = "Kristy", Comment = "Джинсы просто восхитительные!!Рисунок такой яркий и четкий!", Rating = 5, Date = DateTime.Now });
            db.Reviews.Add(new Review { GoodsId = 1, UserName = "Катя", Comment = "Джинсы красивые, вот только размер немного великоват оказался.", Rating = 4, Date = new DateTime(2018, 04, 15, 12, 15, 13) });

            db.Goods.Add(new Goods { Name = "Розали", Price = 32.00m, Description = "Джинсы женские Original rise.Цветовая политра варьируется от темно-синего к светло-голубому, почти белому. Переход цвета очень плавный и мягкий.Slim fit – модель в точности повторяющая формы тела. ", CategoryId = 1, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { xs, m, l } });
            db.Reviews.Add(new Review { GoodsId = 2, UserName = "Екатерина", Comment = "Очень мягкие и эластичная. Доставка очень быстрая. Очень понравились!!! :)", Rating = 5, Date = new DateTime(2018, 04, 11, 18, 23, 12) });

            db.Goods.Add(new Goods { Name = "Rock style jeans", Price = 43.80m, Description = "Женские джинсы Low rise. Пояс таких джинс фиксируется на бедрах.Regular fit – универсальная модель унисекс. Основная характеристика модели – прямые штанины. Крой – стандартный. Джинсы со стразами и потертостями.;", CategoryId = 1, ClothesTypeId = 1, Sizes = new List<Size> { xs, s, l } });

            db.Goods.Add(new Goods { Name = "Моника", Price = 28.85m, Description = "Джинсы женские Original rise.Slim fit – модель в точности повторяющая формы тела. Цвет от светло-голубого до белого, переход плавный. Материал очень мягкий, садится по фигуре. ", CategoryId = 1, ClothesTypeId = 1, NumberOfReviews = 4, Rating = 3.8, Sizes = new List<Size> { xs, s, xl } });
            db.Reviews.Add(new Review { GoodsId = 4, UserName = "Виктория", Comment = "Джинсы блеклые, такое ощущение, что их стирали огромное количество раз, не соответствуют картинке!", Rating = 1, Date = new DateTime(2018, 04, 11, 18, 23, 23) });
            db.Reviews.Add(new Review { GoodsId = 4, UserName = "Катя_Cat", Comment = "Мне джинсы очень понравились) Цвет такой летний).", Rating = 5, Date = new DateTime(2018, 04, 19, 12, 55, 34) });
            db.Reviews.Add(new Review { GoodsId = 4, UserName = "Настя1", Comment = "Джинсы просто отпад какие классные))))Очень рада, что купила именно здесь!", Rating = 5, Date = new DateTime(2018, 04, 24, 19, 24, 23) });
            db.Reviews.Add(new Review { GoodsId = 4, UserName = "Виолетта", Comment = "Цвет немного тускловат, но в целом джинсы классные.", Rating = 4, Date = new DateTime(2018, 04, 01, 13, 23, 54) });

            //женские платья
            db.Goods.Add(new Goods { Name = "Beauty", Price = 35.55m, Description = "Короткое белое кружевное платье с длинными рукавами и расклешенной юбкой.", CategoryId = 2, ClothesTypeId = 1, NumberOfReviews = 5, Rating = 4.2, Sizes = new List<Size> { xs, s } });
            db.Reviews.Add(new Review { GoodsId = 5, UserName = "Милана", Comment = "Платье очень нежное, такой изумительный цвет. Давно о таком мечтала.", Rating = 5, Date = new DateTime(2018, 05, 26, 22, 24, 34) });
            db.Reviews.Add(new Review { GoodsId = 5, UserName = "Black_cat", Comment = "Ужас!!!!!На платье затяжки.", Rating = 2, Date = new DateTime(2018, 04, 12, 15, 34, 00) });
            db.Reviews.Add(new Review { GoodsId = 5, UserName = "Настя1", Comment = "Очень романтичное и изящное)", Rating = 5, Date = new DateTime(2018, 04, 14, 12, 23, 35) });
            db.Reviews.Add(new Review { GoodsId = 5, UserName = "Маша", Comment = "Nice.This dress is a dream for any girl!", Rating = 5, Date = new DateTime(2018, 05, 23, 19, 23, 44) });
            db.Reviews.Add(new Review { GoodsId = 5, UserName = "Мирослава", Comment = "Цвет немного не соответствует.Но в целом осталась довольна. :)", Rating = 4, Date = new DateTime(2018, 05, 29, 22, 12, 34) });

            db.Goods.Add(new Goods { Name = "Джулия", Price = 42.00m, Description = "Короткое черно-белое платье с расклешенной юбкой. Платье с длинные руками, верх черный. Юбка белая с темной окантовкой.", CategoryId = 2, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { s, l,xl } });
            db.Reviews.Add(new Review { GoodsId = 6, UserName = "Анна", Comment = "отличное платье!", Rating = 5, Date = new DateTime(2018, 05, 13, 14, 25, 12) });

            db.Goods.Add(new Goods { Name = "Бриджит", Price = 49.80m, Description = "Женское платье короткое спереди и длинное сзади. Цвет нежно розовый переходящий в светло-фиолетовый оттенок. На верхней части платье черные маленькие цветы, объединенные в один ряд. Тюль черный.", CategoryId = 2, ClothesTypeId = 1, Sizes = new List<Size> { xs, s, m} });

            //женские футболки
            db.Goods.Add(new Goods { Name = "Футболка белая Жираф", Price = 22.25m, Description = "Футболка белая с изображением жирафа. Материал - хлопок.", CategoryId = 3, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 4, Sizes = new List<Size> { m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 8, UserName = "Анастасия", Comment = "Очень милая и позитивная футболка!!!", Rating = 4, Date = new DateTime(2018, 05, 13, 14, 25, 12) });

            db.Goods.Add(new Goods { Name = "Футболка Kitty", Price = 20.00m, Description = "Футболка темно-синяя с надписью Levis. Материал - хлопок.", CategoryId = 3, ClothesTypeId = 1, Sizes = new List<Size> { xs, s, m, l, xl } });

            db.Goods.Add(new Goods { Name = "Футболка Black night", Price = 21.59m, Description = "Футболка черная, свободная с надписью \"Boy London\". Материал - хлопок.", CategoryId = 3, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { xs, s, l } });
            db.Reviews.Add(new Review { GoodsId = 10, UserName = "Anna_Number_one", Comment = "Идеальный пример соотношения цены и качества. Рекомендую!", Rating = 5, Date = new DateTime(2018, 04, 13, 00, 25, 23) });

            //женские шорты
            db.Goods.Add(new Goods { Name = "Шорты бежевые Жасмин", Price = 38.75m, Description = "Женские тканевые бежевые шорты с коричневым поясом.", CategoryId = 4, ClothesTypeId = 1, Sizes = new List<Size> { s, l } });

            db.Goods.Add(new Goods { Name = "Shorts Melissa", Price = 29.99m, Description = "Женские джинсывое щорты бойфренды. Цвет темно-синий", CategoryId = 4, ClothesTypeId = 1, Sizes = new List<Size> {  s, m, l} });

            db.Goods.Add(new Goods { Name = " Шорты Style", Price = 40.00m, Description = "Женские короткие темно-синие шарты с клепами и рисунком.Цветовая палитра рисунка от светло-корричневого до темно-коричневого цвета. Клепы располагаеются рядом с передними карманами.", CategoryId = 4, ClothesTypeId = 1, NumberOfReviews = 3, Rating = 5, Sizes = new List<Size> { xs, s, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 13, UserName = "Милана", Comment = "Восторг!!!!!Они очень крутые!!!!!!!!!!!10 из 10.", Rating = 5, Date = new DateTime(2018, 05, 22, 21, 24, 19) });
            db.Reviews.Add(new Review { GoodsId = 13, UserName = "Настёна", Comment = "Сидят как влитые. я в восторге)", Rating = 5, Date = new DateTime(2018, 04, 14, 15, 34, 23) });
            db.Reviews.Add(new Review { GoodsId = 13, UserName = "Вероника", Comment = "То, что мне было нужно. Качество изумительное!", Rating = 5, Date = new DateTime(2018, 04, 16, 17, 45, 34) });

            //женские джемперы
            db.Goods.Add(new Goods { Name = "Джемпер Коты", Price = 35.15m, Description = "Джемпер белого цвета с длинными рукавами и рисунком. На рисунке спереди избражены три кота разных цветов.", CategoryId = 5, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { s, m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 14, UserName = "Miraslava", Comment = "Прекрасный джемпер :) Я довольна покупкой)", Rating = 5, Date = new DateTime(2018, 04, 12, 00, 12, 15) });

            db.Goods.Add(new Goods { Name = "Джемпер Белая ночь", Price = 31.60m, Description = "Джемпер белого цвета, свободный, немного удлиненный с рукавами в 2/3.", CategoryId = 5, ClothesTypeId = 1, NumberOfReviews = 3, Rating = 5, Sizes = new List<Size> { xs, s, m, l } });
            db.Reviews.Add(new Review { GoodsId = 15, UserName = "Мила", Comment = "Мне очень понравился и доставка быстрая", Rating = 5, Date = new DateTime(2018, 04, 20, 18, 23, 15) });
            db.Reviews.Add(new Review { GoodsId = 15, UserName = "Мариса", Comment = "Суперский!!!", Rating = 5, Date = new DateTime(2018, 02, 15, 00, 23, 45) });
            db.Reviews.Add(new Review { GoodsId = 15, UserName = "Моника", Comment = "Джемпер хорошо качества и цвет отличный", Rating = 5, Date = new DateTime(2018, 01, 18, 15, 12, 17) });

            db.Goods.Add(new Goods { Name = "Джемпер Солнечный взрыв", Price = 30.99m, Description = "Джемпер укороченный ярко-желтого цвета.Хлопковая фабрика. Трикотажная ткань. Ажурные детали. Закругленная шея. Длинный рукав. Кабельный трикотаж.", CategoryId = 5, ClothesTypeId = 1, NumberOfReviews = 1, Rating = 4, Sizes = new List<Size> { s, m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 16, UserName = "Моника", Comment = "Джемпер хорошо качества, но цвет отличается. Он более тусклый!", Rating = 4, Date = new DateTime(2018, 01, 22, 16, 13, 11) });

            //женские юбки
            db.Goods.Add(new Goods { Name = "Юбка Клара", Price = 35.64m, Description = "Расклешенная юбка каралового цвета.", CategoryId = 6, ClothesTypeId = 1, Sizes = new List<Size> {  m, l, xl } });

            db.Goods.Add(new Goods { Name = "Юбка Милана", Price = 32.99m, Description = "Льняная юбка голубого цвета с карманами в боковых швах и  ассиметричным низом.  Изделие с широким поясом и складками по всей окружности. Застежка на тесьму \"молния\" по среднему шву заднего полотнища юбки.", CategoryId = 6, ClothesTypeId = 1, Sizes = new List<Size> { s, l } });

            db.Goods.Add(new Goods { Name = "Адель", Price = 30.7099m, Description = "Трикотажная юбка ниже колена со складками по всей окружности. Ткань светлая с изображением роз.", CategoryId = 6, ClothesTypeId = 1, NumberOfReviews = 2, Rating = 4.5, Sizes = new List<Size> {  m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 19, UserName = "Валентина", Comment = "Я просто безу от неё!", Rating = 5, Date = new DateTime(2018, 02, 19, 16, 13, 11) });
            db.Reviews.Add(new Review { GoodsId = 19, UserName = "Кокетка", Comment = "Доставка ооочень медленная. А юбкой довольна. Снимаю звезду за обслуживание!", Rating = 4, Date = new DateTime(2018, 01, 22, 23, 45, 11) });

            //женские брюки
            db.Goods.Add(new Goods { Name = "Брюки классика", Price = 29.99m, Description = "Зауженные женские брюки с манжетой темно-красного цвета.Брюки с манжетой – это модель штанов с собранными внизу штанинами.", CategoryId = 7, ClothesTypeId = 1, Sizes = new List<Size> { xs, s, m, l, xl } });

            db.Goods.Add(new Goods { Name = "Мидди", Price = 31.80m, Description = "Женские черные брюки Чинос.Брюки-чинос представляют собой фасон свободных брюк со срезанными карманами по бокам, складочками по талии; слегка сужающиеся книзу, но не облегающие ногу. ", CategoryId = 7, ClothesTypeId = 1, Sizes = new List<Size> { xs, s, m, l } });
            #endregion

            //16 шт.
            #region Male
            //мужские джинсы
            db.Goods.Add(new Goods { Name = "Мужские джинсы Терра", Price = 39.99m, Description = "Мужские джинсы с зауженным низом. Цвет джинс темно-синий, спереди полоски светлого цвета, переход контрасный.", CategoryId = 1, ClothesTypeId = 2, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 22, UserName = "Никита", Comment = "Зачетные джинсы", Rating = 5, Date = new DateTime(2018, 04, 18, 12, 55, 34) });

            db.Goods.Add(new Goods { Name = "Джинсы Original", Price = 41.18m, Description = "Мужские зауженные джинсы светлого цвета. Плавный переход от светло-синего к светло-голубому цвету.", CategoryId = 1, ClothesTypeId = 2, NumberOfReviews = 2, Rating = 3.5, Sizes = new List<Size> { s, l } });
            db.Reviews.Add(new Review { GoodsId = 23, UserName = "Слава", Comment = "Зря деньги потратил.", Rating = 2, Date = new DateTime(2018, 04, 19, 06, 55, 12) });
            db.Reviews.Add(new Review { GoodsId = 23, UserName = "Марго", Comment = "Джинсы отличаются хорошим цветом и качеством.Покупала своему парню. Идеально подошел размер.", Rating = 5, Date = new DateTime(2018, 04, 01, 18, 45, 03) });

            db.Goods.Add(new Goods { Name = "Джинсы Smile", Price = 43.89m, Description = "Джинсы мужские прямые с поясом средней длины светлого цвета. Состав: 100% хлопок.", CategoryId = 1, ClothesTypeId = 2, Sizes = new List<Size> { s, m, l } });

            db.Goods.Add(new Goods { Name = "Джинсы Tom", Price = 37.15m, Description = "Мужские джинсы-джоггеры темного цвета со светлыми полосками спереди.", CategoryId = 1, ClothesTypeId = 2, Sizes = new List<Size> { xs, s, l, xl } });

            //мужские футболки
            db.Goods.Add(new Goods { Name = "Футболка Jim", Price = 22.80m, Description = "Футболка светло-серого цвета с V-образным вырезом и надписью черного цвета.", CategoryId = 3, ClothesTypeId = 2, NumberOfReviews = 1, Rating = 4, Sizes = new List<Size> { m, l, xl } });
            db.Reviews.Add(new Review { GoodsId = 26, UserName = "Борис", Comment = "Вполне приличное качество за такие деньги.", Rating = 4, Date = new DateTime(2018, 04, 28, 09, 26, 22) });

            db.Goods.Add(new Goods { Name = "Футболка Волк", Price = 20.99m, Description = "Мужская черная футболка с изображением волка в сумрачном лесу", CategoryId = 3, ClothesTypeId = 2, Sizes = new List<Size> { xs, s, l } });

            db.Goods.Add(new Goods { Name = "Футболка Джеймс", Price = 27.00m, Description = "Футболка черная, облегающая с V-образным вырезом.", CategoryId = 3, ClothesTypeId = 2, Sizes = new List<Size> { xs, s, l } });

            db.Goods.Add(new Goods { Name = "Футболка Череп", Price = 31.75m, Description = "Футболка белая с глубоким V-образным вырезом с надписью и изображением черепа.", CategoryId = 3, ClothesTypeId = 2, NumberOfReviews = 3, Rating = 4.7, Sizes = new List<Size> { xs, s, l, xl } }); 
            db.Reviews.Add(new Review { GoodsId = 29, UserName = "Виктория", Comment = "Парень был в восторге. Подарок удался!!!", Rating = 5, Date = new DateTime(2018, 04, 13, 13, 03, 59) });
            db.Reviews.Add(new Review { GoodsId = 29, UserName = "Максим", Comment = "Неплохой вариант.", Rating = 4, Date = new DateTime(2018, 05, 11, 10, 23, 45) });
            db.Reviews.Add(new Review { GoodsId = 29, UserName = "Слава", Comment = "Футболка топовая. Картинка четкая и яркая.", Rating = 5, Date = new DateTime(2018, 02, 19, 09, 51, 38) });

            //мужские шорты
            db.Goods.Add(new Goods { Name = "Джинсовые шорты Barry", Price = 29.99m, Description = "Джинсовые шорты немного выше колена, светлого цвета. Материал мягкий, эластичный.", CategoryId = 4, ClothesTypeId = 2, NumberOfReviews = 3, Rating = 4.3, Sizes = new List<Size> { m,l} });
            db.Reviews.Add(new Review { GoodsId = 30, UserName = "Костя", Comment = "За такую цену большего и не ожидал.", Rating = 4, Date = new DateTime(2018, 04, 11, 12, 34, 53) });
            db.Reviews.Add(new Review { GoodsId = 30, UserName = "Коля", Comment = "Зачет. 5 из 5.", Rating = 5, Date = new DateTime(2018, 03, 22, 10, 35, 12) });
            db.Reviews.Add(new Review { GoodsId = 30, UserName = "Александр", Comment = "Цвет более тусклый, чем на фото. В остальном хорошие.", Rating = 4, Date = new DateTime(2018, 05, 24, 13, 17, 02) });

            db.Goods.Add(new Goods { Name = "Shorts Simple life", Price = 40.00m, Description = "Шорты спортивные, светлого-серого цвета. 100% хлопок.", CategoryId = 4, ClothesTypeId = 2, Sizes = new List<Size> { xs, s, m, xl } });

            //мужские джемперы
            db.Goods.Add(new Goods { Name = "Мужской джемпер Темперамент", Price = 44.15m, Description = "Уютный мужской вязаный белый свитер с открытым горлом и застежками на шее.", CategoryId = 5, ClothesTypeId = 2, NumberOfReviews = 4, Rating = 4.3, Sizes = new List<Size> { xs, s, m, l } });
            db.Reviews.Add(new Review { GoodsId = 32, UserName = "Мариса", Comment = "Дарила любимому человеку. Он остался очень доволен)", Rating = 5, Date = new DateTime(2018, 04, 11, 18, 11, 23) });
            db.Reviews.Add(new Review { GoodsId = 32, UserName = "Никита", Comment = "Цвет, дизайн хороший. Но вот размер не соответствуетю", Rating = 3, Date = new DateTime(2018, 04, 18, 11, 55, 55) });
            db.Reviews.Add(new Review { GoodsId = 32, UserName = "X_Zone", Comment = "Качество зачетное и выглядит топово.", Rating = 5, Date = new DateTime(2018, 04, 21, 19, 03, 23) });
            db.Reviews.Add(new Review { GoodsId = 32, UserName = "Jim", Comment = "Отличный джемпер, правда оказался немного шире, чем я думал.", Rating = 4, Date = new DateTime(2018, 02, 02, 18, 23, 51) });

            db.Goods.Add(new Goods { Name = "Джемпер Мистик", Price = 39.89m, Description = "Джемпер вязанный, удлиненный темного цвета.", CategoryId = 5, ClothesTypeId = 2, Sizes = new List<Size> {m, l } });

            db.Goods.Add(new Goods { Name = "Мужской джемпер Silver", Price = 40.99m, Description = "Мужской джемпер серого цвета. Трикотаж, круглый вырез.", CategoryId = 5, ClothesTypeId = 2, NumberOfReviews = 2, Rating = 4.5, Sizes = new List<Size> { xs, s, m } });
            db.Reviews.Add(new Review { GoodsId = 34, UserName = "Паша", Comment = "Мягкий, комфортный, уютный! 10", Rating = 5, Date = new DateTime(2018, 04, 28, 18, 23, 23) });
            db.Reviews.Add(new Review { GoodsId = 34, UserName = "Валентин", Comment = "Цвет немного унылый в реальности.", Rating = 4, Date = new DateTime(2018, 03, 19, 15, 25, 32) });

            db.Goods.Add(new Goods { Name = "Джемпер Black Light", Price = 37.99m, Description = "Мужской джемпер ADIDAS.Стильная классика. Лаконичный джемпер свободного кроя с заниженной линией плеч.60% хлопок / 40% полиэстер.", CategoryId = 5, ClothesTypeId = 2, Sizes = new List<Size> { xs, s, l } });


            //мужские брюки
            db.Goods.Add(new Goods { Name = "Брюки классика", Price = 33.99m, Description = "Брюки мужские классические зауженные серого цвета.", CategoryId = 7, ClothesTypeId = 2, NumberOfReviews = 1, Rating = 5, Sizes = new List<Size> { m, l } }); 
            db.Reviews.Add(new Review { GoodsId = 36, UserName = "Павел", Comment = "Отличный вариант для деловых мужчин. Качество высокое.Очень стильно смотрятся.", Rating = 5, Date = new DateTime(2018, 04, 01, 12, 23, 12) });

            db.Goods.Add(new Goods { Name = "Брюки Autumn", Price = 30.50m, Description = "Брюки прямого кроя. Брюки застегивается на молнию и пуговицы, шлевки для ремня, пять карманов.", CategoryId = 7, ClothesTypeId = 2, Sizes = new List<Size> { s, l } });

            #endregion

            base.Seed(db);
        }
    }
}
