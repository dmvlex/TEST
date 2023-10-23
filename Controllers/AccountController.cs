using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TEST.Models;
using TEST.Models.Data;
using TEST.Services;
using MySqlCommand = MySql.Data.MySqlClient.MySqlCommand;
using MySqlConnection = MySql.Data.MySqlClient.MySqlConnection;

namespace TEST.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHashingService hasher;
        private readonly IConfiguration configuration;
        private readonly string mySqlConnection;


        public AccountController(IHashingService _hasher,IConfiguration _configuration)
        {
            configuration = _configuration;
            mySqlConnection = configuration["MySqlTestDbConnection"];
            hasher = _hasher;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl, string error = "")
        {
            var vm = new LoginViewModel()
            { ReturnUrl = returnUrl };

            ViewData["Error"] = error;

            return View(vm);
        }

        //[HttpPost]
        //public async Task<IActionResult> Login(LoginViewModel viewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(viewModel);
        //    }
        //    else
        //    {
        //        var password = hasher.GenerateHash(viewModel.Password);

        //        var user = dbContext.Users
        //            .Where(user => user.Username == viewModel.Username)
        //            .Where(user => user.Password == password).FirstOrDefault();

        //        using (MySqlConnection connection = new MySqlConnection())
        //        {
        //            await connection.OpenAsync();


        //            await connection.CloseAsync();
        //        }


        //        if (user is null)
        //        {
        //            Response.StatusCode = Unauthorized().StatusCode;
        //            return RedirectToAction("Login", new { error = "Неизвестный пользователь. Пройдите регистрацию" });
        //        } //401

        //        //create claim
        //        var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Username),
        //                                       new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())};

        //        //define claims identity by cookie and with our list of custom claims
        //        ClaimsIdentity claimsIdentity =
        //            new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        //        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
        //            new ClaimsPrincipal(claimsIdentity));

        //        return Redirect(viewModel.ReturnUrl ?? "/");
        //    }
        //}

        [HttpGet]
        public IActionResult SignUp(string returnUrl, string error = "")
        {
            var viewModel = new SignUpViewModel()
            { ReturnUrl = returnUrl };

            ViewData["Error"] = error;

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string sqlExpression = $"INSERT INTO Users (Id,Username,Password) VALUES ('{Guid.NewGuid()}','{viewModel.Username}', '{hasher.GenerateHash(viewModel.Password)}')";

                using (MySqlConnection connection = new MySqlConnection(mySqlConnection))
                {
                    await connection.OpenAsync();

                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    await command.ExecuteNonQueryAsync();
                    await connection.CloseAsync();
                }
                return RedirectToAction("Index", "Home");
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

    }
}
