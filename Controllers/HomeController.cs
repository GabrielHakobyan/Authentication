using Authentication.AuthModel;
using Authentication.Services;
using Authentication.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class HomeController(IPerson person) : Controller
    {
        IPerson _person = person;
        [AuthorizationFilter]
      //  [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        //public string Createjwt([FromBody] Person person)
        //{
        //    var pers = _person.Get.Where(a => a.Email == person.Email && a.Password == person.Password);
        //    // Person pers = new Person();
        //    string a = "dasd";
        //    return a;
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LoginIn(Person person)
        {
           
            var pers = _person.Get.Where(a => a.Email == person.Email && a.Password == person.Password).FirstOrDefault();
            if (pers == null)
            {
                ModelState.AddModelError("", "Polzovatel ne sushestvuet!");
                return RedirectToAction("Login", "Home");
            }
            var claims = new List<Claim> { new(ClaimTypes.Name, person.Email)};
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            this.HttpContext.Response.Cookies.Append("testycooki", encodedJwt);
           
            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = person.Email
            };

            //Json(response);
            //this.Url.RouteUrl("/Home/Index");
            return RedirectToAction("Index");
        }
    }
}
