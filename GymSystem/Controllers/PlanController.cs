using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace GymSystem.Controllers
{
    public class PlanController : Controller
    {
        private readonly GymContext dbContext = new GymContext();
       


        public async Task<IActionResult> Index()
        {
            var plans = await dbContext.Plans.ToListAsync();
            return View(plans);

        }
    }
}
