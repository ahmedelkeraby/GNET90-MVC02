namespace GymSystem.Entites
{
    public class Member : GymUser
    {
        public string? Photo { get; set; }   

        public ICollection<MemberShip> Memberships { get; set; } = new List<MemberShip>();
    }
}
