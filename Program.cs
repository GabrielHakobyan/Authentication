using Authentication.AuthModel;
using Authentication.DataBase;
using Authentication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
});
builder.Services.AddAuthorization();
builder.Services.AddTransient<IPersons, OperationDb>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = true,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["testycooki"];
                return Task.CompletedTask;
            }
        };
    });
var app = builder.Build();

app.UseDefaultFiles();
//app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();


app.MapControllerRoute(name: "default", pattern: ("{controller=Home}/{action=Login}/{id?}"));
//app.Map("/login/{username}", (string username) =>
//{
//    var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };
//    // создаем JWT-токен
//    var jwt = new JwtSecurityToken(
//            issuer: AuthOptions.ISSUER,
//            audience: AuthOptions.AUDIENCE,
//            claims: claims,
//            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
//            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

//    return new JwtSecurityTokenHandler().WriteToken(jwt);
//});

//app.Map("/data", [Authorize] () => new { message = "Hello World!" });


app.Run();
