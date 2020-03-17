using Microsoft.AspNetCore.Mvc;
using Project.RandomGenerator;

namespace Project.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private readonly IRandomGenerator _randomGenerator;
        public HomeController(IRandomGenerator randomGenerator)
        {
            _randomGenerator = randomGenerator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("randomnumbers/{minNum}/{maxNum}")]
        public IActionResult DependencyInjection(int minNum, int maxNum)
        {
            var result = _randomGenerator.Generate(minNum, maxNum);
            ViewBag.RandomNumber = result;
            return View("DependencyInjection");
        }
             
    }
}