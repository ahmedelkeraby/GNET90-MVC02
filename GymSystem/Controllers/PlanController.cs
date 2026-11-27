using GymSystem.Entites;
using GymSystem.Repositories.Classes;
using GymSystem.Repositories.Interfaces;
using GymSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GymSystem.Controllers
{
    public class PlanController : Controller
    {
        private readonly IPlanRespository _PlanRepo;
        private readonly IMemberShipRepostory _memberShipRepo;

        public PlanController(IPlanRespository planRepo , IMemberShipRepostory MemberShipRepo)
        {
            _PlanRepo = planRepo;
            _memberShipRepo = MemberShipRepo;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
            var plans = await _PlanRepo.GetAllAsync(ct);
            var planViewModel = plans.Select(P => new PlanViewModel()
            {
                Id= P.Id,
                Name = P.Name,
                Description = P.Description,
                Price = P.Price,
                DurationDays = P.DurationDays,
                IsActive = P.IsActive

            });
            return View(planViewModel);

        }
        public async Task<IActionResult> Edit(int id, CancellationToken ct)
        {
            var plans = await _PlanRepo.GetByIdAsync(id, ct);
           
            if(plans is null || !plans.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }

            var HasCurrentMemberShip = await _memberShipRepo.AnyAsync(M => M.PlanId == id && M.EndDate > DateTime.Now,ct);
            if(HasCurrentMemberShip)
            {
                TempData["ErrprMessage"] = "This Plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }
            var ViewModel = new UpdatedPlanViewModel()
            {

                Name = plans.Name,
                Description = plans.Description,
                Price = plans.Price,
                DurationDays = plans.DurationDays,
            };

            return View(ViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id ,UpdatedPlanViewModel UpdatedPlan,CancellationToken ct )
        {
            if(!ModelState.IsValid)
            {
                return View(UpdatedPlan);
            }

            var plans = await _PlanRepo.GetByIdAsync(id, ct);

            if (plans is null || !plans.IsActive)
            {
                TempData["ErrorMessage"] = "This Plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }

            var HasCurrentMemberShip = await _memberShipRepo.AnyAsync(M => M.PlanId == id && M.EndDate > DateTime.Now, ct);
            if (HasCurrentMemberShip)
            {
                TempData["ErrorMessage"] = "This Plan Can't be Edited";
                return RedirectToAction(nameof(Index));
            }
            plans.Description = UpdatedPlan.Description;
            plans.DurationDays = UpdatedPlan.DurationDays;
            plans.Price = UpdatedPlan.Price;
            plans.UpdatedAt = DateTime.Now;

            var result = await _PlanRepo.UpdatedAsync(ct);
            if (result > 0)
            {
                TempData["SuccessMessage"] = "Plan Updated Successfully";
                return RedirectToAction(nameof(Index));

            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Fail to Update Plan");
                return View(UpdatedPlan);
            
            } 
        }
    }
}
