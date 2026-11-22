using System.ComponentModel.DataAnnotations.Schema;

namespace GymSystem.Entites
{
    public class MemberShip : BaseEntity
    {
        public int MemberId { get; set; }
        public Member Member { get; set; } = null!;
        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [NotMapped] public bool IsActive => EndDate >= DateTime.Now;
        [NotMapped] public string Status => IsActive ? "Active" : "Expired";
    }

}

