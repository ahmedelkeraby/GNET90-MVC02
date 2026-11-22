namespace GymSystem.Entites
{
    public class Session : BaseEntity
    {
        public string Description { get; set; }
        public int capacity { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }   
        public Trainer Trainer { get; set; }
        public int TrainerID { get; set; }

    }
}
