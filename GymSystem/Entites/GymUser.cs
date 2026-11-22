using GymSystem.Enums;

namespace GymSystem.Entites
{
    public abstract class GymUser : BaseEntity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }


    }
}
