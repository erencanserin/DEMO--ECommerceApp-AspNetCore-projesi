using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ECommerceApp.Controllers
{
    [Authorize] // Giriş yapmayanlar buraya erişemesin
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var userName = User.Identity.Name; // Giriş yapan kullanıcının adı
            ViewBag.UserName = userName;

            return View();
        }
    }
}
