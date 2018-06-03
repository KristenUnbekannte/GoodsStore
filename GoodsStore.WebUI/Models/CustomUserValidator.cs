using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace GoodsStore.WebUI.Models
{
    public class CustomUserValidator: UserValidator<ApplicationUser>
    {
        private ApplicationUserManager _userManager;
        public CustomUserValidator(ApplicationUserManager mgr): base(mgr)
        {
            AllowOnlyAlphanumericUserNames = false;
            _userManager = mgr;
        }
        public override async Task<IdentityResult> ValidateAsync(ApplicationUser user)
        {
            IdentityResult result = await base.ValidateAsync(user);
            var find_user = await _userManager.FindByNameAsync(user.UserName);
            if(find_user!=null)
            {
                var errors = result.Errors.ToList();
                errors.Add("Такой ник уже существует");
                result = new IdentityResult(errors);
            }
            if (user.UserName.Contains("admin"))
            {
                var errors = result.Errors.ToList();
                errors.Add("Ник пользователя не должен содержать слово 'admin'");
                result = new IdentityResult(errors);
            }
            return result;
        }
    }
}