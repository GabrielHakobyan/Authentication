using Authentication.AuthModel;
using Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Authentication.Controllers
{
    public class HomeController(IPerson person) : Controller
    {
        IPerson _person = person;
        [Authorize]
        public IActionResult Inde()
        {
            return RedirectToAction("Index");
        }
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
        public IResult LoginIn([FromBody] Person person)
        {
            var pers = _person.Get.Where(a => a.Email == person.Email && a.Password == person.Password).FirstOrDefault();
            if (pers == null)
            {
                return Results.Unauthorized();
            }
            var claims = new List<Claim> { new(ClaimTypes.Name, person.Email) };
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // формируем ответ
            var response = new
            {
                access_token = encodedJwt,
                username = person.Email
            };

            return Results.Json(response);
        }
    }
}
