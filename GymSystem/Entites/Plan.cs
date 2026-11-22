namespace GymSystem.Entites
{
    public class Plan : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; } = true;   

      
        public ICollection<MemberShip> Memberships { get; set; } = new List<MemberShip>();
    }
}
