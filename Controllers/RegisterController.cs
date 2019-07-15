using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace UmbracoWebApplicationHOC.Controllers
{
    public class RegisterController : SurfaceController
    {
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return CurrentUmbracoPage();
            //Member Creation Code
            var memberService = Services.MemberService;

            if (memberService.GetByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", "A Member with that email already exists");
                return CurrentUmbracoPage();
            }

            var member = memberService.CreateMemberWithIdentity(model.Email, model.Email, model.Name, "Member");

            //member.SetValue("bio", model.Biography);
            //member.SetValue("avatar", model.Avatar);

            memberService.SavePassword(member, model.Password);
            Members.Login(model.Email, model.Password);

            //memberService.Save(member);

            return Redirect("/");
        }
    }
}