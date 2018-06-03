using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class AppDbInitializer: DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
 
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
 
            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };
 
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
 
            // создаем пользователей
            var admin = new ApplicationUser { Email = "kristina.platkovskaya@mail.ru", UserName = "Admin" };
            admin.EmailConfirmed = true;
            string password = "c0c@c0l@9319";
            var result = userManager.Create(admin, password);

            // если создание пользователя прошло успешно
            if(result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }

            var kristina = new ApplicationUser { Email = "kristina.platkovskaya@gmail.com", UserName = "Kristina" };
            kristina.EmailConfirmed = true;
            result = userManager.Create(kristina, "Kristina23");

            if (result.Succeeded)
                userManager.AddToRole(kristina.Id, role2.Name);

            var milana = new ApplicationUser { Email = "milana.@mail.ru", UserName = "Милана" };
            milana.EmailConfirmed = true;
            result = userManager.Create(milana, "Milana23");

            if (result.Succeeded)
                userManager.AddToRole(milana.Id, role2.Name);

            var sveta = new ApplicationUser { Email = "svetlana@mail.ru", UserName = "Светик" };
            sveta.EmailConfirmed = true;
            result = userManager.Create(sveta, "Svetlana23");

            if (result.Succeeded)
                userManager.AddToRole(sveta.Id, role2.Name);

            var alex = new ApplicationUser { Email = "alex@gmail.com", UserName = "Alex" };
            alex.EmailConfirmed = true;
            result = userManager.Create(alex, "Alex11");

            if (result.Succeeded)
                userManager.AddToRole(alex.Id, role2.Name);


            var misha = new ApplicationUser { Email = "misha@gmail.com", UserName = "Миша" };
            misha.EmailConfirmed = true;
            result = userManager.Create(misha, "Misha11");

            if (result.Succeeded)
                userManager.AddToRole(misha.Id, role2.Name);


            base.Seed(context);
        }
    }
}