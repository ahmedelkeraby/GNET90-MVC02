using System.ComponentModel.DataAnnotations;

namespace GymSystem.ViewModels
{
    public class UpdatedPlanViewModel
    {
        [Display(Name = "Plan")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage ="Descripton Is Required")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Descripton Must Be Between 5 and 200")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "DurationDays Is Required")]
        [Display(Name = "DurationDays")]
        [Range(1,365,ErrorMessage ="Must be between 1 to 365 ")]
        public int DurationDays { get; set; }
        [Required(ErrorMessage = "Price Is Required")]
        [Display(Name = "Price(EGP)")]
        public decimal Price { get; set; }
    }
}
