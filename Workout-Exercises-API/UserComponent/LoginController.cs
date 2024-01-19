using Microsoft.AspNetCore.Mvc;

namespace Workout_Exercises_API.UserComponent
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
