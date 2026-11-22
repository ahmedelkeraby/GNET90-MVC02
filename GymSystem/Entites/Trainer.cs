using GymSystem.Enums;

namespace GymSystem.Entites
{
    public class Trainer : GymUser
    {
        public DateTime HireDate { get; set; }
        public Specialties Specialties { get; set; }
        public ICollection<Session> Sessions { get; set; } = new List<Session>();
    }
}
